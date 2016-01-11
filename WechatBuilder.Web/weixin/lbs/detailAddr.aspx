<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detailAddr.aspx.cs" Inherits="WechatBuilder.Web.weixin.lbs.detailAddr" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="css/themes/default/jquery.mobile-1.3.1.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.mobile-1.3.1.min.js"></script>
    <style type="text/css">
        body, html, #allmap
        {
            width: 100%;
            height: 100%;
            overflow: hidden;
            margin: 0;
        }

        #l-map
        {
            height: 100%;
            width: 78%;
            float: left;
            border-right: 2px solid #bcbcbc;
        }
    </style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=EAb290e5fc1387c29e70af9550dcd9f6"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div data-role="page" data-theme="a" id="demo-page" class="my-page">
            <div data-role="header">
                <h1 class="ui-title" role="heading"></h1>
                <%--  <a data-role="button" data-ajax="false" rel="external" href="index.aspx?x=32.030367&y=118.732448">更多...
                </a>
                <a data-role="button" href="tel:025-85538169">拨打电话</a> --%>
                <asp:Literal ID="litAInfo" runat="server" EnableViewState="false"></asp:Literal>

            </div>
            <div data-role="content">
                <div id="allmap" class="ui-bar-c ui-corner-all ui-shadow"></div>
            </div>

        </div>

        <asp:Literal ID="litJavaScript" runat="server" EnableViewState="false"></asp:Literal>

      
    </form>
</body>
</html>



