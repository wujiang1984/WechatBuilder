<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="subscribe.aspx.cs" Inherits="WechatBuilder.Web.admin.wxRule.subscribe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>关注时回复</title>
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

            $("input[name='rblResponseType']").click(function () {

                if ($(this).val() == "0") {
                    //文本
                    $(".wenben").show();
                    $(".music").hide();
                    $(".picnews").hide();
                    $("#div_gongju").show();
                }
                else if ($(this).val() == "1") {
                    //图文
                    $(".picnews").show();
                    $(".music").hide();
                    $(".wenben").hide();
                    $("#div_gongju").hide();

                }
                else if ($(this).val() == "2") {
                    //语音
                    $(".wenben").hide();
                    $(".music").show();
                    $(".picnews").hide();
                    $("#div_gongju").show();
                }

            });

            $("#btnSubmit").click(function () {
                var rType = $("input[name='rblResponseType']:checked").val();

                if (rType == "0") {
                    var txtContent = $("#txtContent").val();

                    if ($.trim(txtContent) == "") {
                        $.dialog.alert("请填写内容");
                        return false;
                    }

                }
                if (rType == "2") {
                    var txtMusicTitle = $("#txtMusicTitle").val();
                    var txtMusicFile = $("#txtMusicFile").val();

                    if ($.trim(txtMusicTitle) == "") {
                        $.dialog.alert("请填写音乐标题");
                        return false;
                    }

                    if ($.trim(txtMusicFile) == "") {
                        $.dialog.alert("请填写音乐链接");
                        return false;
                    }

                }



            });

            //图文添加按钮
            $("#itemAddButton").click(function () {

                showGuiZeDialog(0);
            });

        });

        //创建图文的窗口
        function showGuiZeDialog(id) {

            var rid = $("#hidId").val();
            var act = $("#lblact").text();
            
            var contenturl = "";
            if (id == 0) {
                contenturl = "url:wxRule/addNews.aspx?option=add&rid=" + rid + "&act=" + act;
            }
            else {
                contenturl = "url:wxRule/addNews.aspx?option=edit&rid=" + rid + "&id=" + id + "&act=" + act;
            }
            var m = $.dialog({
                id: 'dialogGuiZe',
                fixed: true,
                lock: true,
                max: false,
                min: false,
                title: "添加回复规则",
                content: contenturl,
                height: 420,
                width: 750,

                close: function () {
                    this.reload();
                }
            });
        }

        //执行回传函数
        function DelExePostBack(obj) {
            var objid = obj.id;
            re = new RegExp("_", "g");
            var objid = objid.replace(re, "$");
            
            var msg = "删除记录后不可恢复，您确定吗？";
            $.dialog.confirm(msg, function () {
                
                __doPostBack(objid, '');
            });
            return false;
        }

    </script>


</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location" style="display:none;">

            <a href="javascript:;" class="home"><i></i><span>
                <asp:Literal ID="litNowPosition" runat="server" Text="关注时回复"></asp:Literal>
                </span></a>

        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <asp:HiddenField ID="hidId" runat="server" Value="0" />
         <asp:Label ID="lblact" runat="server" Text="" Style="display: none;"></asp:Label>
        <asp:Label ID="lblreqestType" runat="server" Text="" Style="display: none;"></asp:Label>
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected"><asp:Literal ID="litNowPosition2" runat="server" Text="关注时回复"></asp:Literal></a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <div class="mytips">
                只能选择其一！
            </div>
            <dl>
                <dt>类型</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblResponseType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">文本</asp:ListItem>
                            <asp:ListItem Value="1">图文</asp:ListItem>
                            <asp:ListItem Value="2">语音</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>

            <dl class="wenben" style="display: none;">
                <dt>内容</dt>
                <dd>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="input" Style="height: 300px;" TextMode="MultiLine" datatype="*0-1000" sucmsg="*最多1000个字符 "></asp:TextBox>

                    <span class="Validform_checktip">*最多1000个字符</span>
                </dd>
            </dl>
            <dl id="div_music_title" style="display: none;" class="music">
                <dt>音乐标题</dt>
                <dd>
                    <asp:TextBox ID="txtMusicTitle" runat="server" CssClass="input normal" datatype="*0-255" sucmsg="最多30个字符 " />
                    <span class="Validform_checktip">*最多30个字符</span>
                </dd>
            </dl>

            <dl id="div_music_url" style="display: none;" class="music">
                <dt>音乐链接</dt>
                <dd>
                    <asp:TextBox ID="txtMusicFile" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">*支持mp3格式，可以填写网上的链接，也可以本地上传！</span>
                </dd>
            </dl>
            <dl id="div_music_remark" style="display: none;" class="music">
                <dt>音乐描述</dt>
                <dd>
                    <asp:TextBox ID="txtMusicRemark" runat="server" CssClass="input normal upload-path" />

                </dd>
            </dl>

            <dl class="picnews" style="display: none;">
                <dt></dt>
                <dd>
                    <a id="itemAddButton" class="icon-btn add"><i></i><span>添加内容</span></a>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl class="picnews" style="display: none;">
                <dt></dt>
                <dd>
                    <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
                        <thead>
                            <tr>

                                <th width="20%">图片</th>
                                <th width="40%">标题</th>
                                <th width="25%">链接</th>
                                <th width="5%">排序</th>
                                <th width="10%">操作</th>
                            </tr>
                        </thead>
                        <tbody id="var_box">
                            <asp:Repeater ID="rpnewsList" runat="server" OnItemCommand="rptList_ItemCommand">
                                <ItemTemplate>
                                    <tr class="td_c">
                                        <td>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("picUrl")%>' Style="max-height: 50px; max-width: 100px;" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("rContent")%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("detailUrl")%>'></asp:Label>

                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("seq")%>'></asp:Label>

                                        </td>
                                        <td>
                                            <a title="编辑" href="javascript:;"  onclick='showGuiZeDialog(<%#Eval("id")%>);'>编辑</a>
                                            <asp:LinkButton ID="LinkButton1" runat="server"  OnClientClick="return DelExePostBack(this);" CommandName="delete" CommandArgument='<%#Eval("id")%>'>删除</asp:LinkButton>
                                            
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </dd>

            </dl>
        </div>



        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer" runat="server" id="div_gongju">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
