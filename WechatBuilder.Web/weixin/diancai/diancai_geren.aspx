<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="diancai_geren.aspx.cs" Inherits="WechatBuilder.Web.weixin.diancai.diancai_geren" %>

<html >
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title><%=hotelName %></title>
    <link href="css/diancai.css?20131223" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <style>
</style>
</head>

<body class="mode_webapp">
    <div class="menu_header">
        <div class="menu_topbar">
            <strong class="head-title">修改个人资料</strong>
            <span class="head_btn_left"><a href="javascript:history.go(-1);"><span>返回</span></a><b></b></span>
            <a class="head_btn_right" href="caidan_shangjia.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>">
                <span><i class="menu_header_home"></i></span><b></b>
            </a>
        </div>
    </div>



    <form class="form" method="post" action="" enctype="multipart/form-data">
        <input type="hidden" name="formhash" id="formhash" value="52ebc03e" />
        <input type="hidden" name="insetmb" id="insetmb" value="1" />
        <div class="contact-info" style="margin-top: 10px;">
            <ul>
                <li class="title">个人信息</li>
                <li>
                    <table style="padding: 0; margin: 0; width: 100%;">
                        <tbody>
                            <tr>
                                <td width="80px">
                                    <label for="wxname" class="ui-input-text">微信昵称：</label></td>
                                <td>
                                    <div class="ui-input-text">
                                        <input type="text" id="wxname" name="wxname" value="" placeholder="如：亲亲小猪" class="ui-input-text"></div>
                                </td>
                            </tr>

                            <tr>
                                <td width="80px">
                                    <label for="username" class="ui-input-text">姓名：</label></td>
                                <td>
                                    <div class="ui-input-text">
                                        <input type="text" id="username" name="username" value="" placeholder="如：张先生、王小姐" class="ui-input-text"></div>
                                </td>
                            </tr>
                            <tr id="nameinfo-layout" style="display: none;">
                                <td width="80px"></td>
                                <td colspan="2" id="nameinfo" class="cart-editalertinfo"></td>
                            </tr>

                            <tr>
                                <td width="80px">
                                    <label for="phone" class="ui-input-text">电话：</label></td>
                                <td>
                                    <div class="ui-input-text">
                                        <input type="tel" id="phone" name="phone" value="" placeholder="如：18200000000" class="ui-input-text"></div>
                                </td>
                            </tr>
                            <tr id="phoneinfo-layout" style="display: none;">
                                <td width="80px"></td>
                                <td colspan="2" id="phoneinfo" class="cart-editalertinfo"></td>
                            </tr>

                            <tr>
                                <td width="80px">
                                    <label for="address" class="ui-input-text">地址：</label></td>
                                <td>
                                    <textarea id="address" name="address" placeholder="如：XX小区5号楼318" class="ui-input-text"></textarea>
                                </td>
                            </tr>
                            <tr id="addressinfo-layout">
                                <td width="80px"></td>
                                <td colspan="2" id="addressinfo" class="cart-editalertinfo"></td>
                            </tr>
                        </tbody>
                    </table>
                </li>
            </ul>

        </div>



        <div class="footReturn" style="margin-bottom: 80px;">
            <input type="button" id="showcard" class="submit" value="保存" style="width: 100%">
            <div class="window" id="windowcenter">
                <div id="title" class="wtitle">操作提示<span class="close" id="alertclose"></span></div>
                <div class="content">
                    <div id="txt"></div>
                </div>
            </div>
        </div>

    </form>

    <div class="footermenu">
        <ul>
            <li>
                <a href="caidan_guanyu.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>&id=<%=id %>">
                    <img src="images/xxyX63YryG.png">
                    <p>关于</p>
                </a>
            </li>
            <li>
                <a  href="index.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>&id=<%=id %>">
                    <img src="images/Lngjm86JQq.png">
                    <p>点单外卖</p>
                </a>
            </li>
            <li>
                <a href="diancai_shoppingCart.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>&id=<%=id %>">
                    <span class="num" id="cartN2">0</span>
                    <img src="images/2yFKO6TwKI.png">
                    <p>购物车</p>
                </a>
            </li>
            <li>
                <a href="diancai_oder.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>&id=<%=id %>">
                    <img src="images/s22KaR0Wtc.png">
                    <p>订单</p>
                </a>
            </li>
            <li>
                <a class="active" href="diancai_geren.aspx?aid=<%=aid %>&shopid=<%=shopid %>&openid=<%=openid %>&id=<%=id %>">
                    <img src="images/J0uZbXQWvJ.png">
                    <p>我的</p>
                </a>
            </li>
        </ul>
    </div>


    <script type="text/javascript">


        var oLay = document.getElementById("overlay");
        $(document).ready(function () {


            $("#showcard").click(function () {

                var wxname = $("#wxname").val();
                var username = $("#username").val();
                var phone = $("#phone").val();
                var address = $("#address").val();


                var submitData = {
                    wxname: wxname,
                    username: username,
                    phone: phone,
                    address:address,
                    myact: "addmember"
                };
                $.post('diancai_login.ashx?openid=<%=openid%>&shopid=<%=shopid%>', submitData,
                           function (data) {

                               if (data.ret == "ok") {
                                   alert(data.content);                             
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
            setTimeout('$("#windowcenter").slideUp(500)', 4000);
        }
    </script>

    <script type="text/javascript">
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            WeixinJSBridge.call('hideToolbar');
        });
    </script>
</body>
</html>
