/**
 * 微生活html5页面 通用功能
 * @author luan luan
 */
var 
	/**
	 * 环境检测 _env.ios _env.android _env.version 等
	 */
	_env = (function(){ var _ua = navigator.userAgent, _m = null, _formatV = function(vstr, vdiv){ var f = vstr.split(vdiv); f = f.shift()+'.'+f.join(''); return f*1; }, _rtn = { ua: _ua, version: null, ios: false, android: false, windows: false, blackberry: false, meizu: false, weixin: false, wVersion: null, qq: false, qVersion: null, touchSupport: ('createTouch' in document), hashSupport: !!('onhashchange' in window) }; _m = _ua.match(/MicroMessenger\/([\.0-9]+)/); if ( _m != null ){ _rtn.weixin = true; _rtn.wVersion = _formatV(_m[1], '.'); }_m = _ua.match(/QQ\/([\d\.]+)$/); if ( _m != null ){ _rtn.qq = true; _rtn.qVersion = _formatV(_m[1], '.'); } _m = _ua.match(/Android(\s|\/)([\.0-9]+)/); if ( _m != null ){ _rtn.android = true; _rtn.version = _formatV(_m[2], '.'); _rtn.meizu = /M030|M031|M032|MEIZU/.test(_ua); return _rtn; } _m = _ua.match(/i(Pod|Pad|Phone)\;.*\sOS\s([\_0-9]+)/); if ( _m != null ){ _rtn.ios = true; _rtn.version = _formatV(_m[2], '_'); return _rtn; } _m = _ua.match(/Windows\sPhone\sOS\s([\.0-9]+)/); if ( _m != null ){ _rtn.windows = true; _rtn.version = _formatV(_m[1], '.'); return _rtn; } var bb = { a: _ua.match(/\(BB1\d+\;\s.*\sVersion\/([\.0-9]+)\s/), b: _ua.match(/\(BlackBerry\;\s.*\sVersion\/([\.0-9]+)\s/), c: _ua.match(/^BlackBerry\d+\/([\.0-9]+)\s/), d: _ua.match(/\(PlayBook\;\s.*\sVersion\/([\.0-9]+)\s/) }; for (var k in bb){ if (bb[k] != null){ _m = bb[k]; _rtn.blackberry = true; _rtn.version = _formatV(_m[1], '.'); return _rtn; } } return _rtn; }()),
	_ua = _env.ua,
	_touchSupport = _env.ios || _env.android || _env.touchSupport,
	_hashSupport = _env.hashSupport,
	_isIOS = _env.ios,
	_isOldIOS = _env.ios && (_env.version<4.5),
	_isAndroid = _env.android,
	_isMeizu = _env.meizu,
	_isOldAndroid22 = _env.android && (_env.version<2.3),
	_isOldAndroid23 = _env.android && (_env.version<2.4),
	_clkEvtType = _touchSupport?'touchstart':'click',
	_movestartEvt = _touchSupport?'touchstart':'mousedown',
	_moveEvt = _touchSupport?'touchmove':'mousemove',
	_moveendEvt = _touchSupport?'touchend':'mouseup',
	_vendor = (/webkit/i).test(navigator.appVersion) ? "webkit": (/firefox/i).test(navigator.userAgent) ? "Moz": "opera" in window ? "O": (/MSIE/i).test(navigator.userAgent) ? "ms": "",
	_has3d = "WebKitCSSMatrix" in window && "m11" in new WebKitCSSMatrix(),
	_trnOpen = "translate" + (_has3d ? "3d(": "("),
	_trnClose = _has3d ? ",0)": ")",
	_needHistory = ( _isIOS && !!(window.history && window.history.pushState) ),
	_appCache = window.applicationCache,
	/**
	 * 基础的ajax方法, 提供给普通html5页面使用
	 * @param url
	 * @param method 'get'|'post'
	 * @param params 请求所带参数, 一个Object对象
	 * @param callback 一个json服务器端返回值的回调
	 * @param useJSON 返回值格式是否使用JSON true|false
	 */
	_doAjax = function(url, method, params, callback, useJSON)	{ if (typeof method == 'undefined') method = 'POST'; if (typeof params == 'undefined') params = null; if (typeof useJSON == 'undefined') useJSON = true; method = method.toLowerCase(); var xmlHttp = null, query = []; if(window.ActiveXObject) xmlHttp = new ActiveXObject("Microsoft.XMLHTTP"); else if(window.XMLHttpRequest) xmlHttp = new XMLHttpRequest(); else return false; xmlHttp.onreadystatechange = function(evt) { if(xmlHttp.readyState == 4) { if (xmlHttp.status == 200 || xmlHttp.status == 0) { var rtext = xmlHttp.responseText; var result = useJSON ? JSON.parse(rtext) : rtext; if (callback) callback.call(null, result); } } }; if (params) for (var k in params) query.push(k+'='+params[k]); if (!query.length) query = null; else query = query.join('&'); if (method == 'get' && query != null){ if(url.indexOf('?')>-1) url+= '&'; else url += '?'; url += query; query = null; } if (console && console.log) console.log('ajax: ', url, query); try{ xmlHttp.open(method, url, true); if (method == 'post'){ xmlHttp.setRequestHeader("content-type", "application/x-www-form-urlencoded"); } xmlHttp.setRequestHeader("X-Requested-With","XMLHttpRequest"); xmlHttp.send(query); } catch(ex) { throw "[ajax] request error"; } return true;	},
	/**
	 * 查找单个元素
	 */
	_q = function(s, context){if (context && typeof context === 'string'){ try{context = _q(context);}catch(ex){console.log(ex);return;} } return (context||document).querySelector(s);},
	/**
	 * 查找元素集合
	 */
	_qAll = function(s, context){if (context && typeof context === 'string'){ try{context = _q(context);}catch(ex){console.log(ex);return;} } return (context||document).querySelectorAll(s);},
	/**
	 * 合并元素查找结果
	 */
	_qConcat = function(){ 		var i=0, leng = arguments.length, arr=[]; 		for (;i<leng;i++){ 			var arg = arguments[i]; 			if (typeof arg === 'string') 				arg = _qAll(arg);			else if ('nodeType' in arg && arg.nodeType === 1)				arg = [arg];			_forEach(arg, function(aitem){				arr.push(aitem);			});		} 		return arr; 	},
	/**
	 * 运行时缓存池
	 */
	MCache = (function(){ var cache = {};  return { set:function(key,val) { cache[key]=val; }, get:function(key) { return cache[key]; }, clear:function() { cache = {}; }, remove:function(key) { delete cache[key]; } }; }()),
	/**
	 * 本地存储
	 */
	MStorage = (function(){var _session = window.sessionStorage, _local = window.localStorage, _get = function(k){var d = _getData(k); if (d != null) return d.value; return null; }, _getData = function(k){if (k in _session) {return JSON.parse(_session.getItem(k)); }else if (k in _local) return JSON.parse(_local.getItem(k)); else return null; }, _set = function(k, v){var d = {value: v, ts: (new Date).getTime() }; d = JSON.stringify(d); _session.setItem(k, d); _local.setItem(k, d); }, _clear = function(){_session.clear(); _local.clear(); }, _remove = function(k){_session.removeItem(k); _local.removeItem(k); }, _removeExpires = function(time){var now = (new Date).getTime(), data; for (var key in _local){data = MStorage.getData(key); if ( now - data.ts > time ){_local.removeItem(key);_session.removeItem(key); } } }; return {set: _set, get: _get, getData: _getData, clear: _clear, remove: _remove, removeExpires: _removeExpires }; }()),
	/**
	 * url hash 解析
	 */
	MURLHash = (function(){ function _map2query(q, separator) { var u=encodeURIComponent,k,r=[]; var d=separator?separator:'&'; for (k in q) r.push(u(k)+'='+u(q[k])); return r.join(d); } function _split2(s,separator) { var i = s.indexOf(separator); return i==-1 ? [s,''] : [s.substring(0,i),s.substring(i+1)]; } var hu = function(href, hashChar, separator) { var h = href||window.location.href; var s = separator||"&"; var uArr = _split2(h, hashChar||'#'); var href_part = uArr[0]; var hash_part = uArr[1]; this.map = {}; this.sign = s; if (hash_part) { var arr = hash_part.split(s); for (var i=0;i<arr.length;i++) { var s2 = arr[i]; var o = _split2(s2,'='); this.map[o[0]] = o[1]; } } this.size = function() { return this.keys().length; }; this.keys = function() { var k = []; for (var m in this.map) if (m != '_hashfoo_') k.push(m); return k; }; this.values = function(){ var v = []; for (var m in this.map) if (m != '_hashfoo_') v.push(this.map[m]); return v; };  this.put('_hashfoo_', Math.random()); }; hu.prototype.get = function(key) { return this.map[key]||null; }; hu.prototype.put = function(key, value) { this.map[key] = value; }; hu.prototype.set = hu.prototype.put; hu.prototype.putAll = function(m) { if(typeof(m)=='object') for (var item in m) this.map[item] = m[item]; }; hu.prototype.remove = function(key) { if (this.map[key]) { var newMap = {}; for (var item in this.map) if (item!=key) newMap[item] = this.map[item]; this.map = newMap; } }; hu.prototype.toString = function() { var m2 = {}; for (var m in this.map) if (m != '_hashfoo_') m2[m] = this.map[m]; return _map2query(m2, "&"); }; hu.prototype.clone = function() { return new hu('foo#' + this.toString(), this.sign); }; return hu; }()),
	/**
	 * 元素数据存取
	 */
	MData = (function(){ function line2Upper(str){ var re = new RegExp('\\-([a-z])','g'); if ( !re.test(str) ) return str; return str.toLowerCase().replace( re, RegExp.$1.toUpperCase() ); } function upper2Line(str){ return str.replace(/([A-Z])/g, '-$1').toLowerCase(); } function setD(ele, k, v){ ele.setAttribute('data-'+upper2Line(k), v); } function getD(ele, k){ var attr = ele.getAttribute('data-'+upper2Line(k)); return attr||undefined; } return function(ele, k, v) { if (arguments.length>2){/*set*/ try { ele.dataset[ line2Upper(k) ] = v; } catch(ex) { setD(ele, k, v); } }else{/*get*/ try { return ele.dataset[ line2Upper(k) ]; } catch(ex) { return getD(ele, k); } } }; }()),
	/**
	 * 检测离线缓存更新
	 */
	_checkOffline = function (){ var support = !!_appCache; if (!support) return;  _appCache.addEventListener("updateready", function(e){ if (_appCache.status == _appCache.UPDATEREADY) { try{_appCache.swapCache();}catch(ex1){} location.href = location.origin + location.pathname + '?rnd=' + Math.random() + location.hash; } }, false); },
	/**
	 * 为旧设备提供h5标签支持
	 */
	_html5FixForOldEnv = function(){ var tags = 'abbr,article,aside,audio,canvas,datalist,details,dialog,eventsource,fieldset,figure,figcaption,footer,header,hgroup,mark,menu,meter,nav,output,progress,section,small,time,video,legend'; tags.split(',').forEach(function(ele,idx,arr){ document.createElement(ele); }); _writeCSS(tags+'{display:block;}'); },
	/**
	 * 向页面写入css
	 */
	_writeCSS = function(css) { var s = document.createElement('style'); s.innerHTML = css; try{ _q('head').appendChild(s); }catch(ex){} },
	/**
	 * 测试是否支持fixed样式
	 */
	_testFixedSupport = function(){ var outer = document.createElement('div'),inner = document.createElement('div'),result = true;outer.style.position = 'absolute';outer.style.top = '200px'; 		inner.style.position = 'fixed'; 		inner.style.top = '100px'; 		outer.appendChild(inner); 		document.body.appendChild(outer); 		if (inner.getBoundingClientRect && 			inner.getBoundingClientRect().top == outer.getBoundingClientRect().top) { 			result = false; 		} 		document.body.removeChild(outer); 		return result; 	},
	_requestAnimFrame = (function(){
	    return  window.requestAnimationFrame       || 
	        window.webkitRequestAnimationFrame || 
	        window.mozRequestAnimationFrame    || 
	        window.oRequestAnimationFrame      || 
	        window.msRequestAnimationFrame     || 
	        function(callback, element){
	            return window.setTimeout(callback, 1000 / 60);
	        };
	})(),
	_cancelRequestAnimFrame = ( function() {
	    return window.cancelAnimationFrame          ||
	        window.webkitCancelRequestAnimationFrame    ||
	        window.mozCancelRequestAnimationFrame       ||
	        window.oCancelRequestAnimationFrame     ||
	        window.msCancelRequestAnimationFrame        ||
	        clearTimeout
	} )(),
	/**
	 * 为旧设备提供fixed特性
	 */
	_fixedStyleHook = function (on) {
	    if (!_q('.footFix')) return;
	    if (typeof on == "undefined") on = true;
	    var needFix = ('_needFixedStyle' in window) || (_env.ios && _env.version < 4.5) || (_env.android && _env.version < 3) || _env.meizu || (_env.blackberry && _env.version < 7) || !_testFixedSupport();
	    if (needFix) {
	    	if ( ('_realtimeFixedStyle' in window) && window._realtimeFixedStyle==true){
	    		var _hook1Itv;
	    		if (on){
	    			_hook1Itv = _requestAnimFrame(_fixedStyleHelper);
	    		}else{
	    			_cancelRequestAnimFrame(_hook1Itv);
	    		}
	    	}else{
	    		var _hook1TO;
		        if (on) {
		            _hook1TO = window.setTimeout(_fixedStyleHelper, 200);
		            window.addEventListener('scroll', _fixedStyleHelper);
		            window.addEventListener('orientationchange', _fixedStyleHelper);
		            window.addEventListener('touchmove', _fixedStyleHelper);
		            window.addEventListener('touchend', _fixedStyleHelper);
		        } else {
		            window.clearTimeout(_hook1TO);
		            window.removeEventListener('scroll', _fixedStyleHelper);
		            window.removeEventListener('orientationchange', _fixedStyleHelper);
		            window.removeEventListener('touchmove', _fixedStyleHelper);
		            window.removeEventListener('touchend', _fixedStyleHelper);
		        }
			}
	    }
	},
	_fixedStyleHelper = function (evt) {
	    _forEach(_qAll('.footFix'), function (ftObj) {
	        var $ft = ftObj,
	            wh = window.innerHeight,
	            wt = window.scrollY,
	            ftop = MData($ft, 'ffixTop'),
	            fbtm = MData($ft, 'ffixBottom'),
	            fh;
	        if ($ft) {
	            try {
	                fh = $ft.clientHeight;
	                $ft.style.position = 'absolute';
	                if (ftop) {
	                    $ft.style.top = wt + ftop * 1 + 'px';
	                } else if (fbtm) {
	                    $ft.style.top = wt + wh - fbtm * 1 - fh + 'px';
	                } else {
	                    $ft.style.top = wt + wh - fh + 'px';
	                }
	                $ft.style.bottom = 'auto';
	            } catch (ex) {}
	        }
	    });
	},
	/**
	 * 字符串trim
	 */
	_trim = function(str){return str.replace(/(^\s+|\s+$)/g, '');},
	/**
	 * 删除样式名
	 */
	_removeClass = function(obj, clsName) { if (typeof obj==='string'){try{obj = _q(obj);}catch(ex){console.log(ex);return;} } var re = new RegExp('(^|\\s)+('+clsName+')(\\s|$)+', 'g'); try{obj.className = obj.className.replace(re, "$1$3");}catch(ex){} re = null; },
	/**
	 * 增加样式名
	 */
	_addClass = function(obj, clsName) { if (typeof obj==='string'){try{obj = _q(obj);}catch(ex){console.log(ex);return;} } _removeClass(obj, clsName); obj.className = _trim(obj.className+" "+clsName); },
	/**
	 * 取得实际样式值
	 */
	_getRealStyle = function(object, styleName){ if (!object || !styleName) return; var rtn = ''; try{ rtn = (typeof(window.getComputedStyle) == 'undefined')?object.currentStyle[styleName]:window.getComputedStyle(object,null)[styleName]; } catch(ex) { rtn = object.style[styleName]; } return rtn.replace(/px$/, ''); },
	/**
	 * 遍历
	 */
	_forEach = function(arr, callback) { if (typeof arr === 'string'){ try{arr = _qAll(arr);}catch(ex){console.log(ex);return;} } Array.prototype.forEach.call(arr, callback); },
	/**
	 * 显示元素
	 */
	_show = function() { var i=0, lng=arguments.length, ele; for (;i<lng;i++){ ele = arguments[i]; if (typeof ele==='string'){try{ele = _q(ele);}catch(ex){console.log(ex);return;} } if (ele.nodeType != undefined && ele.nodeType == 1){ele.style.display = ''; ele.removeAttribute('hidden'); }else if (ele.hasOwnProperty('length')){ try{ var arr=[]; _forEach(ele, function(a,b,c){arr.push(a);}); _show.apply(null, arr); }catch(ex){} } } },
	/**
	 * 隐藏元素
	 */
	_hide = function() { var i=0, lng=arguments.length, ele; for (;i<lng;i++){ ele = arguments[i]; if (typeof ele==='string'){try{ele = _q(ele);}catch(ex){console.log(ex);return;} } if (ele && ele.nodeType != undefined && ele.nodeType == 1){ ele.style.display = 'none'; }else if (ele && ele.hasOwnProperty('length')){ try{ var arr=[]; _forEach(ele, function(a,b,c){arr.push(a);}); _hide.apply(null, arr); }catch(ex){} } } },
	/**
	 * 修正过的setTimeout
	 */
	_setTimeout = function() {var func = arguments[0], timeout = arguments[1], args = Array.prototype.slice.call(arguments, 2); return window.setTimeout(function(args){return function(){func.apply(null, args); } }(args), timeout); },
	/**
	 * 注册页面结构加载后的回调 改进的onload
	 */
	_onPageLoaded = function(callback) {window.addEventListener('DOMContentLoaded',callback);},
	/**
	 * 页面跳到顶端
	 */
	_pageToTop = function(){
		_q('body').scrollTop = -1;
		window.scrollTo(0,-1);
	},
	/**
	 * 事件委托
	 */
	_delegate = function(){
		var func = arguments[0], 			thisObj = arguments[1], 			params = Array.prototype.slice.call(arguments, 2); 			if (params.length == 1 && params[0] instanceof Array) 				params = params[0]; 		return function(){			var nowArgs = [],				i = 0,				lng = arguments.length;			for(;i<lng;i++) nowArgs[i] = arguments[i];			nowArgs = nowArgs.concat(params);			func.apply(thisObj, nowArgs);		}; 
	},
	/**
	 * 模拟用户点击事件
	 */
	_fakeClick = function(fn) /*for ios safari*/
	{
		_q('body').insertAdjacentHTML('beforeEnd', '<a href="javascript:void(0)" id="fakeClick" style="opacity:.01"></a>');        var $a = _q('#fakeClick'),        	evt;        $a.addEventListener("click", function(e){            e.preventDefault();            fn();        });        if (document.createEvent) {            evt = document.createEvent("MouseEvents");            if (evt.initMouseEvent) {                evt.initMouseEvent("click", true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);                $a.dispatchEvent(evt);            }        }        $a.parentNode.removeChild($a);
	},
	/**
	 * 隐藏软键盘(目前对android无效)
	 */
	_hideKeyboard = function(){
		if ('activeElement' in document)
			document.activeElement.blur();
		window.focus();
	},
	/**
	 * 调试输出工具
	 */
	console = window.console || {log: function(){}};

//页面加载时自动执行
_checkOffline();
_html5FixForOldEnv();

//微信@IOS7宽度错误 且_env.weixin第一次进入不正确
if (/iPad/.test(_ua) && _env.ios && _env.version >= 7){
	_onPageLoaded(function(){
		_q('body').style.width = window.innerWidth + 'px';
		
		window.addEventListener('orientationchange', function(e){
			_q('body').style.width = window.innerWidth + 'px';
		}, false);
	});
}



/**
 * 屏蔽页面级别被微信注入的滑动效果
 */
var _preventWXPageScroll = function(){
	if (!_env.ios) return;
	if (_env.version>6) return;
	if (!_env.weixin) return;
	var xStart, 
		yStart = 0,
		allowUp,
		allowDown,
		prevTop,
		prevBot,
		d = document;
	var em = function(e) {
		var xRightDirect = e.touches[0].screenX > xStart;
		var yDownDirect = e.touches[0].screenY > yStart;
	    var xMovement = Math.abs(e.touches[0].screenX - xStart);
	    var yMovement = Math.abs(e.touches[0].screenY - yStart);
	    allowUp = d.body.scrollTop > 0;
		allowDown = d.body.scrollTop<d.body.clientHeight - window.innerHeight;
		if (xMovement > 10 && xRightDirect) { //防止微信中右划出页面
			e.preventDefault();
		}
		/*if ( yMovement > 10 ){
			if ( yDownDirect ){
				if ( !allowUp) e.preventDefault();
			}else{
				if ( !allowDown) e.preventDefault();
			}
		}*/
	};
	var ee = function(e){
		d.removeEventListener('touchmove', em);
		d.removeEventListener('touchend', ee);
		d.removeEventListener('touchcancel', ee);
	};
	d.addEventListener('touchstart',function(e) {
		d.addEventListener('touchmove', em);
		d.addEventListener('touchend', ee);
		d.addEventListener('touchcancel', ee);
		
	    xStart = e.touches[0].screenX;
	    yStart = e.touches[0].screenY;
	    allowUp = d.body.scrollTop > 0;
		allowDown = d.body.scrollTop<d.body.clientHeight - window.innerHeight;
	});
};
_preventWXPageScroll();

(function(){
	var preventSafariTouchMove = function(e) {
		   	e.preventDefault();
		};
	window._disableSafariElastic = function(){
		document.addEventListener('touchmove', preventSafariTouchMove, false);
	};
	window._enableSafariElastic = function(){
		document.removeEventListener('touchmove', preventSafariTouchMove, false);
	};
}());




if (location.href.indexOf('qq.com')>-1){ window.onerror = function(){return true;}; }
