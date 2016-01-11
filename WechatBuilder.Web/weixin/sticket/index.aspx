<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatBuilder.Web.weixin.sticket.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta name="description" content="微信">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>优惠券活动开始啦 恭喜你中奖了</title>
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery/alert.js" type="text/javascript"></script>
     <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>
    <link href="css/activity-style.css" rel="stylesheet" type="text/css">
</head>
<body class="activity-coupon-winning">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidAwardId" runat="server" EnableViewState="false" Value="0" />

        <div class="main">
            <div class="banner">
                <a href="javascript:;">
                    <asp:Image ID="zjpic" runat="server" ImageUrl="images/banner.jpg" EnableViewState="false" />
                </a>
            </div>
            <div class="content" style="margin-top: -5px">
                <div class="boxcontent boxwhite" id="zjl" style="display: none;">
                    <div class="box">
                        <div class="title-red"><span>中奖了</span></div>
                        <div class="Detail">
                            <p>你抢到：<span class="red"><asp:Literal ID="litJiangPing" runat="server" EnableViewState="false"></asp:Literal></span></p>

                            <p>SN码：<span class="red" id="sncode"><asp:Literal ID="litSn" runat="server" EnableViewState="false"></asp:Literal></span></p>
                            <p class="red">
                                <asp:Literal ID="litsuccTip" runat="server" EnableViewState="false"></asp:Literal>
                            </p>

                            <p>
                                <input name="" class="px" id="tel" value="" type="text" placeholder="用户请输入您的手机号">
                            </p>


                            <p>
                                <input name="" class="px" id="parssword" type="password" value="" placeholder="商家输入兑奖密码">
                            </p>

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
                        <div class="title-red"><span>优惠券设置：</span></div>
                        <div class="Detail">
                            <asp:Literal ID="litJiangXing" runat="server" EnableViewState="false"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="boxcontent boxwhite">
                    <div class="box">
                        <div class="title-red">使用说明：</div>
                        <div class="Detail">
                            <p>
                                <asp:Literal ID="litusedRemark" runat="server" EnableViewState="false"></asp:Literal>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="boxcontent boxwhite">
                    <div class="box">
                        <div class="title-red">活动说明：</div>
                        <div class="Detail">
                            <p>
                                <asp:Literal ID="litaContent" runat="server" EnableViewState="false"></asp:Literal>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <script type="text/javascript">
            var wid = $.query.get("wid");
            var aid = $.query.get("aid");
            var thisurl = document.URL;
          
            var status = $("#hidStatus").val();
            var showInfo = $("#hidErrInfo").val();
            var openid = $.query.get("openid");

            if (status == "-2")
            {
                alert(showInfo);
            }
            else if (status == "-1")
            {
                alert(showInfo);
                setTimeout(function () {
                   
                    window.location.href = "end.aspx?wid=" + wid + "&aid="+aid+"&openid=" + openid;
                }, 2000);

            }
            else if (status == "2")
            {
                $("#zjl").show();
            }
            else if (status == "3")
            {
                $("#result").show();
                $("#zjl").hide();
            }

            $("#save-btn").bind("click",
           function () {


               var btn = $(this);
               var tel = $("#tel").val();
               var pwd = $("#parssword").val();
               var hidAwardId = $("#hidAwardId").val();

               if ($.trim(pwd) == "") {
                   alert("请输入兑奖密码!");
                   return
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
               $.post('sttAct.ashx?myact=update', submitData,
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


        </script>

        <script type="text/javascript">
            document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
                window.shareData = {
                    "imgUrl": thisurl,
                    "timeLineLink": thisurl+"&is_share=1",
                    "sendFriendLink": thisurl + "&is_share=1",
                    "weiboLink": thisurl + "&is_share=1",
                    "tTitle": "<%=stitle%>",
                    "tContent": "<%=sbrief%>",
                    "fTitle": "<%=stitle%>",
                    "fContent": "<%=sbrief%>",
                    "wContent": "<%=sbrief%>"
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
