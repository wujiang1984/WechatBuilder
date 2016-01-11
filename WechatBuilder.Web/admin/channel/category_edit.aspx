<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="category_edit.aspx.cs" Inherits="WechatBuilder.Web.admin.channel.category_edit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑频道分类</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });

    function change2cn(en, cninput) {
        cninput.value = getSpell(en, "");
    }

</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="attribute_field_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="category_list.aspx"><span>频道分类</span></a>
  <i class="arrow"></i>
  <span>编辑分类</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑分类信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>标题名称</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal"  datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*标题备注，允许中文。</span></dd>
  </dl>
  <dl>
    <dt>生成目录名</dt>
    <dd>
      <asp:TextBox ID="txtBuildPath" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="请填写正确的名称！" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*频道分类目录，只允许使用英文、下划线。</span>
    </dd>
  </dl>
  <dl>
    <dt>绑定域名</dt>
    <dd>
      <asp:TextBox ID="txtDomain" runat="server" CssClass="input normal" datatype="/^\s*$|^([a-zA-Z0-9\-\u4e00-\u9fa5]+\.)+[a-zA-Z\u4e00-\u9fa5]+$/" errormsg="请输入正确的域名！" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*不能和主域名相同，域名去除“http://”部分。</span>
    </dd>
  </dl>
  <dl>
    <dt>是否默认</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsDefault" runat="server" />
      </div>
      <span class="Validform_checktip">*只允许一个默认频道分类，默认则以主域名访问。</span>
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
<!--/内容-->


<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
