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

//icon  1 成功  5 失败   0 慎重

//layer.alert('内容', {
//    icon: 5,
//    skin: 'layer-ext-moon' //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则，去这里查阅
//})