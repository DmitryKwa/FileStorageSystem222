const response = await fetch('/api/document', {
    method: 'GET',
    body: formData, // Отправляем FormData
});