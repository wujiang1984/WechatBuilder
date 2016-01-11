<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caipin_manage.aspx.cs" Inherits="WechatBuilder.Web.admin.diancai.caipin_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>菜品管理</title>
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
            <span>菜品管理</span>
        </div>
       <div class="mytips">        
            提醒：请先设置好菜品分类，再添加新的菜品，点击设置菜品分类
         </div>
       <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn add" href="caipin_manage_add.aspx?action=<%=WechatBuilder.Common.MXEnums.ActionEnum.Add %>&shopid=<%=shopid %>&type=add"  id="itemAddButton"><i></i><span>新增商品</span></a></li>

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

          <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th >选择</th>
                           
                            <th >名称</th>
                            <th >市场价格</th>   
                            <th >销售价格</th> 
                            <th >类别</th> 
                            <th >浏览次数</th>
                            <th >时间</th>     
                            <th >排序值</th>         
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
                        <%# Eval("cpName") %>
                    </td>
                     <td>
                        <%# Eval("cpPrice") %>
                        
                    </td>
                    <td>
                        <%# Eval("zkPrice") %>
                        
                    </td>
                    <td>
                        <%# Eval("categoryName") %>
                        
                    </td>
                     <td>
                        <%# Eval("scan") %>
                        
                    </td>
                    <td>
                        <%# Eval("createDate") %>
                        
                    </td>
                    <td>
                        <%# Eval("sortid") %>
                        
                    </td>
                  <td>
                  <a  href='caipin_manage_add.aspx?id=<%#Eval("id") %>&type=edite&shopid=<%#Eval("shopid")%>' >编辑</a>
                  </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
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
