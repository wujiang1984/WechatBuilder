<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlackManage.aspx.cs" Inherits="MxWeiXinPF.Web.admin.message.BlackManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        //function parentToIndex(id) {
        //    parent.location.href = "/admin/Index.aspx?id=" + id;

        //}

        $(function () {

        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <!--导航栏-->
        <div class="location">
          <a href="message_list.aspx" class="home"><i></i><span>留言管理</span></a>
            <i class="arrow"></i>

            <span>黑名单管理</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <div class="toolbar-wrap">
            <div id="Div1" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">

                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>取消拉黑</span></asp:LinkButton></li>
                    </ul>
                </div>
                <div class="r-list">

                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
        </div>


        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th>选择</th>
                            <th>wid</th>
                            <th>用户openid</th>
                            <th>拉黑时间</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody class="ltbody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="td_c">
                    <td>
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("openId")%>' runat="server" />
                    </td>
                    <td>
                        <%# Eval("wid") %>
                    </td>
                    <td>
                        <%# Eval("openid") %>
                    </td>
                    <td>
                        <%# Eval("blacktime") %>
                        
                    </td>

                    <td>
                        <a href='BlackCancle.aspx?wid=<%#Eval("wid")%>&openid=<%#Eval("openid") %>'>取消拉黑</a>

                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
                 </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>





        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
    </form>
</body>
</html>
