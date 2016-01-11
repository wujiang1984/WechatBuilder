<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_express.aspx.cs" Inherits="WechatBuilder.Web.admin.dialog.dialog_express" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>订单发货窗口</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
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

    //提交表单处理
    function submitForm() {
        //验证表单
        if ($("#ddlExpressId").val() == "") {
            W.$.dialog.alert('请选择配送方式！', function () { $("#ddlExpressId").focus(); }, api);
            return false;
        }
        //组合参数
        var postData = {
            "order_no": $("#spanOrderNo", W.document).text(), "edit_type": "order_express",
            "express_id": $("#ddlExpressId").val(), "express_no": $("#txtExpressNo").val()
        };
        //判断是否需要输入物流单号
        if ($("#txtExpressNo").val() == "") {
            W.$.dialog.confirm('您确定不填写物流单号吗？',
            function () {
                //发送AJAX请求
                W.sendAjaxUrl(api, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
            },
            function () {
                $("#txtExpressNo").focus();
            },
            api);
            return false;
        } else {
            //发送AJAX请求
            W.sendAjaxUrl(api, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
        }
        return false;
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="div-content">
  <dl>
    <dt>更改配送方式</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlExpressId" runat="server"></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>发货物流单号</dt>
    <dd><asp:TextBox ID="txtExpressNo" runat="server" CssClass="input txt"></asp:TextBox></dd>
  </dl>
</div>
</form>
</body>
</html>