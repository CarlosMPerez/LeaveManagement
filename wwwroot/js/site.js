// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('.tableGrid').DataTable({
        ordering: false
    }); // Each <table class="tableGrid"> will be a datatable
})