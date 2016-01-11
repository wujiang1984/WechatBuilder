<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="diancai_Login.aspx.cs" Inherits="WechatBuilder.Web.weixin.diancai.diancai_Login" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

    <title>后台管理</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <style type="text/css">
        body, article, section, h1, h2, hgroup, p, a, ul, li, em, div, small, span, footer, canvas, figure, figcaption, input {
            margin: 0;
            padding: 0;
        }

        a {
            color: #333;
            cursor: pointer;
            text-decoration: none;
        }

        ul, li {
            list-style-type: none;
        }

        .clr {
            clear: both;
        }

        body {
            font-family: Microsoft YaHei,Helvitica,Verdana,Tohoma,Arial,san-serif;
            margin: 0 auto;
            padding: 0;
            color: #666666;
            background: url(images/A3pvbcomeF.jpg) no-repeat #fff;
            background-size: 100% auto;
        }

        .cardcenter {
            position: fixed;
            width: 100%;
            bottom: 0;
            z-index: 2;
        }

        .cardexplain {
            margin: 0;
            padding: 10px;
        }

        .touming {
            position: fixed;
            width: 100%;
            height: 100%;
            top: 30%;
            bottom: 0;
            z-index: 1;
            background: -webkit-gradient(linear, 0 0, 0 100%, from(rgba(255,255,255,0)), to(rgba(255,255,255,1)), color-stop(10%, rgba(255, 255, 255, 0.6)), color-stop(50%, rgba(255,255,255,1)));
        }

        .footReturn {
            display: block;
            margin: 11px auto;
            padding: 0;
            position: relative;
        }

            .footReturn h2 {
                margin: 20px 0 20px 0;
                font-weight: normal;
                font-size: 24px;
                text-align: center;
                color: #333;
            }

        .copyright {
            margin: 15px 0 0px;
            text-align: center;
            font-size: 12px;
            color: #666;
            display: block;
        }

            .copyright a {
                color: #666;
            }

        .px {
            margin: 0.5em 0;
            position: relative;
            background-color: #FFFFFF;
            border-radius: 5px;
            border: 1px solid #C6C6C6;
            color: #333333;
            text-shadow: 0 1px 0 #FFFFFF;
            display: block;
            width: 100%;
            padding: 10px 10px;
            font-size: 16px;
            margin: 0 auto;
            font-family: Arial, Helvetica, sans-serif;
        }

            .px:hover {
                border: 1px solid #ff6501;
            }

            .px:focus {
                border: 1px solid #ff6501;
                box-shadow: 0 0 5px #ff6501;
            }

        .err {
            margin: 0.5em 0;
            position: relative;
            background-color: #FFFFFF;
            border-radius: 5px;
            border: 1px solid #ff6501;
            color: #ff6501;
            text-shadow: 0 1px 0 #FFFFFF;
            display: block;
            width: 100%;
            padding: 10px 10px;
            font-size: 16px;
            margin: 0 auto;
            font-family: Arial, Helvetica, sans-serif;
        }

        .px[type="text"] {
            width: 100%;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .px[type="password"] {
            width: 100%;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .px[type="button"] {
            width: 100%;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .pxbtn[type="button"] {
            width: 100%;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .submit[type="button"] {
            width: 100%;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .del[type="button"] {
            width: 100%;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .pxtextarea[type="textarea"] {
            width: 100%;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .pxtextarea {
            margin: 0.5em 0;
            position: relative;
            background-color: #FFFFFF;
            border-radius: 5px;
            border: 1px solid #C6C6C6;
            color: #333333;
            text-shadow: 0 1px 0 #FFFFFF;
            display: block;
            width: 100%;
            padding: 10px 10px;
            font-size: 16px;
            margin: 0 auto;
        }

        .px::-moz-placeholder, textarea::-moz-placeholder {
            color: #999;
        }

        .pxerror::-moz-placeholder {
            color: #ff6501;
        }

        input[readonly]:focus, textarea[readonly]:focus, input.disabled {
            background: #f5f5f5;
            border-color: #ddd;
            -webkit-box-shadow: none;
            -moz-box-shadow: none;
            box-shadow: none;
            color: #555555;
        }

        .px[readonly="readonly"] {
            background: #F9F9F9;
            color: #555555;
            border: 1px solid #C6C6C6;
            -webkit-box-shadow: none;
            -moz-box-shadow: none;
            box-shadow: none;
        }

        .submit {
            background-color: #c32d32;
            padding: 10px 20px;
            font-size: 16px;
            text-decoration: none;
            border: 1px solid #9C1402;
            background: -webkit-gradient(linear,left top,left bottom,from(#fe444a),to(#c32d32));
            box-shadow: 0 1px 0 #FF9D9D inset, 0 1px 2px rgba(0, 0, 0, 0.5);
            border-radius: 5px;
            color: #ffffff;
            display: block;
            text-align: center;
            text-shadow: 0 1px rgba(0, 0, 0, 0.2);
        }

            .submit:active {
                padding-bottom: 9px;
                padding-left: 20px;
                padding-right: 20px;
                padding-top: 11px;
                top: 0px;
                background: -webkit-gradient(linear,left top,left bottom,from(#c32d32),to(#fe444a));
                box-shadow: 0 1px 0 #FF9D9D inset, 0 1px 2px rgba(0, 0, 0, 0.5);
            }
        /*window*/
        .window {
            width: 267px;
            position: absolute;
            display: none;
            margin: 0px auto 0 -136px;
            padding: 2px;
            bottom: 60px;
            left: 50%;
            border-radius: 0.6em;
            -webkit-border-radius: 0.6em;
            -moz-border-radius: 0.6em;
            background-color: #f1f1f1;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
            font: 14px/1.5 Microsoft YaHei, Helvitica, Verdana, Arial, san-serif;
            z-index: 10;
        }

            .window .wtitle {
                background-color: #585858;
                line-height: 26px;
                padding: 5px 5px 5px 10px;
                color: #ffffff;
                font-size: 16px;
                border-radius: 0.5em 0.5em 0 0;
                -webkit-border-radius: 0.5em 0.5em 0 0;
                -moz-border-radius: 0.5em 0.5em 0 0;
            }

            .window .content {
                /*min-height:100px;*/
                overflow: auto;
                padding: 10px;
                color: #222222;
                text-shadow: 0 1px 0 #FFFFFF;
            }

            .window #txt {
                min-height: 30px;
                font-size: 14px;
                line-height: 20px;
            }

            .window .content p {
                margin: 10px 0 0 0;
            }

            .window .wtitle .close {
                float: right;
                background-image: url("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABoAAAAaCAYAAACpSkzOAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACTSURBVEhL7dNtCoAgDAZgb60nsGN1tPLVCVNHmg76kQ8E1mwv+GG27cestQ4PvTZ69SFocBGpWa8+zHt/Up+IN+MhgLlUmnIE1CpBQB2COZibfpnXhHFaIZkYph0SOeeK/QJ8o7KOek84fkCWSBtfL+Ny2MPpCkPFMH6PWEhWhKncIyEk69VfiUuVhqJefds+YcwNbEwxGqGIFWYAAAAASUVORK5CYII=");
                width: 26px;
                height: 26px;
                display: block;
            }

        #overlay {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: #000000;
            opacity: 0.5;
            filter: alpha(opacity=0);
            display: none;
            z-index: 9;
        }
    </style>
</head>

<body id="card">
    <div class="touming"></div>
    <div class="cardcenter">
        <div class="cardexplain">
            <ul>
                <div class="footReturn" id="footReturn">

                    <div id="zxcz">
                        <p>
                            <input name="" type="text" class="px" id="username" value="" placeholder="请输入用户名">
                        </p>
                        <p style="margin: 10px 0 0 0">
                            <input name="" type="password" class="px" id="parssword" value="" placeholder="请输入密码">
                            <input name="url" id="url" type="hidden" value="">
                        </p>
                        <p style="margin: 10px 0"><a id="showcard" class="submit" href="javascript:void(0)">登 录</a></p>
                        <p style="margin: 10px 0"><a class="copyright" href="#"><%=shopname %></a></p>
                    </div>
                </div>
            </ul>
        </div>

        <div class="window" id="windowcenter">
            <div id="title" class="wtitle">操作提示<span class="close" id="alertclose"></span></div>
            <div class="content">
                <div id="txt"></div>
            </div>
        </div>

    </div>
    <script type="text/javascript">


        var oLay = document.getElementById("overlay");
        $(document).ready(function () {


            $("#showcard").click(function () {

                var parssword = document.getElementById('parssword').value;
                var username = document.getElementById('username').value;
                var url = document.getElementById('url').value;
                var submitData = {
                    parssword: parssword,
                    username: username,
                    myact: "login"
                };
                $.post('diancai_login.ashx', submitData,
                 function (data) {
                     if (data.ret == "ok") {
                         alert(data.content);

                         window.location.href = "caidan_manage_index.aspx?shopid=<%=shopid%>";

                     } else { alert(data.content); }
                 },
                "json");


                oLay.style.display = "block";
            });
        });

        $("#windowclosebutton").click(function () {
            $("#windowcenter").slideUp(500);
            oLay.style.display = "none";

        });
        $("#alertclose").click(function () {
            $("#windowcenter").slideUp(500);
            oLay.style.display = "none";

        });

        function alert(title) {

            $("#windowcenter").slideToggle("slow");
            $("#txt").html(title);

        }

    </script>


</body>
</html>
