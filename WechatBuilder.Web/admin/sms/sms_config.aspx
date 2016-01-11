<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sms_config.aspx.cs" Inherits="WechatBuilder.Web.admin.sms.sms_config" %>

<%@ Import Namespace="WechatBuilder.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>短信接口设置</title>
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
        <!--导航栏-->
        <div class="location">
            <a href="sms_list.aspx" class="back"><i></i><span>返回短信列表</span></a>
            <i class="arrow"></i>
            <span>短信接口设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">设置短信接口信息</a></li>
                        
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>帐号</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txtucode" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="" nullmsg="请输入帐号" />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>密码</dt>
                <dd>
                    <asp:TextBox ID="txtpwd" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" nullmsg="请输入密码" />
                    <span class="Validform_checktip">* </span>
                </dd>
            </dl>
            <dl>
                <dt>签名</dt>
                <dd>
                    <asp:TextBox ID="txtqianming" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" " Text="" nullmsg="签名格式如【XX公司】" />
                    <span class="Validform_checktip">*签名格式如【XX公司】</span>
                </dd>
            </dl>

            <dl>
                <dt>备注</dt>
                <dd>
                    <textarea name="txtremark" rows="2" cols="20" id="txtremark" class="input" runat="server" datatype="*0-300" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
        </div>
        
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="sms_list.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
