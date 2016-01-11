<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="plugin_list.aspx.cs" Inherits="MxWeiXinPF.Web.admin.settings.plugin_list" %>
<%@ Import namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>插件配置</title>
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
  <span>应用管理</span>
  <i class="arrow"></i>
  <span>插件安装配置</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="lbtnInstall" runat="server" CssClass="save" OnClientClick="return ExePostBack('lbtnInstall','已安装的插件不执行重复安装，是否继续？');" onclick="lbtnInstall_Click"><i></i><span>安装</span></asp:LinkButton></li>
        <li><asp:LinkButton ID="lbtnUnInstall" runat="server" CssClass="del" OnClientClick="return ExePostBack('lbtnUnInstall','卸载插件不会删除插件目录，是否继续？');" onclick="lbtnUnInstall_Click"><i></i><span>卸载</span></asp:LinkButton></li>
        <li><asp:LinkButton ID="lbtnRemark" runat="server" CssClass="folder" OnClientClick="return CheckPostBack('lbtnRemark');" onclick="lbtnRemark_Click"><i></i><span>生成模板</span></asp:LinkButton></li>
      </ul>
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
    <th align="left" width="20%">插件名称</th>
    <th align="left" width="12%">目录</th>
    <th align="left" width="12%">作者</th>
    <th align="left" width="10%">版本号</th>
    <th align="left">备注</th>
    <th width="10%">状态</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
      <asp:HiddenField ID="hidDirName" Value='<%#Eval("directory")%>' runat="server" />
    </td>
    <td><%#Eval("name")%></td>
    <td><%#Eval("directory")%></td>
    <td><%#Eval("author")%></td>
    <td><%#Eval("version")%></td>
    <td><%#Eval("description")%></td>
    <td align="center">
      <%#Convert.ToInt32(Eval("isload")) == 1 ? "已安装" : "未激活"%>
    </td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->
</form>
</body>
</html>
