<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatBuilder.Web.weixin.groupbuy.index" %>

<!DOCTYPE html>

<html>
<head>
    <title><%=activityName %></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="css/Groupbuying.css?20131222" media="all">
</head>
<body>

    <section class="F_home box-shadow marg20">
        <h1><%=activityName %></h1>
        <div class="Fh_img position_re">
         
            <img id="shateImg_163839" src="<%=status=="团购已结束"?model.imageUrlend :model.imageUrl%>" def="/images/def.png" onerror="imgOnerror();"><span id="countDown"></span>
  
            <img src="<%=status.Contains("每人限购") ? "http://wxapi.cn/index/images/Groupbuying/success.png":""%>"  class="tgts">

        </div>
        <div class="Fh_price Fh_teshd F_zindex">
            <strong>￥<%=groupPrice %></strong><del>￥<%=costPrice %></del><span class="F_grey"><cite><%=purchaseCount %></cite>人购买</span><div class="tishi">

                <small class="F_grey"><%=days %></small>
                <small class="F_red"><%=chengtuanCount %>人已成团</small>
            </div>
        </div>

        <!-- 活动描述 -->
        <h2 class="fhdtl_h"><strong>活动描述</strong></h2>
        <div class="fhdtl_p">
            <p>
              <asp:Literal ID="activeDescription" runat="server" EnableViewState="true"></asp:Literal>
            </p>
        </div>

        <!-- 特别提醒 -->
        <h2 class="fhdtl_h"><strong>特别提醒</strong></h2>
        <div class="fhdtl_p">
            <p>
     <asp:Literal ID="specialRemind" runat="server" EnableViewState="true"></asp:Literal>
            </p>
        </div>


        <!-- 商家信息 -->
        <h2 class="fhdtl_h"><strong>商家信息</strong></h2>
        <div class="fhdtl_p">
            <p><%=introduction %></p>
            <ul class="round">
                <li class="addr"><a href="http://api.map.baidu.com/marker?location=<%=txtLatXPoint%>,<%=txtLatYPoint %>&amp;title=<%=activityName %>&amp;content=<%=activityName %>&amp;output=html"><span><%=address %></span></a></li>
                <li class="tel"><a href="tel:<%=tel %>"><span><%=shopstel %></span></a></li>
            </ul>
        </div>



        <h2 class="fhdtl_h"></h2>
        <div class="Fh_dtlfont padb40"><%=copyrightSetup %></div>
        <footer>
            <div class="Fh_btn2 dlt_btn">
                <i></i>
                <a class="fhbtn F_bB1" href='<%=status=="团购已结束"? "":"purchase.aspx?wid="+model.wid+"&aid="+model.Id+"&openid="+openid+""%>'><%=status%></a>
                <i class="iright"></i>
            </div>
        </footer>
    </section>

    <script type="text/javascript">
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            WeixinJSBridge.call('hideToolbar');
        });
    </script>
</body>
</html>
