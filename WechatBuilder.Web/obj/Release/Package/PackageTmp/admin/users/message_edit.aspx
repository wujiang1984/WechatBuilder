<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.users.message_edit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑短消息</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //加载编辑器
        var editorMini = KindEditor.create('#txtContent', {
            width: '98%',
            height: '250px',
            resizeType: 1,
            uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            items: [
				'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
				'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				'insertunorderedlist', '|', 'emoticons', 'image', 'link']
        });
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="sms_template_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>会员管理</span>
  <i class="arrow"></i>
  <span>编辑短消息</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑消息内容</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <div id="div_view" runat="server" visible="false">
      <dl>
        <dt>短信类型</dt>
        <dd><asp:Label ID="labType" runat="server" /></dd>
      </dl>
      <dl>
        <dt>发件人</dt>
        <dd><asp:Label ID="labPostUserName" runat="server" /></dd>
      </dl>
      <dl>
        <dt>收件人</dt>
        <dd><asp:Label ID="labAcceptUserName" runat="server" /></dd>
      </dl>
      <dl>
        <dt>发送时间</dt>
        <dd><asp:Label ID="labPostTime" runat="server" /></dd>
      </dl>
      <dl>
        <dt>阅读状态</dt>
        <dd><asp:Label ID="labIsRead" runat="server" /></dd>
      </dl>
      <dl>
        <dt>阅读时间</dt>
        <dd><asp:Label ID="labReadTime" runat="server" /></dd>
      </dl>
      <dl>
        <dt>标题</dt>
        <dd><asp:Label ID="labTitle" runat="server" /></dd>
      </dl>
      <dl>
        <dt>内容</dt>
        <dd><asp:Literal ID="litContent" runat="server"></asp:Literal></dd>
      </dl>
  </div>

  <div id="div_add" runat="server">
      <dl>
        <dt>收件人</dt>
        <dd>
          <asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
          <span class="Validform_checktip">*输入用户名，以英文逗号“,”分隔开</span>
        </dd>
      </dl>
      <dl>
        <dt>标题</dt>
        <dd>
          <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
          <span class="Validform_checktip">*100个字符以内</span>
        </dd>
      </dl>
      <dl>
        <dt>短信内容</dt>
        <dd>
          <textarea id="txtContent" style="visibility:hidden;" runat="server"></textarea>
        </dd>
      </dl>
  </div>
</div>
<!--/内容-->


<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交发送" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
