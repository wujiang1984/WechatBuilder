<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="MxWeiXinPF.Web.admin.center" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理首页</title>
    <link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/layout.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a class="home"><i></i><span>管理中心</span></a>
           
        </div>
        <!--/导航栏-->

        <!--内容-->
        <div class="line10"></div>
        <div class="nlist-1">
            <ul>
                <li>本次登录IP：<asp:Literal ID="litIP" runat="server" Text="-" /></li>
                <li>上次登录IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></li>
                <li>上次登录时间：<asp:Literal ID="litBackTime" runat="server" Text="-" /></li>
            </ul>
        </div>
        <div class="line10"></div>

        <div class="nlist-2">
            <h3><i></i>站点信息</h3>
            <ul>
                <li>站点名称：<%=siteConfig.webname %></li>
                <li>公司名称：<%=siteConfig.webcompany %></li>
                <li>系统版本：V<%=Utils.GetVersion()%></li>
                <li>升级通知：<asp:Literal ID="LitUpgrade" runat="server" /></li>
            </ul>
            <h3><i class="msg"></i>官方消息</h3>
            <ul>
                <asp:Literal ID="LitNotice" runat="server" />
            </ul>
        </div>
        <div class="line20"></div>

       <%-- <div class="nlist-3">
            <ul>
                <li><a onclick="parent.linkMenuTree(true, 'site_config');" class="icon-setting" href="javascript:;"></a><span>系统设置</span></li>
                <li><a onclick="parent.linkMenuTree(true, 'site_channel_category');" class="icon-channel" href="javascript:;"></a><span>频道分类</span></li>
                <li><a onclick="parent.linkMenuTree(true, 'app_templet_list');" class="icon-templet" href="javascript:;"></a><span>模板管理</span></li>
                <li><a onclick="parent.linkMenuTree(true, 'app_builder_html');" class="icon-mark" href="javascript:;"></a><span>生成静态</span></li>
                <li><a onclick="parent.linkMenuTree(true, 'app_plugin_list');" class="icon-plugin" href="javascript:;"></a><span>插件配置</span></li>
                <li><a onclick="parent.linkMenuTree(true, 'user_list');" class="icon-user" href="javascript:;"></a><span>会员管理</span></li>
                <li><a onclick="parent.linkMenuTree(true, 'manager_list');" class="icon-manaer" href="javascript:;"></a><span>管理员</span></li>
                <li><a onclick="parent.linkMenuTree(true, 'manager_log');" class="icon-log" href="javascript:;"></a><span>系统日志</span></li>
            </ul>
        </div>--%>

       

        <!--/内容-->
    </form>
</body>
</html>
