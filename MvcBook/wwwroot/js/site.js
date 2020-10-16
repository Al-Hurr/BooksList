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

        //$('#modDialog').modal('hide');
        $('#modDialog').html(data);
        $('#modDialog').modal('show');
    });
});

$(function () {
    $.ajaxSetup({ cache: false });
    $(document).on('click', ".openmodal", function (e) {

        var url = this.href;

        e.preventDefault();

        $.get(url, function (data) {
            //$('#modDialog').modal('hide');
            $('#modDialog').html(data);
            $('#modDialog').modal('show');
        });
    });
});

$(document).on('click', '.plusbutton', function () {
    var value = parseInt($('[name="Ammount"]').val());
    $('[name="Ammount"]').val(++value);
    $('[name="Ammount"]').trigger('change');
});

$(document).on('click', '.minusbutton', function () {
    var value = parseInt($('[name="Ammount"]').val());

    if (value <= 1)
        return; 

    $('[name="Ammount"]').val(--value);
    $('[name="Ammount"]').trigger('change');
});


$(document).on('change', '[name="Ammount"]', function () {
    var amount = parseFloat($(this).val());
    var price = parseFloat($('[bookprice]').val());
    $('[name="Price"]').val(amount * price);
});


$(document).on('click', '.buy', function () {
    alert('Куплено!');
});
//nativeJS
//document.getElementsByClassName('buy')[0].addEventListener('click', function () { alert('gg') });