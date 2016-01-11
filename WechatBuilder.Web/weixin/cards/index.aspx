<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatBuilder.Web.weixin.cards.index" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title><%=title %></title>
    <link href="css/heka1.css?201312211656" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="js/jquery.min.js"></script>

</head>
<body>
    <div id="sharemcover" onclick="document.getElementById('sharemcover').style.display='';" style="display: none">
        <img src="images/MgnnofmleM.png">
    </div>
    <div class="hot">
        <p>点击文字可直接编辑，按底部按钮发送</p>
    </div>
    <div class="cardWrap">
        <script>

            window.addEventListener("DOMContentLoaded", function () {
                playbox.init("playbox");
            }, true);
        </script>
        <style>
            .btn_music {
                display: inline-block;
                width: 35px;
                height: 35px;
                background: url('images/play.png') no-repeat center center;
                background-size: 100% auto;
                position: absolute;
                z-index: 100;
                left: 15px;
                top: 30px;
            }

                .btn_music.on {
                    background-image: url("images/stop.png");
                }
        </style>

        <script type="text/javascript" src="js/audio.js"></script>


        <span id="playbox" class="btn_music" onclick="playbox.init(this).play();">
            <audio autoplay="autoplay" src="<%=music %>" loop id="audio"></audio>
        </span>

        <input type="hidden" id="hkid" runat="server" value="" />
        <input type="hidden" id="backimage" runat="server" value="" />

        <img class="cardbg" src="<%=imageback %>" id="imageback">
        <div class="messageBox">
            <div class="user">
                <div class="message"><%=characters %></div>

                <div class="name"><%=name %></div>
                <div class="time"><%=createDate%></div>
            </div>
            <div class="dh" id="dh" style="display: none">
                <select class="selectstyle fl" id="bjdh" onchange="doit()" name="bjdh">
                    <option value="0">请选择动画</option>
                    <option value="1">下落的枫叶</option>
                    <option value="2">飘雪</option>
                    <option value="4">飘玫瑰</option>
                    <option style="display: none;" value="5">驯鹿</option>
                    <option value="7">金元宝</option>

                </select>

            </div>
            <div class="sendBtn-box"><a class="sendBtn"   id="fengxiangbtn"><%=buttonCharacter %><span>(<%=zfCount %>)</span></a> </div>
            <div class="copyright"><%=copyRight %></div>
        </div>

    </div>


    <script type="text/javascript">


        function doit() {

            location.href = "http://" + window.location.host + "/weixin/cards/index.aspx?aid=<%=id%>&dh=" + $("#bjdh").val() + "&openid=<%=openid%>&wid=<%=wid%>";
        }


        function changeText(cont1, cont2, speed) {
            var Otext = cont1.text();
            var Ocontent = Otext.split("");
            var i = 0;
            function show() {
                if (i < Ocontent.length) {
                    cont2.append(Ocontent[i]);
                    i = i + 1;
                }

            };
            var Otimer = setInterval(show, speed);
        }

        function zfj1() {

            var submitData = {
                id: <%=id%>,
                openid: "<%=openid%>",
                myact: "zf"
            };

            $.post("fengxang.ashx", submitData,
           function (data) {

           },
           "json")

        }


        $(document).ready(function () {

            $("#fengxiangbtn").click(function () {

                $("#sharemcover").show();

                zfj1();
            });


            $(".name").click(function () {

                $(".dh").show();
                if ($(this).find(".sort_input").attr("type") == "text") { return false; }
                var name = $.trim($(this).html());
                var m = $.trim($(this).text());
                $(this).html("<input type=text value=\"" + name + "\" class=\"sort_input\">");
                $(this).find(".sort_input").focus();
                $(this).find(".sort_input").bind("blur", function () {
                    var n = $.trim($(this).val());
                    if (n != m && n != "") {
                        //window.location = "sort.php?val="+encodeURIComponent(n);
                        //发送信息
                        $(this).parent().html(n);
                    } else {
                        $(this).parent().html(name);
                    }
                });
            });
            $(".message").click(function () {

                $(".dh").show();
                if ($(this).find(".sort_textarea").attr("name") == "textarea") { return false; }
                var message = $.trim($(this).html());
                var mm = $.trim($(this).text());
                $(this).html("<textarea name=\"textarea\" class=\"sort_textarea\">" + message + "</textarea>");
                $(this).find(".sort_textarea").focus();
                //$(this).find(".sort_textarea").select() ;
                $(this).find(".sort_textarea").bind("blur", function () {

                    var nn = $.trim($(this).val());
                    if (nn != mm && nn != "") {
                        //window.location = "sort.php?val="+encodeURIComponent(n);
                        //发送信息
                        $(this).parent().html(nn);
                    } else {
                        $(this).parent().html(message);
                    }
                });
            });
        });


        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            //背景图片
            var url = "http://" + window.location.host + $("#backimage").val();
            // 发送给好友
            WeixinJSBridge.on('menu:share:appmessage', function (argv) {
                WeixinJSBridge.invoke('sendAppMessage', {
                    "img_url": url,
                    "img_width": "640",
                    "img_height": "640",
                    "link": "http://" + window.location.host + "/weixin/cards/index.aspx?aid=<%=id%>&wid=<%=wid%>&dh=" + $("#bjdh").val() + "&name=" + encodeURIComponent($.trim($(".name").html())) + "&characters=" + encodeURIComponent($.trim($(".message").html())) + "&from=app",
                    "desc": $(".message").html(),
                    "title": "<%=title %>"
                }, function (res) {
                    var ret = zfj1();
                    var result = syncEvent(ret);
                    _report('send_msg', res.err_msg);

                })
            });

            // 分享到朋友圈
            WeixinJSBridge.on('menu:share:timeline', function (argv) {
                WeixinJSBridge.invoke('shareTimeline', {
                    "img_url": url,
                    "img_width": "640",
                    "img_height": "640",
                    "link": "http://" + window.location.host + "/weixin/cards/index.aspx?aid=<%=id%>&wid=<%=wid%>&dh=" + $("#bjdh").val() + "&name=" + encodeURIComponent($.trim($(".name").html())) + "&characters=" + encodeURIComponent($.trim($(".message").html())) + "&from=app",
                "desc": $(".message").html(),
                "title": "<%=title %>"
            }, function (res) {

                var ret = zfj1();
                var result = syncEvent(ret);
                _report('timeline', res.err_msg);



            });
        });

            // 分享到微博
            WeixinJSBridge.on('menu:share:weibo', function (argv) {
                WeixinJSBridge.invoke('shareWeibo', {
                    "content": $(".message").html(),
                    "url": "http://" + window.location.host + "/weixin/cards/index.aspx?aid=<%=id%>&wid=<%=wid%>&dh=" + $("#bjdh").val() + "&name=" + encodeURIComponent($.trim($(".name").html())) + "&characters=" + encodeURIComponent($.trim($(".message").html())) + "&from=app"
                }, function (res) {
                    var ret = zfj1();
                    var result = syncEvent(ret);
                _report('weibo', res.err_msg);
            });
        });
        }, false)
    </script>

    <!--{if $dhid}-->
    <div id="leafContainer"></div>

    <style>
        #leafContainer {
            position: fixed;
            z-index: 2;
            width: 100%;
            height: 690px;
            top: 0;
            overflow: hidden;
        }

            #leafContainer > div {
                position: absolute;
                max-width: 100px;
                max-height: 100px;
                -webkit-animation-iteration-count: infinite, infinite;
                -webkit-animation-direction: normal, normal;
                -webkit-animation-timing-function: linear, ease-in;
            }

                #leafContainer > div > img {
                    position: absolute;
                    width: 100%;
                    -webkit-animation-iteration-count: infinite;
                    -webkit-animation-direction: alternate;
                    -webkit-animation-timing-function: ease-in-out;
                    -webkit-transform-origin: 50% -100%;
                }

        @-webkit-keyframes fade {

            0% {
                opacity: 1;
            }

            95% {
                opacity: 1;
            }

            100% {
                opacity: 0;
            }
        }

        @-webkit-keyframes drop {
            0% {
                -webkit-transform: translate(0px, -50px);
            }

            100% {
                -webkit-transform: translate(0px, 650px);
            }
        }

        @-webkit-keyframes clockwiseSpin {
            0% {
                -webkit-transform: rotate(-50deg);
            }

            100% {
                -webkit-transform: rotate(50deg);
            }
        }

        @-webkit-keyframes counterclockwiseSpinAndFlip {

            0% {
                -webkit-transform: scale(-1, 1) rotate(50deg);
            }

            100% {
                -webkit-transform: scale(-1, 1) rotate(-50deg);
            }
        }
    </style>
    <script src="js/bjdh<%=dhId %>.js" type="text/javascript"></script>

    <!--{/if}-->
    <script type="text/javascript">
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            WeixinJSBridge.call('hideToolbar');
        });


    </script>
</body>
</html>
