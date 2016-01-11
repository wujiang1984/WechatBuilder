<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="richeng_edit.aspx.cs" Inherits="WechatBuilder.Web.admin.sjb.richeng_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
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
        <div class="location">
            <a href="richeng_list.aspx"  class="home"><i></i><span>世界杯日程管理</span></a>
            <i class="arrow"></i><span>日程管理</span>
        </div>

           <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">比赛日程管理</a></li>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>

       <div class="tab-content">

           <dl>
                <dt>日程名称：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="rcName" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

           <dl>
            <dt>开始时间：</dt>
            <dd>
        <asp:TextBox runat="server" ID="beginDate"  CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"  datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " ></asp:TextBox>
          <span class="Validform_checktip">*</span>
                </dd>
            </dl>

             <dl>
              <dt>结束时间：</dt>
             <dd>
            <asp:TextBox runat="server" ID="endDate"  CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"  datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " ></asp:TextBox>
           <span class="Validform_checktip">*</span>
                </dd>
            </dl>

               <dl>
                <dt>日程图片：</dt>
                <dd>
                    <asp:TextBox ID="rcPic" runat="server" CssClass="input normal upload-path"   Style="width: 200px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>

                 <dl>
                <dt>日程简介：</dt>
                <dd>
                <textarea name="remark" rows="2" cols="20" id="remark" datatype="*1-2000" sucmsg=" " nullmsg=" "  class="input" runat="server"></textarea>               
                 <span class="Validform_checktip">*</span>
                </dd>
            </dl>

              <dl>
                <dt>排序号：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="sort_id" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

       </div>

         <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="save_richeng" runat="server" CssClass="btn" Text="保存" OnClick="save_richeng_Click"  />
            </div>
            <div class="clear"></div>
        </div>

    </form>
</body>
</html>
