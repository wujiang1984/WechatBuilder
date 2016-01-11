/**
 * 微信会员卡二期
 * @author luan luan
 */
var _appVersion = 1;


/*****************************************************************************/
var APP = (function(window){ //MVC结构
	var _cfg = {},
		_ecache = [],
		_isReqesting = false,
		_hook1TO,
		_body,
		_stage,
		_hash,
		_externalIter = {},
		_currPage = '',
		/**************************************************************/
		_utils = {
			ajax: function(reqObject, callback, toSimpleMode)
			{
				if (_isReqesting) return;
				if (toSimpleMode == undefined)
					toSimpleMode = true;
				var url = reqObject.url,
					method = reqObject.method,
					params = reqObject.params,
					myCallback = reqObject.callback,
					xmlHttp,
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
							_isReqesting = false;
							var rtext = xmlHttp.responseText;
							//console.log(rtext);
							rtext = rtext.replace(/&apos;/g, '&amp;apos;');
							rtext = rtext.replace(/&quot;/g, '&amp;quot;');
							var result = JSON.parse(rtext);
							if (!result)
								throw '[ajax] result error';
							//强制更新
							if (result.result.hasOwnProperty('appVersion') 
								&& result.result.appVersion*1 !== _appVersion){
								console.log('force reload, waiting for update');
								_setTimeout(function(){
									try{_appCache.swapCache();}catch(ex1){}
                                    location.href = location.origin + location.pathname + '?rnd=' + Math.random() + location.hash;
								},6180);
								return;
							}
							//外部回调
							if (myCallback)
								myCallback.call(reqObject, result);							
							//映射服务器端数据逻辑
							if (toSimpleMode){
								result = _utils.simplifyData(result);
							}
							//内部回调
							if (callback)
								callback.call(null, result);

							if (_cfg.callback_loadingOff)
								_cfg.callback_loadingOff.call(null);	
						} //end of status
					}
				};
				if (!method) method = 'post';
				method = method.toLowerCase();
				if (params)
					for (var k in params)
						query.push(k+'='+params[k]);
				query.push('majaxr='+Math.random());
				query.push('appVer='+_appVersion);
				//if (!query.length)
				//	query = null;
				//else
					query = query.join('&');
				if (method == 'get' && query != null){
					if(url.indexOf('?')>-1) url+= '&';
					else url += '?';
					url += query;
					query = null;
				}				
				console.log('ajax: ', url, query);
				try{
					xmlHttp.open(method, url, true);
					if (method == 'post'){
						xmlHttp.setRequestHeader("content-type",
							"application/x-www-form-urlencoded");
					}
					xmlHttp.send(query);
				} 
				catch(ex)
				{
					throw "[ajax] request error";
					_isReqesting = false;

					if (_cfg.callback_loadingOff)
						_cfg.callback_loadingOff.call(null);
				}
				_isReqesting = true;
				if (_cfg.callback_loadingOn)
					_cfg.callback_loadingOn.call(null);
				return true;
			},
			simplifyData: function(data)
			{
				if (data.hasOwnProperty('code'))
					data['issuccess'] = (data['code']*1 == 0);
				if (data.hasOwnProperty('result')){
					for (var k in data['result'])
						data[k] = data['result'][k];
					data['result'] = null;
				}
				return data;
			},
			getTagRangeFromHTMLStr: function(p_featureStr, p_html){ //根据特征值找到一段html中其所在的tag范围
				var t = p_html+'',
					p = p_featureStr,
					eStart = t.indexOf(p),
					eEnd = null,
					temp = null,
					tagName = null,
					closeTag = null,
					m = null;
				if (eStart == -1){
					return null;
				}
				temp = t.substr(0, eStart + p.length)
				eStart = temp.lastIndexOf('<');
				temp = t.substr(eStart);
				tagName = temp.match(/^\<([a-zA-Z]+)[\s\>]/)[1];
				if ( new RegExp('^\\<' + tagName + '[^\\>]*\\/\\>').test(temp) ){ // 直接关闭 <tag />
					closeTag = '/>';
					eEnd = eStart + temp.indexOf(closeTag) + closeTag.length;
				}else{
					closeTag = '</'+tagName+'>';
					eEnd = eStart + temp.indexOf(closeTag) + closeTag.length;
					temp = t.substring(eStart + tagName.length + temp.indexOf('>'), eEnd);
					m = temp.match( new RegExp('\\<' + tagName + '[^\/\>]*[^\\/]?\\>', 'g') );
					if ( m!=null ){ //是否嵌套了相同元素
						var lng = m.length;
						while(lng--){
							eEnd += t.substr(eEnd).indexOf(closeTag) + closeTag.length;
						}
					}
				}
				return {start:eStart, end:eEnd};
			},
			removeEmptyTags: function(tmplStr)
			{
				var t = tmplStr+'';
				var de = 'data-empty="1"';
				while ( t.indexOf(de)>-1){
					var range = _utils.getTagRangeFromHTMLStr(de, t);
					var t1 = t.substr(0, range.start);
					var t2 = t.substr(range.end);
					t = t1 + t2;
				}
				return t;
			},
			parseTmpl: function(tmpl, data, cache, removeEmpty) //填充模版
			{
				if ('undefined' === typeof tmpl) tmpl='';
				if ('undefined' === typeof data) data={};
				if ('undefined' === typeof cache) cache=_v;
				if ('undefined' === typeof removeEmpty) removeEmpty=true;
				var t = (new TemplateParser).doAll(tmpl, data, cache);
				return removeEmpty ? _utils.removeEmptyTags(t) : t;
			},
			clearStage: function()
			{
				_body.id = '';
				_body.className = '';
				_stage.innerHTML = '';
				_fixedStyleHook(false);
				_forEach(_ecache, function(ele,idx,arr){
					ele.obj.removeEventListener(ele.type, ele.func);
				});
				_ecache = [];
				if (_cfg.callback_loadingOff)
					_cfg.callback_loadingOff.call(null);
			},
			addToStage: function(cont)
			{
				_body.id = '';
				_body.className = '';
				_stage.innerHTML = cont;
				_fixedStyleHook(true);
				_utils.confirmTel();
				_utils.fixPageHeight();
			},
			listenEvt: function(obj, type, func)
			{
				try{
					obj.addEventListener(type, func);
					_ecache.push({'obj':obj,'type':type,'func':func});
				}catch(ex){}
			},
			pageChg: function()
			{
				if (_cfg.onPageChange)
					_cfg.onPageChange.call(null, _currPage);
				_q('body').scrollTop = 0;
				window.scrollTo(0,0);
			},
			setCurrPage: function(curr)
			{
				_currPage = curr;
				console.log('setCurrPage', curr);
			},
			updateHash: function(obj)
			{
				if (_isIOS){ // fix for Weixin@IOS
					_utils.directJumpInIOSWeixin(obj);
					return;
				}
				var h = new MURLHash('foo#'),  s,  k;
				for (k in obj) h.put(k, obj[k]);
				s = h.toString();
				location.hash = s; //'#'+s;
				console.log('updateHash', s);
			},
			/**
			 * 修复IOS版本微信下第一次跳转到特权页没有浏览器历史
			 */
			directJumpInIOSWeixin: function(obj)
			{
				var u = location.href.replace(/#.*$/,'').replace(/\??ioswx\=[\d|\.]+/, ''),
					sign = '&',
					arr = [];
				if (u.indexOf('?')==-1) sign = '?';
				for (var k in obj) arr.push(k+'='+obj[k]);
				u = u + sign + 'ioswx=' + Math.random() + '#' + arr.join('&');
				u = u.replace(/\?+/, '?').replace(/\&+/, '&').replace(/\#+/, '#');
				location.href = u;
				console.log('directJumpInIOSWeixin', u);
			},
			bindHashListener: function()
			{
				if ( !_hashSupport ){
					window.addEventListener('hashchange', _e.hashchgEvt);
				}else{
					if ( !window.hasOwnProperty('_oldurlflag') )
						window._oldurlflag = location.href;
					window.setInterval(function(){
						var nh = location.href;
						if (nh == window._oldurlflag) return;
						console.log('fake hash', nh);
						_e.hashchgEvt.call(null, {
							newURL: nh,
							oldURL: window._oldurlflag
						});
						window._oldurlflag = nh;
					}, 500);
				}
			},
			unbindHashListener: function()
			{
				window.removeEventListener('hashchange', _e.hashchgEvt);
			},
			getCurrStyle: function(object, styleName)
			{
				if (!object || !styleName) return;
				var rtn = '';
				try{
					rtn = (typeof(window.getComputedStyle) == 'undefined')?object.currentStyle[styleName]:window.getComputedStyle(object,null)[styleName];
				} catch(ex) {
					rtn = object.style[styleName];
				}
				return rtn.replace(/px$/, '');
			},
			fixPageHeight: function()
			{
				var inn = _q('#'+_stage.id+' > '+_cfg.rootElem||'.root');
				if (inn){
					inn.style.height = 'auto';
					setTimeout(function(){
						var h = window.innerHeight 
							- _utils.getCurrStyle(inn, 'paddingTop')*1 
							- _utils.getCurrStyle(inn, 'paddingBottom')*1
							- _utils.getCurrStyle(_body, 'paddingTop')*1 
							- _utils.getCurrStyle(_body, 'paddingBottom')*1;
						h = Math.max(h, inn.scrollHeight);
						inn.style.height = h+'px';
					}, 0);
				}
			},
			confirmTel: function()
			{
				if (_env.ios && _env.weixin && _env.wVersion>4.4) return; //ios下的微信4.5会出现两次电话确认

				var tels = _qAll('.autotel');
				if (!tels.length) return;
				function telclk(e){
					e.preventDefault();

					var ele = e.currentTarget,
						str = '是否拨打 ' + MData(ele, 'telnum').replace('tel:','') + ' ?';
					if ( window.confirm(str) ) {
						location.href = MData(ele, 'telnum');
					}
					return false;
				}
				_forEach(tels, function(ele,idx,arr){
					MData(ele, 'telnum', ele.href);
					ele.href = 'javascript:void(0)';
					_utils.listenEvt(ele, 'click', telclk);
				});
			},
			changeDocTitle: function(title)
			{
				document.title = title || '';
			},
			saveTmpls: function()
			{
				var scripts = _qAll('script');
				_forEach(scripts, function(ele, idx, arr){
					if (ele.type == _cfg.tmplType){
						_v[ele.id] = ele.innerHTML.replace(/\n/g, '').replace(/\r/g, '').replace(/\t/g, '').replace(/\s\s+/g, ' ');
						try{ele.parentNode.removeChild(ele);}catch(ex){}
					}
				});
				
				var childs = _q('body').childNodes;
				for (var i=childs.length-1; i>=0; i--){
					if ( childs[i].nodeType == 8 ){ //删除注释
						_q('body').removeChild( childs[i] );
					}
				}
				
				scripts = null;
				childs = null;
			},
			logicMap: function(kscope, obj)
			{
				var m = {};
				for (var k in obj)
					m[ kscope[k] ] = obj[k];
				return m;
			},
			initCommonPage: function(data, id)
			{
				_utils.clearStage();
				_utils.changeDocTitle(data['docTitle']);
				var tmpl = _v[id];
				tmpl = _utils.parseTmpl(tmpl, data);
				_utils.addToStage(tmpl);
				_body.id = id;
			}
		}, //end of utils
		/**************************************************************/
		_e = {
			hashchgEvt: function(evt)
			{
				var newh = new MURLHash(evt.newURL),
					oldh = new MURLHash(evt.oldURL),
					newa = newh.get('act')*1,
					olda = oldh.get('act')*1;
				console.log('hashchange', 'from ' + olda + ' to ' + newa);
				_c.RouteCommand();
			},
			commonAjaxClick: function(e)
			{
				var lk = e.currentTarget;
				if (!lk.hasAttribute('data-ajax-act')){
					return;
				}
				
				/*
					情况1:页内跳转逻辑
					对于包含了ajaxAct和ajaxParams的自动调用相关控制器
					array(
						'styleName'=> 'applicable',
						'label'=> '适用门店电话及地址',
						'ajaxAct'=> PAGE_GETAPPLICABLE,
						'ajaxParams'=>array(
						)
					),
				*/
				
				var hObj = {
						act: MData(lk, 'ajaxAct')
					},
					tmp, k;
				if (/(^|\s)disable(\s|$)/.test(lk.className)){
					e.preventDefault();
					e.stopPropagation();
					return;
				}
				if ( MData(lk, 'ajaxParams') ){
					tmp = MData(lk, 'ajaxParams');
					tmp = JSON.parse(tmp);
					for (k in tmp)	hObj[k] = tmp[k];
				}
				
				/*
					情况2:调用页面js方法而不是跳转
					array(
						'label'=> '自定义链接3',
						'ajaxAct'=> 'js:somefunction',
						'ajaxParams'=> array(
							'jsParam1'=> 111,
							'jsParam2'=> 222,
						)
					)
				*/
				if ( typeof hObj.act === 'string' && /^js\:/.test(hObj.act) ){
					var cbkName = hObj.act.replace(/^js\:/, '');
					if ( _cfg.jsbridge.hasOwnProperty(cbkName) ){
						delete hObj.act;
						_cfg.jsbridge[cbkName].call(null, hObj);
						return;
					}
				}
				
				/*
					情况3:直接跳转
					array(
						'label'=> '自定义链接4',
						'ajaxAct'=> 'http://qq.com'
					)
				*/
				if ( typeof hObj.act === 'string' && /^https?\:\/{2}/.test(hObj.act) ){
					lk.setAttribute('href', hObj.act);
					if (lk.hasAttribute('data-ajax-act')) lk.removeAttribute('data-ajax-act');
					if (lk.hasAttribute('data-ajax-params')) lk.removeAttribute('data-ajax-params');
					return true;
				}
				
				_utils.updateHash(hObj);
			}
		}, //end of events
		/**************************************************************/
		_m = {
			ReqObject: function(url, method, /*一维的ojbect */params, callback, overwrite)
			{
				this.url = url;
				this.method = method;
				this.params = params;
				this.callback = callback;
				this.set = function(k,v){
					if ( !overwrite || (overwrite && !this.params.hasOwnProperty(k)) )
						this.params[k] = v;
				};
			}
		},
		_v = {},
		_c = {
			//=== 出错提示 ===
			ErrorCommand: function(data)
			{
				window.alert(data['message']);
			}, //end of Commmand
			RouteCommand: function(h)
			{
				_hash = h||(new MURLHash);
				var ha = _hash.get('act'),
					reqObj = null;
				console.log('RouteCommand', _hash.get('act'));
				//hash中的act同时接受 ‘PAGE_GETSHOPDETAIL’ 或 1 的形式
				if (!ha) {
					console.log('采用默认动作 act=_PAGE_GETROUTE');
					ha = APP._PAGE_GETROUTE;
				}
				ha = ha+'';
				if (ha.indexOf('PAGE_')>-1)
					ha = APP[ha];
				else
					ha = ha*1;
				reqObj = _cfg.ajaxMap[ha] || _cfg.defaultAjax;
				reqObj = _cfg.ajax[ reqObj ];
				if (reqObj)
					_forEach(_hash.keys(), function(key,idx,arr){
						reqObj.set( key, _hash.get(key) );
					});

				_utils.ajax(reqObj, function(result){
					if (result['issuccess'] == 1)
					{
						if ('preJSAction' in result){
							var preFunc = new Function( result.preJSAction );
							
							if (preFunc() === false){
								return;								
							}
						}
						var pt = result['pagetype'],
							cmd = _cfg.commandMap[pt];
						cmd = _cfg.commands[cmd];
						if (cmd)
							cmd.call(null, result);
						_utils.pageChg();
					}else{
						_c.ErrorCommand(result);
					}
				});
			} //end of RouteCommand
		},
		/**************************************************************/
		_init = function()
		{
			_stage = document.createElement('div');
			_stage.id = 'mappContainer';
			_body = _q('body');
			_facade.stage = _stage;
			_facade.body = _body;
			_body.appendChild(_stage);
			_hash = new MURLHash();
			if ( !_hash.toString().length ){
				location.hash = 'act=' + APP._PAGE_GETROUTE;
			}
			_utils.bindHashListener();
			_utils.saveTmpls();

			for (var c in _cfg.commands)
				if ( !_c[c] )
					_c[c] = _cfg.commands[c];

			window.addEventListener('resize', _utils.fixPageHeight);
			_c.RouteCommand();
			
			if ('initialize' in _cfg){
				_cfg.initialize.call(null);
			}
		},
		_facade = {
			startup: _init,
			$m: _m,
			$v: _v,
			$c: _c,
			$e: _e,
			config: _cfg,
			utils: _utils,
			body: _body,
			stage: _stage,
			hash: _hash
		};
	return {
		facade: _facade,
		config: function(cfg){
			_cfg = cfg;
			_facade.config = _cfg;
			
			for (var c in _cfg.commands)
				_c[c] = _cfg.commands[c];
		},		
		getConfigItem: function(name){
			return _cfg[name];
		},
		getCurrPage: function(){
			return _currPage;
		},
		getHandler: function(name){
			return _externalIter[name];
		}
	}
}(window,undefined));
APP._PAGE_GETROUTE = 0;

