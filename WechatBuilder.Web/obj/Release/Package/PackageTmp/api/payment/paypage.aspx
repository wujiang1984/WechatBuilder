<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paypage.aspx.cs" Inherits="MxWeiXinPF.Web.api.payment.paypage" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>微支付</title>
    <meta http-equiv="Content-type" content="text/html; charset=utf-8">
    <meta content="application/xhtml+xml;charset=UTF-8" http-equiv="Content-Type">
    <meta content="telephone=no, address=no" name="format-detection">
    <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js"></script>
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/lazyloadv3.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery.query.js"></script>
    <script>
        
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            //公众号支付
            jQuery('a#getBrandWCPayRequest').click(function (e) {
               

                //begin:开始付款
                WeixinJSBridge.invoke('getBrandWCPayRequest',<%=packageValue%> , function (res) {
                    WeixinJSBridge.log(res.err_msg);

                   var rpage=$.query.get("rpage");
                   var openid = $.query.get("openid");
                   var otid = $.query.get("orderid");
                   var wid=$.query.get("wid");
                   var radNum = Math.random();

                    if (res.err_msg == 'get_brand_wcpay_request:ok') {
                        // alert('支付成功');
                        //去判断交易信息
                        window.location.href = "/api/payment/wxpay/payResult.aspx?wid="+wid+"&otid="+otid+"&openid="+openid+"&radnum="+radNum+"&rpage="+escape(rpage);
                          
                    } else {

                       // alert('支付失败：'+res.err_msg);
                        
                        // window.location.href = rpage;
 
                        return false;
                    }
                    //alert(res.err_msg);
                });
                //end:开始付款

            });
            WeixinJSBridge.log('yo~ ready.');

        }, false);

      

    </script>
    <style type="text/css">
        * {
            margin: 0px;
            padding: 0px;
            -webkit-box-sizing: border-box;
        }

        .body {
            text-align: center;
            width: 100%;
            padding: 60px 20px;
        }

            .body .ordernum {
                font-size: 14px;
                line-height: 30px;
            }

            .body .money {
                font-size: 20px;
                font-weight: bold;
                line-height: 60px;
            }

            .body .time {
                font-size: 16px;
                font-weight: bold;
                line-height: 30px;
            }

            .body .btn {
                display: block;
                background: #25a52e;
                text-decoration: none;
                border-radius: 2px;
                color: #fff;
                height: 44px;
                line-height: 44px;
                font-size: 18px;
                margin-top: 20px;
            }
    </style>
</head>
<body>
    <section class="body">
        <div class="ordernum">订单号：<asp:Literal ID="litout_trade_no" runat="server" EnableViewState="false"></asp:Literal></div>
        <div class="money">共计金额￥<asp:Literal ID="litMoney" runat="server" EnableViewState="false"></asp:Literal></div>
        <div class="time">下单时间：<asp:Literal ID="litDate" runat="server" EnableViewState="false"></asp:Literal></div>
        <div class="paytype" style="display: none;">支付方式：微信支付</div>
        <a href="javascript:void(0);" class="btn" id="getBrandWCPayRequest">确认支付</a>
    </section>

</body>

</html>

