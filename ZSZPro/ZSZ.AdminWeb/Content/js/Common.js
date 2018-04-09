$(function () {

    //Ajax 统一配置
    $.ajaxSetup({
        error: function (xhr, status, error) {
            layer.alert(xhr.status + ":" + xhr.statusText);
        },
        complete: function () {
            setTimeout(function () {
                layer.closeAll('loading');
            }, 5000);
            
        }
    });
})