<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paypage.aspx.cs" Inherits="MxWeiXinPF.Web.api.payment.wxpay.paypage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>微支付</title>
    <META HTTP-EQUIV="Content-type" CONTENT="text/html; charset=utf-8">
    <meta content="application/xhtml+xml;charset=UTF-8" http-equiv="Content-Type">
    <meta content="telephone=no, address=no" name="format-detection">
    <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js"></script>
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/lazyloadv3.js"></script>
    <script>

        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            //公众号支付
            jQuery('a#getBrandWCPayRequest').click(function (e) {
                WeixinJSBridge.invoke('getBrandWCPayRequest', {
                    "appId": "", //公众号名称,由商户传入
                    "timeStamp": "", //时间戳 这里随意使用了一个值
                    "nonceStr": "", //随机串
                    "package": "",//扩展字段,由商户传入
                    "signType": "", //微信签名方式:sha1
                    "paySign": "" //微信签名
                }, function (res) {
                    WeixinJSBridge.log(res.err_msg);
                    if (res.err_msg == 'get_brand_wcpay_request:ok') {
                        alert('支付成功');
                        window.history.back(-1);
                        return false;
                    } else {
                        alert('支付失败');

                        return false;
                    }
                    //alert(res.err_msg);
                });

            });
            WeixinJSBridge.log('yo~ ready.');

        }, false);
    </script>
    <style type="text/css">
        *{ margin:0px; padding:0px;-webkit-box-sizing:border-box;}
        .body { text-align:center; width:100%; padding:60px 20px; }
        .body .ordernum{ font-size:14px; line-height:30px;}
        .body .money{ font-size:20px; font-weight:bold; line-height:60px;}
        .body .time{font-size:16px; font-weight:bold; line-height:30px;}
        .body .btn{ display:block;background:#25a52e; text-decoration:none; border-radius:2px; color:#fff; height:44px; line-height:44px; font-size:18px; margin-top:20px;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <section class="body">
        <div class="ordernum">订单号：</div>
        <div class="money">共计金额￥0.00</div>
        <div class="time">下单时间：</div>
        <a href="javascript:void(0);" class="btn" id="getBrandWCPayRequest">确认支付</a>
    </section>
    </form>
</body>
</html>
