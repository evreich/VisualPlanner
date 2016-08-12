//Плавный переход к якорям
var $page = $('html, body');
$('a[href*="#"]').click(function () {
    $page.animate({
        scrollTop: $($.attr(this, 'href')).offset().top
    }, 400);
    return false;
});

function clearForm(form) {
    $(form)[0].reset();
}