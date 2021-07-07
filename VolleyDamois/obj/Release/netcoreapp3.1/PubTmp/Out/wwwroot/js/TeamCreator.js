jQuery.noConflict();
(function ($) {
    var nbEncodedPlayers = Number($("form input[name='NbEncodedPlayers']").val());
    var nbPlayers = 0;
    var maxPlayers = $(".player-form").length;

    $(".player-form").hide();
    $("form>input[type='hidden'][value='false']").eq(0).nextAll().remove();
    $(".player-form input, .player-form select").attr("disabled", true);
    $(".captain-data").hide();


    for (var i = 0; i < nbEncodedPlayers; i++)
        onAdd();

    if (nbEncodedPlayers === 0)
        onAdd();

    $(".player-form").eq(0).fadeIn("fast");

    $("#add-btn").click(onAdd);

    $(".captain-checkbox").change(function () {
        var captainData = $(this).parents(".player-form").find(".captain-data");
        if ($(this).prop("checked")) {
            console.log("checked");
            captainData.fadeIn("fast");
        } else {
            captainData.fadeOut("fast");
        }
    });

    function onAdd() {
        if (nbPlayers < maxPlayers) {
            nbPlayers++;
            var newPlayerForm = $(".player-form").eq(nbPlayers - 1);
            var firstnameInput = newPlayerForm.find("input").eq(2);
            newPlayerForm.find("input, select").attr("disabled", false);
            $("#players-list").append(new Option(firstnameInput.val() ? firstnameInput.val() : "Joueur " + nbPlayers, nbPlayers));

            firstnameInput.on("keyup", function () {
                $("#players-list option:selected").text(firstnameInput.val());
            });
        }
    }

    $("#remove-btn").click(function () {
        if (nbPlayers > 1) {
            var removedPlayerForm = $(".player-form").eq(nbPlayers - 1);
            removedPlayerForm.find("input").eq(2).off("keyup");
            removedPlayerForm.find("input, select").attr("disabled", true);
            removedPlayerForm.find("input").val("");
            removedPlayerForm.hide();
            nbPlayers--;
            $("#players-list option").last().remove();
        }
    });

    $("#players-list").change(function () {
        var visiblePlayerForm = $(".player-form:visible");
        if (visiblePlayerForm.length > 0) {
            $(".player-form:visible").fadeOut("fast", renderSelectedPlayerForm);
        } else {
            renderSelectedPlayerForm();
        }
    });

    function renderSelectedPlayerForm() {
        $(".player-form").eq($("#players-list option:selected").val() - 1).fadeIn("fast");
    }

})(jQuery);