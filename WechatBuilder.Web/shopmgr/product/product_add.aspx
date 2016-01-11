<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_add.aspx.cs" Inherits="WechatBuilder.Web.shopmgr.product.product_add" ValidateRequest="false" %>

<%@ Import Namespace="WechatBuilder.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>录入商品</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../../admin/js/layout.js"></script>
    <link href="../../admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../admin/skin/mystyle.css" rel="stylesheet" type="text/css" />
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

            $("#btnSubmit").click(function () {
              
                var txt_attrArr = $(".txt_attr");
                var attrStr = "";
                if (typeof (txt_attrArr) != "undefined") {

                    for (var i = 0; i < txt_attrArr.length; i++) {
                        var $attrV = txt_attrArr.eq(i);
                        if ($.trim($attrV.val()) != "") {
                            attrStr += "attrid_" + $attrV.attr("attrid") + "_value_" + $attrV.val() + "||";
                        }
                    }
                    $("#hidAttrValueStr").val(attrStr);
                }

                var chkSkuArr = $(".skuchk");
                var skuvaddmenoyArr = $(".skuvaddmenoy");
                var skuattrName = $(".skuattrName");
                var skuStr = "";
               
                if (typeof (chkSkuArr) != "undefined") {

                    for (var i = 0; i < chkSkuArr.length; i++) {
                        var $chkSku = chkSkuArr.eq(i);
                      
                        if ($chkSku.is(":checked")) {

                            skuStr += "attrid_" + $chkSku.attr("attrid") + "_value_" + skuvaddmenoyArr.eq(i).val() + "_attrname_" + skuattrName.eq(i).text() + "||";
                        }
                    }
                    $("#hidSkuVauleStr").val(skuStr);
                }
              
            });

        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <asp:Literal ID="litReturnPage" runat="server"></asp:Literal>
            <a href="javascript:;" class="home"><i></i><span>商品录入</span></a>

        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">商品描述</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">商品属性</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">商品相册</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>商品类型</dt>
                <dd>
                    <div class="rule-single-select">
                  <asp:DropDownList ID="ddlCatalog" runat="server" datatype="*" sucmsg=" " AutoPostBack="True" OnSelectedIndexChanged="ddlCatalog_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </dd>
            </dl>

            <dl>
                <dt>商品名称</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txtproductName" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text=""  nullmsg=" " />
                    <span class="Validform_checktip">*商品名称，长度在1至25个字符之间.</span>
                </dd>
            </dl>

            <dl>
                <dt>货号</dt>
                <dd>

                    <asp:TextBox ID="txtsku" runat="server" CssClass="input normal" datatype="*0-10" sucmsg=" " Text=""  nullmsg=" "/>
                    <span class="Validform_checktip">*如果您不输入商品货号，系统将自动生成一个唯一的货号。</span>
                </dd>
            </dl>

            <dl>
                <dt>商品分类</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlCategoryId" runat="server" datatype="*" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>是否上架销售</dt>
                <dd>

                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="radType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="否" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <span>选是则出售，选否则在仓库中</span>
                </dd>
            </dl>

            <dl id="shuxingValue">
                <dt>商品栏目设置</dt>
                <dd>
                    <div class="rule-multi-porp">
                        <asp:CheckBoxList ID="cblActionType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="最新" Value="latest"></asp:ListItem>
                            <asp:ListItem Text="热卖" Value="hotsale"></asp:ListItem>
                            <asp:ListItem Text="推荐" Value="recommended"></asp:ListItem>
                            <asp:ListItem Text="特价" Value="specialOffer"></asp:ListItem>
                        </asp:CheckBoxList>
                    </div>

                </dd>
            </dl>

            <dl>
                <dt>成本价</dt>
                <dd>
                    <asp:TextBox ID="txtcostPrice" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" "  nullmsg=" "></asp:TextBox>元
                    <span class="Validform_checktip">*不能为空，若有小数，则保留2位小数 </span>
                </dd>
            </dl>

            <dl>
                <dt>市场价</dt>
                <dd>
                    <asp:TextBox ID="txtmarketPrice" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" "  nullmsg=" "></asp:TextBox>元
                    <span class="Validform_checktip">*不能为空，若有小数，则保留2位小数</span>
                </dd>
            </dl>

            <dl>
                <dt>销售价</dt>
                <dd>
                    <asp:TextBox ID="txtsalePrice" runat="server" CssClass="input small"  datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" "  nullmsg=" "> </asp:TextBox>元
                    <span class="Validform_checktip">*不能为空，若有小数，则保留2位小数</span>
                </dd>
            </dl>

            <dl>
                <dt>库存</dt>
                <dd>
                    <asp:TextBox ID="txtstock" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" "  nullmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>排序</dt>
                <dd>
                    <asp:TextBox ID="txtsort_id" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                    <span class="Validform_checktip">*数字，越小越向前</span>
                </dd>
            </dl>

        </div>
        <div class="tab-content" style="display: none;">
            <dl>
                <dt>商品简介</dt>
                <dd>
                    <asp:TextBox ID="txtshortDesc" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">255个字符以内</span>
                </dd>
            </dl>
            <dl>
                <dt>详细描述</dt>
                <dd>
                    <textarea id="txtdescription" class="editor" style="visibility: hidden;" runat="server"></textarea>
                </dd>
            </dl>
        </div>
          
            
        <div class="tab-content" style="display: none;">
            <asp:Literal ID="litAttr" runat="server"></asp:Literal>
            <asp:HiddenField ID="hidAttrValueStr" runat="server" />
            <asp:HiddenField ID="hidSkuVauleStr" runat="server" />
        </div>

        <div class="tab-content" style="display: none;">
            <dl>
                <dt>商品图片</dt>
                <dd>
                    <div class="upload-box upload-album"></div>
                    <input type="hidden" name="hidFocusPhoto" id="hidFocusPhoto" runat="server" class="focus-photo" />
                    <div class="photo-list">
                        <ul>
                            <asp:Repeater ID="rptAlbumList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <input type="hidden" name="hid_photo_name" value="<%#Eval("id")%>|<%#Eval("pUrl")%>|" />
                                        <input type="hidden" name="hid_photo_remark" value="<%#Eval("remark")%>" />
                                        <div class="img-box" onclick="setFocusImg(this);">
                                            <img src="<%#Eval("pUrl")%>" bigsrc="<%#Eval("pUrl")%>" />
                                            <span class="remark"><i><%#Eval("remark").ToString() == "" ? "暂无描述..." : Eval("remark").ToString()%></i></span>
                                        </div>
                                        <a href="javascript:;" onclick="setRemark(this);">描述</a>
                                        <a href="javascript:;" onclick="delImg(this);">删除</a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="attribute_list.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
