<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photoy1y.aspx.cs" Inherits="WechatBuilder.Web.weixin.albums.photoy1y" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>微相册摇一摇</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="../xitie/css/wedding.css" media="all">
    <script src="../../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../xitie/js/wedding.js" type="text/javascript"></script>
    <script src="../xitie/js/jquery_easing.js" type="text/javascript"></script>
    <script src="../xitie/js/wedding_sys.js" type="text/javascript"></script>
    <script src="../../scripts/jquery/alert.js" type="text/javascript"></script>
    <script src="../../scripts/jquery/jquery.query.js" type="text/javascript"></script>


    <link href="/templatesstore/css/iscroll.css" rel="stylesheet" type="text/css" />

    <script src="/templatesstore/js/iscroll.js" type="text/javascript"></script>

    <script src="js/shake.js" type="text/javascript"></script>

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
        function yyl() {

            
            
            myScroll.scrollToPage('next', 0, 400, count);

        }

        document.addEventListener('DOMContentLoaded', loaded, false);

        window.onload = function () {

            window.addEventListener('shake', yyl, false);
        };


    </script>

     
</head>
<body onselectstart="return true;" ondragstart="return false;">

    <script type="text/javascript">
        var thisurl = document.URL;

        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            window.shareData = {
                "imgUrl": "<%=albums.facePic%>",
                "timeLineLink": thisurl,
                "sendFriendLink": thisurl,
                "weiboLink": thisurl,
                "tTitle": "<%=albums.aName%>",
                "tContent": "<%=albums.aContent%>",
                "fTitle": "<%=albums.aName%>",
                "fContent": "<%=albums.aContent%>",
                "wContent": "<%=albums.aContent%>"
            };
            // 发送给好友
            WeixinJSBridge.on('menu:share:appmessage', function (argv) {
                WeixinJSBridge.invoke('sendAppMessage', {
                    "img_url": window.shareData.imgUrl,
                    "img_width": "640",
                    "img_height": "640",
                    "link": window.shareData.sendFriendLink,
                    "desc": window.shareData.fContent,
                    "title": window.shareData.fTitle
                }, function (res) {
                    _report('send_msg', res.err_msg);
                })
            });

            // 分享到朋友圈
            WeixinJSBridge.on('menu:share:timeline', function (argv) {
                WeixinJSBridge.invoke('shareTimeline', {
                    "img_url": window.shareData.imgUrl,
                    "img_width": "640",
                    "img_height": "640",
                    "link": window.shareData.timeLineLink,
                    "desc": window.shareData.tContent,
                    "title": window.shareData.tTitle
                }, function (res) {
                    _report('timeline', res.err_msg);
                });
            });

            // 分享到微博
            WeixinJSBridge.on('menu:share:weibo', function (argv) {
                WeixinJSBridge.invoke('shareWeibo', {
                    "content": window.shareData.wContent,
                    "url": window.shareData.weiboLink,
                }, function (res) {
                    _report('weibo', res.err_msg);
                });
            });
            WeixinJSBridge.call('hideToolbar');
        }, false)
    </script>
    <script>
        $().ready(function () {

            playbox.init("playbox");

        });
        var openid = $.query.get("openid");

    </script>
    <div>
        <div class="container">
            <header>
                <div>
                    <ul class="box">
                        <li class="relative"><span class="pic">
                            <img src=""></span></li>
                        <li>
                            <div class="name">
                                摇
                                <img src="images/04.png" style="width: 30px;" />
                                摇
                                <div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <span id="playbox" class="btn_music on" onclick="playbox.init(this).play();">
                                <audio id="audio" loop="" src="<%=albums.music%>"></audio>
                            </span>

                            
                        </li>
                    </ul>
                </div>
            </header>
            <div style="height: 70px"></div>
            <section class="body">


                <!--图片-->
                <div style="margin-top: 10px; min-height:100px;" id="bjdiv">
                    <div id="wrapper">
                        <div id="scroller">
                            <ul id="thelist">
                                <asp:Literal ID="litPiclist" runat="server" EnableViewState="false"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                    <div id="nav">
                        <div id="prev" onclick="myScroll.scrollToPage('prev', 0,360,<%=num%>);return false">&larr; prev</div>
                        <ul id="indicator">
                            <asp:Literal ID="litPicNumlist" runat="server" EnableViewState="false"></asp:Literal>
                        </ul>
                        <div id="next" onclick="myScroll.scrollToPage('next', 0,360,<%=num%>);return false">next &rarr;</div>
                    </div>
                    <div class="clr"></div>
                </div>
                <script>
                    var count = document.getElementById("thelist").getElementsByTagName("img").length;

                    var count2 = document.getElementsByClassName("menuimg").length;

                    for (i = 0; i < count; i++) {

                        document.getElementById("thelist").getElementsByTagName("img").item(i).style.cssText = " width:" + (document.body.clientWidth-40) + "px";

                    }
                    document.getElementById("scroller").style.cssText = " width:" + (document.body.clientWidth-40) * count + "px";

                    //setInterval(function () {
                    //    myScroll.scrollToPage('next', 0, 360, count);
                    //}, 3500);
                    window.onresize = function () {
                        for (i = 0; i < count; i++) {

                            document.getElementById("thelist").getElementsByTagName("img").item(i).style.cssText = " width:" + document.body.clientWidth + "px";

                        }
                        document.getElementById("scroller").style.cssText = " width:" + document.body.clientWidth * count + "px";



                    }


                    $("#bjdiv").css("height", (document.body.clientWidth / 3) * 2 + 10);
        </script>




            </section>


        </div>

        <footer>
            <!--版权-->

        </footer>


    </div>

</body>
</html>
