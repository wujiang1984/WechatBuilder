<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Send.aspx.cs" Inherits="WeiPayWeb.Send" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
  
    <title>发起支付</title>
    
      <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
        <meta http-equiv="Content-Type" content="text/html; charset=GBK" />
</head>
<body >
    <form id="form1" runat="server">
    <div>
             <table class="content">
                 <tr>
                     <td  class="td_title">商户订单号：</td>
                    <td class="td_input">  <asp:TextBox ID="txtOrderSN" runat="server" CssClass="txt1" ></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td class="td_title">支付金额(分)：</td>
                    <td class="td_input">  <asp:TextBox ID="txtPrice" runat="server" CssClass="txt1" ></asp:TextBox></td>
                 </tr>
                   <tr>
                     <td class="td_title">商品描述：</td>
                    <td class="td_input">  <asp:TextBox ID="txtBody" runat="server" CssClass="txt1" ></asp:TextBox></td>
                 </tr>
                
                   <tr>
                     <td class="td_title">自定义参数：</td>
                    <td class="td_input">  <asp:TextBox ID="txtOther" runat="server" CssClass="txt1" ></asp:TextBox>
                    <BR /> 不能有中文(修复中)</td>
                 </tr>
                      <tr>
                         <td class="td_title">用户OpenId：</td>
                        <td class="td_input">  <asp:Label ID="lblOpenId" runat="server" Text=""></asp:Label>    </td>
                     </tr>
                     
                      <tr>
                     <td class="td_title">&nbsp;</td>
                    <td class="td_input"> 
                        <asp:Button ID="BtnSave" runat="server" Text="确认支付" onclick="BtnSave_Click" /></td>
                 </tr>
             </table>
    </div>
    </form>
</body>
</html>
