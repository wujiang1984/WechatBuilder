<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ucardNotice.aspx.cs" Inherits="WechatBuilder.Web.weixin.ucard.ucardNotice" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/card.css" rel="stylesheet" type="text/css">
    <script src="js/accordian.pack.js" type="text/javascript"></script>
</head>
<body id="cardnews" onload="new Accordian('basic-accordian',5,'header_highlight');" class="mode_webapp2">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />

        <div class="qiandaobanner">
            <a href="javascript:history.go(-1);">
                <asp:Image ID="imgTopPic" runat="server" ImageUrl="images/themes/1/news.jpg" EnableViewState="false" />
            </a>
        </div>

        <div id="basic-accordian">
            <asp:Literal ID="litNoticeList" runat="server" EnableViewState="false"></asp:Literal>

        </div>
        <script src="js/plugback.js" type="text/javascript" type="text/javascript"></script>

        <div class="footermenu">
            <ul>
                <li>
                    <a href="index.aspx?wid=<%=wid%>&id=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/ucard.png">
                        <p>会员卡</p>
                    </a>
                </li>
                <li>
                    <a href="ucardPrivileges.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/tequan.png">
                        <p>特权</p>
                    </a>
                </li>
                <li>
                    <a href="ucardTicket.aspx?wid=<%=wid %>&sid=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/ticketpic.png">
                        <p>优惠券</p>
                    </a>
                </li>
                <li>
                    <a href="duihuan.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/duihuan.png">
                        <p>兑换</p>
                    </a>
                </li>
                <li>
                    <a href="qiandao.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/qiandao_btm.png">
                        <p>签到</p>
                    </a>
                </li>
            </ul>
        </div>
        <script type="text/javascript">
            document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
                WeixinJSBridge.call('hideToolbar');
            });
        </script>
    </form>
</body>
</html>
