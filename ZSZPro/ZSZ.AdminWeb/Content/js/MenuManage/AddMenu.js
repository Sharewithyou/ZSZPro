
$(function () {

    $("#addMenuform").Validform({
        btnSubmit: ".btnAddNode",
        tiptype: function (msg, o, cssctl) {
            if (!o.obj.is("form")) {
                var objtip = o.obj.parent().next(".Validform_checktip");
                cssctl(objtip, o.type);
                objtip.text(msg);
            }
        },
        label: ".form-label",
        ajaxPost: true,
        callback: function (data) {

        }

    })
    //$("#addMenuform").Validform();
    //$("#addMenuform").Validform({
    //    btnSubmit: ".btnAddNode",
    //    //btnReset: ".btn_reset",
    //    //tiptype: 4,
    //    tiptype: function (msg, o, cssctl) {
    //        if (!o.obj.is("form")) {
    //            var objtip = o.obj.parent().next(".Validform_checktip");
    //            cssctl(objtip, o.type);
    //            objtip.text(msg);
    //        }
    //    },
    //    //ignoreHidden: false,
    //    //默认false，当为true时，值为空时不做验证；
    //    //dragonfly: false,
    //    //默认为false,为true时提示信息将只会在表单提交时触发显示，各表单元素blur时不会触发信息提示
    //    //tipSweep: true,
    //    label: ".form-label",
    //    //true：提交表单时所有错误提示信息都会显示；false：一碰到验证不通过的对象就会停止检测后面的元素，只显示该元素的错误信息；
    //    //showAllError: false,
    //    //为true时，在数据成功提交后，表单将不能再继续提交。
    //    //postonce: true,
    //    ajaxPost: true,
    //    //datatype: {
    //    //    "*6-20": /^[^\s]{6,20}$/,
    //    //    "z2-4": /^[\u4E00-\u9FA5\uf900-\ufa2d]{2,4}$/,
    //    //    "username": function (gets, obj, curform, regxp) {
    //    //        //参数gets是获取到的表单元素值，obj为当前表单元素，curform为当前验证的表单，regxp为内置的一些正则表达式的引用;
    //    //        var reg1 = /^[\w\.]{4,16}$/,
    //    //            reg2 = /^[\u4E00-\u9FA5\uf900-\ufa2d]{2,8}$/;

    //    //        if (reg1.test(gets)) { return true; }
    //    //        if (reg2.test(gets)) { return true; }
    //    //        return false;

    //    //        //注意return可以返回true 或 false 或 字符串文字，true表示验证通过，返回字符串表示验证失败，字符串作为错误提示显示，返回false则用errmsg或默认的错误提示;
    //    //    },
    //    //    "phone": function () {
    //    //        // 5.0 版本之后，要实现二选一的验证效果，datatype 的名称 不 需要以 "option_" 开头;	
    //    //    }
    //    //},
    //    //usePlugin: {
    //    //    swfupload: {},
    //    //    datepicker: {},
    //    //    passwordstrength: {},
    //    //    jqtransform: {
    //    //        selector: "select,input"
    //    //    }
    //    //},
    //    //beforeCheck: function (curform) {
    //    //    //在表单提交执行验证之前执行的函数，curform参数是当前表单对象。
    //    //    //这里明确return false的话将不会继续执行验证操作;	
    //    //},
    //    //beforeSubmit: function (curform) {
    //    //    //在验证成功后，表单提交前执行的函数，curform参数是当前表单对象。
    //    //    //这里明确return false的话表单将不会提交;	
    //    //},
    //    callback: function (data) {
    //        //返回数据data是json对象，{"info":"demo info","status":"y"}
    //        //info: 输出提示信息;
    //        //status: 返回提交数据的状态,是否提交成功。如可以用"y"表示提交成功，"n"表示提交失败，在ajax_post.php文件返回数据里自定字符，主要用在callback函数里根据该值执行相应的回调操作;
    //        //你也可以在ajax_post.php文件返回更多信息在这里获取，进行相应操作；
    //        //ajax遇到服务端错误时也会执行回调，这时的data是{ status:**, statusText:**, readyState:**, responseText:** }；

    //        //这里执行回调操作;
    //        //注意：如果不是ajax方式提交表单，传入callback，这时data参数是当前表单对象，回调函数会在表单验证全部通过后执行，然后判断是否提交表单，如果callback里明确return false，则表单不会提交，如果return true或没有return，则会提交表单。
    //    }
    //});
})

