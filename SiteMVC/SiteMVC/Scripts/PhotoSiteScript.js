var activeEl = -1;
$(function () {
    var items = $('.menu-item');
    $(items[activeEl]).addClass('active');
    $(".menu-item").click(function () {
        $(items[activeEl]).removeClass('active');
        $(this).addClass('active');
        activeEl = $(".menu-item").index(this);
        //$("body,html").animate({ "scrollTop": 212 }, 500);
    });
});

$(document).ready(function() {
    //Обработка нажатия на кнопку "Вверх"
    $("#up").click(function() {
        scrollUp();
    });
});

function ChangeUrl(title, url) {
    if (typeof (history.pushState) != "undefined") {
        var obj = { Title: title, Url: url };
        history.pushState(obj, obj.Title, obj.Url);
    } else {
        alert("Browser does not support HTML5.");
    }
}

function scrollUp() {
    var curPos = $(document).scrollTop();
    var scrollTime = curPos / 1.75;
    $("body,html").animate({ "scrollTop": 0 }, scrollTime);
}



