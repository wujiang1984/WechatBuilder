<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.ggk.index" %>

<%if (ggkAction != null) { %>

<%@ Import Namespace="MxWeiXinPF.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="羽帮、微信营销、微信代运营、微信定制开发、微信托管、微网站、微商城、微营销" name="Keywords">
    <meta content="羽帮，国内最大的微信公众智能服务平台，羽帮八大微体系：微菜单、微官网、微会员、微活动、微商城、微推送、微服务、微统计，企业微营销必备。" name="Description">
    <meta name="viewport" content=" initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta name="description" content="刮刮卡">
    <title>刮刮卡</title>
    <link rel="stylesheet" type="text/css" href="css/activity_style.css" media="all" />
    <script type="text/javascript" src="js/zepto.js"></script>
    <script type="text/javascript" src="js/alert.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>
    <script src="js/wScratchPad.js"></script>
    <script type="text/javascript">
        function loading(canvas, options) {
            this.canvas = canvas;
            if (options) {
                this.radius = options.radius || 12;
                this.circleLineWidth = options.circleLineWidth || 4;
                this.circleColor = options.circleColor || 'lightgray';
                this.moveArcColor = options.moveArcColor || 'gray';
            } else {
                this.radius = 12;
                this.circelLineWidth = 4;
                this.circleColor = 'lightgray';
                this.moveArcColor = 'gray';
            }
        }
        loading.prototype = {
            show: function () {
                var canvas = this.canvas;
                if (!canvas.getContext) return;
                if (canvas.__loading) return;
                canvas.__loading = this;
                var ctx = canvas.getContext('2d');
                var radius = this.radius;
                var me = this;
                var rotatorAngle = Math.PI * 1.5;
                var step = Math.PI / 6;
                canvas.loadingInterval = setInterval(function () {
                    ctx.clearRect(0, 0, canvas.width, canvas.height);
                    var lineWidth = me.circleLineWidth;
                    var center = { x: canvas.width / 2, y: canvas.height / 2 };

                    ctx.beginPath();
                    ctx.lineWidth = lineWidth;
                    ctx.strokeStyle = me.circleColor;
                    ctx.arc(center.x, center.y + 20, radius, 0, Math.PI * 2);
                    ctx.closePath();
                    ctx.stroke();
                    //在圆圈上面画小圆   
                    ctx.beginPath();
                    ctx.strokeStyle = me.moveArcColor;
                    ctx.arc(center.x, center.y + 20, radius, rotatorAngle, rotatorAngle + Math.PI * .45);
                    ctx.stroke();
                    rotatorAngle += step;

                }, 100);
            },
            hide: function () {
                var canvas = this.canvas;
                canvas.__loading = false;
                if (canvas.loadingInterval) {
                    window.clearInterval(canvas.loadingInterval);
                }
                var ctx = canvas.getContext('2d');
                if (ctx) ctx.clearRect(0, 0, canvas.width, canvas.height);
            }
        };
    </script>

</head>
<body data-role="page" class="activity-scratch-card-winning">
    <form id="form1" runat="server">


        <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidAwardId" runat="server" EnableViewState="false" Value="0" />
        <div class="main" >
            <div class="cover" id="jiangqu">
                <img src="images/activity-scratch-card-bannerbg.png">
                <div id="prize">
                    <asp:Literal ID="litPrize" runat="server" EnableViewState="false" Text="谢谢参与"></asp:Literal>
                </div>
                <div id="scratchpad"></div>
            </div>

            <div class="content">

                <div id="zjl" style="display: none" class="boxcontent boxwhite">
                    <div class="box">
                        <div class="title-red"><span>恭喜你中奖了</span></div>
                        <div class="Detail">
                            <p>你中了：<span class="red"><asp:Literal ID="litJiangPing" runat="server" EnableViewState="false"></asp:Literal></span></p>
                            <p>兑奖SN码：<span class="red" id="sncode"><asp:Literal ID="litSnCode" runat="server" EnableViewState="false"></asp:Literal></span></p>
                            <p class="red">
                                <asp:Literal ID="litContentInfo" runat="server" EnableViewState="false"></asp:Literal>
                            </p>
                            <p>
                                <input name="" class="px" id="tel" value="" type="text" autocomplete="off" placeholder="用户请输入您的手机号">
                            </p>
                            <asp:Literal ID="litPwd" runat="server" EnableViewState="false" Text=""></asp:Literal>
                           <%-- <p>
                                <input name="" class="px" id="parssword" type="password" value="" placeholder="商家输入兑奖密码">
                            </p>--%>
                            <p>
                                <input class="pxbtn" name="提 交" id="save-btn" type="button" value="用户提交">
                            </p>
                        </div>
                        
                    </div>

                </div>

                <div class="boxcontent boxwhite" id="result" style="display:none;">
                    <div class="box">
                        <div class="title-orange"><span>恭喜你中奖了</span></div>
                        <div class="Detail">
                           <p>你中了：<span class="red"><asp:Literal ID="litJp" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                           <p>兑奖sn码为：<span class="red"><asp:Literal ID="litSNM" runat="server" EnableViewState="false"></asp:Literal></span></p>
                           <p class="red">你已经兑奖成功，本SN码自定作废!</p>
                        </div>


                    </div>
                </div>

                <div class="boxcontent boxwhite">
                    <div class="box">
                        <div class="title-red"><span>奖项设置：</span></div>
                        <div class="Detail">
                            <asp:Literal ID="litJiangXing" runat="server" EnableViewState="false"></asp:Literal>

                        </div>
                    </div>
                </div>
                <div class="boxcontent boxwhite">
                    <div class="box">
                        <div class="title-red">活动说明：</div>
                        <div class="Detail">
                            <p class="red">
                                本次活动总共可以刮<asp:Literal ID="litTTTimes" runat="server" EnableViewState="false"></asp:Literal>
                                次,
                                你已经刮了
                                <asp:Literal ID="litRemainTimes" runat="server" EnableViewState="false"></asp:Literal>
                                次,机会如果没用完重新进入本页面可以再刮!
                               
                            </p>
                            <p>
                                <asp:Literal ID="litRemark" runat="server" EnableViewState="false"></asp:Literal>
                            </p>

                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>


        <script type="text/javascript">
            var wid = $.query.get("wid");
            var aid = $.query.get("aid");
            var thisurl = document.URL;
            var status = $("#hidStatus").val();
            var showInfo = $("#hidErrInfo").val();
            var openid = $.query.get("openid");
            var zjl = false;//没中奖为false中奖为true 

            if (status == "-1") {
                window.location.href = "end.aspx?openid=" + openid + "&wid=" + wid + "&aid=" + aid;
            }
            else if (status == "0") {
                alert(showInfo);

            }
            else if (status == "2") {
                zjl = true;
            }
            else if (status == "100")
            {
                $("#zjl").show();
                $("#jiangqu").hide();
            }
            else if (status == "110")
            {
                $("#result").show();
                $("#jiangqu").hide();

            }

            var num = 0;
            var goon = true;
            $(function () {

                var useragent = window.navigator.userAgent.toLowerCase();
                $("#scratchpad").wScratchPad({
                    width: 150,
                    height: 40,
                    color: "#a9a9a7",
                    scratchMove: function () {
                        num++;
                        if (zjl && num > 30 && goon) {
                            //$("#zjl").fadeIn();
                            goon = false;
                            $("#zjl").slideToggle(500);
                            //$("#outercont").slideUp(500)
                        }

                        if (useragent.indexOf("android 4") > 0) {
                            if ($("#scratchpad").css("color").indexOf("51") > 0) {
                                $("#scratchpad").css("color", "rgb(50,50,50)");
                            } else if ($("#scratchpad").css("color").indexOf("50") > 0) {
                                $("#scratchpad").css("color", "rgb(51,51,51)");
                            }
                        }

                    }
                });

            });

            $("#save-btn").bind("click",
            function () {


                var btn = $(this);
                var tel = $("#tel").val();
                var pwd = "";
                var hidAwardId = $("#hidAwardId").val();

                if ($("#parssword").length > 0 && $.trim($("#parssword").val()) == "") {
                    alert("请输入兑奖密码!");
                    return
                }
                if ($("#parssword").length > 0) {
                    pwd = $("#parssword").val();
                }


                if ($.trim(tel) == "") {
                    alert("请输入手机号!");
                    return
                }
                var rad = Math.random();

                var submitData = {
                    id: hidAwardId,
                    aid: aid,
                    pwd: pwd,
                    snumber: $("#sncode").text(),
                    tel: tel,
                    rad: rad,
                    openid: openid
                };
                $.post('ggkAct.ashx?myact=update', submitData,
                function (data) {
                    if (data.success == "1") {
                        alert("提交成功！");
                        $("#result").slideToggle(500);
                        $("#zjl").slideToggle(500);

                    } else {
                        alert(data.msg);
                    }
                },
                "json")
            });


            document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
                window.shareData = {
                    "imgUrl": thisurl,
                    "timeLineLink": thisurl + "&is_share=1",
                    "sendFriendLink": thisurl + "&is_share=1",
                    "weiboLink": thisurl + "&is_share=1",
                    "tTitle": "<%=ggkAction.actName%>",
                    "tContent": "<%=ggkAction.brief%>",
                    "fTitle": "<%=ggkAction.actName%>",
                    "fContent": "<%=ggkAction.brief%>",
                    "wContent": "<%=ggkAction.brief%>"
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
            }, false)
        </script>

    </form>
</body>
</html>
<%} %>
