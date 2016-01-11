/**
 * 微信会员卡二期 通用环境功能
 * @author luan luan
 */
var _env = (function(){ var _ua = navigator.userAgent, _m = null, _formatV = function(vstr, vdiv){ var f = vstr.split(vdiv); f = f.shift()+'.'+f.join(''); return f*1; }, _rtn = { ua: _ua, version: null, ios: false, android: false, windows: false, blackberry: false, meizu: false, weixin: false, wVersion: null, touchSupport: ('createTouch' in document), hashSupport: !!('onhashchange' in window) }; _m = _ua.match(/MicroMessenger\/([\.0-9]+)/); if ( _m != null ){ _rtn.weixin = true; _rtn.wVersion = _formatV(_m[1], '.'); } _m = _ua.match(/Android\s([\.0-9]+)/); if ( _m != null ){ _rtn.android = true; _rtn.version = _formatV(_m[1], '.'); _rtn.meizu = /M030|M031|M032|MEIZU/.test(_ua); return _rtn; } _m = _ua.match(/i(Pod|Pad|Phone)\;.*\sOS\s([\_0-9]+)/); if ( _m != null ){ _rtn.ios = true; _rtn.version = _formatV(_m[2], '_'); return _rtn; } _m = _ua.match(/Windows\sPhone\sOS\s([\.0-9]+)/); if ( _m != null ){ _rtn.windows = true; _rtn.version = _formatV(_m[1], '.'); return _rtn; } var bb = { a: _ua.match(/\(BB1\d+\;\s.*\sVersion\/([\.0-9]+)\s/), b: _ua.match(/\(BlackBerry\;\s.*\sVersion\/([\.0-9]+)\s/), c: _ua.match(/^BlackBerry\d+\/([\.0-9]+)\s/), d: _ua.match(/\(PlayBook\;\s.*\sVersion\/([\.0-9]+)\s/) }; for (var k in bb){ if (bb[k] != null){ _m = bb[k]; _rtn.blackberry = true; _rtn.version = _formatV(_m[1], '.'); return _rtn; } } return _rtn; }()),
	_ua = _env.ua,
	_touchSupport = _env.touchSupport,
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
	_testFixedSupport = function(){ var outer = document.createElement('div'),inner = document.createElement('div'),result = true;outer.style.position = 'absolute';outer.style.top = '200px'; 		inner.style.position = 'fixed'; 		inner.style.top = '100px'; 		outer.appendChild(inner); 		document.body.appendChild(outer); 		if (inner.getBoundingClientRect && 			inner.getBoundingClientRect().top == outer.getBoundingClientRect().top) { 			result = false; 		} 		document.body.removeChild(outer); 		return result; 	},
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
	_doAjax = function(url, method, params, callback, useJSON)
	{
		if (typeof method == 'undefined') method = 'POST';
		if (typeof params == 'undefined') params = null;
		if (typeof useJSON == 'undefined') useJSON = true;
		method = method.toLowerCase();
		var xmlHttp = null,
			query = [];
		if(window.ActiveXObject)
			xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
		else if(window.XMLHttpRequest)
			xmlHttp = new XMLHttpRequest();
		else
			return false;
		xmlHttp.onreadystatechange = function(evt) {
			 if(xmlHttp.readyState == 4) {
				if (xmlHttp.status == 200 || xmlHttp.status == 0) {
					var rtext = xmlHttp.responseText;
					var result = useJSON ? JSON.parse(rtext) : rtext;
					if (callback)
						callback.call(null, result);
				} 
			}
		};
		if (params)
			for (var k in params)
				query.push(k+'='+params[k]);
		if (!query.length)
			query = null;
		else
			query = query.join('&');
		if (method == 'get' && query != null){
			if(url.indexOf('?')>-1) url+= '&';
			else url += '?';
			url += query;
			query = null;
		}
		if (console && console.log)
			console.log('ajax: ', url, query);
		try{
			xmlHttp.open(method, url, true);
			if (method == 'post'){
				xmlHttp.setRequestHeader("content-type", "application/x-www-form-urlencoded");
			}
            xmlHttp.setRequestHeader("X-Requested-With","XMLHttpRequest");
			xmlHttp.send(query);
		} 
		catch(ex)
		{
			throw "[ajax] request error";
		}
		return true;
	},

	_q = function(s, context){if (context && typeof context === 'string'){ try{context = _q(context);}catch(ex){console.log(ex);return;} } return (context||document).querySelector(s);},
	_qAll = function(s, context){if (context && typeof context === 'string'){ try{context = _q(context);}catch(ex){console.log(ex);return;} } return (context||document).querySelectorAll(s);},
	_qConcat = function(){
		var i=0, leng = arguments.length, arr=[];
		for (;i<leng;i++){
			var arg = arguments[i];
			if (typeof arg === 'string') arg = _qAll(arg);
			for (var j=0; j<arg.length; j++){
				arr.push(arg[j]);
			}
		}
		return arr;
	},
	MCache = (function(){ var cache = {};  return { set:function(key,val) { cache[key]=val; }, get:function(key) { return cache[key]; }, clear:function() { cache = {}; }, remove:function(key) { delete cache[key]; } }; }()),
	MStorage = (function(){var _session = window.sessionStorage, _local = window.localStorage, _get = function(k){var d = _getData(k); if (d != null) return d.value; return null; }, _getData = function(k){if (k in _session) {return JSON.parse(_session.getItem(k)); }else if (k in _local) return JSON.parse(_local.getItem(k)); else return null; }, _set = function(k, v){var d = {value: v, ts: (new Date).getTime() }; d = JSON.stringify(d); _session.setItem(k, d); _local.setItem(k, d); }, _clear = function(){_session.clear(); _local.clear(); }, _remove = function(k){_session.removeItem(k); _local.removeItem(k); }, _removeExpires = function(time){var now = (new Date).getTime(), data; for (var key in _local){data = MStorage.getData(key); if ( now - data.ts > time ){_local.removeItem(key);_session.removeItem(key); } } }; return {set: _set, get: _get, getData: _getData, clear: _clear, remove: _remove, removeExpires: _removeExpires }; }()),
	MURLHash = (function(){ function _map2query(q, separator) { var u=encodeURIComponent,k,r=[]; var d=separator?separator:'&'; for (k in q) r.push(u(k)+'='+u(q[k])); return r.join(d); } function _split2(s,separator) { var i = s.indexOf(separator); return i==-1 ? [s,''] : [s.substring(0,i),s.substring(i+1)]; } var hu = function(href, hashChar, separator) { var h = href||window.location.href; var s = separator||"&"; var uArr = _split2(h, hashChar||'#'); var href_part = uArr[0]; var hash_part = uArr[1]; this.map = {}; this.sign = s; if (hash_part) { var arr = hash_part.split(s); for (var i=0;i<arr.length;i++) { var s2 = arr[i]; var o = _split2(s2,'='); this.map[o[0]] = o[1]; } } this.size = function() { return this.keys().length; }; this.keys = function() { var k = []; for (var m in this.map) if (m != '_hashfoo_') k.push(m); return k; }; this.values = function(){ var v = []; for (var m in this.map) if (m != '_hashfoo_') v.push(this.map[m]); return v; };  this.put('_hashfoo_', Math.random()); }; hu.prototype.get = function(key) { return this.map[key]||null; }; hu.prototype.put = function(key, value) { this.map[key] = value; }; hu.prototype.set = hu.prototype.put; hu.prototype.putAll = function(m) { if(typeof(m)=='object') for (var item in m) this.map[item] = m[item]; }; hu.prototype.remove = function(key) { if (this.map[key]) { var newMap = {}; for (var item in this.map) if (item!=key) newMap[item] = this.map[item]; this.map = newMap; } }; hu.prototype.toString = function() { var m2 = {}; for (var m in this.map) if (m != '_hashfoo_') m2[m] = this.map[m]; return _map2query(m2, "&"); }; hu.prototype.clone = function() { return new hu('foo#' + this.toString(), this.sign); }; return hu; }()),
	MData = (function(){
		function line2Upper(str){
			var re = new RegExp('\\-([a-z])','g');
			if ( !re.test(str) ) return str;
			return str.toLowerCase().replace( re, RegExp.$1.toUpperCase() ); 
		}
		function upper2Line(str){
			return str.replace(/([A-Z])/g, '-$1').toLowerCase();
		}
		function setD(ele, k, v){
			ele.setAttribute('data-'+upper2Line(k), v);
		}
		function getD(ele, k){
			var attr = ele.getAttribute('data-'+upper2Line(k)); 
			return attr||undefined;
		}
		return function(ele, k, v) {
			if (arguments.length>2){/*set*/ 
				try {
					ele.dataset[ line2Upper(k) ] = v;
				} catch(ex) {
					setD(ele, k, v);
				}
			}else{/*get*/
				try {
					return ele.dataset[ line2Upper(k) ];
				} catch(ex) {
					return getD(ele, k);
				}
			}
		};
	}()),

	/**
	 * 统一加载中效果
	 */
	MLoading = {
		show: MDialog.showLoading,
		hide: function(){
			var l = _q('#mLoading');
			if (l) l.parentNode.removeChild(l);
			var m = _q('#mLoadingModal');
			if (m) m.parentNode.removeChild(m);
		}
	},
	console = window.console || {log: function(){}};

function _onPageLoaded(callback) {window.addEventListener('DOMContentLoaded',callback);}
function _checkOffline() { var support = !!_appCache; if (!support) return;  _appCache.addEventListener("updateready", function(e){ if (_appCache.status == _appCache.UPDATEREADY) { try{_appCache.swapCache();}catch(ex1){} location.href = location.origin + location.pathname + '?rnd=' + Math.random() + location.hash; } }, false); }
function _html5FixForOldEnv(){ var tags = 'abbr,article,aside,audio,canvas,datalist,details,dialog,eventsource,figure,figcaption,footer,header,hgroup,mark,menu,meter,nav,output,progress,section,small,time,video,legend'; tags.split(',').forEach(function(ele,idx,arr){ document.createElement(ele); }); _writeCSS(tags+'{display:block;}'); }
function _writeCSS(css) { var s = document.createElement('style'); s.innerHTML = css; try{ _q('head').appendChild(s); }catch(ex){} }
function _trim(str){return str.replace(/(^\s+|\s+$)/g, '');}
function _removeClass(obj, clsName) { if (typeof obj==='string'){try{obj = _q(obj);}catch(ex){console.log(ex);return;} } var re = new RegExp('(^|\\s)+('+clsName+')(\\s|$)+', 'g'); try{obj.className = obj.className.replace(re, "$1$3");}catch(ex){} re = null; }
function _addClass(obj, clsName) { if (typeof obj==='string'){try{obj = _q(obj);}catch(ex){console.log(ex);return;} } _removeClass(obj, clsName); obj.className = _trim(obj.className+" "+clsName); }
function _forEach(arr, callback) { if (typeof arr === 'string'){ try{arr = _qAll(arr);}catch(ex){console.log(ex);return;} } Array.prototype.forEach.call(arr, callback); }
function _show() { var i=0, lng=arguments.length, ele; for (;i<lng;i++){ ele = arguments[i]; if (typeof ele==='string'){try{ele = _q(ele);}catch(ex){console.log(ex);return;} } if (ele.nodeType != undefined && ele.nodeType == 1){ ele.style.display = ''; ele.removeAttribute('hidden'); }else if (ele.hasOwnProperty('length')){ try{ var arr=[]; _forEach(ele, function(a,b,c){arr.push(a);}); _show.apply(null, arr); }catch(ex){} } } }
function _hide() { var i=0, lng=arguments.length, ele; for (;i<lng;i++){ ele = arguments[i]; if (typeof ele==='string'){try{ele = _q(ele);}catch(ex){console.log(ex);return;} } if (ele && ele.nodeType != undefined && ele.nodeType == 1){ ele.style.display = 'none'; }else if (ele && ele.hasOwnProperty('length')){ try{ var arr=[]; _forEach(ele, function(a,b,c){arr.push(a);}); _hide.apply(null, arr); }catch(ex){} } } }
function _setTimeout() {var func = arguments[0], timeout = arguments[1], args = Array.prototype.slice.call(arguments, 2); return window.setTimeout(function(args){return function(){func.apply(null, args); } }(args), timeout); }
function _fixFootBtnForOldIOS(evt) { 
	_forEach( _qAll('.footFix'), function(ftObj){
		var $ft = ftObj, wh = window.innerHeight, wt = window.scrollY, ftop = MData($ft,'ffixTop'), fbtm = MData($ft,'ffixBottom'), fh; if ($ft){ try{ fh = $ft.clientHeight; $ft.style.position = 'absolute'; if (ftop){ $ft.style.top = wt+ftop*1+'px'; }else if (fbtm){ $ft.style.top = wt+wh-fbtm*1-fh+'px'; }else{ $ft.style.top = wt+wh-fh+'px'; } $ft.style.bottom = 'auto'; }catch(ex){} } 
	});
}

_checkOffline();
_html5FixForOldEnv();

if (location.href.indexOf('qq.com')>-1){
	window.onerror = function(){return true;};
}
