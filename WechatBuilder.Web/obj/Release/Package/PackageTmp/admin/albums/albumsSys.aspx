<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="albumsSys.aspx.cs" Inherits="MxWeiXinPF.Web.admin.albums.albumsSys" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确定',
        focus: true,
        callback: function () {
            if (!submitForm()) {
                return false;
            }


        }

    }, {
        name: '取消'
    });

    //提交表单处理
    function submitForm() {
        //验证表单
        if ($("#txtImgUrl").val() == "") {
            W.$.dialog.alert('请选择图片！', function () {  }, api);
            return false;
        }


        $("#btnSubmit").click();
    }



    $(function () {
        //初始化表单验证
        $("#form1").initValidform();

        //初始化上传控件
        $(".upload-img").each(function () {
            $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
        });

    });
</script>
</head>
<body>
    <form id="form1" runat="server">
          <asp:HiddenField ID="hidwid" runat="server" Value="0" />
        <asp:HiddenField ID="hidid" runat="server" Value="0" />
        <div class="div-content">
             
            <dl>
                <dt>首页底图</dt>
                <dd>
                 <dd>
                    <asp:Image ID="imgfacePicPic" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height:120px;" /><br />
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip"><br />*（尺寸：宽宽1366像素，高1799像素） 小于200k;</span>

                </dd>   
                </dd>
            </dl>
             

        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="提交保存" style="display:none;" onclick="btnSubmit_Click" />
       

    </form>
</body>
</html>
