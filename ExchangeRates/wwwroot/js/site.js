// Write your JavaScript code.
$(document).ready(function () {

    var crypto = "BTC";
    var fiat = "USD";

    $('#list-tab-crypto a').on('click', function (e) {
        e.preventDefault();
        $(this).tab('show');
        crypto = $(this).text();
    });

    $('#list-tab-fiat a').on('click', function (e) {
        e.preventDefault();
        $(this).tab('show');
        fiat = $(this).text();
    });

    $('.datepicker').datepicker({

    });


    $("#display").click(function () {

        $('#tblData').html(' ');
        $('#spinner').show();

        $.ajax({
            url: '/Home/Data',
            type: 'POST',
            data: {
                symbol: crypto,
                market: fiat,
                date1: $('#StartDate').val(),
                date2: $('#EndDate').val()
            },
            dataType: 'json',
            success: function (response) {

                var data = response.bars;
                var html = '';
                var template = $('#data-template').html();

                $.each(data, function (i, item) {

                    html += Mustache.render(template, {
                        Date: item.date,
                        Open: item.open,
                        High: item.high,
                        Low: item.low,
                        Close: item.close,
                        Volume: item.volume
                    });
                });
                $('#spinner').hide();
                $('#tblData').html(html);
            },
            error: function (err) {
                alert(err.statusText);
            }
        })
        //
    });
    //
});
