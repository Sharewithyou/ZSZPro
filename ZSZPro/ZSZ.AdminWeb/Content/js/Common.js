﻿$(function () {

    //Ajax 统一配置
    $.ajaxSetup({
        error: function (xhr, status, error) {
            layer.alert(xhr.status + ":" + xhr.statusText);
        },
        complete: function () {
            layer.closeAll('loading');
            
        }
    });
})