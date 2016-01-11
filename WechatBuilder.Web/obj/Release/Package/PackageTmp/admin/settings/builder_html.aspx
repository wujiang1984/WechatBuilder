<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="builder_html.aspx.cs" Inherits="MxWeiXinPF.Web.admin.settings.builder_html" %>
<%@ Import namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>生成静态页面</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //全局变量声明
    var isLock = false; //是否锁定正在执行操作
    var dialogDG; //dialog窗口实例

    //①提示且生成相应的频道
    function builerTip(obj) {
        //检查是否正在执行操作
        if (isLock) {
            $.dialog.alert('上次操作未完成，不可同时执行！');
            return false;
        }
        //提示是否执行
        $.dialog.confirm('此操作将会消耗大量的资源，确认要继续吗？', function () {
            getBuilerUrl(obj);
        });
    }
    //②发送AJAX请求获取生成地址
    function getBuilerUrl(obj) {
        //如dialog窗口不存在则创建
        if (!dialogDG || dialogDG.closed) {
            createDialogObj();
        }
        //重置dialog窗口的值
        dialogDG.title('正在获取信息...');
        dialogDG.content('正在加载，请稍候...');
        isLock = true; //锁定操作
        //发送AJAX请求
        $.ajax({
            url: $(obj).attr("url"),
            type: "POST",
            success: function (data) {


                if (data == 0) {
                    dialogDG.title('执行生成处理完毕');
                    dialogDG.content('该栏目下没有内容！');
                    isLock = false; //解除锁定
                }
                else if (data == -1) {
                    dialogDG.title('执行请求完毕');
                    dialogDG.content('<font color=red>登陆超时！</font>');
                    isLock = false; //解除锁定
                }
                else if (data == -2) {
                    dialogDG.title('执行请求完毕');
                    dialogDG.content('<font color=red>您没有操作生成静态的权限！</font>');
                    isLock = false; //解除锁定
                }
                else if (data == -3) {
                    dialogDG.title('执行请求完毕');
                    dialogDG.content('<font color=red>您还未开启生成静态功能！<a navid=\"site_config\" href=\"settings/sys_config.aspx\" target=\"mainframe\">立即开启</a></font>');
                    isLock = false; //解除锁定
                }
                else {
                    var json = eval(data);

             
                    if (json == "") {
                        dialogDG.title('执行生成处理完毕');
                        dialogDG.content('<font color=red>没有需要生成数据！</font>');
                        isLock = false; //解除锁定
                    }
                    else {
                        execBuilerHtml(json, 0);
                    }
                }
            }
        });
    }
    //③迭代执行生成
    function execBuilerHtml(jsonUrl, k) {

       
        $.ajax({
            url: jsonUrl[k],
            type: "POST",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            error: function () {
                getBuilerStatus(jsonUrl, k, "需要生成的静态页面路径有误！");
            },
            success: function (data) {
                if (data != 1 && data != 2 && data != 0)
                    data = "错误";
                getBuilerStatus(jsonUrl, k, data);
            }
        });
    }
    //④返回执行结果及状态
    function getBuilerStatus(jsonUrl, k, msg) {
        var fodname = jsonUrl[k].split('&catalogue=');
        var fname = jsonUrl[k].split('&html_filename=');
        fname = fname[1].split('&catalogue=');
        fname[0] = unescape(fname[0]);
        var finame = !fodname[1] ? fname[0] + '.html' : fodname[1];

        var spanTxt = msg == 0 ? '<span class="suc">成功</span>' : '<span class="error">失败</span>';
        var linkTxt = spanTxt + '<a href="<%=siteConfig.webpath %>' + finame + '" target="_blank">/' + finame + '</a>';

        dialogDG.title('已完成页面生成' + '[' + jsonUrl.length + '/' + (k + 1) + ']');
        if ($(".build-box", parent.document).length == 0) {
            dialogDG.content('<div class="build-box"></div>');
        }
        $(".build-box", parent.document).append('<div class="xlist">' + linkTxt + '</div>');
        if (k == jsonUrl.length - 1) {
            isLock = false; //解除锁定
            //完成提示
            $.dialog.tips('页面全部生成完毕', 2, '32X32/succ.png', function () { });
        } else {
            k++;
            execBuilerHtml(jsonUrl, k);
        }
    }
    //创建dialog窗口
    function createDialogObj() {
        dialogDG = $.dialog({
            id: 'buildDialog',
            width: 300,
            height: 150,
            padding: '5px',
            left: '99%',
            top: '99%',
            fixed: true,
            resize: false,
            min: false,
            max: false
        });
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>界面管理</span>
  <i class="arrow"></i>
  <span>生成静态</span>
</div>
<!--/导航栏-->
<div class="line20"></div>

<!--列表-->
<asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th align="left" width="50%" style="padding-left:10px;">频道列表</th>
    <th align="left">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td style="padding-left:10px;white-space:nowrap;word-break:break-all;overflow:hidden;">
      <span class="folder-open"></span>
      <%#Eval("title")%>
    </td>
    <td>
      <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=<%#Eval("build_path")%>&name=&type=index" onclick="builerTip(this);">生成首页</a>
    </td>
  </tr>
  <asp:Repeater ID="rptChannel" runat="server">
  <ItemTemplate>
  <tr>
    <td style="padding-left:10px;">
      <span class="folder-line"></span>
      <span class="folder-open"></span>
      <%#Eval("title")%>
    </td>
    <td>
      <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=<%# DataBinder.Eval((Container.NamingContainer.NamingContainer as RepeaterItem).DataItem, "build_path") %>&name=<%#Eval("name")%>" onclick="builerTip(this);">全部生成</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=<%# DataBinder.Eval((Container.NamingContainer.NamingContainer as RepeaterItem).DataItem, "build_path") %>&name=<%#Eval("name")%>&type=list" onclick="builerTip(this);">生成列表页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=<%# DataBinder.Eval((Container.NamingContainer.NamingContainer as RepeaterItem).DataItem, "build_path") %>&name=<%#Eval("name")%>&type=category" onclick="builerTip(this);">生成栏目页</a>
      | <a href="javascript:;" url="../../tools/admin_ajax.ashx?action=get_builder_urls&lang=<%# DataBinder.Eval((Container.NamingContainer.NamingContainer as RepeaterItem).DataItem, "build_path") %>&name=<%#Eval("name")%>&type=detail" onclick="builerTip(this);">生成详细页</a>
    </td>
  </tr>
  </ItemTemplate>
  </asp:Repeater>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"2\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->
</form>
</body>
</html>
