<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="type_edit.aspx.cs" Inherits="WechatBuilder.Web.admin.albums.type_edit" %>


<%@ Import Namespace="WechatBuilder.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑相册--分类</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
            $(".attach-btn").click(function () {
                showAttachDialog();
            });


        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
         <asp:HiddenField ID="hidwid" runat="server" Value="0" />
        <asp:HiddenField ID="hidid" runat="server" Value="0" />

        <!--导航栏-->
        <div class="location">
            <a href="index.aspx" class="home"><i></i><span>微相册管理</span></a>
            <i class="arrow"></i>
            <a href="typelist.aspx"><span>相册分类列表</span></a>
            <i class="arrow"></i>
            <span>相册分类编辑</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">相册分类编辑</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>分类名称</dt>
                <dd>
                   
                    <asp:TextBox ID="txttName" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*尽量简单，不要超过20字.</span>
                </dd>
            </dl>
            <dl>
                <dt>头部图片</dt>
                <dd>
                    <asp:Image ID="imgbannerPic" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtbannerPic" runat="server" CssClass="input normal upload-path" datatype="*0-800" sucmsg=" " nullmsg=" "/>
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>

                </dd>
            </dl>
             <dl>
                <dt>分类图标</dt>
                <dd>
                    <asp:Image ID="imgtypeIco" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txttypeIco" runat="server" CssClass="input normal upload-path" datatype="*1-800" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>

                </dd>
            </dl>
            <dl>
                <dt>说明</dt>
                <dd>
                    <textarea name="txttContent" rows="2" cols="20" id="txttContent" class="input" runat="server" datatype="*0-300" sucmsg=" " nullmsg=" "></textarea>

                    <span class="Validform_checktip">*请简单描述内容，尽量控制在150文字以内。</span>
                </dd>
            </dl>

           
            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtseq" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                    <span class="Validform_checktip">*数字，越小越向前</span>
                </dd>
            </dl>




        </div>



        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="typelist.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
