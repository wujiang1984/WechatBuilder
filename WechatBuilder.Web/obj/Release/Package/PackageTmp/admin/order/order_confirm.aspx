<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_confirm.aspx.cs" Inherits="MxWeiXinPF.Web.admin.order.order_confirm" %>
<%@ Import namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>待确认订单</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link  href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="order_list.aspx"><span>订单管理</span></a>
  <i class="arrow"></i>
  <span>待确认订单</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnConfirm" runat="server" CssClass="save" OnClientClick="return ExePostBack('btnConfirm','确认后将无法修改信息，是否继续？');" onclick="btnConfirm_Click"><i></i><span>确认订单</span></asp:LinkButton></li>
      </ul>
    </div>
    <div class="r-list">
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left">订单号</th>
    <th align="left" width="12%">会员账号</th>
    <th align="left" width="10%">支付方式</th>
    <th align="left" width="10%">配送方式</th>
    <th width="8%">订单状态</th>
    <th width="10%">总金额</th>
    <th align="left" width="16%">下单时间</th>
    <th width="8%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Enabled='<%#bool.Parse((Convert.ToInt32(Eval("status")) > 3 ).ToString())%>' style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td><a href="order_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("order_no")%></a></td>
    <td><%#Eval("accept_name").ToString() == "" ? "匿名用户" : Eval("accept_name").ToString()%></td>
    <td><%#Eval("paymentName") %></td>
    <td><%#Eval("expressName") %></td>
    <td align="center"><%#Eval("statusName") %></td>
    <td align="center"><%#Eval("order_amount")%></td>
    <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
    <td align="center"><a href="order_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">详细</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
