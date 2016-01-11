<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userResult.aspx.cs" Inherits="WechatBuilder.Web.admin.yuyue.userResult" %>


<%@ Import Namespace="WechatBuilder.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>预约管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function parentToIndex(id) {
            parent.location.href = "/admin/Index.aspx?id=" + id;

        }
        $(function () {
            //设置头部图片
            $("#setBanner").click(function () {

                showGuiZeDialog();
            });

        });

        //设置头部图片
        function showGuiZeDialog() {
            var id = $("#lblWid").text();
            var contenturl = "url:albums/albumsSys.aspx?wid=" + id;

            var m = $.dialog({
                id: 'dialogKWGuiZe',
                fixed: true,
                lock: true,
                max: false,
                min: false,
                title: "相册头部图片",
                content: contenturl,
                height: 250,
                width: 650
            });
        }

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="index.aspx" class="home"><i></i><span>预约管理</span></a>
               <i class="arrow"></i>
               <span>用户提交数据</span>
        </div>
        <!--/导航栏-->
        

        <!--列表-->
        <asp:Literal ID="litTable" runat="server"></asp:Literal>
        
        <!--/列表-->

      
    </form>
</body>
</html>
