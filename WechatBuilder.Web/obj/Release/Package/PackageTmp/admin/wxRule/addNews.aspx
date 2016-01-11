<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNews.aspx.cs" Inherits="MxWeiXinPF.Web.admin.wxRule.addNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
   
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
 
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
        if ($("#txtTitle").val() == "") {
            W.$.dialog.alert('请填写标题！', function () { $("#txtTitle").focus(); }, api);
            return false;
        }
       
       
        if ($("#txtSortId").val() == "") {
            W.$.dialog.alert('请填写排序号！', function () { $("#txtSortId").focus(); }, api);
            return false;
        }
        if (isNaN($('#txtSortId').val()))
        {
            W.$.dialog.alert('排序号请填写数字！', function () { $("#txtSortId").focus(); }, api);
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
          <asp:HiddenField ID="hidrId" runat="server" Value="0" />
         <asp:HiddenField ID="hidId" runat="server" Value="0" />
        <asp:HiddenField ID="hidAction" runat="server" Value="0" />
       
        <div class="div-content">
            <dl>
                <dt>标题</dt>
                <dd>
                    <textarea name="txtTitle" rows="2" cols="20" id="txtTitle" class="input" runat="server"></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>图片</dt>
                <dd>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>

            <dl>
                <dt>内容</dt>
                <dd>
                    <textarea name="txtContent" rows="2" cols="20" id="txtContent" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
             <dl>
                <dt>链接</dt>
                <dd>
                    <textarea name="txtUrl" rows="2" cols="20" id="txtUrl" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">1</asp:TextBox>
                    <span class="Validform_checktip">*数字，越小越向前</span>
                </dd>
            </dl>

        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="提交保存" style="display:none;" onclick="btnSubmit_Click" />
       

    </form>
</body>
</html>
