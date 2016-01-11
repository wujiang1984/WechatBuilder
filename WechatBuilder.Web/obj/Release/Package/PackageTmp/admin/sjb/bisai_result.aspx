<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bisai_result.aspx.cs" Inherits="MxWeiXinPF.Web.admin.sjb.bisai_result" %>

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
            <i class="arrow"></i><span><a href="bisai_list.aspx?id=<%=richengid %>" >比赛管理</a></span>
            <i class="arrow"></i>             
            <span>比赛设置</span>
        </div>

         <div class="line10"></div>

         <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">比赛结果</a></li>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>


        <div class="tab-content">
            <dl>
                <dt>比赛结果：</dt>
                <dd>
                         <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="resultType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" >球队1胜利</asp:ListItem>
                            <asp:ListItem Value="2">球队2胜利</asp:ListItem>
                            <asp:ListItem Value="3">平局</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
           </div>

              <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="save_qiudui" runat="server" CssClass="btn" Text="保存" OnClick="save_qiudui_Click"  />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
