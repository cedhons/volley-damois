function createPdf(name) {
    console.log("create pdf");

    var element = document.getElementById("printable");

    var options = {
        filename: name,
        margin: 10,
        pagebreak: {
             mode: ['avoid-all']
        },
        html2canvas: {
            scale: 4,
            onclone: function (document) {
                document.body.style.color = "black";
                document.querySelectorAll("table").forEach(function(e) {
                    e.className = "table m-3";
                });
                document.querySelectorAll("round").forEach(function (e) {
                    e.style.display = "block";
                });
            }
        }
    }
    html2pdf().set(options).from(element).save();
}