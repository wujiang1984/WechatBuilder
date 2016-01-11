<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_config.aspx.cs" Inherits="MxWeiXinPF.Web.admin.order.order_config" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>订单参数设置</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>

<body class="mainbody" style="display:none;">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>订单设置</span>
            <i class="arrow"></i>
            <span>参数设置</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本参数设置</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">物流跟踪配置</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <!--订单参数设置-->
        <div class="tab-content">
            <dl>
                <dt>开启匿名购物</dt>
                <dd>
                    <div class="rule-single-checkbox">
                        <asp:CheckBox ID="anonymous" runat="server" />
                    </div>
                    <span class="Validform_checktip">*注意：开启匿名后无需登录即可下订单</span>
                </dd>
            </dl>
            <dl>
                <dt>订单确认通知</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="confirmmsg" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">关闭通知</asp:ListItem>
                            <asp:ListItem Value="1">短信通知</asp:ListItem>
                            <asp:ListItem Value="2">邮件通知</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>确认模板别名</dt>
                <dd>
                    <asp:TextBox ID="confirmcallindex" runat="server" CssClass="input normal" datatype="*" sucmsg=" " />
                    <span class="Validform_checktip">*订单确认通知模板调用别名</span>
                </dd>
            </dl>
            <dl>
                <dt>订单发货通知</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="expressmsg" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">关闭通知</asp:ListItem>
                            <asp:ListItem Value="1">短信通知</asp:ListItem>
                            <asp:ListItem Value="2">邮件通知</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>发货模板别名</dt>
                <dd>
                    <asp:TextBox ID="expresscallindex" runat="server" CssClass="input normal" datatype="*" sucmsg=" " />
                    <span class="Validform_checktip">*订单发货通知模板调用别名</span>
                </dd>
            </dl>
            <dl>
                <dt>订单完成通知</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="completemsg" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">关闭通知</asp:ListItem>
                            <asp:ListItem Value="1">短信通知</asp:ListItem>
                            <asp:ListItem Value="2">邮件通知</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>完成模板别名</dt>
                <dd>
                    <asp:TextBox ID="completecallindex" runat="server" CssClass="input normal" datatype="*" sucmsg=" " />
                    <span class="Validform_checktip">*订单完成通知模板调用别名</span>
                </dd>
            </dl>
        </div>
        <!--/订单参数设置-->

        <!--物流跟踪设置-->
        <div class="tab-content" style="display: none">
            <dl>
                <dt>快递100API地址</dt>
                <dd>
                    <asp:TextBox ID="kuaidiapi" runat="server" CssClass="input normal" datatype="url" sucmsg=" " />
                    <span class="Validform_checktip">*还没申请？<a href="http://www.kuaidi100.com/openapi/" target="_blank">点击这里注册</a></span>
                </dd>
            </dl>
            <dl>
                <dt>快递100授权Key</dt>
                <dd>
                    <asp:TextBox ID="kuaidikey" runat="server" CssClass="input normal" datatype="*" sucmsg=" " />
                    <span class="Validform_checktip">*申请成功后得到的授权KEY</span>
                </dd>
            </dl>
            <dl>
                <dt>信息返回格式</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="kuaidishow" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0">JSON字符串</asp:ListItem>
                            <asp:ListItem Value="1">XML对象</asp:ListItem>
                            <asp:ListItem Value="2">HTML表格</asp:ListItem>
                            <asp:ListItem Value="3" Selected="True">文本信息</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>显示信息数量</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="kuaidimuti" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0">显示一行</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">显示全部</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>跟踪信息排序</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="kuaidiorder" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="asc">由旧到新</asp:ListItem>
                            <asp:ListItem Value="desc" Selected="True">由新到旧</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>
        </div>
        <!--/物流跟踪设置-->
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
