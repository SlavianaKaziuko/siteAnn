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
    //var w = screen.width,
    //h = screen.height;
    //alert(w + 'x' + h);
	/*$('.zoom-gallery').magnificPopup({
                delegate: 'a',
                type: 'image',
                closeOnContentClick: false,
                closeBtnInside: false,
                mainClass: 'mfp-with-zoom mfp-img-mobile',
                image: {
                    verticalFit: true,
                    titleSrc: function (item) {
                        return item.el.attr('title') + ' &middot; <a class="image-source-link" href="' + item.el.attr('data-source') + '" target="_blank">image source</a>';
                    }
                },
                gallery: {
                    enabled: true
                },
                zoom: {
                    enabled: true,
                    duration: 300, // don't foget to change the duration also in CSS
                    opener: function (element) {
                        return element.find('img');
                    }
                }

            });*/
			
    $("#up").click(function() {
        scrollUp();
    });
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
};

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
    var scrollTime = curPos / 2;
    $("body,html").animate({ "scrollTop": 0 }, scrollTime);
}



