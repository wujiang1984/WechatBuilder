<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxcode_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.manager.wxcode_edit" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑微信公众号</title>
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
            //设置封面图片的样式
            $(".photo-list ul li .img-box img").each(function () {
                if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                    $(this).parent().addClass("selected");
                }
            });

        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="wxcodemgr.aspx" class="back"><i></i><span>返回列表页</span></a>
            <i class="arrow"></i>
            <span>编辑微信公众号</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑微信公众号</a></li>
                    </ul>
                </div>
            </div>
        </div>
        
        <div class="tab-content">
            <dl>
                <dt>微帐号Id</dt>
                <dd>
                     <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>公众帐号名称</dt>
                <dd>
                    <asp:TextBox ID="txtwxName" runat="server" CssClass="input normal " datatype="*" sucmsg=" " nullmsg="请填写公众帐号名称"></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>公众号原始ID</dt>
                <dd>
                    <asp:TextBox ID="txtwxId" runat="server" CssClass="input normal " datatype="*" sucmsg=" " nullmsg="请填写公众帐号原始ID"></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>微信号</dt>
                <dd>
                    <asp:TextBox ID="txtweixinCode" runat="server" CssClass="input normal " datatype="*" sucmsg=" " nullmsg="请填写微信号"></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
             <dl>
                <dt>接口地址</dt>
                <dd>
                    <asp:Label ID="txtapiurl" runat="server" Text="" CssClass="input normal"></asp:Label>
                    <span class="Validform_checktip">* 自动生成的地址</span>
                </dd>
            </dl>

             <dl>
                <dt>有效期</dt>
                <dd>
                     创建时间：<asp:Label ID="lblAddDate" runat="server" Text="" ></asp:Label>  <br />
                     到期时间： <asp:Label ID="lblEndDate" runat="server" Text=""  ></asp:Label>
                     <div class="input-date">
                        <asp:TextBox ID="txtEndTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"  errormsg="请选择正确的日期" sucmsg=" " nullmsg="请填写时间" />
                        <i>日期</i>
                    </div>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>头像</dt>
                <dd>

                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path"   />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
           
            <dl>
                <dt>TOKEN值</dt>
                <dd>
                    <asp:TextBox ID="txtwxToken" runat="server" CssClass="input normal" datatype="*" sucmsg=" "  nullmsg="请填写TOKEN值"></asp:TextBox>
                    <span class="Validform_checktip">*与公众帐号官方网站上保持一致</span>
                </dd>
            </dl>
            <dl>

                <dd style="color: #16a0d3;">以下为高级功能配置，非必填项</dd>
            </dl>
            <dl>
                <dt>AppId</dt>
                <dd>
                    <asp:TextBox ID="txtAppId" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>AppSecret</dt>
                <dd>
                    <asp:TextBox ID="txtAppSecret" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                 <a href="wxcodemgr.aspx"  > <span class="btn yellow">返回上一页</span></a>
                
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
