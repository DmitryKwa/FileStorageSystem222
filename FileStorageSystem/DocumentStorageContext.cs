using FileStorageSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace FileStorageSystem
{
    public class DocumentStorageContext : DbContext
    {
        // Конструктор для инъекции опций (строка подключения и т.д.)
        public DocumentStorageContext(DbContextOptions<DocumentStorageContext> options) : base(options) { }

        // DbSet для каждой сущности (таблицы в БД)
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Details> Extensions { get; set; }
        public DbSet<DocumentsType> DocumentTypes { get; set; }
        public DbSet<CAgents> Counterparties { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Users> Users { get; set; }
        /*
        // Метод для настройки модели (связи, ключи и т.д.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Вызов базового метода

            // Настройка для junction-таблицы DocumentKeywords (многие-ко-многим между Documents и Keywords)
            modelBuilder.Entity<DocumentKeyword>()
                .HasKey(dk => new { dk.DocumentId, dk.KeywordId });  // Составной первичный ключ

            // Настройка foreign keys для DocumentKeyword
            modelBuilder.Entity<DocumentKeyword>()
                .HasOne(dk => dk.Document)
                .WithMany(d => d.DocumentKeywords)
                .HasForeignKey(dk => dk.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);  // Каскадное удаление (опционально, если хотите)

            modelBuilder.Entity<DocumentKeyword>()
                .HasOne(dk => dk.Keyword)
                .WithMany(k => k.DocumentKeywords)
                .HasForeignKey(dk => dk.KeywordId)
                .OnDelete(DeleteBehavior.Cascade);

            // Дополнительные настройки связей (если EF Core не infer их автоматически)
            // Например, для Document: связи с Counterparty, DocumentType и Extension
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Counterparty)
                .WithMany(c => c.Documents)  // Предполагаю, что Counterparty имеет ICollection<Document>
                .HasForeignKey(d => d.CounterpartyId);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.DocumentType)
                .WithMany(dt => dt.Documents)
                .HasForeignKey(d => d.DocumentTypeId);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Extension)
                .WithMany(e => e.Documents)
                .HasForeignKey(d => d.ExtensionId);

            // Можно добавить индексы для производительности (опционально)
            modelBuilder.Entity<Document>()
                .HasIndex(d => d.FileName);  // Индекс по имени файла для быстрого поиска
        }*/

        // Асинхронный метод для тестирования подключения к БД
        // Возвращает true, если подключение работает, и есть ли данные в Counterparties
    }
}