jQuery.noConflict();
(function ($) {
    var firstDisplayed = "#round11";
    var isAllDisplayed = false;

    $(".round").hide();
    $(".round input").attr("disabled", true);
    $(firstDisplayed + " input").attr("disabled", false);
    $(firstDisplayed).show();
    
    var lastDisplayed = $(firstDisplayed);

    $("#roundsDropdown").change(function () {
        if (isAllDisplayed) {
            $(".round").hide();
            $(".round input").attr("disabled", true);
        } else {
            lastDisplayed.hide();
            lastDisplayed.find("input").attr("disabled", true); 
        }
        var selectedRound = $(this).children("option:selected").val();
        lastDisplayed = $("#" + selectedRound);
        lastDisplayed.find("input").attr("disabled", false);
        lastDisplayed.fadeIn("fast");
    });

    $("#displayAll").click(function () {
        $(".round input").attr("disabled", true);
        $(".round").fadeIn("fast");
        isAllDisplayed = true;
    });
})(jQuery);