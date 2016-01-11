<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="url_rewrite_list.aspx.cs" Inherits="WechatBuilder.Web.admin.settings.url_rewrite_list" %>
<%@ Import namespace="WechatBuilder.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>URL配置管理</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>系统管理</span>
  <i class="arrow"></i>
  <span>URL配置管理</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="url_rewrite_edit.aspx?action=<%=MXEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会导致网站前台无法运作，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
      <div class="menu-list">
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlChannel" runat="server" AutoPostBack="True" onselectedindexchanged="ddlChannel_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlPageType" runat="server" AutoPostBack="True" onselectedindexchanged="ddlPageType_SelectedIndexChanged">
              <asp:ListItem Selected="True" Value="">所有类型</asp:ListItem>
              <asp:ListItem Value="index">首页</asp:ListItem>
              <asp:ListItem Value="list">列表页</asp:ListItem>
              <asp:ListItem Value="category">栏目页</asp:ListItem>
              <asp:ListItem Value="detail">详细页</asp:ListItem>
              <asp:ListItem Value="plugin">插件页</asp:ListItem>
              <asp:ListItem Value="other">其它页</asp:ListItem>
            </asp:DropDownList>
        </div>
      </div>
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
    <th align="left">调用名称</th>
    <th width="10%" align="left">页面类型</th>
    <th width="20%" align="left">源页面名称</th>
    <th width="18%" align="left">继承类名</th>
    <th width="15%" align="left">模板名称</th>
    <th width="10%" align="left">归属频道</th>
    <th width="8%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hideName" Value='<%#Eval("name")%>' runat="server" />
    </td>
    <td><%#Eval("name")%></td>
    <td><%#Eval("type")%></td>
    <td><%#Eval("page")%></td>
    <td><%#Eval("inherit")%></td>
    <td><%#Eval("templet")%></td>
    <td><%#Eval("channel").ToString() != "" ? Eval("channel") : "-"%></td>
    <td align="center"><a href="url_rewrite_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&name=<%#Eval("name")%>">修改</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->
</form>
</body>
</html>
