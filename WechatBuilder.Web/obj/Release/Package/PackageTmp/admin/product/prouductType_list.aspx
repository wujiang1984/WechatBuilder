<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prouductType_list.aspx.cs" Inherits="MxWeiXinPF.Web.admin.product.prouductType_list" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>产品库分类管理</title>
    <link rel="stylesheet" type="text/css" href="../../images/font-awesome/css/font-awesome.css" media="all" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />

</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a   class="home"><i></i><span>产品库分类管理</span></a>
            
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="productType_edit.aspx?action=<%=MXEnums.ActionEnum.Add %>"><i></i><span>新增分类</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本类别，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                    <div class="menu-list">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlPStore" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPStore_SelectedIndexChanged"></asp:DropDownList>
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
        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="6%">选择</th>
                        <th align="left" width="6%">编号</th>
                        <th align="left">分类名称</th>
                         <th align="left">产品库</th>
                        <th align="left" width="12%">图标</th>
                        <th align="left" width="37%">链接地址</th>
                        <th align="left" width="5%">排序</th>
                        <th width="5%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        <asp:HiddenField ID="hidLayer" Value='<%#Eval("class_layer") %>' runat="server" />
                    </td>
                    <td><%#Eval("id")%></td>
                    <td>
                        <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                        <a href="productType_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("tName")%></a>
                    </td>
                     <td><%#Eval("storeName")%></td>
                    <td>
                        <div class="wxico_container">
                            <asp:Literal ID="litImgInfo" runat="server" Text='<%#Eval("icoPic")%>'></asp:Literal>
                        </div>
                    </td>
                    <td>
                        <%#Eval("tUrl")%> 
                    </td>

                    <td>
                        <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
                    <td align="center">
                        <a href="productType_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a>
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
