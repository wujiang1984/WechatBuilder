<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_score.aspx.cs" Inherits="MxWeiXinPF.Web.admin.ucard.user_score" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员积分详情</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
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
            <a href="user_list.aspx?id=<%=sid %>" class="back"><i></i><span>返回会员列表</span></a>

            <a href="business_list.aspx" class="home"><i></i><span>会员卡商会员管理</span></a>
            <i class="arrow"></i>
            <a href="user_list.aspx?id=<%=sid %>"><span>会员列表</span></a>
            <i class="arrow"></i>
            <span>会员积分详情</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        
                     </ul>
                </div>
                <div class="l-list">
                    &nbsp;  &nbsp; &nbsp; 姓名:<asp:Label ID="lblrealName" runat="server" Text=""></asp:Label>
                      &nbsp;  &nbsp; 编号:<asp:Label ID="lblCardNo" runat="server" Text=""></asp:Label>
                      &nbsp;  &nbsp; 电话:<asp:Label ID="lblTel" runat="server" Text=""></asp:Label>
                      &nbsp;  &nbsp; 地址:<asp:Label ID="lblAddr" runat="server" Text=""></asp:Label>
                </div>

                <div class="r-list">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                </div>


            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                <HeaderTemplate>

                    <thead>
                        <tr>
                            <th width="5%">选择</th>
                            <th width="15%">日期</th>
                            <th width="10%">消费金额</th>
                            <th width="10%">积分情况</th>

                            <th>消费描述</th>
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
                            <%# Eval("addTime") %> 
                        </td>
                        <td>
                            <%# Eval("consumeMoney") %> 
                        </td>
                        <td>
                            <%# Eval("score") %> 
                        </td>
                        <td>
                            [<%# Eval("moduleType") %>]<%# Eval("moduleActionName")%>
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
