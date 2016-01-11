<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatBuilder.Web.weixin.dzp.index" %>

<% if (ErrLevel < 100)
   {
       Response.Write(ErrorInfo);
   }
   else if (ErrLevel == 101)  
   {  //活动已结束，跳转到结束页面
%>
<script type="text/javascript">
    window.location.href = "end.aspx?wid="+<%=wid%>+"&aid="+<%=aid%>+"&openid="+<%=openid%>+";";
</script>
<%
   }
   else
   {  %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta name="description" content="微信">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>幸运大转盘抽奖</title>
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>
    <script src="../../scripts/jquery/alert.js" type="text/javascript"></script>
    <link href="css/activity-style2.css" rel="stylesheet" type="text/css">
    <style>
        .activity-lottery-winning
        {
            background: url(images/beijing.gif) repeat scroll 0 0 #7E65AB;
            background-size: 120px auto;
            overflow: hidden;
        }
    </style>
</head>
<body class="activity-lottery-winning">
    <form id="form1" runat="server">
        <div class="main">

            <asp:HiddenField ID="hidStatus" runat="server" Value="" EnableViewState="false" />
            <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
            <asp:HiddenField ID="hidAwardId" runat="server" EnableViewState="false" Value="0" />
            <div id="outercont">
                <div id="outer-cont">
                    <div id="outer">
                        <img src="images/zp<%=picIndex %>-.png">
                    </div>
                </div>
                <div id="inner-cont">
                    <div id="inner">
                        <img src="images/activity-lottery-2.png">
                    </div>
                </div>
            </div>
            <div class="content">
                <div class="boxcontent boxwhite" id="zjl" style="display: none">

                    <div class="box">
                        <div class="title-orange"><span>恭喜你中奖了</span></div>
                        <div class="Detail">

                            <p>你中了：<span class="red" id="prizetype"><asp:Literal ID="litzjlJP" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                            <p>兑奖SN码：<span class="red" id="sncode"><asp:Literal ID="litzjlSN" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                            <p class="red">
                                <asp:Literal ID="litContentInfo" runat="server" EnableViewState="false"></asp:Literal>
                            </p>
                            <p>
                                <input name="" class="px" id="tel" value="" type="text" placeholder="用户请输入您的手机号">
                            </p>

                            <asp:Literal ID="litPwd" runat="server" EnableViewState="false" Text=""></asp:Literal>
                            <p>
                                <input class="pxbtn" name="提 交" id="save-btn" type="button" value="用户提交">
                            </p>
                        </div>
                    </div>
                </div>
                <div class="boxcontent boxwhite" id="result" style="display: none;">
                    <div class="box">
                        <div class="title-orange"><span>恭喜你中奖了</span></div>
                        <div class="Detail">
                            <p>你中了：<span class="red" id="jiangping"><asp:Literal ID="litJp" runat="server" EnableViewState="false" Text=""></asp:Literal></span></p>
                            <p>兑奖sn码为：<span class="red" id="jpsn"><asp:Literal ID="litSNM" runat="server" EnableViewState="false"></asp:Literal></span></p>
                            <p class="red">你已经兑奖成功，本SN码自定作废!</p>
                        </div>


                    </div>
                </div>



                <div class="boxcontent boxwhite">
                    <div class="box">
                        <div class="title-red"><span>奖项设置：</span></div>

                        <div class="Detail">
                            <asp:Literal ID="litOtherTip" runat="server" EnableViewState="false"></asp:Literal>
                            <asp:Literal ID="litJiangXing" runat="server" EnableViewState="false"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="boxcontent boxwhite">
                    <div class="box">
                        <div class="title-red">活动说明：</div>
                        <div class="Detail">
                            <p class="red">
                                本次活动每天可以转
                            <asp:Literal ID="litdaysTimes" runat="server" EnableViewState="false"></asp:Literal>
                                次,总共可以转 
                            <asp:Literal ID="littotTimes" runat="server" EnableViewState="false"></asp:Literal>
                                次 你已经转了 <span id="zhuantimes">
                                    <asp:Literal ID="litHasUsedTimes" runat="server" EnableViewState="false"></asp:Literal></span> 次
                            </p>
                            <p>
                                <asp:Literal ID="litRemark" runat="server" EnableViewState="false"></asp:Literal>
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </div>


        <script type="text/javascript">
            var thisurl= document.URL;
            var wid = <%=wid%>;
            var aid =<%=aid%>;
            var status = $("#hidStatus").val();
            var showInfo = $("#hidErrInfo").val();
            var openid ="<%=openid%>";
            var jxname="";
            var jpname="";
            var cjtip="";
            var zhuantimes=parseInt( $("#zhuantimes").text());
             
            var zjl = false;//没中奖为false中奖为true 
            <% if (isZhJing)
               { %>
            $("#outercont").hide();
            $("#result").show();
               <%} %>
            if (status == "2") {
                $("#outercont").hide();

            }
            else if(status=="100")
            {
                $("#outercont").hide();
                $("#result").hide();
                $("#zjl").show();
            }


            $(function () {
                window.requestAnimFrame = (function () {
                    return window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || window.oRequestAnimationFrame || window.msRequestAnimationFrame ||
                    function (callback) {
                        window.setTimeout(callback, 1000 / 60)
                    }
                })();
                var totalDeg = 360 * 3 + 0;
                var steps = [];
               
                var lostDeg = [360];
                var prizeDeg = <%=shuzu%>;
                var prize, sncode;
                var count = 0;
                var now = 0;
                var a = 0.01;
                var outter, inner, timer, running = false;
                function countSteps() {
                    var t = Math.sqrt(2 * totalDeg / a);
                    var v = a * t;
                    for (var i = 0; i < t; i++) {
                        steps.push((2 * v * i - a * i * i) / 2)
                    }
                    steps.push(totalDeg)
                }
                function step() {
                    // alert('rotate(' + steps[now++] + 'deg)');
                    outter.style.webkitTransform = 'rotate(' + steps[now++] + 'deg)';
                    outter.style.MozTransform = 'rotate(' + steps[now++] + 'deg)';

                    if (now < steps.length) {
                        running = true;
                        requestAnimFrame(step)
                    } else {
                        running = false;
                        setTimeout(function () {
                            $("#zhuantimes").text(++zhuantimes);
                            if (zjl) {
                                $("#sncode").text(sncode);
                                $("#jpsn").text(sncode);
                                $("#jiangping").text(jxname+" "+jpname);
                                $("#prizetype").text(jxname+" "+jpname);
                                $("#zjl").slideToggle(500);
                                $("#outercont").slideUp(500)
                            }  
                            else
                            {
                                alert(cjtip);
                            }
                        },
                        200)
                    }
                }

                function start(deg) {

                    deg = deg || lostDeg[parseInt(lostDeg.length * Math.random())];
                    running = true;
                    clearInterval(timer);
                    totalDeg = 360 * 5 + deg;
                    steps = [];
                    now = 0;
                    countSteps();
                    requestAnimFrame(step)
                }
                window.start = start;
                outter = document.getElementById('outer');
                inner = document.getElementById('inner');
                i = 10;
                $("#inner").click(function () {
                    if (status == "2") {
                        alert(showInfo);
                    }
                    if (running) return;
                   
                    $.ajax({
                        url: "dzpAct.ashx",
                        dataType: "json",
                        data: {
                            openid: openid,
                            myact: "choujiang",
                            aid: aid,
                            wid:wid,
                            rad: Math.random()
                        },
                        beforeSend: function () {
                            running = true;
                            timer = setInterval(function () {
                                i += 5;
                              
                                outter.style.webkitTransform = 'rotate(' + i + 'deg)';
                                outter.style.MozTransform = 'rotate(' + i + 'deg)'
                            },
                            1)
                        },
                        success: function (data) {
                            if (data.error == "sys" ||data.error == "nostart" ) {
                                cjtip=data.content;
                                count = 100;
                                clearInterval(timer);
                                return
                            }
                            else if(data.error=="notimes")
                            {
                                cjtip=data.content;
                                start();
                            }
                            else if (data.error=="succ") {
                                
                                zjl=true;
                                cjtip=data.content;
                                prize = data.sortid;
                                sncode = data.sn;
                                jpname=data.jpname;
                                jxname=data.jxname;
                                $("#hidAwardId").val(data.uid);
                                start(prizeDeg[data.sortid - 1])
                            }
                            
                            else {
                                cjtip=data.content;
                                start()
                            }
                            running = false;
                            count++
                        },
                        error: function () {

                            prize = null;
                            start();
                            running = false;
                            count++
                        },
                        timeout: 1000
                    })
                })
            });

            $("#save-btn").bind("click",
            function () {
                var btn = $(this);
              
                var tel = $("#tel").val();
                var pwd = "";
                var hidAwardId = $("#hidAwardId").val();
                if ($("#parssword").length>0 &&  $.trim($("#parssword").val()) == "") {
                    alert("请输入兑奖密码!");
                    return
                }

                if ($.trim(tel) == "") {
                    alert("请输入手机号!");
                    return
                }
                if($("#parssword").length>0){
                    pwd= $("#parssword").val();
                }
                var rad = Math.random();
                 
                var submitData = {
                    id: hidAwardId,
                    aid: aid,
                    pwd: pwd,
                    snumber:$("#sncode").text(),
                    tel: tel,
                    rad: rad,
                    openid:openid
                };
                 
                $.post('dzpAct.ashx?myact=update', submitData,
               function (data) {
                   if (data.success == "1") {
                       alert("提交成功！");
                       $("#result").slideToggle(500);
                       $("#zjl").slideToggle(500);
                       $("#outercont").slideUp(500);

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
                    "imgUrl": "",
                    "timeLineLink":  thisurl + "&is_share=1",
                    "sendFriendLink":  thisurl + "&is_share=1",
                    "weiboLink":  thisurl + "&is_share=1",
                    "tTitle": "<%=dzpAction.actName%>",
                    "tContent": "请关注后，再来抽奖。<%=dzpAction.brief%>",
                    "fTitle": "请关注后，再来抽奖。<%=dzpAction.actName%>",
                    "fContent": "请关注后，再来抽奖。<%=dzpAction.brief%>",
                    "wContent": "请关注后，再来抽奖。<%=dzpAction.brief%>"
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
<% }%>