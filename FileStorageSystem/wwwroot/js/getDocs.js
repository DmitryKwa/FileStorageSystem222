const table = document.getElementById('files-table');
const tbody = document.createElement('files-tbody');

const response = fetch('/api/document', {
    method: 'GET'
});

if (!response.ok) {
    throw new Error(response.text);
}

jsonData = response.json();

function addTableRow(name, address, date, type, description) {
    // 1. Получаем ссылку на tbody таблицы
    const tableBody = document.getElementById('files-tbody');

    // 2. Создаем элементы <tr> и <td>
    const newRow = document.createElement('tr');

    const checkboxCell = document.createElement('td');
    const nameCell = document.createElement('td');
    const addressCell = document.createElement('td');
    const dateCell = document.createElement('td');
    const typeCell = document.createElement('td');
    const descriptionCell = document.createElement('td');

    // 3. Создаем checkbox
    const checkbox = document.createElement('input');
    checkbox.type = 'checkbox';
    checkboxCell.appendChild(checkbox);

    // 4. Заполняем ячейки данными
    nameCell.textContent = name;
    addressCell.textContent = address;
    dateCell.textContent = date;
    typeCell.textContent = type;
    descriptionCell.textContent = description;

    // 5. Добавляем ячейки в строку
    newRow.appendChild(checkboxCell);
    newRow.appendChild(nameCell);
    newRow.appendChild(addressCell);
    newRow.appendChild(dateCell);
    newRow.appendChild(typeCell);
    newRow.appendChild(descriptionCell);

    // 6. Добавляем строку в таблицу
    tableBody.appendChild(newRow);
}

filePath = jsonData.filePath;
const extension = filePath.substring(filePath.lastIndexOf('.'));
// Пример использования функции:
addTableRow(
    jsonData.name,
    jsonData.inncAgents,
    jsonData.addTime,
    extension,
    jsonData.docType
);
