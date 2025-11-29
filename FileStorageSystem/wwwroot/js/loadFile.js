document.getElementById('AddNewFile').addEventListener('click', function (event) {
    event.preventDefault(); // Предотвращаем стандартное поведение кнопки
    document.getElementById('fileInput').click(); // Кликаем на скрытый input file
});

document.getElementById('fileInput').addEventListener('change', function () {
    // Здесь можно обработать выбранный файл, например, отправить на сервер
    let file = this.files[0];

    if (file) {
        let fileName = file.name;
        let fileExtension = '.' + fileName.split('.').pop(); // Получаем расширение файла, добавляем точку в начале
        let fileNameWithoutExtension = fileName.substring(0, fileName.lastIndexOf('.')); // Обрезаем расширение
        document.getElementById('DocType').value = fileExtension;
        document.getElementById('DocName').value = fileNameWithoutExtension;
    } else {
        document.getElementById('DocType').value = 'Ошибка загрузки'; // Очищаем поле, если файл не выбран
    }
    // Дальнейшая обработка файла (загрузка на сервер и т.д.)
});