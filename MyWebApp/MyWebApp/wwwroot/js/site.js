$(document).ready(function () {
    // Подписать кнопки пейджера на событие click
    $(".page-link").click(function (e) {
        e.preventDefault();
        // Получить адрес
        var uri = this.attributes["href"].value;
        // Отправить асинхронный запрос и поместить ответ в контейнер с id="list"
        $("#list").load(uri);
        // Снять выделение с кнопки
        $(".active").removeClass("active disabled");
        // Выделить текущую кнопку
        $(this).parent().addClass("active");
        // Изменить адрес в адресной строке браузера
        history.pushState(null, null, uri);
    })
})