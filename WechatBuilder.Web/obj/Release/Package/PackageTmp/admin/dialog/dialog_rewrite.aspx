<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_rewrite.aspx.cs" Inherits="MxWeiXinPF.Web.admin.dialog.dialog_rewrite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>URL重写表达式窗口</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确定',
        focus: true,
        callback: function () {
            submitForm();
            return false;
        }
    }, {
        name: '取消'
    });

    //页面加载完成执行
    $(function () {
        if ($(api.data).length > 0) {
            var parentObj = $(api.data).parent().parent(); //取得节点父对象
            //分析正则表达式
            var strPath = $(parentObj).find("input[name='itemPath']").val().replace(new RegExp("{\\d+}", "g"), "(.*)"); //替换成正则表达式
            var strPattern = $(parentObj).find("input[name='itemPattern']").val();
            var pathArr = strPattern.match(strPath);
            //开始赋值
            $("#txtItemPath").val($(parentObj).find("input[name='itemPath']").val());
            if ($(parentObj).find("input[name='itemQuerystring']").val() != "") {
                var querystrArr = $(parentObj).find("input[name='itemQuerystring']").val().split("^");
                for (i = 0; i < querystrArr.length; i++) {
                    //插入一行TR并赋值变量
                    var trObj = $("#tr_box").append(createVarHtml());
                    var strArr = querystrArr[i].split("=");
                    $(trObj).children("tr").eq(i).find("input[name='varName']").val(strArr[0]);
                    //赋值正则表达式
                    $(trObj).children("tr").eq(i).find("input[name='varExp']").val(pathArr[i + 1]);
                }
            }
        }
    });

    //提交表单处理
    function submitForm() {
        //验证表单
        if ($("#txtItemPath").val() == "") {
            W.$.dialog.alert('请填写重写表达式！', function () { $("#txtItemPath").focus(); }, api);
            return false;
        }
        //查找变量表达式
        var patternStr = $("#txtItemPath").val();
        var querystringStr = "";
        $("#tr_box tr").each(function (i) {
            if ($(this).find("input[name='varName']").val() != "" && $(this).find("input[name='varExp']").val() != "") {
                patternStr = patternStr.replace("{" + i + "}", $(this).find("input[name='varExp']").val());
                querystringStr += $(this).find("input[name='varName']").val() + "=$" + (i + 1);
                if (i < $("#tr_box tr").length - 1) {
                    querystringStr += "^";
                }
            }
        });
        //添加或修改
        if ($(api.data).length > 0) {
            var parentObj = $(api.data).parent().parent();
            parentObj.find("input[name='itemPath']").val($("#txtItemPath").val());
            parentObj.find("input[name='itemPattern']").val(patternStr);
            parentObj.find("input[name='itemQuerystring']").val(querystringStr);
        } else {
            var trHtml = '<tr class="td_c">'
            + '<td><input type="text" name="itemPath" class="td-input" value="' + $("#txtItemPath").val() + '" style="width:90%;" readonly="readonly" /></td>'
            + '<td><input type="text" name="itemPattern" class="td-input" value="' + patternStr + '" style="width:90%;" readonly="readonly" /></td>'
            + '<td><input type="text" name="itemQuerystring" class="td-input" value="' + querystringStr + '" style="width:90%;" readonly="readonly" /></td>'
            + '<td>'
            + '<i class="icon"></i>'
            + '<a title="编辑" class="img-btn edit operator" onclick="showUrlDialog(this);">编辑</a>'
            + '<a title="删除" class="img-btn del operator" onclick="delUrlNode(this);">删除</a>'
            + '</td>'
            + '</tr>'
            //如果是窗口调用则添加到窗口
            if (!api.get('dialogChannel') || !api.get('dialogChannel')) {
                $("#var_box", W.document).append(trHtml);
            } else {
                $("#var_box", api.get('dialogChannel').document).append(trHtml);
            }
        }
        api.close();
    }

    //创建URL变量HTML
    function createVarHtml() {
        varHtml = '<tr class="td_c">'
        + '<td><select class="select1" onchange="setVal(this, \'varName\');"><option value="">@规定参数</option><option value="id">文章ID</option><option value="category_id">类别ID</option><option value="page">分页页码</option></select>\n'
        + '<input type="text" name="varName" class="td-input" style="width:60%;" /></td>'
        + '<td><select class="select1" onchange="setVal(this, \'varExp\');"><option value="">@参考正则</option><option value="(\\w+)">字符串</option><option value="(\\d+)">数字</option></select>\n'
        + '<input type="text" name="varExp" class="td-input" style="width:60%;" /></td>'
        + '<td><a title="删除" class="img-btn del operator" onclick="delVarTr(this);">删除</a></td>'
        + '</tr>'
        return varHtml;
    }

    //添加一行变量
    function addVarTr() {
        varHtml = createVarHtml();
        $("#tr_box").append(varHtml);
        api.size($(document).width(), $(document).height());
    }
    //删除一行变量
    function delVarTr(obj) {
        $(obj).parent().parent().remove();
        api.size($(document).width(), $(document).height() - 32);
    }

    //赋值参考选项
    function setVal(obj, objName) {
        var value = $(obj).children("option:selected").attr("value");
        if (value != "") {
            $(obj).next("input[name='" + objName + "']").val(value);
        }
    }
</script>
</head>

<body>
<div class="div-content">
    <dl>
      <dt>重写表达式</dt>
      <dd>
        <input type="text" id="txtItemPath" class="input normal" />
        <span class="Validform_checktip">*如：article-{0}-{1}.aspx，{n}表示第N个变量</span>
      </dd>
    </dl>
    <dl>
    <dt>传输参数</dt>
    <dd>
      <a class="icon-btn add" onclick="addVarTr();"><i></i><span>添加变量</span></a>
    </dd>
  </dl>
    <dl>
      <dt></dt>
      <dd>
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        <thead>
          <tr>
            <th width="45%">变量名称</th>
            <th width="45%">正则表达式</th>
            <th width="8%">操作</th>
          </tr>
        </thead>
        <tbody id="tr_box"></tbody>
      </table>
      </dd>
    </dl>
</div>
</body>
</html>
