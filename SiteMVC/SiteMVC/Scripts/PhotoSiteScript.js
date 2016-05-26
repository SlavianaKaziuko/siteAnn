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
    $('.carousel').carousel({
        interval: 4000
    });

    bindEvents();
});

function bindEvents() {
    $(window).off('hashchange');
    $(window).on('hashchange', hashChanged);
    //$("#services>li>h3").off("click");
    //$("#services>li>h3").on("click", expandService);
    if (!/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        $('nav .menu-item').off('click');
        $('nav .menu-item').on('click', function() {});
        $('nav .menu-item').hover(
            function() {
                //показать подменю
                $('ul', this).slideDown(100);
                $('ul', this).addClass("expanded");
            },
            function() {
                //скрыть подменю
                $('ul', this).slideUp(100);
                $('ul', this).removeClass("expanded");
            }
        );
    } else {
        $('nav .menu-item').off('click');
        $('nav .menu-item').on('click', showSubmenu);
        $('nav .menu-item a').on('click', function(e) { e.preventDefault(); });
    }

    hashChanged();
    $(window).off('popstate');
    $(window).on('popstate', function () {
        if (!/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            if (window.history.previous.href != null && window.history.previous.href.contains("#")) {
                location.reload();
            }
        }
    });
}

function hashChanged() {
    if ($(top.location.hash).length > 0) {
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

$(function() {

// Dropdown toggle
    $('.dropdown-toggle').click(function() {
        $(this).next('.dropdown').toggle();
    });

    $(document).click(function(e) {
        var target = e.target;
        if (!$(target).is('.dropdown-toggle') && !$(target).parents().is('.dropdown-toggle')) {
            $('.dropdown').hide();
        }
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
    return true;
}

function ChangeUrl(title, url) {
    if (typeof (history.pushState) != "undefined") {
        var obj = { Title: title, Url: url };
        history.pushState({ page: obj.Url, type: "page" }, obj.Title, obj.Url);
    } else {
        //alert("Browser does not support HTML5.");
    }
}

function showSubmenu() {
    var isExpanded = $('ul', this).hasClass("expanded") == true;
    //показать подменю
    if (isExpanded) {
        $('ul', this).slideUp(100);
        $('ul', this).removeClass("expanded");
    } else {
        $('ul', this).slideDown(100);
        $('ul', this).addClass("expanded");
    }
}

function scrollUp() {
    var curPos = $(document).scrollTop();
    var scrollTime = curPos / 5;
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
    setTimeout($.proxy(function () { $(this).next().addClass("expanded"); }, curService), 301);

    var obj = { Title: curService.parent().attr("id"), Url: "/Services#" + curService.parent().attr("id") };
    history.pushState(null, obj.Title, obj.Url);
    return false;
}

// Function to load and initiate the Analytics tracker
function gaTracker(id){
  $.getScript('//www.google-analytics.com/analytics.js'); // jQuery shortcut
  window.ga=window.ga||function(){(ga.q=ga.q||[]).push(arguments)};ga.l=+new Date;
  ga('create', id, 'auto');
  ga('send', 'pageview');
}
		  

// Function to track a virtual page view
function gaTrack(path, title) {
  ga('set', { page: path, title: title });
  ga('send', 'pageview');
}
