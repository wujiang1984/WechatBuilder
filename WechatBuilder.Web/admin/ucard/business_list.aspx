<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="business_list.aspx.cs" Inherits="WechatBuilder.Web.admin.ucard.business_list" %>


<%@ Import Namespace="WechatBuilder.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员卡商家管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <style  type="text/css">
        .operator_a {
        padding-left:5px;
        padding-right:5px;
        }

    </style>
    <script type="text/javascript">
        function parentToIndex(id) {
            parent.location.href = "/admin/Index.aspx?id=" + id;

        }

        $(function () {


        });



    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>会员卡商家管理</span></a>
        </div>
        <!--/导航栏-->
        <div class="mytips">
            会员卡商城网址：<a href="javascript:;"><asp:Literal ID="litUrl" runat="server"></asp:Literal></a> 可以直接融合代3G页面(使用关键词回复)
        </div>
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn add" href="business_edit.aspx?action=<%=MXEnums.ActionEnum.Add %>" id="itemAddButton"><i></i><span>新增会员卡商家</span></a></li>
                        <li><a class="icon-btn folder" href="business_setting.aspx" id="A1"><i></i><span>会员卡商城设置</span></a></li>
                        <li><a class="icon-btn folder" href="business_adver_list.aspx" id="A2"><i></i><span>会员卡商城头部广告位设置</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                </div>
                <div class="r-list">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->

        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th width="5%">选择</th>
                            <th width="25%">商家名称/电话</th>
                            <th width="49px">推荐</th>
                            <th width="15%">链接地址</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody class="ltbody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="td_c">
                    <td>
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td>
                        <%# Eval("storeName") %>/<%# Eval("tel") %>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkbtnRecommend" runat="server" Text='<%# Eval("isRecommend") %>' CommandName="recommend" CommandArgument='<%# Eval("isRecommend") %>'> </asp:LinkButton>

                    </td>
                    <td>
                        <asp:TextBox ID="txtscardurl" runat="server" Text=""></asp:TextBox>
                    </td>
                    <td>
                        <a href='business_edit.aspx?id=<%#Eval("id") %>&action=<%=MXEnums.ActionEnum.Edit %>' class="operator_a">编辑</a>
                        <a href='store_fendian.aspx?id=<%#Eval("id") %>' class="operator_a">分店</a>
                        <a href='score_mgr.aspx?id=<%#Eval("id") %>' class="operator_a">积分策略</a>
                        <a href='card_design.aspx?id=<%#Eval("id") %>' class="operator_a">卡面设置</a>
                        <a href='notice_list.aspx?id=<%#Eval("id") %>' class="operator_a">通知管理</a>
                        <a href='privileges_list.aspx?id=<%#Eval("id") %>' class="operator_a">特权管理</a>
                        <a href='ticket_list.aspx?id=<%#Eval("id") %>' class="operator_a">优惠券管理</a>
                        <a href='gift_list.aspx?id=<%#Eval("id") %>' class="operator_a">礼品券管理</a>
                        <a href='user_list.aspx?id=<%#Eval("id") %>' class="operator_a">会员管理</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
                 </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
