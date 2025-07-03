$(document).ready(function () {
    $('.searchable').each(function () {
        var $select = $(this);
        var options = $select.find('option').clone();
        var $input = $('<input type="text" class="form-control mb-2 select-search-input" placeholder="Search...">');
        $select.before($input);
        $input.on('keyup', function () {
            var term = $(this).val().toLowerCase();
            var filtered = options.filter(function () {
                return $(this).text().toLowerCase().indexOf(term) > -1;
            });
            $select.html(filtered);
        });
    });
});
