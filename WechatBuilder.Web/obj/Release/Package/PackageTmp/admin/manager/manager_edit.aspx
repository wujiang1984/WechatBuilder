<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manager_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.manager.manager_edit"  ValidateRequest="false" %>

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
            <a href="manager_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="manager_list.aspx"><span>用户</span></a>
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
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                    </ul>
                </div>
            </div>
        </div>




        <div class="tab-content">

            <dl>
                <dt>管理角色</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlRoleId" runat="server" datatype="*" errormsg="请选择管理员角色" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>是否启用</dt>
                <dd>
                    <div class="rule-single-checkbox">
                        <asp:CheckBox ID="cbIsLock" runat="server" Checked="True" />
                    </div>
                    <span class="Validform_checktip">*不启用则无法使用该账户登录</span>
                </dd>
            </dl>
            <dl>
                <dt style="color:#16a0d3; font-weight:bolder;">可创建的微信帐号数量</dt>
                <dd>
                    <asp:TextBox ID="txtMaxNum" runat="server" CssClass="input small" datatype="n" sucmsg=" ">1</asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>登录名</dt>
                <dd>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" sucmsg=" " ajaxurl="../../tools/admin_ajax.ashx?action=manager_validate"></asp:TextBox>
                    <span class="Validform_checktip">*字母、下划线，不可修改</span></dd>
            </dl>
            <dl>
                <dt>登录密码</dt>
                <dd>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input normal"   datatype="*0-20" nullmsg="请设置密码" errormsg="密码范围在6-20位之间" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*密码范围在6-20位之间。<asp:Literal ID="litpwdtip" runat="server"></asp:Literal></span></dd>
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
           


            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtSortid" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                     <span class="Validform_checktip">*数字，越小越向前</span>
                </dd>
            </dl>

        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
