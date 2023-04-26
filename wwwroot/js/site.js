document.addEventListener('DOMContentLoaded', function () {
    const darkModeToggle = document.getElementById('darkModeToggle');
    const databaseInfoTable = document.getElementById('databaseInfoTable');
    const isDarkMode = localStorage.getItem('darkMode') === 'true';

    applyDarkMode(isDarkMode);

    darkModeToggle.addEventListener('click', function () {
        const darkModeEnabled = document.body.classList.toggle('dark-mode');
        if (databaseInfoTable) {
            databaseInfoTable.classList.toggle('table-dark', darkModeEnabled);
        }
        localStorage.setItem('darkMode', darkModeEnabled.toString());
        applyDarkMode(darkModeEnabled);
    });

    function applyDarkMode(enabled) {
        if (enabled) {
            darkModeToggle.innerText = 'Toggle Light Mode';
            document.body.classList.add('dark-mode');
            if (databaseInfoTable) {
                databaseInfoTable.classList.add('table-dark');
            }
        } else {
            darkModeToggle.innerText = 'Toggle Dark Mode';
            document.body.classList.remove('dark-mode');
            if (databaseInfoTable) {
                databaseInfoTable.classList.remove('table-dark');
            }
        }
    }
});
