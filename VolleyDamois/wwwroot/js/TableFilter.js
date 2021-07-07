jQuery.noConflict();
(function ($) {
    $(".filterable-table").each(function () {
        var table = $(this);
        table.find(".filter-columns th").each(function (i) {
            var currentColor = $(this).css("color");
            $(this).hover(function() {
                $(this).css("color", "lightskyblue");
            },
            function () {
                $(this).css("color", currentColor);
            });

            var isClicked = false;
            $(this).click(function () {
                var rows = table.find(".filtered-rows tr");

                var sortedElements = rows.toArray().sort(function (a, b) {
                    if (isClicked) {
                        var tmp = a;
                        a = b;
                        b = tmp;
                    }
                    var left = $(a).children().eq(i).text();
                    var right = $(b).children().eq(i).text();
                    if (!isNaN(left) && !isNaN(right)) {
                        return Number(left) - Number(right);
                    }
                    return $(a).children().eq(i).text().localeCompare($(b).children().eq(i).text());
                });

                $(sortedElements).appendTo(table.find(".filtered-rows"));
                isClicked = !isClicked;
            });
        });
    });
})(jQuery);