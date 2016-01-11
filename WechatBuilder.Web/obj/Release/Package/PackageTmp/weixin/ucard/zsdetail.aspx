<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zsdetail.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.ucard.zsdetail" %>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>商家详情</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/card.css" rel="stylesheet" type="text/css">
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>
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
<body id="cardunion" class="mode_webapp2">
    <form id="form1" runat="server">
           <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
        <div class="cardexplain">
            <!--招商热线-->
            <ul class="round">
                <li class="tel">
                    <asp:Literal ID="litTel" runat="server" EnableViewState="false"></asp:Literal>
                </li>
            </ul>

            <div class="detailcontent">
                <h2>详情介绍</h2>
                <div class="content">
                    <asp:Literal ID="litContent" runat="server" EnableViewState="false"></asp:Literal>
                </div>
            </div>
        </div>

        <script>


            var count = document.getElementById("thelist").getElementsByTagName("img").length;


            for (i = 0; i < count; i++) {
                document.getElementById("thelist").getElementsByTagName("img").item(i).style.cssText = " width:" + document.body.clientWidth + "px";

            }

            document.getElementById("scroller").style.cssText = " width:" + document.body.clientWidth * count + "px";


            setInterval(function () {
                myScroll.scrollToPage('next', 0, 400, count);
            }, 3500);

            window.onresize = function () {
                for (i = 0; i < count; i++) {
                    document.getElementById("thelist").getElementsByTagName("img").item(i).style.cssText = " width:" + document.body.clientWidth + "px";

                }

                document.getElementById("scroller").style.cssText = " width:" + document.body.clientWidth * count + "px";
            }

        </script>
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
        
        <script src="js/plugback.js" type="text/javascript"></script>


         <div class="footermenu">
            <ul>
                <li>
                    <a href="javascript:history.go(-1);">
                        <img src="images/themes/1/9uKCykhUSh.png">
                        <p>返回</p>
                    </a>
                </li>
                <li>
                    <a  href="ucardlist.aspx?wid=<%=wid%>&openid=<%=openid%>">
                        <img src="images/themes/1/3YQLfzfunJ.png">
                        <p>商城首页</p>
                    </a>
                </li>
                <li>
                    <a class="active" href="zsdetail.aspx?wid=<%=wid%>&openid=<%=openid%>">
                        <img src="images/themes/1/xxyX63YryG.png">
                        <p>详情</p>
                    </a>
                </li>
                <li>
                    <a href="myUcard.aspx?wid=<%=wid%>&openid=<%=openid%>">
                        <span class="num2">
                             <asp:Literal ID="lituStoreNum2" runat="server" EnableViewState="false"></asp:Literal>
                        </span>
                        <img src="images/themes/1/MczZiNz6a5.png">
                        <p>我的卡</p>
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
