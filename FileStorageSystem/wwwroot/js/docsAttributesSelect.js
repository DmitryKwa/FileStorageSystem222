document.addEventListener('DOMContentLoaded', function () {
    // Функция для заполнения выпадающего списка данными из API
    function fillDropdown() {
        // Находим элемент select по его id
        const selectElement = document.getElementById('DocOwner');

        // Проверяем, что элемент найден
        if (!selectElement) {
            console.error('Элемент select с id "DocOwner" не найден.');
            return;
        }

        // Отправляем запрос к API
        fetch('api/cagent')
            .then(response => {
                // Проверяем, что запрос выполнен успешно
                if (!response.ok) {
                    throw new Error(`Ошибка при запросе к API: ${response.status}`);
                }
                // Преобразуем ответ в JSON
                return response.json();
            })
            .then(data => {
                // Проверяем, что данные пришли и являются массивом
                if (!data || !Array.isArray(data)) {
                    console.error('Некорректные данные, полученные от API. Ожидается массив.');
                    return;
                }

                // Очищаем существующие option (кроме дефолтного "Выберите отправителя")
                while (selectElement.options.length > 1) {
                    selectElement.remove(1); // Удаляем начиная со второго элемента (индекс 1)
                }
                // Создаем и добавляем новые option на основе JSON данных
                data.forEach(item => {
                    // Предполагаем, что в JSON есть поля, которые мы хотим использовать в качестве value и текста option.
                    // Замени 'id' и 'name' на соответствующие поля в твоем JSON.  Важно!
                    const optionText = item.inn;  // Или item.какое_то_другое_поле

                    // Создаем элемент option
                    const option = document.createElement('option');
                    option.text = optionText;

                    // Добавляем option в select
                    selectElement.add(option);
                });
            })
            .catch(error => {
                console.error('Произошла ошибка:', error);
                // Здесь можно добавить обработку ошибок, например, отобразить сообщение об ошибке на странице.
            });
    }

    // Вызываем функцию fillDropdown для заполнения списка при загрузке страницы
    fillDropdown();
});

document.addEventListener('DOMContentLoaded', function () {

    function fillDocumentTypeDropdown() {
        const selectElement = document.getElementById('DocType');

        if (!selectElement) {
            console.error('Элемент select с id "DocType" не найден.');
            return;
        }

        fetch('api/documenttype')
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Ошибка при запросе к API: ${response.status}`);
                }
                return response.json();
            })
            .then(data => {
                if (!data || !Array.isArray(data)) {
                    console.error('Некорректные данные, полученные от API. Ожидается массив.');
                    return;
                }

                // Очищаем существующие option (кроме дефолтного "Выберите тип")
                while (selectElement.options.length > 1) {
                    selectElement.remove(1);
                }

                data.forEach(item => {
                    // Важно! Замени 'id' и 'name' на соответствующие поля в твоем JSON.
                    const optionText = item; // Или item.какое_то_другое_поле

                    const option = document.createElement('option');
                    option.text = optionText;

                    selectElement.add(option);
                });
            })
            .catch(error => {
                console.error('Произошла ошибка:', error);
                // Здесь можно добавить обработку ошибок, например, отобразить сообщение об ошибке на странице.
            });
    }

    // Вызываем функцию fillDocumentTypeDropdown для заполнения списка при загрузке страницы
    fillDocumentTypeDropdown();

});