let session = new Map();

session.set("userAgent", window.navigator.userAgent)


session.set("age", prompt("Пожалуйста, введите ваш возраст?"))

if (session.get("age") >= 18) {
    let startDate = new Date().toLocaleString();

    alert("Приветствуем на LifeSpot! " + '\n' + "Текущее время: " + startDate);
    session.set("startDate", startDate)
}
else {
    alert("Наши трансляции не предназначены для лиц моложе 18 лет. Вы будете перенаправлены");
    window.location.href = "http://www.google.com"
    a = true + 20 + "name"
}

for (let result of session) {
    console.log(result)
}