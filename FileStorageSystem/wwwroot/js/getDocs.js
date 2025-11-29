const table = document.getElementById('files-table');
const tbody = document.createElement('files-tbody');

const response = await fetch('/api/document', {
    method: 'GET'
});

if (!response.ok) {
    throw new Error(await response.text);
}

jsonData = response.json();

jsonData.forEach(item => {
    const row = document.createElement('tr');
    for (let key in item) {
        const cell = document.createElement('td');
        cell.textContent = item[key];
        row.appendChild(cell);
    }
    tbody.appendChild(row);
});




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

// Пример использования функции:
addTableRow(
    'Rosie Pearson',
    '979 Immanuel Ferry',
    '27.11.2025',
    'DOCS',
    'Договор'
);
