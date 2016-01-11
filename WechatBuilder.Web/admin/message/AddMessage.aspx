<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMessage.aspx.cs" Inherits="WechatBuilder.Web.admin.message.AddMessage" %>

<%@ Import Namespace="WechatBuilder.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
          <!--导航栏-->
        <div class="location">
            <a href="message_list.aspx" class="home"><i></i><span>微留言管理</span></a>
            <i class="arrow"></i>
             
            <span>微留言设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

          <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">微留言设置</a></li>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>


        <div  class="tab-content" >
            
                <dl>
                    <dt>显示留言内容：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="title" CssClass="input normal" datatype="*1-100" ></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>
             <%--   <dl>
                    <dt >用户OpenId：</dt>
                    <dd>
                        <asp:TextBox runat="server" CssClass="input normal" ID="adminOpenid" datatype="*1-20"></asp:TextBox>
                        <span class="Validform_checktip">*</span>
                    </dd>
                </dl>--%>
                <dl>
                    <dt >头部图片外链URL地址：</dt>
                    <dd>
                        <asp:TextBox runat="server" CssClass="input normal upload-path" ID="picurl"></asp:TextBox>
                         <div class="upload-box upload-img"></div>
                   
                    </dd>
                </dl>

   
                <dl>
                    <dt>
                      是否开放留言板：
                    </dt>
                    <dd>
                         <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="needSH" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem  Value="True" >需审核</asp:ListItem>
                            <asp:ListItem  Value="False" Selected="True">无需审核</asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                    </dd>
                </dl>
               
        </div>

           <div class="page-footer" >
            <div class="btn-list">
                  <asp:Button ID="Button1" runat="server"  CssClass="btn" Text="保存" OnClick="Button1_Click" />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>

</html>
