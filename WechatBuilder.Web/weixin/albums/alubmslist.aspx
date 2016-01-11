<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alubmslist.aspx.cs" Inherits="WechatBuilder.Web.weixin.albums.alubmslist" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>相册列表</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">

    <meta charset="utf-8">
    <link href="css/photo.css" rel="stylesheet" type="text/css" />

</head>

<body id="photo">
    <form id="form1" runat="server">
        <div class="qiandaobanner">
            <asp:Literal ID="litBanner" runat="server" EnableViewState="false"></asp:Literal>
        </div>
        <div id="todayList">
              <ul class="chatPanel">
                  <asp:Literal ID="litAlbumsList" runat="server" EnableViewState="false"></asp:Literal>
                  </ul>
            </div>
         <div class="copyright"> <asp:Literal ID="litCopyRight" runat="server" EnableViewState="false"></asp:Literal></div>


    </form>
</body>
</html>
