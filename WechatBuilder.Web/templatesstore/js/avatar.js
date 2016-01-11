/* 
*作者：一些事情
*时间：2012-10-28
*需要结合jquery.Jcrop一起使用
----------------------------------------------------------*/
var jcrop_api, boundx, boundy;
//提交裁剪
function CropSubmit(webpath) {
	$("#upload_form").ajaxSubmit({
		success: function(data, textStatus) {
			if (data.status == 1){
				$.dialog.tips("头像上传成功！", 2, "32X32/succ.png", function(){
				    location.reload();
				});
			} else {
                $.dialog.alert(data.msg);
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
		    $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
		},
		url: webpath + "tools/submit_ajax.ashx?action=user_avatar_crop",
		type: "post",
		dataType: "json",
		timeout: 200000
	});
	return false;
}

//上传头像
function Upload(webpath) {
    //开始提交
    $("#upload_form").ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            //隐藏上传按钮
            $(".avatar_upload .files").eq(0).hide();
            //显示LOADING图片
            $(".avatar_upload .uploading").eq(0).show();
        },
        success: function (data, textStatus) {
            if (data.status == 1) {
                //初始化
                InitJcrop();
                jcrop_api.setImage(data.path, function () {
                    $('#hideFileName').val(data.path);
                    $('#preview').attr('src', data.path);
                    var bounds = jcrop_api.getBounds();
                    boundx = bounds[0];
                    boundy = bounds[1];
                    jcrop_api.setSelect([0, 0, 180, 180]);
                });
            } else {
                $.dialog.alert(data.msg);
            }
            $(".avatar_upload .files").eq(0).show();
            $(".avatar_upload .uploading").eq(0).hide();
        },
        error: function (data, status, e) {
            $.dialog.alert("上传失败，错误信息：" + e);
            $(".avatar_upload .files").eq(0).show();
            $(".avatar_upload .uploading").eq(0).hide();
        },
        url: webpath + "tools/upload_ajax.ashx?action=SingleFile&DelFilePath=hideFileName",
        type: "post",
        dataType: "json",
        timeout: 60000
    });
    return false;
}

//初始化Jcrop
function InitJcrop(){
    //var jcrop_api, boundx, boundy;
	$("#target").Jcrop({
		onChange: updatePreview,
		onSelect: updatePreview,
		aspectRatio: 1,
		boxWidth: 350,
		boxHeight: 350
	},function(){
		jcrop_api = this;
	});
};
//头像预览图
function updatePreview(c){
	if (parseInt(c.w) > 0){
		var rx = 180 / c.w;
		var ry = 180 / c.h;
		$('#preview').css({
			width: Math.round(rx * boundx) + 'px',
			height: Math.round(ry * boundy) + 'px',
			marginLeft: '-' + Math.round(rx * c.x) + 'px',
			marginTop: '-' + Math.round(ry * c.y) + 'px'
		});
		$('#hideX1').val(Math.round(c.x));
        $('#hideY1').val(Math.round(c.y));
        $('#hideWidth').val(Math.round(c.w));
        $('#hideHeight').val(Math.round(c.h));
	}
};