var activeEl = -1;

//Deny right mouse click on photo
var isNS = (navigator.appName == "Netscape") ? 1 : 0;
if (navigator.appName == "Netscape") document.captureEvents(Event.MOUSEDOWN || Event.MOUSEUP);
//Deny right mouse click on photo
document.oncontextmenu = mischandler;
document.onmousedown = mousehandler;
document.onmouseup = mousehandler;

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
    $("#up").on("click", scrollUp);

    bindEvents();
});

function bindEvents() {
    $(window).off('hashchange');
    $(window).on('hashchange', hashChanged);
    $("#services>li>h3").off("click");
    $("#services>li>h3").on("click", expandService);
    hashChanged();
}

function hashChanged() {
    if ($(top.location.hash).length > 0) {
        $(top.location.hash).find("h3").trigger("click");
        $("body,html").animate({ "scrollTop": $(top.location.hash).offset().top }, 500);
    }
}

$(document).ajaxStart(function () {
    document.body.style.cursor = "wait";
});

$(document).ajaxStop(function () {
    document.body.style.cursor = "default";
});

$(document).ajaxComplete(function() {
    document.body.style.cursor = "default";
    if ($("#title").length > 0) {
        $("title").text($("#title").text());
    }
    bindEvents();
});

//Deny right mouse click on photo
function mischandler() {
    return false;
}


//Deny right mouse click on photo
function mousehandler(e) {
    var myevent = (isNS) ? e : event;
    var eventbutton = (isNS) ? myevent.which : myevent.button;
    if ((eventbutton == 2) || (eventbutton == 3)) return false;
    return true;
}


function ChangeUrl(title, url) {
    if (typeof (history.pushState) != "undefined") {
        var obj = { Title: title, Url: url };
        history.pushState(obj, obj.Title, obj.Url);
    } else {
        //alert("Browser does not support HTML5.");
    }
}

function scrollUp() {
    var curPos = $(document).scrollTop();
    var scrollTime = curPos / 2;
    $("body,html").animate({ "scrollTop": 0 }, scrollTime);
}

function expandService(event) {
    var curService = $(event.currentTarget);
    var isExpanded = curService.next().hasClass("expanded") == true;
    $("#services>li>div.expanded")
        .slideUp(300)
        .removeClass("expanded");

    if (isExpanded) return false;

    curService.next()
        .slideDown(300);
    setTimeout($.proxy(function() { $(this).next().addClass("expanded"); }, curService), 301);
}


