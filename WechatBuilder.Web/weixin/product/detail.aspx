<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="WechatBuilder.Web.weixin.product.detail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title></title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta charset="utf-8">
    <link href="css/news3.css" rel="stylesheet" type="text/css" />
    <link href="css/menu-2.css" rel="stylesheet" type="text/css" />
    <script src="../../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/jquery/alert.js"></script>
    <script src="../../scripts/jquery/jquery.query.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(function () {
            var openid = $.query.get("openid");
            var aid = $.query.get("id");
            var retdef = $.query.get("returnPage");
            var tid = $.query.get("tid");
            var wid = $.query.get("wid");
            var pid = $.query.get("pid");
            $.get("api.ashx?aid=" + aid + "&openid=" + openid + "&act=init&wid=" + wid,
               { Action: "get" }, function (data, textStatus) {
                   if (data.ret == "err") {
                       //已经评价过了
                       $("#pingjia_div").html("<p>您已经评价过了，评价内容：" + data.content + "</p>");
                       $("#mess_share").hide();
                   }
                   else {

                   }

               });

            $("#pingjia").click(function () {

                var pjRet = $('input:radio[name="pingjia"]:checked').next().text();


                $.get("api.ashx?aid=" + aid + "&pjret=" + pjRet + "&openid=" + openid + "&act=pingjia",
                 { Action: "get" }, function (data, textStatus) {
                     if (data.ret == "ok") {
                         alert("谢谢评价！");
                         setTimeout(function () {
                             window.location.reload();
                         }, 2000);
                     }
                     else {
                         // alert("绑定失败！请重新填写！");
                     }

                 });


            });

            if (retdef == null || retdef == "") {
                $("#redefault").attr("href", "index.aspx?tid=" + tid + "&wid=" + wid + "&openid=" + openid + "?wxref=mp.weixin.qq.com");
            }
            else {

                $("#redefault").attr("href", "all.aspx?wid=" + wid + "&pid=" + pid + "wxref=mp.weixin.qq.com" + "&openid=" + openid);
            }

        });

        function dourl(url) {

            window.location.href = url + "?openid=" + openid + "&tid=" + tid;
        }
        function refresh() {
            window.location.href = window.location.href;
        }

    </script>


    <style type="text/css">
        .olditem img {
            width: 100%;
        }
    </style>

</head>
<body id="news">
    <form id="form1" runat="server">
        <div class="Listpage" style="display: none;">

            <div class="page-bizinfo">

                <div class="header" style="position: relative;">
                    <h1 id="activity-name">
                        <asp:Literal ID="litTheme" runat="server" EnableViewState="false"></asp:Literal>
                    </h1>
                    <span id="post-date">
                        <asp:Literal ID="litCreateDate" runat="server" EnableViewState="false"></asp:Literal>
                    </span>
                </div>
                <div class="showpic">
                    <asp:Image ID="imgPic" runat="server" EnableViewState="false" />
                </div>
            </div>


        </div>

        <div class="list">

            <div id="oldlist">
                <ul>
                    <asp:Literal ID="litDetail" runat="server" EnableViewState="false"></asp:Literal>
                </ul>

            </div>
        </div>
        <div class="div_content_lp">
            <asp:Literal ID="litContent" runat="server" EnableViewState="false"></asp:Literal>

        </div>


        <div class="clr" style="height: 30px;"></div>

        <!--_bottommenu-->
        <div id="sharemcover" onclick="document.getElementById('sharemcover').style.display='';" style="display: none">
            <img src="/templatesstore/images/MgnnofmleM.png">
        </div>
        <script type="text/javascript" src="/templatesstore/js/bottommenu.js"></script>
        <div class="top_bar" style="-webkit-transform: translate3d(0,0,0)">
            <nav>
                <ul id="top_menu" class="top_menu">
                     <asp:Literal ID="litdaohang" runat="server" EnableViewState="false"></asp:Literal>
                </ul>
            </nav>
        </div>
        <div id="plug-wrap" onclick="closeall()" style="display: none;"></div>
        <link href="/templatesstore/css/bottommenu.css" rel="stylesheet" type="text/css" />


        <!--/_bottommenu-->
    </form>
</body>
</html>
