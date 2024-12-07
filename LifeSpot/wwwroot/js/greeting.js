let age = prompt("Пожалуйста, введите ваш возраст:");

if (age < 18) {
    alert("Извините, наш сайт предназначен для лиц старше 18 лет.");
    window.location.replace("https://www.google.com");
} else {
    alert("Приветствуем на LifeSpot\n" +
        new Date().toLocaleString());
}