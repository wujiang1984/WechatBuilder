<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productInStock.aspx.cs" Inherits="WechatBuilder.Web.shopmgr.product.productInStock" %>

<%@ Import Namespace="WechatBuilder.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>仓库中的商品</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../admin/js/layout.js"></script>
    <link href="../../admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../admin/skin/mystyle.css" rel="stylesheet" type="text/css" />
    <link href="../../../admin/css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
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
            <a href="javascript:;" class="home"><i></i><span>仓库中的商品</span></a>
        </div>
        <!--/导航栏-->
        <asp:Label ID="lblWid" runat="server" Text="" Style="display: none;"></asp:Label>

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">

                        <li><a class="icon-btn add" href="product_add.aspx?frompage=productInStock.aspx" id="itemAddButton"><i></i><span>新增商品</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存排序</span></asp:LinkButton></li>
                         <li>
                            <asp:LinkButton ID="btnXiJia" runat="server" CssClass="folder" OnClick="btnXiJia_Click"><i></i><span>上架商品</span></asp:LinkButton></li>

                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                    <div class="menu-list">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlCategoryId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoryId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
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
                            <th width="13%">货号</th>
                            <th>商品名称</th>
                            <th width="8%">库存</th>
                            <th width="10%">销售价</th>
                            <th width="6%">最新</th>
                            <th width="6%">最热</th>
                            <th width="6%">特价</th>
                            <th width="8%">排序</th>
                            <th width="12%">操作</th>
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

                        <%# Eval("sku") %>
                    </td>
                    <td>
                        <%# Eval("productName") %>
                    </td>
                    <td>
                        <%# Eval("stock") %>
                    </td>
                    <td>
                        <%# Eval("salePrice") %>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbtnIsTop" CommandName="lbtnIslatest" runat="server">
                            <asp:Literal ID="litlatest" runat="server" Text='<%# Eval("latest") %>'></asp:Literal>
                        </asp:LinkButton>


                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" CommandName="lbtnIshotsale" runat="server">
                            <asp:Literal ID="lithotsale" runat="server" Text='<%# Eval("hotsale") %>'></asp:Literal>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton2" CommandName="lbtnIsspecialOffer" runat="server">
                            <asp:Literal ID="litspecialOffer" runat="server" Text='<%# Eval("specialOffer") %>'></asp:Literal>
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" />
                    </td>
                    <td>
                        <a href='product_edit.aspx?id=<%#Eval("id") %>&frompage=productInStock.aspx' class="operator">编辑</a>

                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
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
