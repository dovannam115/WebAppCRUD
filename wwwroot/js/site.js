﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    if ($.fn.select2) {
        $('.searchable').select2({ width: 'resolve' });
    }
});
