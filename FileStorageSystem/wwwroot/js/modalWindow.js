document.getElementById('OpenModalBtn').addEventListener('click', function () {
    event.preventDefault(); // предотвращаем отправку формы

    const modal = document.getElementById('MyModal');
    modal.style.display = "block"; // Делаем модальное окно видимым
});

// Закрытие модального окна при клике вне его области
window.addEventListener('click', function (event) {
    const modal = document.getElementById('MyModal');
    if (event.target == modal) {
        modal.style.display = "none";
    }
});