<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiPay.aspx.cs" Inherits="MxWeiXinPF.Web.api.payment.WeiPayWeb.WeiPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>公众号JSAPI支付测试网页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=GBK" />
  <%--  <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js" type="text/javascript"></script>
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/lazyloadv3.js" type="text/javascript"></script>--%>

    <script src="JS/jquery.js" type="text/javascript"></script>
    <script src="JS/lazyloadv3.js" type="text/javascript"></script>
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
 
</head>
<body>
 <form id="form1" runat="server">
     <div>
                 <table class="content">
                     <tr>
                         <td  class="td_title">商户订单号：</td>
                        <td class="td_input"><asp:Label ID="lblOrderSN" runat="server" Text=""></asp:Label></td>
                     </tr>
                       <tr>
                         <td class="td_title">支付金额(分)：</td>
                        <td class="td_input"> <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></td>
                     </tr>
                       <tr>
                         <td class="td_title">商品描述：</td>
                        <td class="td_input"> <asp:Label ID="lblBody" runat="server" Text=""></asp:Label></td>
                     </tr>
                   
                     
                       <tr>
                         <td class="td_title">自定义参数：</td>
                        <td class="td_input">  <asp:Label ID="lblAttach" runat="server" Text=""></asp:Label>    </td>
                     </tr>
                     
                         <tr>
                         <td class="td_title">OpenId：</td>
                        <td class="td_input">  <asp:Label ID="lblOpenId" runat="server" Text=""></asp:Label>    </td>
                     </tr>
                          <tr>
                         <td class="td_title">&nbsp;</td>
                        <td class="td_input"> 
                         <input type="button" value="确认支付"  id="getBrandWCPayRequest" onclick="SavePay()" />
                          </td>
                     </tr>
                 </table>
        </div>
     
 
<%--    <div class="WCPay">
    <h1 class="title"  id="getBrandWCPayRequest" onclick="SavePay()" >提交</h1>
    
<a id="getBrandWCPayRequest" href="javascript:void(0);">
            <h1 class="title" onclick="">点击提交可体验微信支付</h1>
        </a>

    </div>--%>
        </form>
</body>
</html>


<script type="text/javascript">

function SavePay(){
    WeixinJSBridge.invoke('getBrandWCPayRequest', {
                   "appId": "<%= WeiPay.PayConfig.AppId %>", //公众号名称，由商户传入
                   "timeStamp": "<%= TimeStamp %>", //时间戳
                   "nonceStr": "<%= NonceStr %>", //随机串
                   "package": "<%= Package %>", //扩展包
                   "signType": "MD5", //微信签名方式:1.sha1
                   "paySign": "<%= PaySign %>" //微信签名
               }, 
               function(res) {
                   if (res.err_msg == "get_brand_wcpay_request:ok") {
                       alert("微信支付成功!");
                   } else if (res.err_msg == "get_brand_wcpay_request:cancel") {
                       alert("用户取消支付!");
                   } else {
                       alert(res.err_msg);
                       alert("支付失败!");
                   }
                   // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                   //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
               });    
}
   


</script>