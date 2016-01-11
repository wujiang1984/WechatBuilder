<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dingdan_manage.aspx.cs" Inherits="WechatBuilder.Web.admin.diancai.dingdan_manage" %>

<!DOCTYPE html>

<html >
<head id="Head1" runat="server">
    <title>订单管理</title>
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
        color:red;
        
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">

          <div class="location">
            <a href="shop_list.aspx" class="home"><i></i><span>点菜系统</span></a>
            <i class="arrow"></i>            
            <span>订单管理</span>
        </div>
        <!--/导航栏-->
         <div class="mytips">        
            1、确认订单后，用户不能再取消该订单；被设置为无效的订单，将成为失败订单！
             <br />
            2、交易成功的订单会计入销售统计；交易失败的订单不会计入销售统计，多次交易失败的客户建议加入黑名单！
             <br />
            3、确认订单后，用户不能再取消该订单；被设置为无效的订单，将成为失败订单！
         </div>
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
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
                            <th >选择</th>
                            <th >订单号</th>
                            <th >桌号</th>
                            <th >姓名</th> 
                            <th >电话</th> 
                            <th >配送地址</th> 
                            <th >下单时间</th> 
                            <th >备注</th>   
                            <th >总价</th>
                            <th >状态</th>                     
                            <th >操作</th>
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
                        <%# Eval("orderNumber") %>
                    </td>
                    <td>
                        <%# Eval("deskNumber") %>
                    </td>
                     <td>
                        <%# Eval("customerName") %>                        
                    </td>
                    <td>
                       <%# Eval("customerTel") %>                        
                    </td>
                     <td>
                       <%# Eval("address") %>                        
                    </td>
                    <td>
                       <%# Eval("oderTime") %>                        
                    </td>
                    <td>
                       <%# Eval("oderRemark") %>                        
                    </td>
                    <td>
                       <%# Eval("payAmount") %>                        
                    </td>
                     <td>
                     <%# Eval("payStatusStr")%>                          
                    </td>
                     <td>   
                      
                         <a  href='dingdan_deal.aspx?id=<%#Eval("id") %>&shopid=<%=shopid %>'>操作</a>                  
                
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
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
    </form>
</body>
</html>
