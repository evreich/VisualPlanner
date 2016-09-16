//Плавный переход к якорям
var $page = $('html, body');
$('a[class="list-group-item"]').click(function () {
    $page.animate({
        scrollTop: $($.attr(this, 'href')).offset().top
    }, 400);
    return false;
});
//очистка форм
function clearForm(form) {
    $(form)[0].reset();
}
//скрытие оповещения об отправке запроса
setTimeout(function () { $('#successSend').fadeOut('fast') }, 5000);
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
        $("#page-content-wrapper").css({ "background": "white", "opacity": "1" });
    }
    else {
        $("#sidebar-fa").removeClass("fa-chevron-right");
        $("#sidebar-fa").addClass("fa-chevron-left");
        $("#page-content-wrapper").css({ "background": "#eeeeee", "opacity": "0.5" });
    }
    $("#wrapper").toggleClass("toggled");
});
//появление подсказки
$(function () {
    $('[data-toggle="tooltip"]').tooltip({ delay: 250 });
});

$(".tooltip-elem").tooltip({
    placement: "top",
    delay: 250
});
//календарь
$(function () {
    if ($('#calendar').length > 0)
    {
        var calendar = $("#calendar").calendar(
        {
            language: 'ru-RU',
            tmpl_path: "/Content/CalendarTemplates/",
            events_source: function () { return []; }
        });
    }
})

//запрет/открытие рабочей области
$('#menu-toggle').click(function () {
    if ($('#sidebar-fa').hasClass("fa-chevron-left"))
        $('#page-content-wrapper').css("z-index", -100)
    else
        $('#page-content-wrapper').css("z-index", 0)
})


//вывод части формы соответствующей типу задачи
$('#type_task').click(function () {
    if ($(".task-form").length == 0)
    {
        $(".additional-form").fadeOut(300, function () {
            $(".additional-form").html('')
            $(".additional-form").append('<div class="task-form"></div>').fadeIn(500)
            $(".task-form").append('<div class="form-group-sm"><label class="col-sm-3" for="Remind">Напоминание</label><div class="col-sm-9"><input class="" data-val="true" data-val-required="Требуется поле Напоминание." id="Remind" name="Remind" type="checkbox" value="true"><input name="Remind" type="hidden" value="false"></div></div>').fadeIn(500)
            $(".task-form").append('<div class="form-group-sm"><label class="col-sm-3 control-label" for="ParentTask">Проект</label><div class="col-sm-9"><select class="form-control" id="ParentTask" name="ParentTask"><option value="Курсовая работа">Курсовая работа</option><option value="Ремонт авто">Ремонт авто</option><option value="Поездка на дачу">Поездка на дачу</option></select></div></div>').fadeIn(500)
        })

    }
})
$('#type_event').click(function () {
    if ($(".event-form").length == 0)
    {
        $(".additional-form").fadeOut(300, function () {
            $(".additional-form").html('')
            $(".additional-form").append('<div class="event-form"></div>').fadeIn(500)
            $(".event-form").append('<div class="form-group-sm"><label class="col-sm-3" for="Remind">Напоминание</label><div class="col-sm-9"><input class="" data-val="true" data-val-required="Требуется поле Напоминание." id="Remind" name="Remind" type="checkbox" value="true"><input name="Remind" type="hidden" value="false"></div></div>').fadeIn(500)
            $(".event-form").append('<div class="form-group-sm"><label class="col-sm-3" for="Repeat">Повторение</label><div class="col-sm-9"><input data-val="true" data-val-required="Требуется поле Повторение." id="Repeat" name="Repeat" type="checkbox" value="true"><input name="Repeat" type="hidden" value="false"></div></div>').fadeIn(500)
        })
    }
})
$(document).on("change", 'input[name="Repeat"]',(function () {
    if ($(this).prop('checked'))
    {
        $(".event-form").append('<div class="event-form-app"></div>')
        $(".event-form-app").hide().fadeIn(500)
        $(".event-form-app").append('<div class="form-group-sm"><label class="col-sm-3 control-label" for="Period">Периодичность</label><div class="col-sm-9"><label class="control-label period-label">Каждые </label><input class="form-control" data-val="true" data-val-number="Значением поля Периодичность должно быть число." data-val-range="Недопустимое значение" data-val-range-max="1000" data-val-range-min="1" data-val-required="Требуется поле Периодичность." id="Period" min="1" name="Period" style="width:20%; margin-right: 3px;display:inline" type="number" value=""><select class="form-control" id="period_type" name="period_type" style="width:20%; display:inline"><option value="hour">Часов</option><option value="day">Дней</option><option value="week">Недель</option><option value="month">Месяцев</option><option value="year">Лет</option></select></div></div>').fadeIn(500)
        $(".event-form-app").append('<div class="form-group-sm"><label class="col-sm-3" for="EndPeriod">Дата окончания повторений</label><div class="col-sm-9"><div class="input-group date" name="period_end" id="period_end_event"><input class="form-control" data-val="true" data-val-date="Поле Дата окончания повторений должно содержать дату." data-val-required="Требуется поле Дата окончания повторений." id="EndPeriod" name="EndPeriod" type="text" value=""><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span></div></div></div>').fadeIn(500)
        $('#period_end_event').datetimepicker({
            format: 'DD.MM.YYYY',
            locale: 'ru'
        });
    }
    else
        $(".event-form-app").fadeOut(300, function () {
            $(".event-form-app").remove()
        })
}))
$('#type_project').click(function () {
    $(".additional-form").fadeOut(300, function () { $(".additional-form").html('') })
})
