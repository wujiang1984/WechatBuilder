<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopping_history.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.ucard.shopping_history" %>

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
     <script type="text/javascript">
         $(document).ready(function () {
             var m = $.query.get("m");
           
             if($.trim(m)!="")
             {
                 $("#monthselect").val(m);
             }
         });

    </script>

</head>
<body id="cardshopping" onload="new Accordian('basic-accordian',5,'header_highlight');" class="mode_webapp2">
    <form id="form1" runat="server">
         <asp:HiddenField ID="hidStatus" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />


        <div class="qiandaobanner">
            <a href="javascript:history.go(-1);">
                <asp:Image ID="imgTopPic" runat="server" ImageUrl="images/themes/1/shopping.jpg" EnableViewState="false" />
            </a>
        </div>

        <div class="cardexplain">
             <!--会员积分信息 begin-->
            <asp:Literal ID="litJiFen" runat="server" EnableViewState="false"></asp:Literal>
             <!--会员积分信息 end-->

            <div class="jifen-box header_highlight">
                <div class="tab month_sel">
                    <span class="title">查看每月积分获取已消费记录
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
                <div class="accordion_child" style="padding: 0">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="integral_table">
                        <thead>
                            <tr>
                                <th>日期</th>
                                <th>消费金额</th>
                                <th>积分</th>
                            </tr>
                        </thead>

                        <tbody>
                             <asp:Literal ID="litXFStr" runat="server" EnableViewState="false" Text=""></asp:Literal>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td class="right">本月</td>
                                <td><span class="heji"> <asp:Literal ID="litttMoney" runat="server" EnableViewState="false"></asp:Literal>元</span></td>
                                <td><span class="heji"> <asp:Literal ID="litttScore" runat="server" EnableViewState="false"></asp:Literal></span></td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>

        </div>
        <div id="basic-accordian">
            <h2>消费详情</h2>
              <%=detailStr %>
        </div>
        <script>
            function dourl(m) {
                location.href = 'shopping_history.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>&m=' + m;
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
                    <a  href="qiandao.aspx?wid=<%=wid%>&sid=<%=sid%>&openid=<%=openid%>">
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
