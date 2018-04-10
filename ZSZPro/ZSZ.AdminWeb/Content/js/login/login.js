
$(function () {

    refreshVerifyCode();

    //验证开始
    $("#loginForm").bootstrapValidator({
        /**
        *  指定不验证的情况
        *  值可设置为以下三种类型：
        *  1、String  ':disabled, :hidden, :not(:visible)'
        *  2、Array  默认值  [':disabled', ':hidden', ':not(:visible)']
        *  3、带回调函数  
            [':disabled', ':hidden', function($field, validator) {
                // $field 当前验证字段dom节点
                // validator 验证实例对象 
                // 可以再次自定义不要验证的规则
                // 必须要return，return true or false; 
                return !$field.is(':visible');
            }]
        */
        excluded: [':disabled', ':hidden', ':not(:visible)'],
        /**
        * 指定验证后验证字段的提示字体图标。（默认是bootstrap风格）
        * Bootstrap 版本 >= 3.1.0
        * 也可以使用任何自定义风格，只要引入好相关的字体文件即可
        * 默认样式 
            .form-horizontal .has-feedback .form-control-feedback {
                top: 0;
                right: 15px;
            }
        * 自定义该样式覆盖默认样式
            .form-horizontal .has-feedback .form-control-feedback {
                top: 0;
                right: -15px;
            }
            .form-horizontal .has-feedback .input-group .form-control-feedback {
                top: 0;
                right: -30px;
            }
        */
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        /**
        * 生效规则（三选一）
        * enabled 字段值有变化就触发验证
        * disabled,submitted 当点击提交时验证并展示错误信息
        */
        live: 'enabled',
        /**
        * 为每个字段指定通用错误提示语
        */
        message: '当前值不符合规则',
        /**
        * 指定提交的按钮，例如：'.submitBtn' '#submitBtn'
        * 当表单验证不通过时，该按钮为disabled
        */
        submitButtons: 'button[type="submit"]',
        /**
        * submitHandler: function(validator, form, submitButton) {
        *   //validator: 表单验证实例对象
        *   //form  jq对象  指定表单对象
        *   //submitButton  jq对象  指定提交按钮的对象
        * }
        * 在ajax提交表单时很实用
        *   submitHandler: function(validator, form, submitButton) {
                // 实用ajax提交表单
                $.post(form.attr('action'), form.serialize(), function(result) {
                    // .自定义回调逻辑
                }, 'json');
             }
        * 
        */
        //submitHandler: null,
        /**
        * 为每个字段设置统一触发验证方式（也可在fields中为每个字段单独定义），默认是live配置的方式，数据改变就改变
        * 也可以指定一个或多个（多个空格隔开） 'focus blur keyup'
        */
        //trigger: null,
        /**
        * Number类型  为每个字段设置统一的开始验证情况，当输入字符大于等于设置的数值后才实时触发验证
        */
        threshold: 6,
        /**
        * 表单域配置
        */
        fields: {
            //多个重复
            UserAccount: {
                //隐藏或显示 该字段的验证
                enabled: true,
                //错误提示信息
                message: '用户名无效',
                /**
                * 定义错误提示位置  值为CSS选择器设置方式
                * 例如：'#firstNameMeg' '.lastNameMeg' '[data-stripe="exp-month"]'
                */
                //container: null,
                /**
                * 定义验证的节点，CSS选择器设置方式，可不必须是name值。
                * 若是id，class, name属性，<fieldName>为该属性值
                * 若是其他属性值且有中划线链接，<fieldName>转换为驼峰格式  selector: '[data-stripe="exp-month"]' =>  expMonth
                */
                //selector: null,
                /**
                * 定义触发验证方式（也可在fields中为每个字段单独定义），默认是live配置的方式，数据改变就改变
                * 也可以指定一个或多个（多个空格隔开） 'focus blur keyup'
                */
                //trigger: null,
                // 定义每个验证规则
                validators: {
                    //多个重复
                    //官方默认验证参照  http://bv.doc.javake.cn/validators/
                    // 注：使用默认前提是引入了bootstrapValidator-all.js
                    // 若引入bootstrapValidator.js没有提供常用验证规则，需自定义验证规则哦

                    notEmpty: {
                        message: '用户名不允许为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 30,
                        message: '账户长度在6-30之间'
                    },
                    regexp: {
                        regexp: /^[a-zA-Z0-9_\.]+$/,
                        message: '用户名仅允许数字，字母以及下划线'
                    }

                }
            },
            PassWord: {
                message: '密码无效',
                validators: {
                    notEmpty: {
                        message: '密码不允许为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 30,
                        message: '密码长度在6-30之间'
                    },
                    regexp: {
                        regexp: /^[a-zA-Z0-9_\.]+$/,
                        message: '密码仅允许数字，字母以及下划线'
                    }
                }
            }
        }
    }).on('success.form.bv', function (e) {
        // Prevent form submission
        e.preventDefault();

        // Get the form instance
        var $form = $(e.target);

        // Get the BootstrapValidator instance
        var bv = $form.data('bootstrapValidator');

        bv.disableSubmitButtons(false);
        // Use Ajax to submit form data
        layer.load(2);

        setTimeout(function () {
            layer.closeAll('loading');
        }, 10000);

        $.post($form.attr('action'), $form.serialize(), function (result) {
            // ... Process the result ...
            if (result.IsSuccess) {
                window.location.href = "/home/index";
            } else {
                layer.alert(result.Message);
                refreshVerifyCode();
                //bv.disableSubmitButtons(false);
            }
        }, 'json');


    });

    //验证结束

    $("#verifyCodeImg").click(function () {
        refreshVerifyCode();
    })

    $("#pwdIpt").keypress(function (e) {
        if (isCapsLock(e)) {
            layer.tips('已开启大写锁定', '#pwdIpt');
        }

    })


})

//刷新验证码

function refreshVerifyCode() {
    $("#verifyCodeImg").attr("src", "/login/GetVerifyCode?" + Math.random())
}

function isCapsLock(e) {
    var valueCapsLock = e.keyCode ? e.keyCode : e.which; // 按键     
    var valueShift = e.shiftKey ? e.shiftKey : ((valueCapsLock == 16) ? true : false); // shift键是否按住    
    if (((valueCapsLock >= 65 && valueCapsLock <= 90) && !valueShift) // 输入了大写字母，并且shift键没有按住，说明Caps Lock打开  
        || ((valueCapsLock >= 97 && valueCapsLock <= 122) && valueShift)) {// 输入了小写字母，并且按住 shift键<span style="font-family:Arial, Helvetica, sans-serif;">，说明</span><span style="font-family:SimSun;">Caps Lock</span><span style="font-family:Arial, Helvetica, sans-serif;">打开</span>  
        return true;
    } else {
        return false;
    }
}  