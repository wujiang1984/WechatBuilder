<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="templet_list.aspx.cs" Inherits="WechatBuilder.Web.admin.settings.templet_list" %>

<%@ Import Namespace="WechatBuilder.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>模板管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //只能选中一项
            $(".checkall input").click(function () {
                $(".checkall input").prop("checked", false);
                $(this).prop("checked", true);
            });
            //管理模板检测
            $("#btnManage").click(function () {
                if ($(".checkall input:checked").size() < 1) {
                    $.dialog.alert('对不起，请选中您要管理的模板！');
                    return false;
                }
            });
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>模板管理</span></a>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>
                            <asp:LinkButton ID="btnManage" runat="server" CssClass="folder" OnClick="btnManage_Click"><i></i><span>管理</span></asp:LinkButton></li>
                    </ul>
                    <div class="menu-list" style="display:none;">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlCategoryPath" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoryPath_SelectedIndexChanged"></asp:DropDownList>
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
                        <th align="left" width="20%">模板名称</th>
                        <th width="13%">作者</th>
                        <th width="16%">创建日期</th>
                        <th width="12%">版本号</th>
                        <th align="left">适用版本</th>
                        <th width="10%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hideSkinName" runat="server" Value='<%#Eval("skinname")%>' />
                    </td>
                    <td><%#Eval("name")%>(<%#Eval("skinname")%>)</td>
                    <td align="center"><%#Eval("author")%></td>
                    <td align="center"><%#Eval("createdate")%></td>
                    <td align="center"><%#Eval("version")%></td>
                    <td><%#Eval("fordntver")%></td>
                    <td align="center"><a href="templet_file_list.aspx?skin=<%#Eval("skinname")%>">管理</a></td>
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
