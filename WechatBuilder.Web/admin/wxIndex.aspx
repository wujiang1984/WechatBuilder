<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxIndex.aspx.cs" Inherits="WechatBuilder.Web.admin.wxIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>微信帐号管理</title>
    <link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/jquery.nicescroll.js"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="js/layout.js"></script>
    <script type="text/javascript">
        //页面加载完成时
        $(function () {
            //检测IE
            if ('undefined' == typeof (document.body.style.maxHeight)) {
                window.location.href = 'ie6update.html';
            }

            //初始化导航菜单
            initMenuTree(true);
          
            //设置左边导航滚动条
            $("#sidebar-nav").niceScroll({ touchbehavior: false, cursorcolor: "#7C7C7C", cursoropacitymax: 0.6, cursorwidth: 5 });
            $("#pop-menu .list-box").niceScroll({ touchbehavior: false, cursorcolor: "#7C7C7C", cursoropacitymax: 0.6, cursorwidth: 5 });
            $("#pop-menu .list-box").getNiceScroll().hide();
            //设置主导航菜单显示和隐藏
            navresize();

        });

        //页面尺寸改变时
        $(window).resize(function () {
            navresize();
        });

       
        //初始化导航菜单
        function initMenuTree(islink) {
            //先清空NAV菜单内容
            $("#nav").html('');
            $("#sidebar-nav .list-box .list-group").each(function (i) {
                //添加菜单导航
                var navHtml = $('<li><i class="icon-' + i + '"></i><span>' + $(this).attr("name") + '</span></li>').appendTo($("#nav"));
                //默认选中第一项
                if (i == 0) {
                    $(this).show();
                    navHtml.addClass("selected");
                }
                //为菜单添加事件
                navHtml.click(function () {
                    $("#nav li").removeClass("selected");
                    $(this).addClass("selected");
                    $("#sidebar-nav .list-box .list-group").hide();
                    $("#sidebar-nav .list-box .list-group").eq($("#nav li").index($(this))).show();
                });
                //为H2添加事件
                $(this).children("h2").click(function () {
                    if ($(this).next("ul").css('display') != 'none') {
                        return false;
                    }
                    $(this).siblings("ul").slideUp(300);
                    $(this).next("ul").slideDown(300);
                    //展开第一个菜单
                    if ($(this).next("ul").children("li").first().children("ul").length > 0) {
                        //$(this).next("ul").children("li").first().children("a").children(".expandable").last().removeClass("close");
                        //$(this).next("ul").children("li").first().children("a").children(".expandable").last().addClass("open");
                        //$(this).next("ul").children("li").first().children("ul").first().show();
                    }
                });

                //首先隐藏所有的UL
                $(this).find("ul").hide();
                //绑定树菜单事件.开始
                $(this).find("ul").each(function (j) { //遍历所有的UL
                    //遍历UL第一层LI
                    $(this).children("li").each(function () {
                        liObj = $(this);
                        //插入选中的三角
                        var spanObj = liObj.children("a").children("span");
                        $('<div class="arrow"></div>').insertBefore(spanObj); //插入到span前面
                        //判断是否有子菜单和设置距左距离
                        var parentExpandableLen = liObj.parent().parent().children("a").children(".expandable").length; //父节点的左距离
                        if (liObj.children("ul").length > 0) { //如果有下级菜单
                            //删除链接，防止跳转
                            liObj.children("a").removeAttr("href");
                            //更改样式
                            liObj.children("a").addClass("pack");
                            //设置左距离
                            var lastExpandableObj;
                            for (var n = 0; n <= parentExpandableLen; n++) { //注意<=
                                lastExpandableObj = $('<div class="expandable"></div>').insertBefore(spanObj); //插入到span前面
                            }
                            //设置最后一个为闭合+号
                            lastExpandableObj.addClass("close");
                            //创建和设置文件夹图标
                            $('<div class="folder close"></div>').insertBefore(spanObj); //插入到span前面
                            //隐藏下级的UL
                            liObj.children("ul").hide();
                            //绑定单击事件
                            liObj.children("a").click(function () {
                                //搜索所有同级LI且有子菜单的左距离图标为+号及隐藏子菜单
                                $(this).parent().siblings().each(function () {
                                    //alert($(this).html());
                                    if ($(this).children("ul").length > 0) {
                                        //设置自身的左距离图标为+号
                                        $(this).children("a").children(".expandable").last().removeClass("open");
                                        $(this).children("a").children(".expandable").last().addClass("close");
                                        //隐藏自身子菜单
                                        $(this).children("ul").slideUp(300);
                                    }
                                });

                                //设置自身的左距离图标为-号
                                $(this).children(".expandable").last().removeClass("close");
                                $(this).children(".expandable").last().addClass("open");
                                //显示自身父节点的UL子菜单
                                $(this).parent().children("ul").slideDown(300);
                            });
                        } else {
                            //设置左距离
                            for (var n = 0; n < parentExpandableLen; n++) {
                                $('<div class="expandable"></div>').insertBefore(spanObj); //插入到span前面
                            }
                            //创建和设置文件夹图标
                            $('<div class="folder open"></div>').insertBefore(spanObj); //插入到span前面
                            //绑定单击事件
                            liObj.children("a").click(function () {
                                //删除所有的选中样式
                                $("#sidebar-nav .list-box .list-group ul li a").removeClass("selected");
                                //自身添加样式
                                $(this).addClass("selected");
                                //保存到cookie
                                addCookie("dt_manage_navigation_cookie", $(this).attr("navid"), 240);
                            });
                        }
                    });
                    //显示第一个UL
                    if (j == 0) {
                        $(this).show();
                        //展开第一个菜单
                        if ($(this).children("li").first().children("ul").length > 0) {
                            $(this).children("li").first().children("a").children(".expandable").last().removeClass("close");
                            $(this).children("li").first().children("a").children(".expandable").last().addClass("open");
                            $(this).children("li").first().children("ul").show();
                        }
                    }
                });
                //绑定树菜单事件.结束
            });
            //定位或跳转到相应的菜单
            
        }

        //导航菜单显示和隐藏
        function navresize() {
            var docWidth = $(document).width();
            if (docWidth < 1004) {
                $(".nav li span").hide();
            } else {
                $(".nav li span").show();
            }
        }

    </script>
