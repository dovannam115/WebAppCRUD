$(document).ready(function () {
    // Search filter
    $('#tableSearch').on('keyup', function () {
        var value = $(this).val().toLowerCase();
        $('#a3StdSaleunitsTable tbody tr').filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });

    // Sorting
    $('#a3StdSaleunitsTable th.sortable').on('click', function () {
        var table = $(this).parents('table').eq(0);
        var rows = table.find('tbody tr').toArray().sort(comparer($(this).index()));
        this.asc = !this.asc;
        if (!this.asc) {
            rows = rows.reverse();
        }
        table.children('tbody').empty().append(rows);
    });

    function comparer(index) {
        return function (a, b) {
            var valA = getCellValue(a, index), valB = getCellValue(b, index);
            var numA = parseFloat(valA), numB = parseFloat(valB);
            if (!isNaN(numA) && !isNaN(numB)) {
                return numA - numB;
            }
            return valA.localeCompare(valB);
        };
    }

    function getCellValue(row, index) {
        return $(row).children('td').eq(index).text();
    }
});
