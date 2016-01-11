<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vote_list.aspx.cs" Inherits="WechatBuilder.Web.admin.vote.vote_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发起投票</title>
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

    <style>
        a.shenghe {
            color: red;
        }
    </style>

</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>发起投票</span></a>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">

                    <ul class="icon-list">
                        <li><a class="icon-btn add" href="vote_character_add.aspx?action=<%=WechatBuilder.Common.MXEnums.ActionEnum.Add %>" id="itemAddButton"><i></i><span>发起文字投票</span></a></li>
                        <li><a class="icon-btn add" href="vote_picture_add.aspx?action=<%=WechatBuilder.Common.MXEnums.ActionEnum.Add %>" id="itemBlackButton"><i></i><span>发起图片投票</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>

                    </ul>
                    <div class="l-list">
                        <ul class="rule-single-select">
                            <li>
                                <asp:DropDownList ID="ddlProperty" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProperty_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">所有属性</asp:ListItem>
                                    <asp:ListItem Value="1">文字投票</asp:ListItem>
                                    <asp:ListItem Value="2">图片投票</asp:ListItem>

                                </asp:DropDownList>
                                <%#new WechatBuilder.BLL.article_category().GetTitle(Convert.ToInt32(Eval("category_id")))%>
                            </li>
                        </ul>
                    </div>

                </div>

                <div class="r-list">

                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />

                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">搜索</asp:LinkButton>
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
                            <th>选择</th>
                            <th>标题</th>
                            <th>类型</th>
                            <th>开始时间/结束时间</th>
                            <th>外链代码</th>
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
                        <%# Eval("title") %>
                    </td>
                    <td>
                        <%# Eval("voteType").ToString().ToLower()=="1"?"文字投票":"图片投票"  %>
                    </td>
                    <td>
                        <%# Eval("beginTime") %><br />
                        <%# Eval("endTime") %>
                        
                    </td>

                    <td>
                        <a href="javascript:;"><%=yuming%>/weixin/vote/index.aspx?wid=<%=wid %>&aid=<%#Eval("id") %></a>
                    </td>

                    <td>

                        <%#voteresult(Eval("id"),Eval("wid"))  %>

                        <%#bianjiStr(Eval("id"),Eval("voteType"))  %>


                        <asp:LinkButton ID="likLingQu" runat="server" CommandName="end" CommandArgument='<%#Eval("id")%>'>结束</asp:LinkButton>

                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
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
