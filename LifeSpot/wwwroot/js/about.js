function Comment() {
    // Запросим имя
    this.author = prompt("Как вас зовут ?")
    if (this.author == null) {
        this.empty = true
        return
    }

    // Запросим текст
    this.text = prompt("Оставьте отзыв")
    if (this.text == null) {
        this.empty = true
        return
    }

    // Сохраним текущее время
    this.date = new Date().toLocaleString()
}

function addComment() {
    let comment = new Comment()

    // проверяем, успешно ли юзер осуществил ввод
    if (comment.empty) {
        return;
    }

    // Запросим, хочет ли пользователь оставить полноценный отзыв или это будет обычный комментарий
    let enableLikes = confirm('Разрешить пользователям оценивать ваш отзыв?')

    if (enableLikes) {
        // Создадим для отзыва новый объект из прототипа - комментария
        let review = Object.create(comment)
        // и добавим ему нужное свойство
        review.rate = 0;

        // Добавляем отзыв с возможностью пользовательских оценок
        writeReview(review)
    } else {
        // Добавим простой комментарий без возможности оценки
        writeReview(comment)
    }
}

function showMySlider() {
    let slideIndex = 1;
    // Инициализация при загрузке страницы
    document.addEventListener("DOMContentLoaded", function () {
        showSlides(slideIndex);
    });

    // Управление переходом к следующему/предыдущему слайду
    function plusSlides(n) {
        // Увеличиваем или уменьшаем индекс слайда и вызываем функцию для отображения слайдов
        showSlides(slideIndex += n);
    }

    // Управление слайдами по миниатюрам (точкам)
    function currentSlide(n) {
        // Устанавливаем текущий слайд по переданному индексу и вызываем функцию для отображения слайдов
        showSlides(slideIndex = n);
    }

    // Функция для отображения слайдов
    function showSlides(n) {
        let i;
        let slides = document.getElementsByClassName("mySlides");
        let dots = document.getElementsByClassName("dot");

        // Переключаем индекс слайда, если он выходит за пределы
        if (n > slides.length) { slideIndex = 1; } // Если индекс больше количества слайдов, возвращаемся к первому
        if (n < 1) { slideIndex = slides.length; } // Если индекс меньше 1, переходим к последнему

        // Скрываем все слайды
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none"; // Устанавливаем стиль 'none', чтобы скрыть слайд
        }

        // Убираем класс "active" у всех точек
        for (i = 0; i < dots.length; i++) {
            dots[i].className = dots[i].className.replace(" active", ""); // Убираем активный стиль у всех точек
        }

        // Показываем текущий слайд
        slides[slideIndex - 1].style.display = "block"; // Отображаем слайд с текущим индексом
        dots[slideIndex - 1].className += " active"; // Добавляем класс "active" к текущей точке
    }

    // Автоматическая прокрутка слайдов
    setInterval(function () {
        plusSlides(1); // Переход на следующий слайд каждые 3 секунды
    }, 3000);
}

