//=====================初始化代码======================
$(function () {
    //显示验证码
    $("#txtCode").bind("focus", function () {
        $("#verifyCode").show();
    });
    //同意条款
    $("#chkAgree").click(function () {
        if ($(this).is(":checked")) {
            $("#btnSubmit").prop("disabled", false);
        } else {
            $("#btnSubmit").prop("disabled", true);
        }
    });
	//发送短信
	$("#btnSendcode").click(function(){
		//检查是否输入手机号码
		if($("#txtMobile").val()==""){
			$.dialog.alert("对不起，请先输入手机号码！");
			return false;
		}
		//设置按钮状态
		$("#txtCode").prop("disabled", false);
		$("#btnSendcode").prop("disabled", true);
		$.ajax({
			type: "POST",
			url: $("#btnSendcode").attr("url"),
			dataType: "json",
			data: {
				"mobile" : $("#txtMobile").val()
			},
			timeout: 20000,
			success: function(data, textStatus) {
				if (data.status == 1){
					$.dialog.tips(data.msg, 2, "32X32/succ.png", function(){ });
				} else {
					$("#btnSendcode").prop("disabled", false);
					$.dialog.alert(data.msg);
				}
			},
			error: function (XMLHttpRequest, textStatus, errorThrown) {
				$("#btnSendcode").prop("disabled", false);
				$.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
			}
		});
	});
    //初始化验证表单
	$("#regform").Validform({
		tiptype:3,
		callback:function(form){
			//AJAX提交表单
            $(form).ajaxSubmit({
                beforeSubmit: showRequest,
                success: showResponse,
                error: showError,
                url: $("#regform").attr("url"),
                type: "post",
                dataType: "json",
                timeout: 60000
            });
            return false;
		}
	});

    //表单提交前
    function showRequest(formData, jqForm, options) {
		$("#btnSubmit").val("正在提交...")
        $("#btnSubmit").prop("disabled", true);
        $("#chkAgree").prop("disabled", true);
    }
    //表单提交后
    function showResponse(data, textStatus) {
        if (data.status == 1) { //成功
            location.href = data.url;
        } else { //失败
            $.dialog.alert(data.msg);
            $("#btnSubmit").val("再次提交");
            $("#btnSubmit").prop("disabled", false);
            $("#chkAgree").prop("disabled", false);
        }
    }
    //表单提交出错
    function showError(XMLHttpRequest, textStatus, errorThrown) {
        $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        $("#btnSubmit").val("再次提交");
        $("#btnSubmit").prop("disabled", false);
        $("#chkAgree").prop("disabled", false);
    }
});