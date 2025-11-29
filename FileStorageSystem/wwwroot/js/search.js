const searchInput = document.getElementById('searchInput');
const searchResults = document.getElementById('searchResults');

function debounce(func, delay) {
    let timeout;
    return function (...args) {
        const context = this;
        clearTimeout(timeout);
        timeout = setTimeout(() => func.apply(context, args), delay);
    }
}

function fetchData(query) {
    // Отправляем запрос к API C#
    fetch(`/api/document?query=${query}`, {
        method: 'GET'
    })
        .then(response => response.json())
        .then(data => {
            displayResults(data);
        })
        .catch(error => {
            console.error('Ошибка:', error);
            searchResults.innerHTML = `<p>Ошибка при выполнении запроса.</p>`;
        });
}

function displayResults(results) {
    searchResults.innerHTML = ''; // Очищаем предыдущие результаты
    if (results.length === 0) {
        searchResults.innerHTML = `<p>Ничего не найдено.</p>`;
        return;
    }

    const ul = document.createElement('ul');
    results.forEach(result => {
        const li = document.createElement('li');
        li.textContent = result.title; // Предполагается, что у вас есть поле title
        ul.appendChild(li);
    });
    searchResults.appendChild(ul);
}

const delayedFetchData = debounce(fetchData, 300); // Задержка 300мс

searchInput.addEventListener('DOMContentLoaded', function (event) {
    const query = event.target.value;
    delayedFetchData(query);
});