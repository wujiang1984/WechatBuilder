<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caidan_baobiao.aspx.cs" Inherits="MxWeiXinPF.Web.admin.diancai.caidan_baobiao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>统计报表</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Listcss.css" rel="stylesheet" type="text/css" />

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
        <div class="location">
            <a href="shop_list.aspx" class="home"><i></i><span>点菜系统</span></a>
            <i class="arrow"></i>
            <span>统计报表</span>
        </div>

        <div class="line10"></div>
        <!--/导航栏-->

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">营收统计</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">销量统计</a></li>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <table class="ListProduct" border="0" width="100%">
                <thead>
                    <tr>
                        <th></th>
                        <th>今日</th>
                        <th>昨日</th>
                        <th>本月</th>
                        <th>上月</th>
                        <th>总计</th>
                    </tr>
                </thead>
                <tbody>

                    <tr>
                        <td>成功订单数</td>
                        <td><%=dingdantoday %></td>
                        <td><%=dingdanzuotian %></td>
                        <td><%=dingdanbenyue %></td>
                        <td><%=dingdanshangyue %></td>
                        <td><%=dingdanzj %></td>
                    </tr>
                    <tr>
                        <td>营业额</td>
                        <td><%=yyetoday %></td>
                        <td><%=yyezuotian %></td>
                        <td><%=yyebenyue %></td>
                        <td><%=yyeshangyue %></td>
                        <td><%=yyezj %></td>
                    </tr>
                    <tr>
                        <td>新增顾客</td>
                        <td><%=khtoday %></td>
                        <td><%=khzuotian %></td>
                        <td><%=khbenyue %></td>
                        <td><%=khshangyue %></td>
                        <td><%=khzj %></td>
                    </tr>

                </tbody>
            </table>
        </div>
        <div class="tab-content" style="display: none">
            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <thead>
                            <tr>
                                <th>商品名称</th>
                                <th>今日</th>
                                <th>昨日</th>
                                <th>本月</th>
                                <th>上月</th>
                            </tr>
                        </thead>
                        <tbody class="ltbody">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="td_c">
                        <td>
                            <%# Eval("cpName") %>
                        </td>
                        <td> <%# Eval("jintian") %></td>
                        <td> <%# Eval("zuotian") %></td>
                        <td> <%# Eval("benyue") %></td>

                        <td> <%# Eval("shangyue") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
                 </tbody>
                </table>
                </FooterTemplate>
            </asp:Repeater>


            <div class="line20"></div>
           
        </div>


    </form>
</body>
</html>
