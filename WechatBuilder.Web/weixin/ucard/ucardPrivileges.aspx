<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ucardPrivileges.aspx.cs" Inherits="WechatBuilder.Web.weixin.ucard.ucardPrivileges" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>会员卡</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/card.css" rel="stylesheet" type="text/css">
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>
    <script src="js/accordian.pack.js" type="text/javascript"></script>
    <script src="../../scripts/mycommjs.js" type="text/javascript"></script>
</head>
<body id="cardpower" onload="new Accordian('basic-accordian',2,'header_highlight');" class="mode_webapp2">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
        <div class="qiandaobanner">
            <a href="javascript:history.go(-1);">
                <asp:Image ID="imgTopPic" runat="server" ImageUrl="images/themes/1/vippower.jpg" EnableViewState="false" />
            </a>
        </div>

        <div id="basic-accordian">
            <asp:Literal ID="litPrivilegeslist" runat="server" EnableViewState="false"></asp:Literal>

        </div>
        

        <script src="js/alert.js" type="text/javascript"></script>
        <script>
            var jQ = jQuery.noConflict();
          
            function power(i, sncode, pid) {
              
                var parssword = document.getElementById('parssword' + i).value;
                var money = document.getElementById('money' + i).value;
                var bmoney = document.getElementById('bmoney' + i).value;
                if (money != bmoney) {
                    document.getElementById('sn' + i).innerHTML = '请确认金额!';
                    return
                }
                if(!validMoney(money))
                {
                    document.getElementById('sn' + i).innerHTML = '请确认金额!';
                    return
                }
                var rad = Math.random();
                var submitData = {
                    parssword: parssword,
                    sncode: sncode,
                    money: money,
                    pid: pid,
                    uid:<%=uid%>,
                    openid:"<%=openid%>",
                    sid:<%=sid%>,
                    rad: rad,
                    myact: "tequan"
                };
                
                jQ.post('ucardprocess.ashx', submitData,
                function (data) {
                    if (data.ret == "succ") {
                        document.getElementById('queren' + i).style.display = 'none';
                        document.getElementById('sn' + i).innerHTML = data.msg;
                        document.getElementById('parssword' + i).value = '';
                        document.getElementById('money' + i).value = '';
                        alert(data.msg);
                    } else {
                        jQ('#parssword' + i).addClass('err');
                        // document.getElementById('parssword'+i).value=data.msg;
                    }
                },
                "json");



            }

            
        </script>
        <script src="js/plugback.js" type="text/javascript"></script>

        <div class="footermenu">
            <ul>
                <li>
                    <a href="index.aspx?wid=<%=wid%>&id=<%=sid%>&openid=<%=openid%>">
                        <img src="images/themes/1/ucard.png">
                        <p>会员卡</p>
                    </a>
                </li>
                <li>
                    <a class="active" href="ucardPrivileges.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>">
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
                    <a href="qiandao.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>">
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
