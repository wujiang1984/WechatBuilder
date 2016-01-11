<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment_select.aspx.cs" Inherits="WechatBuilder.Web.shopmgr.setting.payment_select" %>


<%@ Import Namespace="WechatBuilder.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>支付方式</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../admin/js/layout.js"></script>
    <link href="../../admin/skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>

            <a href="payment_list.aspx" class="home"><i></i><span>支付方式</span></a>
            <i class="arrow"></i>
            <span>添加支付方式</span>

        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                </div>

            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="8%">序号</th>
                        <th align="left" width="15%">名称</th>

                        <th align="left">支付描述</th>

                        <th width="10%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        <%#Eval("id")%></td>
                    <td><a href="payment_add.aspx?id=<%#Eval("id")%>"><%#Eval("typeName")%></a></td>

                    <td><%#Eval("remark")%></td>

                    <td align="center"><a href="payment_add.aspx?id=<%#Eval("id")%>">添加</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
</table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/列表-->

    </form>
</body>
</html>