</head>
<body class="indexbody">
    <form id="form1" runat="server">
        

        <div class="header">
            <div class="header-box">
              <a href="wxIndex.aspx">  <h1 class="logo"></h1></a>
                <ul id="nav" class="nav"></ul>
                <div class="nav-right">
                    <div class="icon-info">
                        <span>您好，<%=admin_info.user_name %><br />
                            <%=new WechatBuilder.BLL.manager_role().GetTitle(admin_info.role_id) %>
                        </span>
                    </div>
                    <div class="icon-option">
                        <i></i>
                        <div class="drop-box">
                            <div class="arrow"></div>
                            <ul class="drop-item">
                                <li><a onclick="linkMenuTree(false, '');" href="manager/manager_pwd.aspx" target="mainframe">修改密码</a></li>
                                <li>
                                    <asp:LinkButton ID="lbtnExit" runat="server" OnClick="lbtnExit_Click">注销登录</asp:LinkButton></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="main-sidebar">
            <div id="sidebar-nav" class="sidebar-nav">
                <div class="list-box">
                    <div class="list-group" name="微信帐号管理" style="display: block;">
                        <h2>微信帐号管理<i></i></h2>
                        <ul style="display: block;">
                             <li>
                                <a navid="myinfoedit" href="manager/editormyinfo.aspx" target="mainframe" class="item ">
                                    <span>个人资料修改</span>
                                </a>
                            </li>
                            <li>
                                <a navid="list_weixin" href="weixin/myweixinlist.aspx" target="mainframe" class="item selected">
                                    <span>我的公众帐号</span>
                                </a>
                            </li>
                            <li>
                                <a navid="add_weixin" href="weixin/editorWeiXin.aspx" target="mainframe" class="item">
                                    <span>添加公众帐号</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="main-container">
            <iframe id="mainframe" name="mainframe" frameborder="0" src="weixin/myweixinlist.aspx"></iframe>
        </div>
    </form>
</body>
</html>
