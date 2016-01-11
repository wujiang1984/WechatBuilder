<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productType_edit.aspx.cs" Inherits="WechatBuilder.Web.admin.product.productType_edit" ValidateRequest="false" %>

<%@ Import Namespace="WechatBuilder.Common" %>

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
        function change2cn(en, cninput) {
            cninput.value = getSpell(en, "");
        }

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="prouductType_list.aspx" class="back"><i></i><span>返回列表页</span></a>
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
                        <li><a href="javascript:;" onclick="tabs(this);" >底部菜单设置</a></li>
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
            <dl style="display:none;">
                <dt>所属父分类</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlParentId" runat="server"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
             <dl>
                <dt>所属产品库</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlPStore" runat="server"></asp:DropDownList>
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
                <dt>外链网址</dt>
                <dd>
                    <asp:TextBox ID="txtLinkUrl" runat="server" MaxLength="255" CssClass="input normal" />
                    <span class="Validform_checktip" style="color:red;">如需跳转到其他网址，请在这里填写网址(例如：http://baidu.com，记住必须有http://)</span>
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
          <div class="tab-content" style="display:none;">
               <dl>
                <dt>电话</dt>
                <dd>
                    <asp:TextBox ID="txttel" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip"  >联系电话,用于底部菜单,不填写则不显示</span>
                </dd>
            </dl>

             <dl>
                <dt>导航网址</dt>
                <dd>
                    <asp:TextBox ID="txtdaohangurl" runat="server" CssClass="input normal" datatype="*0-1000" sucmsg=" " Text="" />
                    <span class="Validform_checktip"  >地图的导航地址,用于底部菜单,不填写则不显示</span>
                </dd>
            </dl>
              <dl>
              <dt>首页显示</dt>
                <dd>
                       <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblshowDefault" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">隐藏</asp:ListItem>
                            <asp:ListItem Value="1">显示</asp:ListItem>
                          
                        </asp:RadioButtonList>
                    </div>
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
