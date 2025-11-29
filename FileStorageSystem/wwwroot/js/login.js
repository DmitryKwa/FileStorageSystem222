document.getElementById('loginButton').addEventListener('click', function () {
    event.preventDefault(); // предотвращаем отправку формы

    // Получаем значения из полей ввода
    const email = document.getElementById('login').value;
    const pass = document.getElementById('password').value;

    async function login(email, password) {
        const response = await fetch('/api/account/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                email: email,
                password: password
            })
        });

        if (!response.ok) {
            throw new Error(response.statusText);
        }

        const data = await response.status;
        return data;
    }

    login(email, pass)
        .then(response => {
            localStorage.setItem('login', email);
            window.location.href = '/Main';
        })
        .catch(error => {
            alert(error);
        });
});