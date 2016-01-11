<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="WechatBuilder.Web.reg" ValidateRequest="false"%>
<%@ Import Namespace="WechatBuilder.Common" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title></title>
<meta name="keywords" content="微信云端、微信营销、微信代运营、微信托管、微网站、微商城、微营销、微信定制开发">
<meta name="description" content="微信云端,国内最大的微信公众智能服务平台,云端十大微体系:微菜单、微官网、微会员、微活动、微商城、微推送、微服务、微统计、微支付、微客服,企业微营销必备。">

<link rel="stylesheet" href="css/reg_1.css"> 
<link rel="stylesheet" href="css/reg_2.css">
<link rel="stylesheet" href="css/reg.css">  
 <script type="text/javascript" src="scripts/jquery/jquery-1.10.2.min.js"></script>
 <script type="text/javascript" src="scripts/jquery/Validform_v5.3.2_min.js"></script>
 <script type="text/javascript" src="scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
     <script type="text/javascript" src="admin/js/layout.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
	</div>
	<div class="mainbody">
		<div class="top">
        <div id="hd" class="clearfix">
            <div class="logo"><a href="/" hidefocus="true" onfocus="this.blur();">
            <img src="" width="228" height="61">
            </a></div>
        </div>

        <div class="info">
        <span><a href="/"  title="首页" hidefocus="true" onfocus="this.blur();">首页</a></span>
        <span class="split">|</span>
        <span><a href="admin/login.aspx" class="registerNew" title="登录" hidefocus="true" onfocus="this.blur();">帐号登录</a></span>
    </div>
    <div style="clear:both;"></div>
		</div>
     <div class="reg-wrapper2">
		<div id="regform" class="form-horizontal" >
				  <div class="control-group">
		    <label class="control-label" for="username">用户名</label>
		    <div class="controls" >
		        <asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" sucmsg=" " ajaxurl="tools/admin_ajax.ashx?action=manager_validate"></asp:TextBox>
                    <span class="Validform_checktip">*字母、下划线，不可修改</span>
		    </div>
		  </div>
		  <div class="control-group">
		    <label class="control-label" for="password">设置密码</label>
		    <div class="controls">
		       <asp:TextBox ID="txtPassword" runat="server" CssClass="input normal"   datatype="*0-20" nullmsg="请设置密码" errormsg="密码范围在6-20位之间" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*密码范围在6-20位之间。<asp:Literal ID="litpwdtip" runat="server"></asp:Literal></span>
		    </div>
		  </div>
		  <div class="control-group">
		    <label class="control-label" for="repassword">确认密码</label>
		    <div class="controls">
		     <asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" TextMode="Password" datatype="*" recheck="txtPassword" nullmsg="请再输入一次密码" errormsg="两次输入的密码不一致" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*再次输入密码</span></div>
		  </div>
           <div class="control-group">
		    <label class="control-label" for="phone">姓名</label>
		    <div class="controls">
		      <asp:TextBox ID="txtRealName" runat="server" CssClass="input normal"></asp:TextBox> <span class="Validform_checktip">用户名称</span>
		    </div>
            </div>
            <div class="control-group">
		    <label class="control-label" for="phone">电话</label>
		    <div class="controls">
		       <asp:TextBox ID="txtTelephone" runat="server" CssClass="input normal"></asp:TextBox>
		    </div>
            </div>
             <div class="control-group">
		    <label class="control-label" for="phone">常用qq</label>
		    <div class="controls">
		      <asp:TextBox ID="txtqq" runat="server" CssClass="input normal"  ></asp:TextBox>
		    </div>
            </div>
             <div class="control-group">
		    <label class="control-label" for="phone">所在区域</label>
		    <div class="controls">
		      <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                     <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
		    </div>
		  </div>
		  <div class="control-group">
		  	<div class="controls">
             <asp:Button ID="btnSubmit" runat="server"  CssClass="btn-register" OnClick="btnSubmit_Click" />

		  	</div>
		  	</div>
		  </div>
		</div>
		<div id="ft">Copyright©2014-2015 锐步信息科技有限公司 All Rights Reserved </div>
     </div>
    </form>
</body>
</html>
