<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.admin.pano360.index" %>


<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>360全景图管理</title>
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
            <a href="javascript:;" class="home"><i></i><span>360全景图管理</span></a>
        </div>
        <!--/导航栏-->
        <asp:Label ID="lblWid" runat="server" Text="" Style="display: none;"></asp:Label>
        <div class="mytips">
            所有全景图展示地址：<a href="javascript:;"><asp:Literal ID="litwUrl" runat="server" Text=""></asp:Literal></a>
            <br />
            360全景制作最主要的是有好的拍摄设备现场取景和细节的处理! <a href="http://demowx.duapp.com/tutorial/page1.html">请看详细教程</a>
        </div>


        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn add" href="editpano.aspx?action=<%=MXEnums.ActionEnum.Add %>" id="itemAddButton"><i></i><span>360全景图</span></a></li>

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

        <asp:Repeater ID="rptList" runat="server"  >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <thead>
                        <tr>
                            <th width="5%">选择</th>

                            <th width="25%">景点名称</th>
                            <th width="10%">前方图片</th>
                            <th width="10%">右方图片</th>
                            <th width="10%">后方图片</th>

                            <th width="10%">左方图片</th>
                            <th width="10%">顶部图片</th>
                            <th width="10%">底部图片</th>

                            <th width="12%">操作</th>
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
                        <%# Eval("jdName") %>
                    </td>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("pic_front") %>'   CssClass="panolistpic" />
                    </td>
                   
                     <td>
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("pic_right") %>' CssClass="panolistpic" />
                    </td>

                     <td>
                        <asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("pic_behind") %>' CssClass="panolistpic" />
                    </td>

                     <td>
                        <asp:Image ID="Image4" runat="server" ImageUrl='<%# Eval("pic_left") %>' CssClass="panolistpic" />
                    </td>

                     <td>
                        <asp:Image ID="Image5" runat="server" ImageUrl='<%# Eval("pic_top") %>' CssClass="panolistpic" />
                    </td>

                     <td>
                        <asp:Image ID="Image6" runat="server" ImageUrl='<%# Eval("pic_bottom") %>' CssClass="panolistpic"/>
                    </td>
 
                    <td>
                        <a href='editpano.aspx?id=<%#Eval("id") %>&action=<%=MXEnums.ActionEnum.Edit %>' class="operator">编辑</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
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
