<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editormyinfo.aspx.cs" Inherits="MxWeiXinPF.Web.admin.manager.editormyinfo" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑用户</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();


        });

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>编辑个人资料</span></a>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->


        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑个人资料</a></li>
                    </ul>
                </div>
            </div>
        </div>




        <div class="tab-content">

            <dl>
                <dt>登录名</dt>
                <dd>
                    <asp:Label ID="lblid" runat="server" Text="0" style="display:none;"></asp:Label>
                    <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                 </dd>
            </dl>
            
            <dl>
                <dt>姓名</dt>
                <dd>
                    <asp:TextBox ID="txtRealName" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>电话</dt>
                <dd>
                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
             <dl>
                <dt>常用qq</dt>
                <dd>
                    <asp:TextBox ID="txtqq" runat="server" CssClass="input normal"  ></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>邮箱</dt>
                <dd>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input normal" ></asp:TextBox>
                    <span class="Validform_checktip"> </span>
                </dd>
            </dl>
            
            <dl>
                <dt>地区</dt>
                <dd>
                     
                    <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                     <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
                     
                </dd>
            </dl>
           <dl>
               <dt>详细地址</dt>
               <dd><asp:TextBox ID="txtArea" runat="server" CssClass="input normal" ></asp:TextBox></dd>
           </dl>
          
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
