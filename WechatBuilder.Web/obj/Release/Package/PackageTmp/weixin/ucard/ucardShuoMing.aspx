<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ucardShuoMing.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.ucard.ucardShuoMing" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>会员卡</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/card.css" rel="stylesheet" type="text/css">
    <script src="js/accordian.pack.js" type="text/javascript"></script>
</head>
<body id="cardnews" class="mode_webapp2" onload="new Accordian('basic-accordian',5,'header_highlight');">
    <form id="form1" runat="server">
         <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
        <div class="qiandaobanner"><a href="javascript:history.go(-1);">
             <asp:Image ID="imgTopPic" runat="server" ImageUrl="images/themes/1/info.jpg" EnableViewState="false" />
        </a></div>

        <div id="basic-accordian">
            <div id="test-header" class="accordion_headings header_highlight">
                <div class="tab cardinfo">
                    <span class="title">会员卡使用说明</span>
                </div>
                <div id="test-content" style="display: block; overflow: hidden; opacity: 1;">
                    <div class="accordion_child">
                        <b>详情说明</b>
                        <ul>
                            <asp:Literal ID="lituserdContent" runat="server" EnableViewState="false"></asp:Literal>
                        </ul>
                    </div>
                </div>
            </div>
            <div id="test1-header" class="accordion_headings">
                <div class="tab integral_info">
                    <span class="title">会员积分说明</span>
                </div>
                <div id="test1-content" style="display: none; overflow: hidden;">
                    <div class="accordion_child">
                        <b>详情说明</b>
                        <ul>
                             <asp:Literal ID="litscoreRegular" runat="server" EnableViewState="false"></asp:Literal>
                        </ul>
                    </div>
                </div>
            </div>
            <div id="test2-header" class="accordion_headings">
                <div class="tab businesses_info">
                    <span class="title">商家介绍</span>
                </div>
                <div id="test2-content" style="display: none; overflow: hidden;">
                    <div class="accordion_child">
                        <p class="xiangqing">
                             <asp:Literal ID="litcardBrief" runat="server" EnableViewState="false"></asp:Literal>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <script src="js/plugback.js" type="text/javascript" ></script>

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
