$(function () {

    //Ajax 统一配置
    $.ajaxSetup({
        beforeSend: function () {
            layer.load(2);
        },
        error: function (xhr, status, error) {
            layer.closeAll('loading');
            layer.alert(xhr.status + ":" + xhr.statusText);

        },
        complete: function () {
            layer.closeAll('loading');
        }
    });
})