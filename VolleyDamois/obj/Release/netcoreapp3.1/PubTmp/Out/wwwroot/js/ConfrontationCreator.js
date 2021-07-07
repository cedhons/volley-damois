jQuery.noConflict();
(function ($) {
    $(".matchOfDay2, .btnDay2").hide();
    var showed = $(".matchOfDay1, .btnDay1");

    $("#daysDropdown").change(function() {
        var selectedDay = $(this).children("option:selected").val();
        showed.hide();
        showed = $(".matchOfDay" + selectedDay + ", .btnDay" + selectedDay);
        showed.fadeIn("fast");
    });
})(jQuery);