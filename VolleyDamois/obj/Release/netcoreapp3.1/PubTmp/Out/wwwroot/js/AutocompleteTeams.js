jQuery.noConflict();
(function ($) {
    $("#searchBar").autocomplete({
        source: function (request, response) {
            $.ajax({
                headers: { RequestVerificationToken: $("#requestCsrfToken").val() },
                datatype: 'json',
                url: '../Teams/SearchTeams',
                data: { searchedTeam: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
})(jQuery);