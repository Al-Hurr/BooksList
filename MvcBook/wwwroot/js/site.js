// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).on('click', '.sub', function (e) {
    e.preventDefault();

    var $this = $(this);
    var form = $this.parents('.modal').find('form');
    var dataToSend = form.serialize();
    var url = form.attr('action');

    $.post(url, dataToSend, function (data) {
        if (!data.includes('modal-content')) {
            $('#modDialog').modal('hide');
            location.reload(true);
            return;
        }


        $('#dialogContent').html(data);
        $('#modDialog').modal('show');
    });
});

$(function () {
    $.ajaxSetup({ cache: false });
    $(".openmodal").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
})