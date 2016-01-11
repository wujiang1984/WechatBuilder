<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userinfo.aspx.cs" Inherits="WechatBuilder.Web.weixin.ucard.userinfo" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>会员卡-用户资料</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/fans.css" rel="stylesheet" type="text/css">
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>
    <style>
        #ui-header .fixed {
            background: -webkit-gradient(linear,left top,left bottom,from(#DF0300),to(#9a0000));
            box-shadow: 0 1px 5px rgba(0, 0, 0, 0.4);
            border-bottom: 1px solid #750200;
        }

        .ui-title {
            text-shadow: 0 1px rgba(0, 0, 0, 0.2);
            color: #FFF;
        }

        .ui-btn-right_home {
            background: url(images/themes/1/home2.png) no-repeat center center;
            background-size: 24px auto;
        }

        #popmenu:after {
            border-color: #ffffff transparent;
        }

        .ui-btn-left_pre {
            background: url(images/themes/1/pre2.png) no-repeat center center;
            background-size: 24px auto;
        }

        .ui-btn-right {
            background: url(images/themes/1/Refresh2.png) no-repeat center center;
            background-size: 28px auto;
        }

        .themeStyle {
            background-color: #E82D10 !important;
        }
    </style>
</head>
<body id="fans">
    <form id="form1" runat="server">
         <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
        <div class="qiandaobanner">
            <a href="javascript:history.go(-1);">
                <asp:Image ID="imgTopPic" runat="server" ImageUrl="images/themes/1/user.jpg" EnableViewState="false"/>
            </a> 
        </div>
        <div class="cardexplain">
            <ul class="round">
                <li class="title mb"><span class="none">会员资料</span></li>
                <li class="nob">
                    <div class="beizhu">请认真填写！</div>
                </li>

                <li class="nob">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                        <tr>
                            <th>真实姓名</th>
                            <td>
                                <input name="truename" type="text" class="px" id="truename" value="<%=uName%>" placeholder="请输入您的真实姓名">
                                <input name="url" id="url" type="hidden" value=""></td>
                        </tr>
                    </table>
                </li>
                <li class="nob">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                        <tr>
                            <th>联系电话</th>
                            <td>
                                <input name="tel" class="px" id="tel" value="<%=tel%>" type="tel" placeholder="请输入您的电话"></td>
                        </tr>
                    </table>
                </li>


            </ul>
            <div class="footReturn">
                <a id="showcard" class="submit" href="javascript:void(0)">保 存</a>
                <div class="window" id="windowcenter">
                    <div id="title" class="wtitle">保存成功<span class="close" id="alertclose"></span></div>
                    <div class="content">
                        <div id="txt"></div>
                    </div>
                </div>
            </div>

            <script type="text/javascript">
                var oLay = document.getElementById("overlay");
                $(document).ready(function () {

                    $("#showcard").click(function () {

                        var rad = Math.random();
                        var submitData = {
                            sid: <%=sid%>,
                            openid:"<%=openid%>",
                            truename: $("#truename").val(),
                            tel: $("#tel").val(),
                            rad: rad
                        };
                        $.post('ucardprocess.ashx?myact=userreg', submitData,
                        function (data) {
                            if (data.ret == "succ") {
                                alert("保存成功！");
                                setTimeout("gourl()", 1500);
                               
                            } else {
                                alert("保存失败。");
                            }
                        },
                        "json")
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
                function gourl() {
                    window.location.href=location.href;
                }
                function alert(title) {
                    $("#windowcenter").slideToggle("slow");
                    $("#txt").html(title);
                    
                    setTimeout('$("#windowcenter").slideUp(500)', 4000);
                }



            </script>

        </div>
    </form>
</body>
</html>
