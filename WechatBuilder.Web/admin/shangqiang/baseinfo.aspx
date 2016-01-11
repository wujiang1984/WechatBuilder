<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baseinfo.aspx.cs" Inherits="WechatBuilder.Web.admin.shangqiang.baseinfo" %>

<%@ Import Namespace="WechatBuilder.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>微信上墙管理</title>
    <link rel="stylesheet" type="text/css" href="../../images/font-awesome/css/font-awesome.css" media="all" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />

</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a class="home"><i></i><span>微信上墙管理</span></a>

        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="act_edit.aspx?action=<%=MXEnums.ActionEnum.Add %>"><i></i><span>新增活动</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本类别，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="6%">选择</th>
                        <th align="left">活动名称</th>
                        <th align="left" width="6%">开启</th>
                        <th align="left" width="170">时间范围</th>
                        <th align="left" width="37%">照片墙地址</th>
                        <th width="20%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </td>

                    <td>
                        <a href="act_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("actName")%></a>
                    </td>
                    <td><%#Eval("isOpen").ToString().ToLower()=="true"?"开启":"关闭"%></td>
                    <td>开始：<%#Eval("beginDate")%><br />
                        结束：<%#Eval("endDate")%>
                        
                    </td>
                    <td>
                        <%#Eval("link_url")%> 
                    </td>
                    <td align="center">
                        <a href="act_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a>
                        <a href="photo_list.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">图片列表</a>
                        <a href="heimingdan.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">黑名单</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
</table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/列表-->
    </form>
</body>
</html>

