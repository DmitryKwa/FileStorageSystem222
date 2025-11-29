// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.getElementById('SaveThisFile').addEventListener('click', async function (event) {
    event.preventDefault();

    const docName = document.getElementById('DocName').value;
    const docType = document.getElementById('DocType').value;
    const docOwner = document.getElementById('DocOwner').value;
    const fileInput = document.getElementById('fileInput'); // Получаем input type="file"
    const file = fileInput.files[0]; // Получаем выбранный файл

    async function uploadDocument(docName, docType, docOwner, file) {
        const formData = new FormData();

        // Добавляем JSON-данные
        //const jsonData = {
        //    name: docName,
        //    docType: docType,
        //    INNCAgents: docOwner
        //}
        //formData.append("jsonData", jsonData)

        formData.append('name', docName);
        formData.append('docType', docType);
        formData.append('INNCAgents', docOwner);
        formData.append('file', file); // 'documentFile' - это имя поля на сервере

        const response = await fetch('/api/document', {
            method: 'POST',
            body: formData, // Отправляем FormData
        });

        if (!response.ok) {
            throw new Error(await response.text);
        }
    }

    // Вызываем функцию отправки
    uploadDocument(docName, docType, docOwner, file)
        .then(result => {
            console.log('Успех:', result);
        })
        .catch(error => {
            console.error('Ошибка:', error);
        });
});