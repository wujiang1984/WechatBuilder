<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WechatBuilder.Web.weixin.ucard.index" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>XX公司会员卡</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/card.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        .window {
            width: 267px;
            position: absolute;
            display: none;
            margin: 0px auto 0 -136px;
            padding: 2px;
            top: 0;
            left: 50%;
            border-radius: 0.6em;
            -webkit-border-radius: 0.6em;
            -moz-border-radius: 0.6em;
            background-color: #f1f1f1;
            -webkit-box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
            -moz-box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
            -o-box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
            font: 14px/1.5 Microsoft YaHei, Helvitica, Verdana, Arial, san-serif;
            z-index: 9999;
            bottom: auto;
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
                background: linear-gradient(#FBFBFB, #EEEEEE) repeat scroll 0 0 #FFF9DF;
                color: #222222;
                text-shadow: 0 1px 0 #FFFFFF;
                border-radius: 0 0 0.6em 0.6em;
                -webkit-border-radius: 0 0 0.6em 0.6em;
                -moz-border-radius: 0 0 0.6em 0.6em;
            }

            .window #txt {
                min-height: 30px;
                font-size: 14px;
                line-height: 20px;
            }

            .window .content p {
                margin: 10px 0 0 0;
            }

            .window .txtbtn {
                color: #666666;
                font-weight: bold;
                text-shadow: 0 1px 0 #FFFFFF;
                display: block;
                width: 100%;
                text-overflow: ellipsis;
                white-space: nowrap;
                cursor: pointer;
                text-align: windowcenter;
                font-weight: bold;
                font-size: 16px;
                padding: 8px;
                margin: 10px 0 0 0;
                background-color: #F4F4F4;
                border: 1px solid #C6C6C6;
                background-image: linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                background-image: -o-linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                background-image: -moz-linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                background-image: -webkit-linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                background-image: -ms-linear-gradient(bottom, #E1E1E1 0%, #ffffff 100%);
                background-image: -webkit-gradient( linear, left bottom, left top, color-stop(0, #E1E1E1), color-stop(1, #ffffff) );
                -webkit-box-shadow: 0 1px 0 #FFFFFF inset, 0 1px 0 #EEEEEE;
                -moz-box-shadow: 0 1px 0 #FFFFFF inset, 0 1px 0 #EEEEEE;
                box-shadow: 0 1px 0 #FFFFFF inset, 0 1px 0 #EEEEEE;
                -webkit-border-radius: 5px;
                -moz-border-radius: 5px;
                -o-border-radius: 5px;
                border-radius: 5px;
            }

                .window .txtbtn:visited {
                    background-image: linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -o-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -moz-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -webkit-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -ms-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -webkit-gradient( linear, left bottom, left top, color-stop(0, #ffffff), color-stop(1, #E1E1E1) );
                }

                .window .txtbtn:active {
                    background-image: linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -o-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -moz-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -webkit-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -ms-linear-gradient(bottom, #ffffff 0%, #E1E1E1 100%);
                    background-image: -webkit-gradient( linear, left bottom, left top, color-stop(0, #ffffff), color-stop(1, #E1E1E1) );
                }

            .window .wtitle .close {
                float: right;
                background-image: url("images/index.png");
                width: 26px;
                height: 26px;
                display: block;
            }

        #overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: #000000;
            opacity: 0.5;
            filter: alpha(opacity=0);
            display: none;
            z-index: 999;
        }
    </style>
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>

</head>
<body id="card" class="mode_webapp">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
        <div class="menu_header">
            <div class="menu_topbar">
                <strong class="head-title">会员卡首页</strong>
                <span class="head_btn_left"><a href="javascript:history.go(-1);"><span>返回</span></a><b></b></span>
                <a class="head_btn_right" href="ucardlist.aspx?wid=<%=wid%>&openid=<%=openid %>&id=<%=id %>">
                    <span><i class="menu_header_home"></i></span><b></b>
                </a>
            </div>
        </div>

        <div id="overlay"></div>
        <div class="cardcenter">
            <asp:Literal ID="litLQK" runat="server" EnableViewState="false"></asp:Literal>
           
            <div class="card">
                <asp:Literal ID="litCardInfo" runat="server" EnableViewState="false"></asp:Literal>

           
            </div>
            <p class="explain"><span>使用时向服务员出示此卡</span></p>
            <div class="window" id="windowcenter">
                <div id="title" class="wtitle">领卡信息<span class="close" id="alertclose"></span></div>
                <div class="content">
                    <div id="txt"></div>
                    <p>
                        <input name="truename" value="" class="px" id="truename" type="text" placeholder="请输入您的姓名">
                    </p>
                    <p>
                        <input name="tel" class="px" id="tel" value="" type="number" placeholder="请输入您的电话">
                    </p>
                    <input type="button" value="确 定" name="确 定" class="txtbtn" id="windowclosebutton">
                </div>
            </div>
        </div>


        <div class="cardexplain">

            <!--会员积分信息-->
            <asp:Literal ID="litJiFen" runat="server" EnableViewState="false"></asp:Literal>
            
            <ul class="round" id="notice">
                <asp:Literal ID="litNotice" runat="server" EnableViewState="false"></asp:Literal>
            </ul>
            <ul class="round" id="powerandgift">
                <li><a href="qiandao.aspx?sid=<%=id%>&wid=<%=wid%>&openid=<%=openid %>">
                    <span>签到赚积分 
                        <asp:Literal ID="litHasQD" runat="server" EnableViewState="false" Text='<em class="error">今日未签到</em>'></asp:Literal>
                     </span></a>
                </li>
                <li><a href="userinfo.aspx?sid=<%=id%>&wid=<%=wid%>&openid=<%=openid %>"><span>个人资料</span></a></li>
            </ul>

            <ul class="round">
                <li><a href="ucardShuoMing.aspx?sid=<%=id%>&wid=<%=wid%>&openid=<%=openid %>"><span>会员卡说明</span></a></li>
                <li><a href="ucardFenDian.aspx?sid=<%=id%>&wid=<%=wid%>&openid=<%=openid %>"><span>适用门店电话及地址</span></a></li>
            </ul>
            <ul class="round">
                <li class="addr">
                    <a href="" runat="server" id="aAddr">
                        <span>地址: <asp:Literal ID="litAddr" runat="server" EnableViewState="false"></asp:Literal></span>

                    </a>

                </li>
                <li class="tel"><a href="" runat="server" id="aTel"><span>电话: <asp:Literal ID="litTel" runat="server" EnableViewState="false"></asp:Literal></span></a></li>
            </ul>
        </div>

        <script type="text/javascript">

            $(document).ready(function () {

                $("#windowclosebutton").bind("click",
                function () {
                    var hidStatus=$("#hidStatus").val();
                    if(hidStatus=="-1")
                    {
                        return;
                    }
                    var btn = $(this);
                   
                    var tel = $("#tel").val();

                    var truename = $("#truename").val();

                    var regu = /^[0-9]{7,11}$/;
                    var re = new RegExp(regu);
                    if (!re.test(tel)) {
                        $("#tel").val("请输入正确的手机号码!");
                        return;
                    }

                    if (truename.length < 2 || truename == '请输入名字') {
                        $("#truename").val("请输入名字");
                        return;
                    }
                    var rad = Math.random();
                    var submitData = {
                        sid: <%=id%>,
                        openid:"<%=openid%>",
                        truename: truename,
                        tel: tel,
                        rad: rad 
                    };

                    $.post('ucardprocess.ashx?myact=userreg', submitData,
                    function (data) {
                        
                        if (data.ret == "succ") {
                            
                            window.location.href=location.href;
                            
                        } else {
                            $("#txt").text(data.msg);
                            
                             
                        }
                    },
                    "json");



                });

                $("#showcard").click(function () {
                    alert("填写真实的姓名以及电话号码，即可获得会员卡，享受会员特权。");
                    $("#overlay").css("display", "block");
                });
            });


            $("#alertclose").click(function () {
                $("#windowcenter").slideUp(500);
                $("#overlay").css("display", "none");

            });




            function alert(title) {
                $("#windowcenter").slideToggle("slow");
                $("#txt").html(title);
            }

        </script>
        <script src="js/plugback.js" type="text/javascript" type="text/javascript"></script>


        <div class="footermenu">
            <ul>
                <li>
                    <a class="active" href="index.aspx?wid=<%=wid%>&id=<%=id%>&openid=<%=openid%>">
                        <img src="images/themes/1/ucard.png">
                        <p>会员卡</p>
                    </a>
                </li>
                <li>
                    <a href="ucardPrivileges.aspx?wid=<%=wid%>&sid=<%=id%>&openid=<%=openid %>">
                        <img src="images/themes/1/tequan.png">
                        <p>特权</p>
                    </a>
                </li>
                <li>
                    <a href="ucardTicket.aspx?wid=<%=wid%>&sid=<%=id%>&openid=<%=openid%>">
                        <img src="images/themes/1/ticketpic.png">
                        <p>优惠券</p>
                    </a>
                </li>
                <li>
                    <a href="duihuan.aspx?wid=<%=wid%>&sid=<%=id%>&openid=<%=openid%>">
                        <img src="images/themes/1/duihuan.png">
                        <p>兑换</p>
                    </a>
                </li>
                <li>
                    <a href="qiandao.aspx?wid=<%=wid%>&sid=<%=id%>&openid=<%=openid%>">
                        <img src="images/themes/1/qiandao_btm.png">
                        <p>签到</p>
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
