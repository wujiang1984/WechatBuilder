<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caidan_member_manage.aspx.cs" Inherits="WechatBuilder.Web.admin.diancai.caidan_member_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>会员管理</title>
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
          <a href="shop_list.aspx" class="home"><i></i><span>点菜系统 </span></a>
            <i class="arrow"></i>             
            <span>会员管理</span>
      </div>
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

                        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th >选择</th>
                            <th >客户ID</th>
                            <th >姓名</th>   
                            <th >电话</th>
                            <th >配送地址</th>
                            <th >成功订单数</th>
                            <th >失败订单数</th>
                            <th >取消订单数</th>
                            <th >总成交额</th>
                            <th >总积分</th>  
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
                        <%# Eval("id") %>
                    </td>
                     <td>
                        <%# Eval("memberName") %>                       
                    </td>
                      <td>
                        <%# Eval("menberTel") %>                       
                    </td>   
                     <td>
                        <%# Eval("memberAddress") %>                       
                    </td>
                     <td>
                        <%# Eval("successDingdan") %>                       
                    </td>  
                    <td>
                        <%# Eval("failDingdan") %>                       
                    </td>   
                      <td>
                        <%# Eval("cancelDingdan") %>                       
                    </td> 
                    <td>
                        <%# Eval("zongcje") %>                       
                    </td>
                    <td>
                        <%# Eval("zongjifen") %>                       
                    </td>    
                   <td>
                       <%# Eval("status").ToString().ToLower()=="0"?"黑名单":"正常用户" %>                     
                    </td> 
                    <td>
                        <a  href='caidan_member_Operating.aspx?openid=<%#Eval("openid") %>&status=<%# Eval("status") %>&id=<%# Eval("id") %>&memberName=<%# Eval("memberName") %>&shopid=<%# Eval("shopid") %>' >操作</a>
                    </td>           
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"12\">暂无记录</td></tr>" : ""%>
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
