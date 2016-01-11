<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dianyuan_manage.aspx.cs" Inherits="MxWeiXinPF.Web.admin.diancai.dianyuan_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>店员管理</title>
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
            <span>店员管理</span>
        </div>

               <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn add" href="dianyuan_add.aspx?action=<%=MxWeiXinPF.Common.MXEnums.ActionEnum.Add %>&shopid=<%=shopid %>&type=add"  id="itemAddButton"><i></i><span>新增店员</span></a></li>

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
                            <th >编号</th>
                            <th >姓名</th>   
                            <th >电话</th>   
                            <th >用户名</th>   
                            <th >密码</th>  
                            <th >状态</th>   
                            <th >分店</th>   
                            <th >到岗时间</th>   
                            <th >离职时间</th> 
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
                        <%# Eval("dianyuanName") %>                       
                    </td>
                      <td>
                        <%# Eval("dianyuanTel") %>                       
                    </td>
                     <td>
                        <%# Eval("userName") %>                       
                    </td>
                    <td>
                        <%# Eval("pwd") %>                       
                    </td>
                    <td>
                        <%# Eval("userStatus").ToString().ToLower()=="1"?"在职":"离职" %>    
                       
                    </td>
                     <td>
                        <%# Eval("fendian") %>                       
                    </td>
                   <td>
                        <%# Eval("beginTime") %>                       
                    </td>
                    <td>
                        <%# Eval("endTime") %>                       
                    </td>
                    <td>
                  <a  href='dianyuan_add.aspx?shopid=<%#Eval("shopid") %>&type=edite&id=<%#Eval("id") %>' >编辑</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
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