var TemplateParser = (function(){
	var _rand = function(){
		return _isOldAndroid23
			? '('+ 'a,e,i,o,u'.split(',')[Math.floor(Math.random()*5)] + Math.round(Math.random()*999999) +')?'
			: '';
	};
	var _andReplacer = '=~=and=~='; //避免$被替换成字符串本身
	var p = function(){};
	p.prototype = {
		toStr: function(p_obj){
			var obj = p_obj;
			if (typeof obj !== 'string'){
				if (window.JSON){
					var jobj = JSON.stringify(obj);
					if (jobj){
						obj = jobj.replace(/\"/g, '&quot;');
					}
					return obj;
				}
			}
			return obj;
		},
		getData: function(p_data, p_key){
			var rst, arr, curr;
			if (p_key.indexOf('.')>-1){
				arr = p_key.split('.');
				curr = p_data[ arr.shift() ];
				while (arr.length && curr != undefined){
					curr = curr[ arr.shift() ] || null;
				}
				rst = curr;
			}else{
				rst = p_data[p_key];
			}
			rst = rst || null;
			return rst;
		},
		toJSONAttr: function(obj) {
			var str = JSON.stringify(obj);
			str = str.replace(/\$/g, _andReplacer);
			str = str.replace( eval('/\"'+_rand()+'/g'), '&quot;');
			return str;
		},
		//模版嵌套 {$_v模块中的模板名$}
		doNesting: new Function("p_tmpl", "p_toStr", "p_cache", [
			"var rtn = p_tmpl;",
			"var re = /\\{\\$([^$]+)\\$\\}/g;",
			"var m = rtn.match(re);",
			"if (m != null){",
				"try{",
					"for (var i=0;i<m.length;i++){",
						"var t = m[i].replace(/^\\{\\${1}/, '').replace(/\\${1}\\}$/, '');",
						"if ( p_cache.hasOwnProperty( t ) ){",
							"rtn = rtn.replace(m[i], p_toStr(p_cache[ t ]));",
						"}else{",
							"rtn = rtn.replace(m[i], '');",
						"}",
					"}",
				"}catch(ex){}",
			"}",
			"return rtn;"
		].join('')),
		//和json返回值对应的项	{#键名(可用.嵌套)#}, 用 %me 获取完整信息
		doSimple: new Function("p_tmpl", "p_data", "p_toStr", [
			"var rtn = p_tmpl;",
			"var re = /\\{\\#([^#]+)\\#\\}/g;",
			"var m = rtn.match(re);",
			"if (m != null){",
				"for (var i=0;i<m.length;i++){",
					"var t = m[i].replace(/^\\{\\#{1}/, '').replace(/\\#{1}\\}$/, '');",
					"if ( t.indexOf('.')>-1 ){",
						"var tarr = t.split('.');",
						"var vlu = p_data[ tarr[0] ];",
						"if (vlu !== undefined){",
							"for (var j=1;j<tarr.length;j++){",
								"if ( vlu && vlu.hasOwnProperty( tarr[j] ) ){",
									"vlu = vlu[ tarr[j] ];",
								"}else{ vlu = m[i]+'&nbsp;'; }",
							"}",
						"}else{",
							"vlu = m[i];",
						"}",
					"}else{",
						"if (t==='%me'){",
							"vlu = p_toStr(p_data);",
						"}else if (p_data.hasOwnProperty(t) && typeof p_data[t] === 'string' && !p_data[t].length){",
							"vlu = '';",
						"}else{",
							"vlu = p_data[t] || m[i];",
						"}",
					"}",
					"rtn = rtn.replace(m[i], p_toStr(vlu) );",
				"}",
			"}",
			"return rtn;"
		].join('')),
		//循环 {##循环#,#模板##子循环#,#子模板...##}
		//  数据以 _field.xxx_ 的形式， 全部则为 _field.%me_
		doLoop: function(p_tmpl, p_data, p_toStr, p_getData){
			var rtn = p_tmpl;

			function _parseLoopItem(layerIdx, layerData, layerTmpl){
				var prtn = '';
				if (layerData instanceof Array){
					for (var j=0; j<layerData.length; j++){
						var subData = layerData[j];
						if (subData instanceof Array){
							var t1 = layerTmpl;
							var v1 = null;
							try{
								if (layerIdx < loops.length){
									v1 = _parseLoopItem( layerIdx+1, subData, loops[layerIdx+1].tmpl );
								}else{
									v1 = p.prototype.toJSONAttr.call(p, subData);
								}
							}catch(ex1){
								v1 = p.prototype.toJSONAttr.call(p, subData);
							}
							t1 = t1.replace('_field_', v1 );
							prtn += t1;
						}else if (typeof subData === 'object' && eval('/\_field\.([^\_]+)\_'+_rand()+'/g').test(layerTmpl) ){
							var m2 = layerTmpl.match( eval('/\_field\.([^\_]+)\_'+_rand()+'/g') );
							var t2 = layerTmpl;
							for (var i2=0; i2<m2.length; i2++){
								try{
									var k2 = eval('/\_field\.([^\_]+)\_'+_rand()+'/').exec( m2[i2] )[1],
										dk2 = p.prototype.getData.call(p, subData, k2),
										v2 = null;
									if (k2 === '%me'){
										t2 = t2.replace('_field.%me_', p.prototype.toJSONAttr.call(p, subData) );
									} else {
										if (dk2 instanceof Array){
											try{
												if (layerIdx < loops.length){
													v2 = _parseLoopItem( layerIdx+1, dk2, loops[layerIdx+1].tmpl );
												}else{
													v2 = p.prototype.toJSONAttr.call(p, dk2); 
												}
											}catch(ex2){
												v2 = p.prototype.toJSONAttr.call(p, dk2); 
											}
										}else{
											v2 = p_toStr( dk2 );
										}
										t2 = t2.replace('_field.'+k2+'_', v2 );
									}
								}catch(exFOR){}
							}
							prtn += t2;
						}else{
							prtn += layerTmpl.replace('_field_', p_toStr( subData ));
						}	
					}//end of for j
				}
				return prtn;
			} //end of _parseLoopItem

			var m0 = rtn.match( eval('/\{((\#{2}[^#]+\#\,\#[^#]+)+)\#{2}\}'+_rand()+'/g') );
			if (m0){
				for (var i=0;i<m0.length;i++){
					try{
						var loops = eval('/\{((\#{2}[^#]+\#\,\#[^#]+)+)\#{2}\}'+_rand()+'/g').exec( m0[i] )[1].split('##'); 
						loops.shift();
						for (var lpsi=0; lpsi<loops.length; lpsi++){
							var lparr = loops[lpsi].split('#,#');
							loops[lpsi] = {key:lparr[0], tmpl:lparr[1]};
							lparr = null;
						}
						var rootItem = loops[0];
						var rootData = p_getData(p_data, rootItem.key);
						var rootTmpl = rootItem.tmpl;
						var vlu = _parseLoopItem(0, rootData, rootTmpl);
						rtn = rtn.replace( eval('/\{((\#{2}[^#]+\#\,\#[^#]+)+)\#{2}\}'+_rand()+'/g').exec( m0[i] )[0], vlu	); 
					}catch(ex){}
				}
			}
			return rtn;
		},
		//隐藏指定的数据无效项
		doHide: function(p_tmpl){
			var rtn = p_tmpl,
				f = 'hidden data-empty="1"';
			rtn = rtn.replace(/data-hidden-when-lost=\"undefined\"/g, f);
			rtn = rtn.replace(/data-hidden-when-lost=\"null\"/g, f);
			rtn = rtn.replace(/data-hidden-when-lost=\"\{\#{1}[^\#]+\#{1}\}(\s|\&nbsp\;)*\"/g, f);
			rtn = rtn.replace(/data-hidden-when-lost=\"\_field\.([^\_]+)\_\"/g, f);
			rtn = rtn.replace(/data-hidden-when-lost=\"[^\"]+\"/g, '');
			return rtn;
		},
		//处理时需调用的前置方法
		beginParse: function(p_tmpl){ 
			return p_tmpl;
		},
		//处理时需调用的后置方法
		endParse: function(p_tmpl){ 
			p_tmpl = p_tmpl.replace( eval('/\_nohref\_'+_rand()+'/g'), 'href="javascript:void(0)"');
			return p_tmpl.replace( eval('/'+_andReplacer+_rand()+'/g'), '\$');
		},

		//通常可以直接调用的快捷方法
		doAll: function(p_tmpl, p_data, p_cache){
			var rtn = this.beginParse(p_tmpl);
			rtn = this.doNesting(rtn, this.toStr, p_cache);
			rtn = this.doSimple(rtn, p_data, this.toStr);
			rtn = this.doLoop(rtn, p_data, this.toStr, this.getData);
			rtn = this.doHide(rtn);
			return this.endParse(rtn);
		}
	};
	return p;
}());
