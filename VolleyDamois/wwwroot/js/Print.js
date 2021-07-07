function printPage(title) {
    printJS({
        printable: 'printable',
        type: 'html',
        documentTitle: title,
        scanStyles: false,
        style: 'td, th { border-style: solid; border-width: thin; text-align: center; } h4, table, .not-break { padding-top : 10px; margin: auto; text-align: center; page-break-inside: avoid; } input[type="number"] { width: 40px}'
    });
}