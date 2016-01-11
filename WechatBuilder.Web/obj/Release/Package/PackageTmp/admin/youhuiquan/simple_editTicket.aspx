<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="simple_editTicket.aspx.cs" Inherits="MxWeiXinPF.Web.admin.youhuiquan.simple_editTicket" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑优惠券活动</title>
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
        <div class="location">
            <a href="ggklist.aspx" class="back"><i></i><span>返回优惠券活动列表</span></a>
            <i class="arrow"></i>
            <span>编辑优惠券活动</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑优惠券活动开始内容</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">活动结束内容</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">优惠券设置</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txtKW" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="优惠券" />
                    <span class="Validform_checktip">*只能写一个关键词，用户输入此关键词将会触发此活动。</span>
                </dd>
            </dl>
            <dl>
                <dt>开始活动的图片</dt>
                <dd>
                    <asp:Image ID="imgbeginPic" runat="server" ImageUrl="/weixin/sticket/images/start.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>
                    
                </dd>
            </dl>


            <dl>
                <dt>活动名称</dt>
                <dd>
                    <asp:TextBox ID="txtactName" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="刮刮卡活动开始了" />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>
            <dl>
                <dt>成功抢到券说明</dt>
                <dd>
                    <asp:TextBox ID="txtsuccTip" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" " Text="兑奖请联系我们，电话138xxxxxxx1" />
                    <span class="Validform_checktip">*请不要多于100字! 设置成功强抢券的提示信息!</span>
                </dd>
            </dl>

            <dl>
                <dt>简介</dt>
                <dd>
                    <textarea name="txtbrief" rows="2" cols="20" id="txtbrief" class="input" runat="server" datatype="*1-300" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>活动时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtbeginDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>开始时间</i>
                    </div>
                    到
                  
                    <div class="input-date">
                        <asp:TextBox ID="txtendDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>结束时间</i>
                    </div>
                    <span class="Validform_checktip">*</span>

                </dd>
            </dl>

            <dl>
                <dt>活动说明</dt>
                <dd>
                    <textarea name="txtactContent" rows="2" cols="20" id="txtactContent" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
              <dl>
                <dt>兑换券使用说明</dt>
                <dd>
                    <textarea name="txtusedRemark" rows="2" cols="20" id="txtusedRemark" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>


            <dl>
                <dt>显示的头部图片地址</dt>
                <dd>
                     <asp:Image ID="imgBanner" runat="server" ImageUrl="/weixin/sticket/images/banner.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtBanner" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>
               </dd>
            </dl>

            <dl>
                <dt>商家兑奖密码</dt>
                <dd>
                    <asp:TextBox ID="txtdjPwd" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" nullmsg="请填写信息，并且不要多于50字 "/>
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>


        </div>
        <div class="tab-content" style="display: none">
            <dl>
                <dt>活动结束的图片</dt>
                <dd>
                    <asp:Image ID="imgEndPic" runat="server" ImageUrl="/weixin/sticket/images/end.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtEndPic" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">（尺寸：宽720像素，高400像素） 小于200k;</span>
                </dd>
            </dl>

            <dl>
                <dt>活动结束公告主题</dt>
                <dd>
                    <asp:TextBox ID="txtendNotice" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="刮刮卡活动已经结束了" />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>
            <dl>
                <dt>活动结束说明</dt>
                <dd>
                    <asp:TextBox ID="txtendContent" runat="server" CssClass="input normal" datatype="*1-300" sucmsg=" " Text="亲，活动已经结束，请继续关注我们的后续活动哦。" />
                    <span class="Validform_checktip">* 
                        
                    </span>
                </dd>
            </dl>

        </div>

        <div class="tab-content" style="display: none">
            <dl>
                <dt>优惠券名称1</dt>
                <dd>名称：<asp:TextBox ID="txt1JPName" runat="server" CssClass="input " datatype="*1-20" sucmsg=" " Text="" />
                    数量：<asp:TextBox ID="txt1RealNum" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*必填项</span>
                </dd>
            </dl>
            <dl>
                <dt>优惠券名称2</dt>
                <dd>名称：<asp:TextBox ID="txt2JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    数量：<asp:TextBox ID="txt2RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                </dd>
            </dl>
             <dl>
                <dt>优惠券名称3</dt>
                <dd>名称：<asp:TextBox ID="txt3JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    数量：<asp:TextBox ID="txt3RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                </dd>
            </dl>
            <dl>
                <dt>优惠券名称4</dt>
                <dd>名称：<asp:TextBox ID="txt4JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    数量：<asp:TextBox ID="txt4RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                </dd>
            </dl>
            <dl>
                <dt>优惠券名称5</dt>
                <dd>名称：<asp:TextBox ID="txt5JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    数量：<asp:TextBox ID="txt5RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                </dd>
            </dl>
            <dl>
                <dt>优惠券名称6</dt>
                <dd>名称：<asp:TextBox ID="txt6JPName" runat="server" CssClass="input " datatype="*0-20" sucmsg=" " Text="" />
                    数量：<asp:TextBox ID="txt6RealNum" runat="server" CssClass="input small" datatype="/^\d*$/" sucmsg=" " Text="" />
                </dd>
            </dl>

        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="simpleTList.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
