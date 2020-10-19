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
    var amount = parseFloat($(this).val().replace(',','.'));
    var price = parseFloat($('[bookprice]').val().replace(',', '.'));
    $('[name="Price"]').val((amount * price).toString().replace('.',','));
});


$(document).on('click', '.buy', function () {
    alert('Куплено!');
});
//nativeJS
//document.getElementsByClassName('buy')[0].addEventListener('click', function () { alert('gg') });

$(document).on('click', '.checkbutton', function () {
    if (this.checked) {
        $('.purchasecheck').prop('checked', 'checked');
    }
    else {
        $('.purchasecheck').each(function () {
            this.checked = false;
        });
    }
});

$(document).on('click', function () {
    if ($('.purchasecheck:checked').length) {
        $('.fordisabled').removeAttr('disabled');
    }
    else {
        $('.fordisabled').prop('disabled','disabled');
    }
   
});

$(document).on('click', '.confirmbutton', function (e) {
    if (!confirm('Очистить историю?')) {
        e.preventDefault();
    }
});