<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_category_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.article.wx_category_edit" %>


<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <title>编辑分类</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type='text/javascript' src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../js/pinyin.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../images/font-awesome/css/font-awesome.css" media="all" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            $("#btnVarAdd").click(function () {
                varHtml = createVarHtml();
                $("#tr_box").append(varHtml);

            });



            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
            //初始化编辑器
            var editorMini = KindEditor.create('#txtContent', {
                width: '98%',
                height: '100px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                items: [
                    'source', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'image', 'link', 'fullscreen']
            });

            $("#btnSelectICO").click(function () {

                selectico("imgIco", "txtImgICO");
            });
            $("#btnSelectImg").click(function () {

                selectico("imgUrl", "txtImgUrl");
            });

            $("#selectmoduleinfo").click(function () {

                selectmodule("txtLinkUrl");
            });

        });

        function selectico(imgControlId, txtUrlControlId) {
            $.dialog({
                id: 'selectIco',
                fixed: true,
                lock: true,
                max: false,
                min: false,
                title: "选择图片",
                content: "url:/admin/picmgr/picSelect.aspx?img=" + imgControlId + "&txt=" + txtUrlControlId,
                height: 420,
                width: 750
            });

        }

        function selectmodule(txtUrl) {
            $.dialog({
                id: 'selectmodule',
                fixed: true,
                lock: true,
                max: false,
                min: false,

                title: "选择模型",
                content: "url:/admin/dialog/selectmodulelink.aspx?url=" + txtUrl,
                height: 420,
                width: 440
            });

        }

        function change2cn(en, cninput) {
            cninput.value = getSpell(en, "");
        }

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="wx_category_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <i class="arrow"></i>
            <span>编辑分类</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap"  >
            <div id="floatHead" class="content-tab" >
                <div class="content-tab-ul-wrap" >
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑分类</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">扩展选项</a></li> 
                       
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
             <dl>
                <dt>分类名称</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" onBlur="change2cn(this.value, this.form.txtCallIndex)" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*类别中文名称，100字符内</span></dd>
            </dl>
            <dl>
                <dt>所属父分类</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlParentId" runat="server"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            
            <dl>
                <dt>分类图标</dt>
                <dd>
                    <div class="wxico_container" id="imgIco_Container"> 
                      <asp:Image ID="imgIco" runat="server"  CssClass="imgico"  ImageUrl="~/images/noneimg.jpg" />
                        <asp:Literal ID="litImgIco" runat="server"></asp:Literal>   
                     </div>     
                    <asp:TextBox ID="txtImgICO" runat="server" CssClass="input normal"  ReadOnly="true"></asp:TextBox>
                    <input id="btnSelectICO" type="button" value="选择" class="btn" />
                    <span class="Validform_checktip">首页上显示的图标</span>
                </dd>
            </dl>


             <dl>
                <dt>分类图片</dt>
                <dd>
                     <asp:Image ID="imgUrl" runat="server" style=" max-height:80px; background-color:#A0B4DC;" ImageUrl="~/images/noneimg.jpg" /><br />
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal"   />
                     <input id="btnSelectImg" type="button" value="选择" class="btn" />
                     <span class="Validform_checktip">推荐宽300高300像素正方形图片，个别模版需要宽720高400像素图片</span>

                </dd>
            </dl>
             <dl>
                <dt>外链网址</dt>
                <dd>
                    <asp:TextBox ID="txtLinkUrl" runat="server" MaxLength="255" CssClass="input normal" />
                    <span class="Validform_checktip" style="color:red;">如需跳转到其他网址，请在这里填写网址(例如：http://baidu.com，记住必须有http://)</span>
                <br /><input id="selectmoduleinfo" type="button" value="选择" class="btn" />
                </dd>
            </dl>
           
            <dl>
                <dt>分类介绍</dt>
                <dd>
                    <textarea id="txtContent" class="editor" style="visibility: hidden;" runat="server"></textarea>
                </dd>
            </dl>

           
            <dl>
                <dt>排序数字</dt>
                <dd>
                    <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                    <span class="Validform_checktip">*数字，越小越向前</span>
                </dd>
            </dl>
            
            
        </div>

        <div class="tab-content" style="display: none">
           


            <dl style="display:none;">
                <dt>调用别名</dt>
                <dd>
                    <asp:TextBox ID="txtCallIndex" runat="server" CssClass="input normal" datatype="/^\s*$|^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="请填写正确的别名" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">类别的调用别名，只允许字母、数字、下划线</span>
                </dd>
            </dl>
            <dl>
                <dt>SEO标题</dt>
                <dd>
                    <asp:TextBox ID="txtSeoTitle" runat="server" MaxLength="255" CssClass="input normal" datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">255个字符以内</span>
                </dd>
            </dl>
            <dl>
                <dt>SEO关健字</dt>
                <dd>
                    <asp:TextBox ID="txtSeoKeywords" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    <span class="Validform_checktip">以“,”逗号区分开，255个字符以内</span>
                </dd>
            </dl>
            <dl>
                <dt>SEO描述</dt>
                <dd>
                    <asp:TextBox ID="txtSeoDescription" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    <span class="Validform_checktip">255个字符以内</span>
                </dd>
            </dl>

        </div>




        <!--/内容-->


        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
