<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="category_bottomMenu_edit.aspx.cs" Inherits="WechatBuilder.Web.admin.article.category_bottomMenu_edit" %>

<%@ Import Namespace="WechatBuilder.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <title>编辑底部菜单</title>
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
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
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
            <a href="category_bottomMenu_list.aspx?channel_id=7" class="back"><i></i><span>返回底部菜单管理</span></a>
            <i class="arrow"></i>
            <span>编辑底部菜单</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap" >
            <div id="floatHead" class="content-tab" >
                <div class="content-tab-ul-wrap" >
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">底部菜单编辑</a></li>
                      <%--  <li><a href="javascript:;" onclick="tabs(this);">扩展选项</a></li>--%>
                       
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
             <div class="mytips">
                一键拨号填写范例： tel:136xxxx1570请拷贝代码粘帖到外链网址，修改电话号码。<br />
一键导航填写范例：http://map.baidu.com/mobile/webapp/place/list/qt=s&wd=厦门市厦禾路900号/vt=map请拷贝网址粘帖到输入框，修改地址，写具体地址，如：某市某路某号。 
            </div>

             <dl>
                <dt>菜单名称</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" onBlur="change2cn(this.value, this.form.txtCallIndex)" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*菜单中文名称，100字符内</span></dd>
            </dl>
            <dl>
                <dt>所属父菜单</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlParentId" runat="server"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            
            <dl>
                <dt>菜单图标</dt>
                <dd>
                    <div class="wxico_container" id="imgIco_Container"> 
                      <asp:Image ID="imgIco" runat="server"  CssClass="imgico"  ImageUrl="~/images/noneimg.jpg" />
                        <asp:Literal ID="litImgIco" runat="server"></asp:Literal>   
                     </div>     
                    <asp:TextBox ID="txtImgICO" runat="server" CssClass="input normal"  ReadOnly="true"></asp:TextBox>
                    <input id="btnSelectICO" type="button" value="选择" class="btn" />
                    <span class="Validform_checktip"> 显示的图标 100X100像素的透明png图标</span>
                </dd>
            </dl>
             <dl style="display:none;">
                <dt>菜单图片</dt>
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
                    <asp:TextBox ID="txtLinkUrl" runat="server" MaxLength="255" CssClass="input normal"  TextMode="MultiLine" /><input id="selectmoduleinfo" type="button" value="选择" class="btn" /><br />
                    <span class="Validform_checktip" style="color:red;">注：URL跳转地址，如果需要与用户互动功能，请在url后面添加url参数，若为第一个参数则为:?openid={openid},否则：&openid={openid}</span>
                </dd>
            </dl>
           
            <dl style="display:none;">
                <dt>介绍</dt>
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
           


            <dl>
                <dt>调用别名</dt>
                <dd>
                    <asp:TextBox ID="txtCallIndex" runat="server" CssClass="input normal" datatype="/^\s*$|^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="请填写正确的别名" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">类别的调用别名，只允许字母、数字、下划线</span>
                </dd>
            </dl>
            <dl>
                <dt>SEO标题</dt>
                <dd>
                    <asp:TextBox ID="txtSeoTitle" runat="server" MaxLength="255" CssClass="input normal" datatype="s0-100" sucmsg=" " />
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
