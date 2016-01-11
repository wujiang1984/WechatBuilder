<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_article_page_list.aspx.cs" Inherits="MxWeiXinPF.Web.admin.article.wx_article_page_list" %>


<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>单页列表</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            imgLayout();
            $(window).resize(function () {
                imgLayout();
            });
            //图片延迟加载
            $(".pic img").lazyload({ load: AutoResizeImage, effect: "fadeIn" });
            //点击图片链接
            $(".pic img").click(function () {
                //$.dialog({ lock: true, title: "查看大图", content: "<img src=\"" + $(this).attr("src") + "\" />", padding: 0 });
                var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
                if (linkUrl != "") {
                    location.href = linkUrl; //跳转到修改页面
                }
            });
        });
        //排列图文列表
        function imgLayout() {
            var imgWidth = $(".imglist").width();
            var lineCount = Math.floor(imgWidth / 222);
            var lineNum = imgWidth % 222 / (lineCount - 1);
            $(".imglist ul").width(imgWidth + Math.ceil(lineNum));
            $(".imglist ul li").css("margin-right", parseFloat(lineNum));
        }
        //等比例缩放图片大小
        function AutoResizeImage(e, s) {
            var img = new Image();
            img.src = $(this).attr("src")
            var w = img.width;
            var h = img.height;
            var wRatio = w / h;
            if ((220 / wRatio) >= 165) {
                $(this).width(220); $(this).height(220 / wRatio);
            } else {
                $(this).width(165 * wRatio); $(this).height(165);
            }
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a class="home"><i></i><span>单页列表</span></a>

        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="wx_article_page_edit.aspx?action=<%=MXEnums.ActionEnum.Add %>&channel_id=<%=this.channel_id %>"><i></i><span>新增单页</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                   
                </div>
                <div class="r-list">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                  <%--  <asp:LinkButton ID="lbtnViewImg" runat="server" CssClass="img-view" OnClick="lbtnViewImg_Click" ToolTip="图像列表视图" />
                    <asp:LinkButton ID="lbtnViewTxt" runat="server" CssClass="txt-view" OnClick="lbtnViewTxt_Click" ToolTip="文字列表视图" />--%>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--文字列表-->
        <asp:Repeater ID="rptList1" runat="server" OnItemCommand="rptList_ItemCommand">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="6%">选择</th>
                        <th align="left">标题</th>
                        <th align="left" width="35%">访问地址</th> 
                        <th align="left" width="130">发布时间</th>
                        <th align="left" width="65">排序</th>
                        <th align="left" width="110" style="display: none;">属性</th>
                        <th width="8%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td><a href="article_page_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>"><%#Eval("title")%></a></td>
                    <td>
                        <a href="javascript:;"><%#Eval("link_url")%></a> 
                    </td> 
                    <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
                    <td>
                        <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
                    <td style="display: none;">
                        <div class="btn-tools">
                            <asp:LinkButton ID="lbtnIsMsg" CommandName="lbtnIsMsg" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "msg selected" : "msg"%>' ToolTip='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "取消评论" : "设置评论"%>' />
                            <asp:LinkButton ID="lbtnIsTop" CommandName="lbtnIsTop" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_top")) == 1 ? "top selected" : "top"%>' ToolTip='<%# Convert.ToInt32(Eval("is_top")) == 1 ? "取消置顶" : "设置置顶"%>' />
                            <asp:LinkButton ID="lbtnIsRed" CommandName="lbtnIsRed" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_red")) == 1 ? "red selected" : "red"%>' ToolTip='<%# Convert.ToInt32(Eval("is_red")) == 1 ? "取消推荐" : "设置推荐"%>' />
                            <asp:LinkButton ID="lbtnIsHot" CommandName="lbtnIsHot" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_hot")) == 1 ? "hot selected" : "hot"%>' ToolTip='<%# Convert.ToInt32(Eval("is_hot")) == 1 ? "取消热门" : "设置热门"%>' />
                            <asp:LinkButton ID="lbtnIsSlide" CommandName="lbtnIsSlide" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "pic selected" : "pic"%>' ToolTip='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "取消幻灯片" : "设置幻灯片"%>' />
                        </div>
                    </td>
                    <td align="center"><a href="wx_article_page_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>">修改</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
</table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/文字列表-->

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
