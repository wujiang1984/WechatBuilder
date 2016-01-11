<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_baseinfo.aspx.cs" Inherits="MxWeiXinPF.Web.admin.ucard.user_baseinfo" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>会员基本信息</title>
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
            <a href="user_list.aspx?id=<%=sid %>" class="back"><i></i><span>返回会员列表</span></a>

            <a href="business_list.aspx" class="home"><i></i><span>会员卡商会员管理</span></a>
            <i class="arrow"></i>
            <a href="user_list.aspx?id=<%=sid %>"><span>会员列表</span></a>
            <i class="arrow"></i>
            <span>会员编辑</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <asp:HiddenField ID="hidid" runat="server" Value="0" />
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">会员编辑</a></li>

                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>姓名</dt>
                <dd>
                    <asp:TextBox ID="txtrealName" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*姓名!</span>
                </dd>
            </dl>
            <dl>
                <dt>编号</dt>
                <dd>
                    会员号： <asp:Label ID="lblcardNo" runat="server" Text=""></asp:Label><br />
                     微信码： <asp:Label ID="lblopenid" runat="server" Text=""></asp:Label>
                   
                </dd>
            </dl>
            <dl>
                <dt>会员等级</dt>
                <dd>
                    <asp:Label ID="lblDegree" runat="server" Text=""></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>性别</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="3" Selected="True">保密</asp:ListItem>
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="2">女</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>微信名称</dt>
                <dd>
                    <asp:TextBox ID="txtwxName" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>年龄</dt>
                <dd>
                    <asp:TextBox ID="txtage" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>总积分</dt>
                <dd>
                    <asp:TextBox ID="txtttScore" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>签到积分</dt>
                <dd>
                    <asp:TextBox ID="txtqdScore" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>消费积分</dt>
                <dd>
                    <asp:TextBox ID="txtconsumeScore" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>总消费金额</dt>
                <dd>
                    <asp:TextBox ID="txtconsumeMoney" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="0"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
             <dl>
                <dt>注册时间</dt>
                <dd>

                    <div class="input-date">
                        <asp:TextBox ID="txtregTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                    </div>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>到期时间</dt>
                <dd>

                    <div class="input-date">
                        <asp:TextBox ID="txtendDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                    </div>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>手机号</dt>
                <dd>
                    <asp:TextBox ID="txtmobile" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>
            <dl>
                <dt>地址</dt>
                <dd>
                    <asp:TextBox ID="txtaddr" runat="server" CssClass="input normal" datatype="*0-200" sucmsg=" " Text="" />
                      <span class="Validform_checktip"></span>
                </dd>
            </dl>


        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="user_list.aspx?id=<%=sid %>"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
