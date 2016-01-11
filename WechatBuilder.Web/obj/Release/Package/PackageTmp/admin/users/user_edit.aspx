<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.users.user_edit" ValidateRequest="false" %>
<%@ Import namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑用户</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //初始化上传控件
        $(".upload-img").each(function () {
            $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
        });
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="user_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>会员管理</span>
  <i class="arrow"></i>
  <span>编辑用户</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本资料</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">账户信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>所属组别</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlGroupId" runat="server" datatype="*" errormsg="请选择组别" sucmsg=" "></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>用户状态</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0" Selected="True">正常</asp:ListItem>
        <asp:ListItem Value="1">待验证</asp:ListItem>
        <asp:ListItem Value="2">待审核</asp:ListItem>
        <asp:ListItem Value="3">禁用</asp:ListItem>
        </asp:RadioButtonList>
      </div>
      <span class="Validform_checktip">*禁用账户无法登录</span>
    </dd>
  </dl>
  <dl>
    <dt>用户名</dt>
    <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " ajaxurl="../../tools/admin_ajax.ashx?action=validate_username"></asp:TextBox> <span class="Validform_checktip">*登录的用户名，支持中文</span></dd>
  </dl> 
  <dl>
    <dt>登录密码</dt>
    <dd><asp:TextBox ID="txtPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*6-20" nullmsg="请设置密码" errormsg="密码范围在6-20位之间" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*登录的密码，至少6位</span></dd>
  </dl>
  <dl>
    <dt>确认密码</dt>
    <dd><asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" TextMode="Password" datatype="*" recheck="txtPassword" nullmsg="请再输入一次密码" errormsg="两次输入的密码不一致" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*再次输入密码</span></dd>
  </dl>
  <dl>
    <dt>邮箱账号</dt>
    <dd><asp:TextBox ID="txtEmail" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*取回密码时用到</span></dd>
  </dl>
  <dl>
    <dt>用户昵称</dt>
    <dd><asp:TextBox ID="txtNickName" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>上传头像</dt>
    <dd>
      <asp:TextBox ID="txtAvatar" runat="server" CssClass="input normal upload-path"></asp:TextBox>
      <div class="upload-box upload-img"></div>
    </dd>
  </dl>
  <dl>
    <dt>用户性别</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="保密" Selected="True">保密</asp:ListItem>
        <asp:ListItem Value="男">男</asp:ListItem>
        <asp:ListItem Value="女">女</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>生日日期</dt>
    <dd>
      <div class="input-date">
        <asp:TextBox ID="txtBirthday" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
        <i>日期</i>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>手机号码</dt>
    <dd><asp:TextBox ID="txtMobile" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>电话号码</dt>
    <dd><asp:TextBox ID="txtTelphone" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>QQ号码</dt>
    <dd><asp:TextBox ID="txtQQ" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>通讯地址</dt>
    <dd><asp:TextBox ID="txtAddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
</div>

<div class="tab-content" style="display:none;">
  <dl>
    <dt>账户金额</dt>
    <dd>
      <asp:TextBox ID="txtAmount" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox> 元
      <span class="Validform_checktip">*账户上的余额</span>
    </dd>
  </dl>
  <dl>
    <dt>账户积分</dt>
    <dd>
      <asp:TextBox ID="txtPoint" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox> 分
      <span class="Validform_checktip">*积分也可做为交易</span>
    </dd>
  </dl>
  <dl>
    <dt>升级经验值</dt>
    <dd>
      <asp:TextBox ID="txtExp" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*根据积分计算得来，与积分不同的是只增不减</span>
    </dd>
  </dl>
  <dl>
    <dt>注册时间</dt>
    <dd><asp:Label ID="lblRegTime" Text="-" runat="server"></asp:Label></dd>
  </dl>
  <dl>
    <dt>注册IP</dt>
    <dd><asp:Label ID="lblRegIP" Text="-" runat="server"></asp:Label></dd>
  </dl>
  <dl>
    <dt>最近登录时间</dt>
    <dd><asp:Label ID="lblLastTime" Text="-" runat="server"></asp:Label></dd>
  </dl>
  <dl>
    <dt>最近登录IP</dt>
    <dd><asp:Label ID="lblLastIP" Text="-" runat="server"></asp:Label></dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

</form>
</body>
</html>
