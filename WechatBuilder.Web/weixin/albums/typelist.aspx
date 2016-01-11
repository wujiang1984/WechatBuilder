<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="typelist.aspx.cs" Inherits="WechatBuilder.Web.weixin.albums.typelist" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>全部分类</title>
    <meta charset="UTF-8">

    <meta name="viewport" content=" initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/templates.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <!--_header-->
        <div class="lay_header" style="height: 45px">
            <div class="lay_toptab mod_tab" id="lay_head">
                <%-- <a class="tab_item" href="typelist.aspx?wid=<%=wid%>&openid=<%=openid%>"><i class="qb_icon icon_goback"></i></a>

                <a class="tab_item" href="index.aspx?wid=<%=wid%>&openid=<%=openid%>"><i class="qb_icon icon_icenter"></i></a>--%>
            </div>

            <div class="lay_toptab mod_tab fixed qb_none" id="lay_head_fixed">
                <%-- <a class="tab_item" href="typelist.aspx?wid=<%=wid%>&openid=<%=openid%>"><i class="qb_icon icon_goback"></i></a>

                <a class="tab_item" href="index.aspx?wid=<%=wid%>&openid=<%=openid%>"><i class="qb_icon icon_icenter"></i></a>--%>
            </div>



        </div>
        <!--/_header-->
        <div class="lay_page ">
            <div class="lay_page_wrap">
                <div class="fn_ad ad_bigpic">
                    <!--分类信息 -->
                     <asp:Literal ID="litTypelist" runat="server" EnableViewState="false"></asp:Literal>
                    <!--分类信息 end -->

                </div>


                <!--_bottom-->
                <div class="lay_footer qb_tac qb_fs_s mod_mb15">
                    <div class="fn_quicklinks">
                        <a class="mod_color_weak" href="index.aspx?wid=<%=wid%>&openid=<%=openid%>">首页</a>
                        <span class="mod_color_comment">|</span>
                        <a class="mod_color_weak" href="/index.aspx?wid=<%=wid%>&openid=<%=openid%>">官网</a>
                        <span class="mod_color_comment">|</span>
                        <a class="mod_color_weak" href="typelist.aspx?wid=<%=wid%>&openid=<%=openid%>">相册分类</a>
                    </div>
                    <div class="fn_copyright qb_bfc">
                        <div class="mod_color_comment bfc_c">
                            <asp:Literal ID="litCopyRight" runat="server" EnableViewState="false"></asp:Literal></div>
                    </div>
                </div>

                <!--/_bottom-->

            </div>
        </div>
        <input type="hidden" value="5" id="hidwid" name="hidwid">
        <input type="hidden" value="loseopenid" id="openid" name="openid">
        <div class="qb_quick_tip qb_none" id="bubble"></div>
        <script src="js/zepto.min.js"></script>

        <script type="text/javascript">

            mobile.o2ocn.topic.init();

        </script>



    </form>
</body>
</html>
