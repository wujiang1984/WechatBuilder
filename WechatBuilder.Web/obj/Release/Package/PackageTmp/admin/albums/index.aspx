<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.admin.albums.index" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>微相册管理</title>
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
            //设置头部图片
            $("#setBanner").click(function () {

                showGuiZeDialog();
            });

        });

        //设置头部图片
        function showGuiZeDialog() {
            var id = $("#lblWid").text();
            var contenturl = "url:albums/albumsSys.aspx?wid=" + id;

            var m = $.dialog({
                id: 'dialogKWGuiZe',
                fixed: true,
                lock: true,
                max: false,
                min: false,
                title: "相册头部图片",
                content: contenturl,
                height: 250,
                width: 650 
            });
        }

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:;" class="home"><i></i><span>微相册管理</span></a>
        </div>
        <!--/导航栏-->
        <asp:Label ID="lblWid" runat="server" Text="" style="display:none;"></asp:Label>
         <div class="mytips">
                所有相册的展示地址：<a href="javascript:;"><asp:Literal ID="litwUrl" runat="server" Text=""></asp:Literal></a>
         </div>


        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="icon-btn save" href="javascript:;" id="setBanner"><i></i><span>相册设置</span></a></li>
                        <li><a class="icon-btn folder" href="typelist.aspx"><i></i><span>相册分类管理</span></a></li>
                        <li><a class="icon-btn add" href="editalbums.aspx?action=<%=MXEnums.ActionEnum.Add %>" id="itemAddButton"><i></i><span>新增相册</span></a></li>

                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                     <div class="menu-list">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlCategoryId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoryId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                         
                    </div>

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
                            <th width="5%">选择</th>
                           
                            <th width="25%">封面图片</th>
                              <th>相册名称</th>
                            <th width="15%">分类</th>
                            <th width="10%">显示描述</th>
                            <th width="10%">隐藏相册</th>
                            <th width="8%">排序</th>
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
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("facePic") %>' Style="max-height: 80px;" />

                    </td>
                     <td>
                        <%# Eval("aName") %>
                    </td>
                     <td>
                        <%# Eval("typeName") %>
                    </td>
                    <td>
                        <%# Eval("showContent").ToString().ToLower()=="true"?"是":"否" %> 
                       
                    </td>

                    <td>
                        <%# Eval("isHidden").ToString().ToLower()=="true"?"否":"是" %> 
                      
                    </td>
                    <td>
                        <%# Eval("seq") %>
                    </td>
                    <td>
                        <a href='editalbums.aspx?id=<%#Eval("id") %>&action=<%=MXEnums.ActionEnum.Edit %>' class="operator">编辑</a>
                        <a href='photolist.aspx?id=<%#Eval("id") %>&action=<%=MXEnums.ActionEnum.Edit %>' class="operator">图片管理</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
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
