using FileStorageSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace FileStorageSystem.Services
{
    public class DocumentUploadService
    {
        private readonly DocumentStorageContext _context;
        private readonly IWebHostEnvironment _environment;

        public DocumentUploadService(DocumentStorageContext context, IWebHostEnvironment environment)
        {
            try
            {
                _context = context;
                _environment = environment;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
                Logger.LogError($"User=admin",
                                $"DocumentUploadService error. ", ex);
            }
        }

        public async Task<List<Document>> UploadDocumentsAsync(
            IFormFileCollection files,
            string senderInn,
            string senderName,
            int documentTypeId,
            List<string> keywords = null) // Если файлов несколько, то у каждого файла может быть разный контрагент и тип
        {
            // Проверка общего размера файлов (256 МБ = 268435456 байт)
            long totalSize = files.Sum(f => f.Length);
            const long maxSize = 268435456; // 256 МБ
            if (totalSize > maxSize)
            {
                throw new InvalidOperationException($"Общий размер файлов превышает лимит 256 МБ. Текущий размер: {totalSize} байт.");
            }

            // Найти или создать контрагента
            var counterparty = await _context.Counterparties
                .FirstOrDefaultAsync(c => c.Inn == senderInn);
            if (counterparty == null)
            {
                counterparty = new Counterparty
                {
                    Inn = senderInn,
                    Name = senderName
                };
                _context.Counterparties.Add(counterparty);
                await _context.SaveChangesAsync(); // Сохранить, чтобы получить Id
            }

            // Папка для сохранения файлов
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uploadedDocuments = new List<Document>();

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // Генерировать уникальное имя файла
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // Зачем Guid здесь?
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Сохранить файл на диск
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Определить расширение (найти или создать в БД)
                    string extensionName = Path.GetExtension(file.FileName).TrimStart('.').ToLower();
                    var extension = await _context.Extensions
                        .FirstOrDefaultAsync(e => e.Name == extensionName);
                    if (extension == null)
                    {
                        extension = new Extension { Name = extensionName };
                        _context.Extensions.Add(extension);
                        await _context.SaveChangesAsync();
                    }

                    // Создать документ
                    var document = new Document
                    {
                        Title = Path.GetFileNameWithoutExtension(file.FileName),
                        DateAdded = DateTime.UtcNow,
                        ShortDescription = "", // Можно расширить, чтобы принимать из запроса
                        SenderId = counterparty.Id,
                        TypeId = documentTypeId,
                        ExtensionId = extension.Id
                    };

                    _context.Documents.Add(document);
                    uploadedDocuments.Add(document);

                    // Добавить ключевые слова, если предоставлены
                    if (keywords != null && keywords.Any())
                    {
                        foreach (var keywordWord in keywords)
                        {
                            var keyword = await _context.Keywords
                                .FirstOrDefaultAsync(k => k.Word == keywordWord);
                            if (keyword == null)
                            {
                                keyword = new Keyword { Word = keywordWord };
                                _context.Keywords.Add(keyword);
                                await _context.SaveChangesAsync();
                            }
                            _context.DocumentKeywords.Add(new DocumentKeyword
                            {
                                DocumentId = document.Id,
                                KeywordId = keyword.Id
                            });
                        }
                    }

                    await _context.SaveChangesAsync(); // Сохранить документ и связи
                }
            }

            return uploadedDocuments;
        }
    }
}
