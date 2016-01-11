<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="diancai_oder.aspx.cs" Inherits="WechatBuilder.Web.weixin.diancai.diancai_oder" %>

<html >
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
<title><%=hotelName %></title>
<link href="css/diancai.css" rel="stylesheet" type="text/css">
<script src="js/jquery.min.js" type="text/javascript"></script>
<script src="js/alert.js" type="text/javascript"></script>
<style>
</style>
</head>
<body class="mode_webapp">
<div class="menu_header"> 
     <div class="menu_topbar">
      <strong class="head-title">查看我的订单</strong>
      <span class="head_btn_left"><a href="javascript:history.go(-1);"><span>返回</span></a><b></b></span>
      <a class="head_btn_right" href="caidan_shangjia.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
      <span><i class="menu_header_home"></i></span><b></b>
      </a>
     </div>
</div>

<div class="cardexplain"> 

<!--超过预订时间3天后自动删掉预订记录，免得占服务器资源！-->
<%=str %>
</div>  
       
 
 
<!--页码-->
    


<div class="footermenu">
        <ul>
            <li>
                <a href="caidan_guanyu.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/xxyX63YryG.png">
                    <p>关于</p>
                </a>
            </li>
            <li>
                <a href="index.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/Lngjm86JQq.png">
                    <p>点单外卖</p>
                </a>
            </li>
            <li>
                <a href="diancai_shoppingCart.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <span class="num" id="cartN2">0</span>
                    <img src="images/2yFKO6TwKI.png">
                    <p>购物车</p>
                </a>
            </li>
            <li>
                <a class="active"  href="diancai_oder.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/s22KaR0Wtc.png">
                    <p>订单</p>
                </a>
            </li>
            <li>
                <a href="diancai_geren.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/J0uZbXQWvJ.png">
                    <p>我的</p>
                </a>
            </li>
        </ul>
</div>

<script type="text/javascript">


    document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
        WeixinJSBridge.call('hideToolbar');
    });
</script>

</body>
</html>

