<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_accept.aspx.cs" Inherits="MxWeiXinPF.Web.admin.dialog.dialog_accept" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>修改收货信息窗口</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/jquery/PCASClass.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确定',
        focus: true,
        callback: function () {
            submitForm();
            return false;
        }
    }, {
        name: '取消'
    });

    //页面加载完成执行
    $(function () {
        //初始化省市区
        var areaArr = $("#spanArea", W.document).text().split(",");
        if (areaArr.length == 3) {
            new PCAS("txtProvince", "txtCity", "txtArea", areaArr[0], areaArr[1], areaArr[2]);
        } else {
            new PCAS("txtProvince", "txtCity", "txtArea");
        }
        $("#txtAcceptName").val($("#spanAcceptName", W.document).text());
        $("#txtAddress").val($("#spanAddress", W.document).text());
        $("#txtPostCode").val($("#spanPostCode", W.document).text());
        $("#txtMobile").val($("#spanMobile", W.document).text());
        $("#txtTelphone").val($("#spanTelphone", W.document).text());
    });

    //提交表单处理
    function submitForm() {
        //验证表单
        if ($("#txtAcceptName").val() == "") {
            W.$.dialog.alert('请填写收货人姓名！', function () { $("#txtAcceptName").focus(); }, api);
            return false;
        }
        if ($("#txtArea").val() == "") {
            W.$.dialog.alert('请选择所在地区！', function () { $("#txtProvince").focus(); }, api);
            return false;
        }
        if ($("#txtAddress").val() == "") {
            W.$.dialog.alert('请填写详细的送货地址！', function () { $("#txtAddress").focus(); }, api);
            return false;
        }
        if ($("#txtMobile").val() == "" && $("#txtTelphone").val() == "") {
            W.$.dialog.alert('联系手机或电话至少填写一项！', function () { $("#txtMobile").focus(); }, api);
            return false;
        }
        //下一步，AJAX提交表单
        var postData = {
            "order_no": $("#spanOrderNo", W.document).text(), "edit_type": "edit_accept_info",
            "accept_name": $("#txtAcceptName").val(), "province": $("#txtProvince").val(),
            "city": $("#txtCity").val(), "area": $("#txtArea").val(), "address": $("#txtAddress").val(),
            "post_code": $("#txtPostCode").val(), "mobile": $("#txtMobile").val(), "telphone": $("#txtTelphone").val()
        };
        //发送AJAX请求
        W.sendAjaxUrl(api, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
        return false;
    }
</script>
</head>

<body>
<div class="div-content">
    <dl>
      <dt>收件人姓名</dt>
      <dd><input type="text" id="txtAcceptName" class="input txt" /> <span class="Validform_checktip">*</span></dd>
    </dl>
    <dl>
      <dt>所属省市</dt>
      <dd>
        <select id="txtProvince" name="txtProvince" class="select"></select>
        <select id="txtCity" name="txtCity" class="select"></select>
        <select id="txtArea" name="txtArea" class="select"></select>
      </dd>
    </dl>
    <dl>
      <dt>详细地址</dt>
      <dd><input type="text" id="txtAddress" class="input normal" /> <span class="Validform_checktip">*</span></dd>
    </dl>
    <dl>
      <dt>邮政编码</dt>
      <dd><input type="text" id="txtPostCode" class="input txt" /></dd>
    </dl>
    <dl>
      <dt>联系手机</dt>
      <dd><input type="text" id="txtMobile" class="input txt" /> <span class="Validform_checktip">*</span></dd>
    </dl>
    <dl>
      <dt>联系电话</dt>
      <dd><input type="text" id="txtTelphone" class="input txt" /></dd>
    </dl>
</div>
</body>
</html>