<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="group_base_add.aspx.cs" Inherits="MxWeiXinPF.Web.admin.grouppurchase.group_base_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
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
        <!--导航栏-->
        <div class="location">
            <a href="group_list.aspx" class="home"><i></i><span>团购活动</span></a>
            <i class="arrow"></i>

            <span>团购活动基本设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">团购活动基本设置</a></li>

                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>


        <div class="tab-content">

            <dl>
                <dt>活动名称：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="activityName" CssClass="input normal" datatype="*1-50" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>团购简介：</dt>
                <dd>
                    <textarea name="activitySummary" rows="2" cols="20" id="activitySummary" datatype="*1-1000" sucmsg=" " nullmsg="" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>活动时间：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="activityTimebegin" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>到
                        <asp:TextBox runat="server" ID="activityTimeend" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>通知邮箱：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="email" CssClass="input normal" datatype="*1-100" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    <br />
                    <span class="red">当有用户团购的时候会通过此邮箱通知！建议使用163邮箱 例如:123456789@163.com
                    </span>
                </dd>
            </dl>

            <dl style="display: none">
                <dt>邮箱密码：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="emailPwd" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl style="display: none">
                <dt>SMTP服务器：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="smtp" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>消费确认密码：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="shopsPwd" CssClass="input normal" datatype="*1-100" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    <br />
                    <span class="red">输入正确的密码可以在手机端直接修改消费状态!
                    </span>
                </dd>
            </dl>

            <dl>
                <dt>活动描述及商品描述：</dt>
                <dd>
                    <textarea name="activeDescription" rows="2" cols="20" id="activeDescription" datatype="*1-1000" sucmsg=" " nullmsg="" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>填写活动开始图片网址</dt>
                <dd>
                    <asp:Image ID="imgbeginPic" runat="server" ImageUrl="/weixin/groupbuy/images/Groupbuying-Start.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="imageUrl" runat="server" CssClass="input normal upload-path" Style="width: 200px;" sucmsg=" " nullmsg="" />
                    <div class="upload-box upload-img"></div>

                </dd>
            </dl>
            <dl>
                <dt>填写活动结束图片网址</dt>
                <dd>
                    <asp:Image ID="imgendPic" runat="server" ImageUrl="/weixin/groupbuy/images/activity-coupon-end.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="imageUrlend" runat="server" CssClass="input normal upload-path" Style="width: 200px;" sucmsg=" " nullmsg="" />
                    <div class="upload-box upload-img"></div>

                </dd>

            </dl>

            <dl>
                <dt>特别提醒：</dt>
                <dd>
                    <textarea name="specialRemind" rows="2" cols="20" id="specialRemind" class="input" datatype="*1-1000" sucmsg=" " nullmsg="" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

        </div>

        <div class="tab-content" style="display: none">
            <dl>
                <dt>活动结束公告主题：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="activityEndtitle" CssClass="input normal" datatype="*1-100" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>活动结束说明：</dt>
                <dd>
                    <textarea name="endExplanation" rows="2" cols="20" id="endExplanation" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
        </div>

        <div class="tab-content" style="display: none">
            <dl>
                <dt>团购电话：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="shopstel" CssClass="input normal" datatype="*1-100" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>联系地址：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="address" CssClass="input normal" datatype="*1-100" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
                <dd>纬度（x）: 
                      <asp:TextBox ID="txtLatXPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span> &nbsp;&nbsp;&nbsp;
                </dd>
                <dd>经度（y）:
                      <asp:TextBox ID="txtLngYPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
                <dd>
                    <iframe id="baiduframe" src="../lbs/MapSelectPoint.aspx?yjindu=121.526149&xweidu=31.222663" height="300" width="700" style="border: 1px solid #e1e1e1;"></iframe>
                </dd>
            </dl>
            <dl>
                <dt>商家介绍：</dt>
                <dd>
                    <textarea name="introduction" rows="2" cols="20" id="introduction" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
        </div>

        <div class="tab-content" style="display: none">
            <dl>
                <dt>商品名称：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="goodName" CssClass="input normal" sucmsg=" " nullmsg="" datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>商品原价：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="costPrice" CssClass="input normal" datatype="n" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>每人最多团购产品数：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="limitCount" CssClass="input normal" datatype="n" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>


            <dl>
                <dt>商品团购价：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="groupPrice" CssClass="input normal" datatype="n" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>商品总数：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="totalCount" CssClass="input normal" datatype="n" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>最低参团人数：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="groupPerson" CssClass="input normal" datatype="n" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    <br />
                    <span class="red">最小人数为1
                    </span>
                </dd>
            </dl>

            <dl>
                <dt>虚拟参团人数：</dt>
                <dd>

                    <asp:TextBox runat="server" ID="virtualPerson" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    <br />
                    <span class="red">前台展示的参团人数=虚拟参团人数+有效参团人数!
                    </span>
                </dd>
            </dl>

            <dl>
                <dt>版权设置：</dt>
                <dd>
                    <textarea name="copyrightSetup" rows="2" cols="20" id="copyrightSetup" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

        </div>

        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="save_groupbase" runat="server" CssClass="btn" Text="保存" OnClick="save_groupbase_Click" />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
