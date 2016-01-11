<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ticket_edit.aspx.cs" Inherits="WechatBuilder.Web.admin.ucard.ticket_edit" %>

<%@ Import Namespace="WechatBuilder.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>发布优惠券</title>
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


            $("#btnSubmit").click(function () {
                
              
                var rqValue = $('input:radio[name="rlitRQ"]:checked').attr("value");
              
                if (rqValue == null) {

                    $.dialog.alert("请选中一个人群类型!");
                    return false;
                }
                else {
                   
                    $("#txtRQValue").val(rqValue);

                }
            });
           
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="ticket_list.aspx?id=<%=sid %>" class="back"><i></i><span>返回优惠券列表</span></a>

            <a href="business_list.aspx" class="home"><i></i><span>会员卡商家管理</span></a>
            <i class="arrow"></i>
            <a href="ticket_list.aspx?id=<%=sid %>"><span>优惠券列表</span></a>
            <i class="arrow"></i>
            <span>发布优惠券</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <asp:HiddenField ID="hidid" runat="server" Value="0" />
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">发布优惠券</a></li>

                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>优惠券名称</dt>
                <dd>
                    <asp:TextBox ID="txtnName" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*请不要多于50字!</span>
                </dd>
            </dl>
               <dl>
                <dt>选择人群</dt>
                <dd>
                   <asp:TextBox ID="txtRQValue" runat="server" Text="" Style="display: none;"></asp:TextBox>
                    <asp:RadioButtonList ID="rlitRQ" runat="server" RepeatDirection="Horizontal"  RepeatLayout="Flow"></asp:RadioButtonList>
                    <br />
                    
                    <input id="rlitRQ_sckk" type="radio" name="rlitRQ" value="1001">
                    <label for="rlitRQ_sckk">新开卡会员　</label>

                     <input id="rlitRQ_wxf" type="radio" name="rlitRQ" value="1002">
                    <label for="rlitRQ_wxf">开卡从未消费的会员　</label>

                      <input id="rlitRQ_wxf1" type="radio" name="rlitRQ" value="1003">
                    <label for="rlitRQ_wxf1">一个月未消费的会员　</label>
                    <table>
                        <tr>
                            <td>
                                  <input id="rlitRQ_dcmxy" type="radio" name="rlitRQ" value="2001">
                                 <label for="rlitRQ_dcmxy">单次消费满X元的会员　</label>
                            </td>
                            <td>
                                (金额<asp:TextBox ID="txtdcje" runat="server" CssClass="input small"  onkeydown="return checkNumber(event);"></asp:TextBox>元)
                            </td>
                        </tr>
                         <tr>
                            <td>
                                  <input id="rlitRQ_ljmxy" type="radio" name="rlitRQ" value="2002">
                                 <label for="rlitRQ_ljmxy">累计消费满X元的会员　</label>
                            </td>
                            <td>
                                (金额<asp:TextBox ID="txtljje" runat="server" CssClass="input small"  onkeydown="return checkNumber(event);"></asp:TextBox>元)
                            </td>
                        </tr>
                    </table>
                    

                </dd>
            </dl>
             <dl>
                <dt>有效期</dt>
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
                <dt>优惠券类型</dt>
                <dd>
                     <input id="radType1" type="radio" name="rlitType" value="1" runat="server" checked="true">
                    <label for="radType1">打折优惠券　</label>

                     <input id="radType2" type="radio" name="rlitType" value="2"  runat="server">
                    <label for="radType2">现金抵用券</label>
                    (金额<asp:TextBox ID="txtTypeMoney" runat="server" CssClass="input small"  onkeydown="return checkNumber(event);"></asp:TextBox>元)
                </dd>
            </dl>
            <dl>
                <dt>使用说明</dt>
                <dd>
                    <textarea name="txtusedContent" rows="3" cols="20" id="txtusedContent" class="input" runat="server" datatype="*0-500" sucmsg=" " nullmsg=" "></textarea>
                    <span class="Validform_checktip">*</span>
                    <br />在此说明券的使用方式，如最低消费金额，优惠券打折信息，不与其他优惠同时使用、节假日不可使用等。
                </dd>
            </dl>
 
            <dl>
                <dt>数量</dt>
                <dd>
                   每个用户可以获得
                     <asp:TextBox ID="txtusedTimes" runat="server" CssClass="input small" datatype="n" sucmsg=" ">1</asp:TextBox>
                   张券  
                </dd>
            </dl>
        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="ticket_list.aspx?id=<%=sid %>"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
