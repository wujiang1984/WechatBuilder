<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qiandao.aspx.cs" Inherits="WechatBuilder.Web.weixin.ucard.qiandao" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>会员卡-签到</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/card.css" rel="stylesheet" type="text/css">
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>
    <style type="text/css">
        .window {
            width: 240px;
            position: absolute;
            display: none;
            margin: -50px auto 0 -120px;
            padding: 2px;
            top: 0;
            left: 50%;
            border-radius: 0.6em;
            -webkit-border-radius: 0.6em;
            -moz-border-radius: 0.6em;
            background-color: rgba(255, 0, 0, 0.5);
            -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.2);
            -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.2);
            -o-box-shadow: 0 0 5px rgba(0, 0, 0, 0.2);
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.2);
            font: 14px/1.5 Microsoft YaHei,Helvitica,Verdana,Arial,san-serif;
            z-index: 10;
            bottom: auto;
        }

            .window .content {
                /*min-height:100px;*/
                overflow: auto;
                padding: 10px;
                color: #222222;
                text-shadow: 0 1px 0 #FFFFFF;
                border-radius: 0 0 0.6em 0.6em;
                -webkit-border-radius: 0 0 0.6em 0.6em;
                -moz-border-radius: 0 0 0.6em 0.6em;
            }

            .window #txt {
                min-height: 30px;
                font-size: 20px;
                line-height: 22px;
                color: #FFF;
                text-align: center;
            }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            var m = $.query.get("m");
           
            if($.trim(m)!="")
            {
                $("#monthselect").val(m);
            }
            $("#qiandao").click(function () {
                var errorinfo=$("#hidErrInfo").val();
                if($.trim(errorinfo)!="")
                {
                    alert(errorinfo);
                    return;
                }
                var btn = $(this);
                var submitData = {
                    sid: <%=sid%>,
                    uid: <%=uid%>,
                    myact: "qiandao"
                };
                $.post('ucardprocess.ashx', submitData,
                function (data) {
                    if (data.ret == "succ") {

                        $("#qiandao").html("今天你已经签到了!");
                        alert(data.msg);
                        setTimeout('dourl(0)', 2000);
                        return
                    }
                },
                "json");

            });
        });

    </script>

</head>
<body id="cardintegral" class="mode_webapp2">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />

        <div class="qiandaobanner">
            <a href="javascript:history.go(-1);">
                <asp:Image ID="imgTopPic" runat="server" ImageUrl="images/themes/1/qiandao.jpg" EnableViewState="false" />
            </a>
        </div>


        <div class="cardexplain">
            <a class="receive" id="qiandao" href="javascript:;">
                <span class="red">
                    <asp:Literal ID="litQDinfo" runat="server" EnableViewState="false" Text="点击这里签到赚积分"></asp:Literal>
                </span><span style="display: none"></span></a>
            <!--会员积分信息-->
            <asp:Literal ID="litJiFen" runat="server" EnableViewState="false"></asp:Literal>

            <div class="jifen-box header_highlight">
                <div class="tab month_sel">
                    <span class="title">查看每月签到及积分详情
                        <p>点击这里选择其他月份</p>
                    </span>
                </div>
                <select onchange="dourl(this.value)" class="month" id="monthselect">
                    <option value="1">1月</option>
                    <option value="2">2月</option>
                    <option value="3">3月</option>
                    <option value="4">4月</option>
                    <option value="5">5月</option>
                    <option value="6">6月</option>
                    <option value="7">7月</option>
                    <option value="8">8月</option>
                    <option value="9">9月</option>
                    <option value="10">10月</option>
                    <option value="11">11月</option>
                    <option value="12">12月</option>
                </select>
                <div class="accordion_child">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="integral_table">
                        <thead>
                            <tr>
                                <th>日期</th>
                                <th>签到情况</th>
                                <th>积分</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="litQDStr" runat="server" EnableViewState="false" Text=""></asp:Literal>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td></td>
                                <td class="right">本月合计：</td>
                                <td><span class="heji">+<asp:Literal ID="litTTqdScore" runat="server" EnableViewState="false" Text="0"></asp:Literal></span></td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>

            <div class="window" id="windowcenter">
                <div class="content">
                    <div id="txt"></div>
                </div>

            </div>
        </div>

        <script>
            function dourl(m) {
                location.href = 'qiandao.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>&m=' + m;
            }
        </script>



        <script type="text/javascript">

            function alert(title) {

                $("#windowcenter").slideToggle("slow");
                $("#txt").html(title);
                setTimeout('$("#windowcenter").slideUp(500)', 2000);
            }

        </script>
        <script src="js/plugback.js" type="text/javascript" type="text/javascript"></script>


        <div class="footermenu">
            <ul>
                <li>
                    <a href="index.aspx?wid=<%=wid%>&id=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/ucard.png">
                        <p>会员卡</p>
                    </a>
                </li>
                <li>
                    <a href="ucardPrivileges.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/tequan.png">
                        <p>特权</p>
                    </a>
                </li>
                <li>
                    <a href="ucardTicket.aspx?wid=<%=wid %>&sid=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/ticketpic.png">
                        <p>优惠券</p>
                    </a>
                </li>
                <li>
                    <a href="duihuan.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/duihuan.png">
                        <p>兑换</p>
                    </a>
                </li>
                <li>
                    <a class="active" href="qiandao.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>">
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
