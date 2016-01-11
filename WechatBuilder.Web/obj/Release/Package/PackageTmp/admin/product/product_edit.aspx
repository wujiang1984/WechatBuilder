<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.product.product_edit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑产品信息</title>
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
            //计算用户组价格
            $("#field_control_sell_price").change(function () {
                var sprice = $(this).val();
                if (sprice > 0) {
                    $(".groupprice").each(function () {
                        var num = $(this).attr("discount") * sprice / 100;
                        $(this).val(ForDight(num, 2));
                    });
                }
            });
            //初始化编辑器
            var editor = KindEditor.create('.editor', {
                width: '98%',
                height: '350px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true
            });
            var editorMini = KindEditor.create('.editor-mini', {
                width: '98%',
                height: '250px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
            });
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
            <a href="product_list.aspx"><span class="home"><i></i><span>产品管理</span></a>
            <i class="arrow"></i>
            <span>编辑产品信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <asp:Label ID="lblid" runat="server" Style="display: none;"></asp:Label>
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑产品信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">列表显示设置</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>名称</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                    <span class="Validform_checktip">*标题最多100个字符</span>
                </dd>
            </dl>

            <dl>
                <dt>所属类型</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlCategoryId" runat="server" datatype="*" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>主题</dt>
                <dd>
                    <asp:TextBox ID="txtpSubject" runat="server" CssClass="input" TextMode="MultiLine" datatype="*1-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">不填写则自动截取内容前255字符</span>
                </dd>
            </dl>
            <dl>
                <dt>封面图片</dt>
                <dd>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            <dl>
                <dt>开始时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtbeginDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                        <i>日期</i>
                    </div>
                    <span class="Validform_checktip">不选择默认当前发布时间</span>
                </dd>
            </dl>
            <dl>
                <dt>结束时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtendDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                        <i>日期</i>
                    </div>
                    <span class="Validform_checktip">不选择默认当前发布时间</span>
                </dd>
            </dl>

            <dl>
                <dt>地点</dt>
                <dd>
                    <asp:TextBox ID="txtaddr" runat="server" CssClass="input normal" datatype="*0-200" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">非必填，不可重复</span>
                </dd>
            </dl>
            <dl>
                <dt>内容描述</dt>
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
                <dt>说明</dt>
                <dd>
                    <span class="red">勾选说明显示在列表里;反之，不勾选则不显示</span>
                </dd>
            </dl>
            <dl>
                <dt>报价</dt>
                <dd>
                    <asp:CheckBox ID="chkShowPrice" runat="server" />
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="input" datatype="*0-10" sucmsg=" ">0.00</asp:TextBox>
                    <span class="Validform_checktip">元</span>
                </dd>
            </dl>
            <dl>
                <dt>创建时间</dt>
                <dd>
                    <asp:CheckBox ID="chkShowDate" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>按钮</dt>
                <dd>
                    <asp:CheckBox ID="chkShowYuDing" runat="server" />
                    按钮文字：<asp:TextBox ID="txtAnNiuTxt" runat="server" CssClass="input small" MaxLength="4" Text="预定"></asp:TextBox>

                    链接地址：<asp:TextBox ID="txtUrl" runat="server" CssClass="input normal" Text=""></asp:TextBox>
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
