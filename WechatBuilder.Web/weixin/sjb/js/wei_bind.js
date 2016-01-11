window['BBC.weixin.coastalcitybind.time'] && window['BBC.weixin.coastalcitybind.time'].push(new Date());
function $addClass(ids, cName) {
	$setClass(ids, cName, "add");
};
function $addEvent(obj, type, handle) {
	if (!obj || !type || !handle) {
		return;
	}
	if ( obj instanceof Array) {
		for (var i = 0, l = obj.length; i < l; i++) {
			$addEvent(obj[i], type, handle);
		}
		return;
	}
	if ( type instanceof Array) {
		for (var i = 0, l = type.length; i < l; i++) {
			$addEvent(obj, type[i], handle);
		}
		return;
	}
	window.__allHandlers = window.__allHandlers || {};
	window.__Hcounter = window.__Hcounter || 1;
	function setHandler(obj, type, handler, wrapper) {
		obj.__hids = obj.__hids || [];
		var hid = 'h' + window.__Hcounter++;
		obj.__hids.push(hid);
		window.__allHandlers[hid] = {
			type : type,
			handler : handler,
			wrapper : wrapper
		}
	}

	function createDelegate(handle, context) {
		return function() {
			return handle.apply(context, arguments);
		};
	}

	if (window.addEventListener) {
		var wrapper = createDelegate(handle, obj);
		setHandler(obj, type, handle, wrapper)
		obj.addEventListener(type, wrapper, false);
	} else if (window.attachEvent) {
		var wrapper = createDelegate(handle, obj);
		setHandler(obj, type, handle, wrapper)
		obj.attachEvent("on" + type, wrapper);
	} else {
		obj["on" + type] = handle;
	}
};
function $addSelect(e, t, v) {
	var o = new Option(t, v);
	e.options[e.options.length] = o;
	return o;
};
function $addToken(url, type) {
	var token = $getToken();
	if (url == "" || (url.indexOf("://") < 0 ? location.href : url).indexOf("http") != 0) {
		return url;
	}
	if (url.indexOf("#") != -1) {
		var f1 = url.match(/\?.+\#/);
		if (f1) {
			var t = f1[0].split("#"), newPara = [t[0], "&g_tk=", token, "&g_ty=", type, "#", t[1]].join("");
			return url.replace(f1[0], newPara);
		} else {
			var t = url.split("#");
			return [t[0], "?g_tk=", token, "&g_ty=", type, "#", t[1]].join("");
		}
	}
	return token == "" ? (url + (url.indexOf("?") != -1 ? "&" : "?") + "g_ty=" + type) : (url + (url.indexOf("?") != -1 ? "&" : "?") + "g_tk=" + token + "&g_ty=" + type);
};
var $ajax = (function(window, undefined) {
	var oXHRCallbacks, xhrCounter = 0;
	var fXHRAbortOnUnload = window.ActiveXObject ? function() {
		for (var key in oXHRCallbacks) {
			oXHRCallbacks[key](0, 1);
		}
	} : false;
	return function(opt) {
		var o = {
			url : '',
			method : 'GET',
			data : null,
			type : "text",
			async : true,
			cache : false,
			timeout : 0,
			autoToken : true,
			username : '',
			password : '',
			beforeSend : $empty(),
			onSuccess : $empty(),
			onError : $empty(),
			onComplete : $empty()
		};
		for (var key in opt) {
			o[key] = opt[key]
		}
		var callback, timeoutTimer, xhrCallbackHandle, ajaxLocation, ajaxLocParts;
		try {
			ajaxLocation = location.href;
		} catch (e) {
			ajaxLocation = document.createElement("a");
			ajaxLocation.href = "";
			ajaxLocation = ajaxLocation.href;
		}
		ajaxLocParts = /^([\w\+\.\-]+:)(?:\/\/([^\/?#:]*)(?::(\d+)|)|)/.exec(ajaxLocation.toLowerCase()) || [];
		o.isLocal = /^(?:about|app|app\-storage|.+\-extension|file|res|widget):$/.test(ajaxLocParts[1]);
		o.method = ( typeof (o.method) != "string" || o.method.toUpperCase() != "POST") ? "GET" : "POST";
		o.data = $makeUrl(o.data);
		if (o.method == 'GET' && o.data) {
			o.url += (o.url.indexOf("?") < 0 ? "?" : "&") + o.data;
		}
		if (o.autoToken) {
			o.url = $addToken(o.url, "ajax");
		}
		o.xhr = $xhrMaker();
		if (o.xhr === null) {
			return false;
		}
		try {
			if (o.username) {
				o.xhr.open(o.method, o.url, o.async, o.username, o.password);
			} else {
				o.xhr.open(o.method, o.url, o.async);
			}
		} catch (e) {
			o.onError(-2, e);
			return false;
		}
		if (o.method == 'POST') {
			o.xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
		}
		if (!o.cache) {
			o.xhr.setRequestHeader('If-Modified-Since', 'Thu, 1 Jan 1970 00:00:00 GMT');
			o.xhr.setRequestHeader('Cache-Control', 'no-cache');
		}
		o.beforeSend(o.xhr);
		if (o.async && o.timeout > 0) {
			if (o.xhr.timeout === undefined) {
				timeoutTimer = setTimeout(function() {
					if (o.xhr && callback) {
						callback(0, 1);
					}
					o.onError(0, null, 'timeout');
				}, o.timeout);
			} else {
				o.xhr.timeout = o.timeout;
				o.xhr.ontimeout = function() {
					if (o.xhr && callback) {
						callback(0, 1);
					}
					o.onError(0, null, 'timeout');
				};
			}
		}
		o.xhr.send(o.method == 'POST' ? o.data : null);
		callback = function(e, isAbort) {
			if (timeoutTimer) {
				clearTimeout(timeoutTimer);
				timeoutTimer = undefined;
			}
			if (callback && (isAbort || o.xhr.readyState === 4)) {
				callback = undefined;
				if (xhrCallbackHandle) {
					o.xhr.onreadystatechange = $empty();
					if (fXHRAbortOnUnload) {
						try {
							delete oXHRCallbacks[xhrCallbackHandle];
						} catch (e) {
						}
					}
				}
				if (isAbort) {
					if (o.xhr.readyState !== 4) {
						o.xhr.abort();
					}
				} else {
					var status, statusText, responses;
					responses = {
						headers : o.xhr.getAllResponseHeaders()
					};
					status = o.xhr.status;
					try {
						statusText = o.xhr.statusText;
					} catch (e) {
						statusText = "";
					}
					try {
						responses.text = o.xhr.responseText;
					} catch (e) {
						responses.text = "";
					}
					if (!status && o.isLocal) {
						status = responses.text ? 200 : 404;
					} else if (status === 1223) {
						status = 204;
					}
					if (status >= 200 && status < 300) {
						responses.text = responses.text.replace(/<!--\[if !IE\]>[\w\|]+<!\[endif\]-->/g, '');
						switch (o.type) {
							case 'text':
								o.onSuccess(responses.text);
								break;
							case "json":
								var json;
								try {
									json = (new Function("return (" + responses.text + ")"))();
								} catch (e) {
									o.onError(status, e, responses.text);
								}
								if (json) {
									o.onSuccess(json);
								}
								break;
							case "xml":
								o.onSuccess(o.xhr.responseXML);
								break;
						}
					} else {
						if (status === 0 && o.timeout > 0) {
							o.onError(status, null, 'timeout');
						} else {
							o.onError(status, null, statusText);
						}
					}
					o.onComplete(status, statusText, responses);
				}
				delete o.xhr;
			}
		};
		if (!o.async) {
			callback();
		} else if (o.xhr.readyState === 4) {
			setTimeout(callback, 0);
		} else {
			xhrCallbackHandle = ++xhrCounter;
			if (fXHRAbortOnUnload) {
				if (!oXHRCallbacks) {
					oXHRCallbacks = {};
					if (window.attachEvent) {
						window.attachEvent("onunload", fXHRAbortOnUnload);
					} else {
						window["onunload"] = fXHRAbortOnUnload;
					}
				}
				oXHRCallbacks[xhrCallbackHandle] = callback;
			}
			o.xhr.onreadystatechange = callback;
		}
	};
})(window, undefined);
function $delClass(ids, cName) {
	$setClass(ids, cName, "remove");
};
function $empty() {
	return function() {
		return true;
	}
};
function $getCookie(name) {
	var reg = new RegExp("(^| )" + name + "(?:=([^;]*))?(;|$)"), val = document.cookie.match(reg);
	return val ? (val[2] ? unescape(val[2]) : "") : null;
};
function $getTarget(e, parent, tag) {
	var e = window.event || e, tar = e.srcElement || e.target;
	if (parent && tag && tar.nodeName.toLowerCase() != tag) {
		while ( tar = tar.parentNode) {
			if (tar == parent || tar == document.body || tar == document) {
				return null;
			} else if (tar.nodeName.toLowerCase() == tag) {
				break;
			}
		}
	}
	;
	return tar;
};
function $getToken() {
	var skey = $getCookie("skey"), token = skey == null ? "" : $time33(skey);
	return token;
};
function $hasClass(old, cur) {
	if (!old || !cur)
		return null;
	var arr = ( typeof old == 'object' ? old.className : old).split(' ');
	for (var i = 0, len = arr.length; i < len; i++) {
		if (cur == arr[i]) {
			return cur;
		}
	}
	;
	return null;
};
function $id(id) {
	return typeof (id) == "string" ? document.getElementById(id) : id;
};
function $isMobile(v) {
	var cm = "134,135,136,137,138,139,150,151,152,157,158,159,187,188,147,182,183", cu = "130,131,132,155,156,185,186,145", ct = "133,153,180,181,189", v = v || "", h1 = v.substring(0, 3), h2 = v.substring(0, 4), v = (/^1\d{10}$/).test(v) ? (cu.indexOf(h1) >= 0 ? "联通" : (ct.indexOf(h1) >= 0 ? "电信" : (h2 == "1349" ? "电信" : (cm.indexOf(h1) >= 0 ? "移动" : "未知")))) : false;
	return v;
};
function $isMail(mail) {
	var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
	if (filter.test(mail))
		return true;
	else {
		return false;
	}
};
function $isId(value) {
	var filter = /(^\d{14}\w{1}$)|(^\d{17}\w{1}$)/;
	if (filter.test(value))
		return true;
	else {
		return false;
	}
};
function $makeUrl(data) {
	var arr = [];
	for (var k in data) {
		arr.push(k + "=" + data[k]);
	}
	;
	return arr.join("&");
};
function $namespace(name) {
	for (var arr = name.split(','), r = 0, len = arr.length; r < len; r++) {
		for (var i = 0, k, name = arr[r].split('.'), parent = {}; k = name[i]; i++) {
			i === 0 ? eval('(typeof ' + k + ')==="undefined"?(' + k + '={}):"";parent=' + k) : ( parent = parent[k] = parent[k] || {});
		}
	}
};
function $setClass(ids, cName, kind) {
	if (!ids) {
		return;
	}
	var set = function(obj, cName, kind) {
		if (!obj) {
			return;
		}
		var oldName = obj.className, arrName = oldName ? oldName.split(' ') : [];
		if (kind == "add") {
			if (!$hasClass(oldName, cName)) {
				arrName.push(cName);
				obj.className = arrName.join(' ');
			}
		} else if (kind == "remove") {
			var newName = [];
			for (var i = 0, l = arrName.length; i < l; i++) {
				if (cName != arrName[i] && ' ' != arrName[i]) {
					newName.push(arrName[i]);
				}
			}
			obj.className = newName.join(' ');
		}
	};
	if ( typeof (ids) == "string") {
		var arrDom = ids.split(",");
		for (var i = 0, l = arrDom.length; i < l; i++) {
			if (arrDom[i]) {
				set($id(arrDom[i]), cName, kind);
			}
		}
	} else if ( ids instanceof Array) {
		for (var i = 0, l = ids.length; i < l; i++) {
			if (ids[i]) {
				set(ids[i], cName, kind);
			}
		}
	} else {
		set(ids, cName, kind);
	}
};
function $strTrim(str, code) {
	var argus = code || "\\s";
	var temp = new RegExp("(^" + argus + "*)|(" + argus + "*$)", "g");
	return str.replace(temp, "");
};
function $time33(str) {
	for (var i = 0, len = str.length, hash = 5381; i < len; ++i) {
		hash += (hash << 5) + str.charAt(i).charCodeAt();
	}
	;
	return hash & 0x7fffffff;
};
function $xhrMaker() {
	var xhr;
	try {
		xhr = new XMLHttpRequest();
	} catch (e) {
		try {
			xhr = new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e) {
			try {
				xhr = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e) {
				xhr = null;
			}
		}
	}
	;
	return xhr;
};
function $xss(str, type) {
	if (!str) {
		return str === 0 ? 0 : "";
	}
	switch (type) {
		case "none":
			return str + "";
			break;
		case "html":
			return str.replace(/[&'"<>\/\\\-\x00-\x09\x0b-\x0c\x1f\x80-\xff]/g, function(r) {
				return "&#" + r.charCodeAt(0) + ";"
			}).replace(/ /g, "&nbsp;").replace(/\r\n/g, "<br />").replace(/\n/g, "<br />").replace(/\r/g, "<br />");
			break;
		case "htmlEp":
			return str.replace(/[&'"<>\/\\\-\x00-\x1f\x80-\xff]/g, function(r) {
				return "&#" + r.charCodeAt(0) + ";"
			});
			break;
		case "url":
			return escape(str).replace(/\+/g, "%2B");
			break;
		case "miniUrl":
			return str.replace(/%/g, "%25");
			break;
		case "script":
			return str.replace(/[\\"']/g, function(r) {
				return "\\" + r;
			}).replace(/%/g, "\\x25").replace(/\n/g, "\\n").replace(/\r/g, "\\r").replace(/\x01/g, "\\x01");
			break;
		case "reg":
			return str.replace(/[\\\^\$\*\+\?\{\}\.\(\)\[\]]/g, function(a) {
				return "\\" + a;
			});
			break;
		default:
			return escape(str).replace(/[&'"<>\/\\\-\x00-\x09\x0b-\x0c\x1f\x80-\xff]/g, function(r) {
				return "&#" + r.charCodeAt(0) + ";"
			}).replace(/ /g, "&nbsp;").replace(/\r\n/g, "<br />").replace(/\n/g, "<br />").replace(/\r/g, "<br />");
			break;
	}
};

// 以上为框架代码；
// 以下为业务代码；
// =======================================================================================
var urlhost = window.location.host;
var ticket = $id("u_ticket").value || "";
var code = $id("u_code") ? ($id("u_code").value || "") : '';
var wticket = $id("u_wticket").value || "";
var qrcode = $id("u_qrcode").value || "";
var isAjax = $id("isAjax").value || "";
var ucCrmNo = $id("ucCrmNo")?($id("ucCrmNo").value || ""):"";

var submitData = [];

if (submitUrl == '/wsh/modUser' || submitUrl == '/wsh/bindCard') {
	var obj = document.getElementById('inBirthYear');
	if(obj){
		for (var i = 2014; i > 1913; i--) {
			$addSelect(obj, i, i);
		}
	}

	if($id("gradenameboy")){
		$addEvent([$id("gradenameboy"), $id("gradenamegirl")], "click", function(e) {
			$delClass($id("gradenameboy"), "checked");
			$delClass($id("gradenamegirl"), "checked");
			$addClass($getTarget(e), "checked");
		});
	}

    if($id("protocol")) {
        $addEvent($id("protocol"), "click", function(e) {
            if($hasClass($id('protocol').className, 'checked')) {
                $delClass($id("protocol"), "checked");
            } else {
                $addClass($id("protocol"), "checked");
            }
        });
    }

	if($id("inBirthYear")){
		$addEvent([$id("inBirthYear"), $id("inBirthMonth"), $id("inBirthDay")], "change", function(e) {
			if ($id("inBirthYear").value != '0' && $id("inBirthMonth").value != '0' && $id("inBirthDay").value != '0') {
				$id("inBirthday").value = $id("inBirthYear").value + '-' + $id("inBirthMonth").value + '-' + $id("inBirthDay").value;
			} else {
				$id("inBirthday").value = '';
			}

			testSubmitOk("inBirthday");
		});
	}
}

if (submitUrl == '/wsh/modUser') {
	var obj = document.getElementById('inBabyBirthYear');
	if(obj){
		for (var i = 2014; i > 1913; i--) {
			$addSelect(obj, i, i);
		}
	}

	if($id("gradenameboy")){
		$addEvent([$id("gradenameboy"), $id("gradenamegirl")], "click", function(e) {
			$delClass($id("gradenameboy"), "checked");
			$delClass($id("gradenamegirl"), "checked");
			$addClass($getTarget(e), "checked");
		});
	}

	if($id("inBabyBirthYear")){
		$addEvent([$id("inBabyBirthYear"), $id("inBabyBirthMonth"), $id("inBabyBirthDay")], "change", function(e) {
			if ($id("inBabyBirthYear").value != '0' && $id("inBabyBirthMonth").value != '0' && $id("inBabyBirthDay").value != '0') {
				$id("inBabyBirthday").value = $id("inBabyBirthYear").value + '-' + $id("inBabyBirthMonth").value + '-' + $id("inBabyBirthDay").value;
			} else {
				$id("inBabyBirthday").value = '';
			}

			testSubmitOk("inBabyBirthday");
		});
	}
}

$addEvent($id("recaptchaBtn"), "click", function(e) {
	var inTel = $strTrim($id("inTel").value);
	if ($hasClass($id('recaptchaBtn').className, 'disabled') || !inTel) {
		return;
	}
	if (inTel && ($isMobile(inTel) != 0)) {
		$ajax({
			url :  'http://' + urlhost + '/ucard/weixin/sendsmsyzm.ashx?t=' + new Date().getTime(),
			method : 'post',
			type : 'json',
			data : {
				"tel" : inTel,
//				"code" : code,
//				"ticket" : ticket,
//				"wticket" : wticket,
//				"qrcode" : qrcode,
				"isAjax" : isAjax
			},
			onSuccess : function(data) {
				try {
					if (data.code == 0) {
						showTips("验证码已发送至手机，请查收");
						$addClass($id("recaptchaBtn"), 'disabled');
						var timeroll = 60;
						var checkTimerMove = setInterval(function() {
							if (timeroll > 0) {
								$id("recaptchaBtn").innerHTML = $xss(timeroll + "秒后重新获取", "none");
								timeroll--;
							} else {
                                /*再次获取可点击*/
                                $delClass($id("recaptchaBtn"), "disabled");
								clearInterval(checkTimerMove);
								$id("recaptchaBtn").innerHTML = $xss("再次获取", "none");

								testSubmitOk('inTel');
							}
						}, 1000);
					} else if(data.code == 5) {
						showTips("验证次数超限，请明天再试");
					} else {
						showTips("系统繁忙");
                    }
				} catch (e) {
				}
			},
			onError : function(msg) {
				showTips("网络问题，请稍后重试");
			}
		});
	} else {
		showTips("请输入正确的手机号码");
		$id("inTel").focus();
	}
});

$addEvent($id("submitBtn"), "click", function(e) {
	if ($hasClass($id('submitBtn').className, 'disabled') || !checkInputTxt()) {
		return;
	}

	var da = {
		'ticket' : ticket,
		'code' : code,
		"wticket" : wticket,
		"qrcode" : qrcode,
		"isAjax" : isAjax
	};
	for (key in submitData) {
		if(key == 'inCardNo' && ucCrmNo && submitData[key] && ucCrmNo != submitData[key]){
			if(!confirm('您确定要启用尾号为' + submitData[key].substr(-3) + '的新卡？（绑定后，原微信中领取的会员卡将不能使用）')){
				return;
			}
		}
      //  alert(key+":"+submitData[key]);
      
		da[key] = submitData[key];
	}
    // alert('http://' + urlhost + "/ucard/weixin/ucardProc.ashx" + '?t=' + new Date().getTime()+'&myact=addUser');
     

   // alert('http://' + urlhost + submitUrl + '?t=' + new Date().getTime());

    MLoading.show('资料提交中...');
    $addClass($id('submitBtn'), 'disabled');
	$ajax({
		url : 'http://' + urlhost + "/ucard/weixin/ucardProc.ashx" + '?t=' + new Date().getTime()+'&myact=addUser',
		method : 'post',
		type : 'json',
		data : da,
		onSuccess : function(data) {
            MLoading.hide();
			if (data.code == 0) {
				showTips(data.message);
				setTimeout(function() {
					window.location.href =  'http://' + urlhost + "/ucard/weixin/index.aspx?openid="+code;
				}, 2000);
			} else {
				if (data.code == 200) {
                    $delClass($id('submitBtn'), 'disabled');
					 WeixinJSBridge.invoke('addContact',{
                         "webtype" : "1", // 添加联系人的场景，1表示企业联系人。
                         "username" : data.result.wxid,　// 需要添加的联系人username
	                 },function(res){
	                     // 关注成功提交表单
	                     if (res.err_msg == 'add_contact:ok') {
	                    	 $id("submitBtn").click();
	                     }
	                 });
				}else if (data.message) {
                    $delClass($id('submitBtn'), 'disabled');
					showTips($strTrim(data.message));
				} else {
                    $delClass($id('submitBtn'), 'disabled');
					showTips("失败，请重试");
				}
			}
		},
		onError : function(msg) {
            $delClass($id('submitBtn'), 'disabled');
            MLoading.hide();
			alert("网络问题，请稍后重试");
		}
	});
});

var clearXs = document.getElementsByClassName("x");
for (var i = 0; i < clearXs.length; i++) {
	var clearXsObj = clearXs[i];
	if (clearXsObj) {
		$addEvent(clearXsObj, "click", function(e) {
			var obj = $getTarget(e);
			if (obj) {
				var tar = obj.getAttribute("tar");
				if (tar) {
					$id(tar).value = "";
					obj.style.display = "none";
				}
				if (tar == "inTel") {
					$addClass($id("recaptchaBtn"), 'disabled');
				}
			}
			$addClass($id("submitBtn"), 'disabled');
		});
	}
}

function checkInputTxt() {
	for (key in inputItems) {
		inputId = inputItems[key];

		var value = $id(inputId).value || "";

		value = $strTrim(value);

		submitData[inputId] = value;

		if (inputId == 'inTel' && (!value || $isMobile(value) == 0)) {
			showTips($id('spanMsg_' + inputId).innerHTML);
			$id(inputId).focus();
			return 0;
		} else if (inputId == "inEmail" && (!value || !$isMail(value))) {
			showTips($id('spanMsg_' + inputId).innerHTML);
			$id(inputId).focus();
			return 0;
		}else if (inputId == "inId" && (!value || !$isId(value))) {
			showTips($id('spanMsg_' + inputId).innerHTML);
			$id(inputId).focus();
			return 0;
		}else if(!value){
			showTips($id('spanMsg_' + inputId).innerHTML);
			$id(inputId).focus();
			return 0;
		}
	}

	// 性别
	if ((submitUrl == '/wsh/modUser' || submitUrl == '/wsh/bindCard') && $id('gradenamegirl')) {
		if ($hasClass($id('gradenameboy').className, 'checked')) {
			submitData['inGender'] = 1;
		} else if ($hasClass($id('gradenamegirl').className, 'checked')) {
			submitData['inGender'] = 2;
		} else {
			showTips($id('spanMsg_inGender').innerHTML);
			return 0;
		}
	}

    //协议
    if((submitUrl == '/wsh/modUser' || submitUrl == '/wsh/bindCard') && $id('protocol')) {
        if($hasClass($id('protocol').className, 'checked')) {
        } else {
            showTips($id('spanMsg_protocol').innerHTML);
            return 0;
        }
    }

	return 1;
}

function showTips(txt) {
	if (txt) {
		$id("tipscon").innerHTML = $xss(txt, "html");
		$id("showTips").style.display = "";
		setTimeout(function() {
			$id("showTips").style.display = "none";
		}, 3000);
	}
}

function hideTips(txt) {
	$id("showTips").style.display = "none";
}

function showOne(that) {
	if (that) {
		$addClass($id(that), 'focus');
	}
}

function hideOne(that) {
	if (that) {
		$delClass($id(that), 'focus');
	}
}

function testSubmitOk(inputId) {
	var value = $id(inputId).value || "";
    /* 产品要求获取验证码按钮时时可点击  故此处注释
	if (inputId == 'inTel') {
		if($id("recaptchaBtn").innerHTML == '获取验证码' || $id("recaptchaBtn").innerHTML == '再次获取'){
			if (value && ($isMobile(value) != 0)) {
		//		$delClass($id("recaptchaBtn"), "disabled");
			} else {
		//		$addClass($id("recaptchaBtn"), 'disabled');
			}
		}
	}
    */
	var allow = true;
	for (key in inputItems) {
		if (!$strTrim($id(inputItems[key]).value)) {
			allow = false;
			break;
		}
	}
	if (allow) {
		$delClass($id("submitBtn"), "disabled");
	} else {
		//$addClass($id("submitBtn"), 'disabled'); // 提交按钮改成常绿。
		$delClass($id("submitBtn"), "disabled");
	}
}

if($id('inTel')){
	testSubmitOk('inTel');
}

// 生日
if($id('inBirthday') && $id('inBirthday').value){
	var inBirthday = $id('inBirthday').value.split('-');

    //修改安卓兼容问题
	//for(key in $id("inBirthYear").options){
	for(var key=0;key < $id("inBirthYear").options.length; key++){
		if($id("inBirthYear").options[key].value == inBirthday[0]){
			$id("inBirthYear").options[key].selected = true;
		}
	}

    //修改安卓兼容问题
	//for(key in $id("inBirthMonth").options){
	for(var key=0; key < $id("inBirthMonth").options.length; key++){
		if($id("inBirthMonth").options[key].value == inBirthday[1]){
			$id("inBirthMonth").options[key].selected = true;
		}
	}
    //修改安卓兼容问题
	//for(key in $id("inBirthDay").options){
	for(var key=0; key < $id("inBirthDay").options.length; key++){
		if($id("inBirthDay").options[key].value == inBirthday[2]){
			$id("inBirthDay").options[key].selected = true;
		}
	}
}

// 宝宝生日
if($id('inBabyBirthday') && $id('inBabyBirthday').value){
	var inBirthday = $id('inBabyBirthday').value.split('-');
    //修改安卓兼容问题
	//for(key in $id("inBirthYear").options){
	for(var key=0;key < $id("inBabyBirthYear").options.length; key++){
		if($id("inBabyBirthYear").options[key].value == inBirthday[0]){
			$id("inBabyBirthYear").options[key].selected = true;
		}
	}
    //修改安卓兼容问题
	//for(key in $id("inBirthMonth").options){
	for(var key=0; key < $id("inBabyBirthMonth").options.length; key++){
		if($id("inBabyBirthMonth").options[key].value == inBirthday[1]){
			$id("inBabyBirthMonth").options[key].selected = true;
		}
	}
    //修改安卓兼容问题
	//for(key in $id("inBirthDay").options){
	for(var key=0; key < $id("inBabyBirthDay").options.length; key++){
		if($id("inBabyBirthDay").options[key].value == inBirthday[2]){
			$id("inBabyBirthDay").options[key].selected = true;
		}
	}
}

window['BBC.weixin.coastalcitybind'] = '20958:20130109:20130114165832';
window['BBC.weixin.coastalcitybind.time'] && window['BBC.weixin.coastalcitybind.time'].push(new Date());
/* |xGv00|fbc9a39c4267fc4517baa8b3c4af1ade */
