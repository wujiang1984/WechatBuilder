<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="channel_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.channel.channel_edit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑频道信息</title>
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
        //添加按钮(点击绑定)
        $("#itemAddButton").click(function () {
            showChannelDialog();
        });
    });

    //创建窗口
    function showChannelDialog(obj) {
        var objNum = arguments.length;
        var m = $.dialog({
            id: 'dialogChannel',
            fixed: true,
            lock: true,
            max: false,
            min: false,
            title: "URL配置信息",
            content: 'url:dialog/dialog_channel.aspx',
            width: 750
        });
        //检查是否修改状态
        if (objNum == 1) {
            m.data = obj;
        }
    }

    //删除一行
    function delItemTr(obj) {
        $.dialog.confirm("您确定要删除这个页面吗？", function () {
            $(obj).parent().parent().remove(); //删除节点
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
  <a href="channel_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="channel_list.aspx"><span>频道列表</span></a>
  <i class="arrow"></i>
  <span>编辑频道</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">频道基本信息</a></li>
        <li><a href="javascript:;" onclick="tabs(this);">URL配置信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">

<dl>
    <dt>标题</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*标题备注，允许中文。</span></dd>
  </dl>
  
    <dl>
    <dt>字段名称</dt>
    <dd>
      <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="请填写正确的名称！" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*频道名称，只允许使用英文、数字或下划线。</span>
    </dd>
  </dl>
  
  <dl>
    <dt>所属分类</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlCategoryId" runat="server" datatype="*" errormsg="请选择所属分类！" sucmsg=" "></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>开启相册功能</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsAlbums" runat="server" />
      </div>
      <span class="Validform_checktip">*开启相册功能后可上传多张图片</span>
    </dd>
  </dl>
  <dl>
    <dt>开启附件功能</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsAttach" runat="server" />
      </div>
      <span class="Validform_checktip">*开启附件功能后可上传多个附件。</span>
    </dd>
  </dl>
  <dl>
    <dt>开启会员价格</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsGroupPrice" runat="server" />
      </div>
      <span class="Validform_checktip">*只有当会员功能开启状态下才生效</span>
    </dd>
  </dl>
  <dl>
    <dt>分页数量</dt>
    <dd>
      <asp:TextBox ID="txtPageSize" runat="server" CssClass="input small" datatype="n" sucmsg=" ">10</asp:TextBox>
      <span class="Validform_checktip">*列表页每页显示数据数量</span>
    </dd>
  </dl>
  <dl>
    <dt>排序数字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*数字，越小越向前</span>
    </dd>
  </dl>
  <dl>
    <dt>选择字段</dt>
    <dd>
      <div class="rule-multi-porp">
          <asp:CheckBoxList ID="cblAttributeField" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
      </div>
    </dd>
  </dl>
</div>
<div class="tab-content" style="display:none;">
  <dl>
    <dt>URL生成配置</dt>
    <dd><a id="itemAddButton" class="icon-btn add"><i></i><span>添加页面</span></a></dd>
  </dl>
  <dl>
    <dt></dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        <thead>
          <tr>
            <th width="12%">类型</th>
            <th width="20%">调用名称</th>
            <th width="28%">生成文件名</th>
            <th width="28%">模板文件名</th>
            <th width="10%">操作</th>
          </tr>
        </thead>
        <tbody id="item_box">
          <asp:Repeater ID="rptList" runat="server">
          <ItemTemplate>
          <tr class="td_c">
            <td>
              <input type="hidden" name="item_rewrite" value="<%#Eval("url_rewrite_str") %>" />
              <input type="hidden" name="item_type" value="<%#Eval("type")%>" />
              <span class="item_type"><%#GetPageTypeTxt(Eval("type").ToString())%></span>
            </td>
            <td>
              <input type="hidden" name="old_item_name" value="<%#Eval("name")%>" />
              <input type="hidden" name="item_name" value="<%#Eval("name")%>" />
              <span class="item_name"><%#Eval("name")%></span>
            </td>
            <td>
              <input type="hidden" name="item_page" value="<%#Eval("page")%>" />
              <span class="item_page"><%#Eval("page")%></span>
            </td>
            <td>
              <input type="hidden" name="item_templet" value="<%#Eval("templet")%>" />
              <span class="item_templet"><%#Eval("templet")%></span>
            </td>
            <td>
              <a title="编辑" class="img-btn edit operator" onclick="showChannelDialog(this);">编辑</a>
              <a title="删除" class="img-btn del operator" onclick="delItemTr(this);">删除</a>
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
