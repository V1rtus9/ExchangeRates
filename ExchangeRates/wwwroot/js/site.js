
var formValues = {
    symbol: "BTC",
    market: "USD",
    date1: "01/01/2016",
    date2: "31/12/2017"
}

$(document).ready(function () {

    $('#list-tab-crypto a').on('click', function (e) {
        e.preventDefault();
        $(this).tab('show');
        formValues.symbol = $(this).text();
    });

    $('#list-tab-fiat a').on('click', function (e) {
        e.preventDefault();
        $(this).tab('show');
        formValues.market = $(this).text();
    });

    $('.datepicker').datepicker({
        autoclose: true,
        startDate: formValues.date1,
        endDate: formValues.date2
    });

    $('#date1').datepicker()
        .on("changeDate", function (e) {
            formValues.date1 = $('#date1').val();
        });

    $('#date2').datepicker()
        .on("changeDate", function (e) {
            formValues.date2 = $('#date2').val();
        });

    $(document).on('mouseleave', leaveFromTop);

    function leaveFromTop(e) {
        if (e.clientY < 0) {

        }          
    }

    $("#display").click(function () {

        $('#tblData').html(' ');
        $('#spinner').show();

        $.ajax({
            url: '/Home/Data',
            type: 'POST',
            data: {
                symbol: formValues.symbol,
                market: formValues.market,
                date1: formValues.date1,
                date2: formValues.date2
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
                alert("Error happened: " + err.statusText);
            }
        })
        //
    });
    //
});
