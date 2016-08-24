//Плавный переход к якорям
var $page = $('html, body');
$('a[href*="#"]').click(function () {
    $page.animate({
        scrollTop: $($.attr(this, 'href')).offset().top
    }, 400);
    return false;
});
//очистка форм
function clearForm(form) {
    $(form)[0].reset();
}
//маска ввода телефона
jQuery(function ($) {
    $("#phone").mask("+7(999) 999-99-99");
});
//переход по вкладкам
$('#profile-pills a').click(function (e) {
    e.preventDefault()
    $(this).tab('show')
})
//scrollbar
$("#menu-toggle").click(function (e) {
    e.preventDefault();
    if ($("#sidebar-fa").hasClass("fa-chevron-left"))
    {
        $("#sidebar-fa").removeClass("fa-chevron-left");
        $("#sidebar-fa").addClass("fa-chevron-right");
    }
    else {
        $("#sidebar-fa").removeClass("fa-chevron-right");
        $("#sidebar-fa").addClass("fa-chevron-left");
    }
    $("#wrapper").toggleClass("toggled");
});
//появление подсказки
$(function () {
    $('[data-toggle="tooltip"]').tooltip({ delay: 750 });
});
