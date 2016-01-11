<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caidan_shangjia.aspx.cs" Inherits="WechatBuilder.Web.weixin.diancai.caidan_shangjia" %>


<html >
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
<title>订餐系统</title>
<link href="css/diancai.css" rel="stylesheet" type="text/css" />
<script src="js/jquery.min.js" type="text/javascript"></script>
<script src="js/iscroll.js" type="text/javascript"></script>
<script type="text/javascript">
    var myScroll;

    function loaded() {
        myScroll = new iScroll('wrapper', {
            snap: true,
            momentum: false,
            hScrollbar: false,
            onScrollEnd: function () {
                document.querySelector('#indicator > li.active').className = '';
                document.querySelector('#indicator > li:nth-child(' + (this.currPageX + 1) + ')').className = 'active';
            }
        });
    }
    document.addEventListener('DOMContentLoaded', loaded, false);
</script>
</head>
<body id="diancaiindex">
<div class="banner">
<div id="wrapper">
<div id="scroller">
<ul id="thelist">
               
<li><p>111</p><a href="http://www.baidu.com" > <img src="http://img.ishangtong.com/baeimages/DkPOhq1Vd1.jpg"></a></li>
 
<li><p>111222</p><img src="http://img.ishangtong.com/baeimages/GkHiHG0woj.jpg"></li>
 
<li><p>111</p><img src="http://img.ishangtong.com/baeimages/YNlY0K3WL7.jpg"></li>
 

</ul>
</div>
</div>
<div id="nav">
<div id="prev" onClick="myScroll.scrollToPage('prev', 0,400,1);return false">&larr; prev</div>
<ul id="indicator">
            
<li   class="active"  >1</li>
 
<li   >2</li>
 
<li   >3</li>
 
</ul>
<div id="next" onClick="myScroll.scrollToPage('next', 0);return false">next &rarr;</div>
</div>
<div class="clr"></div>
</div>


<div class="cardexplain"> 


<!--热门商家-->
<ul class="round">
<li class="title"><span class="none smallspan">热门商家</span></li>
           <li class="dandanb"><a href="caidan_guanyu.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>"><span class="none shangjia">
           <img src="http://www.wxapi.cn/ke4/attached/image/uid10441/33473/20140311120918_35915.jpg" /><h2>商家1</h2>
<p>区域：63466</p><p>起送价：￥12</p><em class="ok">营业中</em><div class="clr"></div></span></a>
</li>
  </ul>

<!--招商热线-->
    <ul class="round">
<li class="tel"><a href="tel:"><span> 招商热线</span></a></li>
<li class="detail"><a href="?ac=diancaidetail&id=33473&shopid=783&c=o99epjjmjWhMPNzoQbo9r6DAEYds&refex=mp.weixin.qq.com"><span>查看详情</span></a></li>
</ul>
 

</div>

<script>
    var count = $("#thelist img").size();
    $("#thelist img").css("width", document.body.clientWidth);
    $("#scroller").css("width", document.body.clientWidth * count);
    setInterval(function () {
        myScroll.scrollToPage('next', 0, 400, count);
    }, 3500);
    window.onresize = function () {

        $("#thelist img").css("width", document.body.clientWidth);
        $("#scroller").css("width", document.body.clientWidth * count);
    }

</script>



<script type="text/javascript">
    document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
        WeixinJSBridge.call('hideToolbar');
    });
</script>
</body>
</html>

