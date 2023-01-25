$(function () {
    $('.snippet').hover(function () {
        console.log();
        var slug = $(this).data('slug');
        $.get('/articles/' + slug, function (data, status) {
            $('#code').html(data);
        });
    });
    $('.copyBtn').click(function () {
        var slug = $(this).data('slug');
        var that = $(this);
        $.get('/articles/' + slug + '/copy', function (data, status) {
            console.log(data);

            navigator.clipboard.writeText(data).then(
                function () {
                    //window.alert('Success! The text was copied to your clipboard')
                    that.removeClass('btn-primary');
                    that.addClass('btn-success');
                    window.setTimeout(function () {
                        that.removeClass('btn-success');
                        that.addClass('btn-primary');
                    }, 1000);
                },
                function () {
                    window.alert('Opps! Your browser does not support the Clipboard API')
                }
            )
        });
    });
});
