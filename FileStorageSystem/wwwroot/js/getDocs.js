const table = document.getElementById('files-table');
const tbody = document.createElement('files-tbody');

const response = await fetch('/api/document', {
    method: 'GET'
});

response.json();

jsonData.forEach(item => {
    const row = document.createElement('tr');
    for (let key in item) {
        const cell = document.createElement('td');
        cell.textContent = item[key];
        row.appendChild(cell);
    }
    tbody.appendChild(row);
});

if (!response.ok) {
    throw new Error(await response.text);
}