<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caidan_member_Operating.aspx.cs" Inherits="MxWeiXinPF.Web.admin.diancai.caidan_member_Operating" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>客户状态设置</title>
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
          <i class="arrow"></i><span><a href="caidan_member_manage.aspx?shopid=<%=shopid %>" >会员管理</a></span>
            <i class="arrow"></i>             
            <span>客户状态设置</span>
      </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">客户状态设置</a></li>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>

         <div  class="tab-content" >
                 <dl>
                    <dt>客户状态调整为：</dt>
                    <dd>
                        <select name="type" id="type"  runat="server">
                            <option value="0">加入黑名单</option>
                            <option value="1">移除黑名单</option>
                        </select>
                    </dd>
                </dl>
             </div>

           <div class="page-footer" >
            <div class="btn-list">      
             <asp:Button ID="save_status" runat="server"  CssClass="btn" Text="提交" OnClick="save_status_Click" />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
