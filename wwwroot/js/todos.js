const toggleElements = document.querySelectorAll('.js-toggle-todo');

for (const element of toggleElements) {
    element.addEventListener('change', (event) => {
        event.target.form.submit();
    });
}
