/**
 * 微生活html5页面 对话框
 * @author luanluan, yanwenkai, shiyanchao
 * @requires /trunk/src/apps/Meishi/docs/html1103/scripts/wei_webapp_v2_common.js,
 *			/trunk/src/apps/Meishi/docs/html1103/styles/wei_dialog.css
 */
var 
	/**
	 * 统一弹出对话框
	 * 	  参考: /trunk/src/apps/Meishi/docs/html1103/_doc/弹窗规范-扁平.jpg
	 */
	MDialog = (function(){
		var nohref = 'javascript:void(0)';
		var _notset = function(obj){
			return (typeof obj == 'undefined');
		};
		var _makeModal = function(){
			var tmpl = '<div class="mModal"><a href="'+nohref+'"></a></div>';
			_q('body').insertAdjacentHTML('beforeEnd', tmpl);
			tmpl = null;
			var m = _q('.mModal:last-of-type');
			if (_qAll('.mModal').length > 1) m.style.opacity = .01;
			_q('a',m).style.height = window.innerHeight + 'px';
			m.style.zIndex = window._dlgBaseDepth++;
			return m;
		};
		var _ensureDepth = function(){
			if ( _notset(window._dlgBaseDepth) )
				window._dlgBaseDepth = 900; /*对话框类基准深度*/
		};
		var _lockPage = function(isLock){
			if (_notset(isLock)) isLock = true;
			_q('body').style.overflow = isLock ? 'hidden' : 'visible';
		};
		var _c = function(title, content, notice, 
				btn1Label, btn1Callback, btn1Style, btn2Label, btn2Callback, btn2Style,
				iconType, needCloseBtn, needModal, closeCallback)
			{
				if (_notset(content)) content = null;
				if (_notset(notice)) notice = null;
				if (_notset(btn1Callback)) btn1Callback = null;
				if (_notset(btn1Style)) btn1Style = null;
				if (_notset(btn2Label)) btn2Label = null;
				if (_notset(btn2Callback)) btn2Callback = null;
				if (_notset(btn2Style)) btn2Style = null;
				if (_notset(iconType)) iconType = null;
				if (_notset(needCloseBtn)) needCloseBtn = true;
				if (_notset(needModal)) needModal = true;
				
				_ensureDepth();
				
				var	pw = window.innerWidth,
					ph = window.innerHeight,
					tmpl = null,
					m = null;
				
				if (needModal)
					m = _makeModal();
				
				tmpl = '<div class="mDialog">' + '<figure></figure>' + '<h1></h1>' + '<h2></h2>' + '<h3></h3>' + '<footer>' + '	<a class="two"></a>' + '	<a class="two"></a>' + '	<a class="one"></a>' + '</footer>' + '<a class="x">X</a>' + '</div>';
				_q('body').insertAdjacentHTML('beforeEnd', tmpl);
				
				tmpl = null;
				
				var dlg = _q('div.mDialog:last-of-type', _q('body')),
					fg = _q('figure', dlg),
					b0 = _q('footer a.one', dlg),
					b1 = _q('footer a.two:nth-of-type(1)', dlg),
					b2 = _q('footer a.two:nth-of-type(2)', dlg),
					bx = _q('a.x', dlg),
					t = 0,
					evtsCache = [],
					listen = function(obj, evt, func){
						obj.addEventListener(evt, func);
						evtsCache.push({o:obj, e:evt, f:func});
					},
					insert = function(ctx, str){
						var tgt = _q(ctx, dlg);
						if (str != null)
							tgt.innerHTML = str;
						else
							tgt.parentNode.removeChild(tgt);
						return tgt;
					},
					close = function(e){
						if ( /mModal/.test(e.currentTarget.className) 
							&& typeof MData(dlg, 'closeByModal') !== 'undefined'
							&& MData(dlg, 'closeByModal') == 0 ) 
							return;
						
						if(typeof closeCallback === 'function') {
							closeCallback();
						}
						while(evtsCache.length){
							var eobj = evtsCache.shift();
							eobj.o.removeEventListener(eobj.e, eobj.f);
						};
						dlg.parentNode.removeChild(dlg);
						window._dlgBaseDepth--;
						if (m==null) return;
						m.parentNode.removeChild(m);
						window._dlgBaseDepth--;
						
						_lockPage(false);
					};
				
				/*contents*/
				var h1 = insert('h1', title);
				if (h1.clientHeight > 51) h1.style.textAlign = 'left';
				insert('h2', content);
				insert('h3', notice);
				/*icon*/
				if (iconType == null)
					dlg.removeChild(fg);
				else
					_addClass(fg, iconType);
				fg = null;
				/*buttons*/
				if (btn2Label == null){
					b1.parentNode.removeChild(b1);
					b2.parentNode.removeChild(b2);
					b1 = null;
					b2 = null;
					
					b0.innerHTML = btn1Label;
					b0.href = nohref;
					if (btn1Style != null) _addClass(b0, btn1Style);
					if (btn1Callback != null) listen(b0, 'click', btn1Callback);
					listen(b0, 'click', close);
				}else{
					b0.parentNode.removeChild(b0);
					b0 = null;
					
					b1.innerHTML = btn1Label;
					b1.href = nohref;
					if (btn1Style != null) _addClass(b1, btn1Style);
					if (btn1Callback != null) listen(b1, 'click', btn1Callback);
					listen(b1, 'click', close);
					b2.innerHTML = btn2Label;
					b2.href = nohref;
					if (btn2Style != null) _addClass(b2, btn2Style);
					if (btn2Callback != null) listen(b2, 'click', btn2Callback);
					listen(b2, 'click', close);
				}
				/*close*/
				if (needCloseBtn){
					bx.href = nohref;
					listen(bx, 'click', close);
				}else{
					bx.parentNode.removeChild(bx);
					bx = null;
				}
				if (m!=null){
					listen(m, 'click', close);
				}
				
				/*position*/
				dlg.style.zIndex = window._dlgBaseDepth++;
				dlg.style.left = .5 * (pw - dlg.clientWidth) + 'px';
				t = parseInt(.45 * (ph - dlg.clientHeight));
				dlg.style.top = t + 'px';
				MData(dlg, 'ffixTop', t);
				
				if (needModal)
					_lockPage();
				
				D.close = close;
				return dlg;
			};
		var _a = function(title, content, notice, 
				btn1Label, btn1Callback, btn1Style,
				iconType, needCloseBtn, needModal)
			{
				return _c(title, content, notice, 
					btn1Label, btn1Callback, btn1Style, 
					null, null, null,
					iconType, needCloseBtn, needModal);
			};
		var _n = function(message, iconType, timeout)
			{
				if (_notset(iconType)) iconType = null;
				if (_notset(timeout)) timeout = 3000;
				
				var tmpl = '<div class="mNotice">'
					+ '	<span></span>'
					+ '</div>';
				_q('body').insertAdjacentHTML('beforeEnd', tmpl);
				
				_ensureDepth();
				
				var ntc = _q('div.mNotice:last-of-type', _q('body')),
					sp = _q('span', ntc),
					pw = window.innerWidth,
					ph = window.innerHeight,
					t = 0;
				
				sp.innerHTML = message;
				
				if (iconType != null)
					_addClass(sp, iconType);
				
				ntc.style.zIndex = window._dlgBaseDepth++;
				ntc.style.left = .5 * (pw - ntc.clientWidth) + 'px';
				t = parseInt(.45 * (ph - ntc.clientHeight));
				ntc.style.top = t + 'px';
				MData(ntc, 'ffixTop', t);
				
				_setTimeout(function(){
					ntc.parentNode.removeChild(ntc);
					window._dlgBaseDepth--;
				}, timeout);
				
				return ntc;
			};
		var _pi = function(imgPath, maxWidth, needCloseBtn, needModal)
			{
				if (_notset(maxWidth)) maxWidth = 295;
				if (_notset(needCloseBtn)) needCloseBtn = true;
				if (_notset(needModal)) needModal = true;
				
				_ensureDepth();
				
				var	pw = window.innerWidth,
					ph = window.innerHeight,
					tmpl = null,
					m = null;
				
				if (needModal)
					m = _makeModal();
				
				tmpl = '<div class="mImgPopup">'
					+ '<figure></figure>'
					+ '<a class="x">X</a>'
				+ '</div>';
				_q('body').insertAdjacentHTML('beforeEnd', tmpl);
				
				var p = _q('div.mImgPopup:last-of-type', _q('body')),
					fg = _q('figure', p),
					sp = _q('span', p),
					bx = _q('a.x', p),
					pw = window.innerWidth,
					ph = window.innerHeight,
					t = 0,
					evtsCache = [],
					listen = function(obj, evt, func){
						obj.addEventListener(evt, func);
						evtsCache.push({o:obj, e:evt, f:func});
					},
					close = function(e){
						while(evtsCache.length){
							var eobj = evtsCache.shift();
							eobj.o.removeEventListener(eobj.e, eobj.f);
						};
						p.parentNode.removeChild(p);
						window._dlgBaseDepth--;
						if (m==null) return;
						m.parentNode.removeChild(m);
						window._dlgBaseDepth--;
						
						_lockPage(false);
					},
					onImg = function(e){
						var idom = e.currentTarget,
							w1 = idom.width,
							h1 = idom.height,
							f = 1;
						fg.appendChild(idom);
						
						if (w1 > maxWidth){
							f = w1/maxWidth;
						}
						
						fg.style.height = p.style.height = idom.style.height = parseInt(h1/f) + 'px';
						fg.style.width = p.style.width = idom.style.width = parseInt(w1/f) + 'px';
						
						doPosition();
					},
					doPosition = function(){
						p.style.zIndex = window._dlgBaseDepth++;
						p.style.left = .5 * (pw - p.clientWidth) + 'px';
						t = .5 * (ph - p.clientHeight);
						p.style.top = t + 'px';
						MData(p, 'ffixTop', t);
						
						if (needModal)
							_lockPage();
					};
				
				doPosition();
				
				if (needCloseBtn){
					bx.href = nohref;
					listen(bx, 'click', close);
				}else{
					bx.parentNode.removeChild(bx);
					bx = null;
				}
				if (m!=null){
					listen(m, 'click', close);
				}
				
				var img = new Image;
				listen(img, 'load', onImg);
				img.src = imgPath;
				
				D.close = close;
				return p;
			};
		var _sl = function(notice, needModal)
			{
				if(_q('#mLoading')) return;
				
				if (_notset(notice)) notice = '';
				if (_notset(needModal)) needModal = false;
				
				_ensureDepth();
				
				var	pw = window.innerWidth,
					ph = window.innerHeight,
					tmpl = null,
					m = null;
				
				if (needModal){
					m = _makeModal();
					m.id = 'mLoadingModal';
				}
				
				tmpl = '<div id="mLoading"><div class="lbk"></div><div class="lcont">'+notice+'</div></div>';
				_q('body').insertAdjacentHTML('beforeEnd', tmpl);
				
				var l = _q('#mLoading');
				l.style.top = (_q('body').scrollTop + .5 * (ph - l.clientHeight)) + 'px';
				l.style.left = .5 * (pw - l.clientWidth) + 'px';
				
				return l;
			};

		/*			
			* _fs author:KeelvinYan
			* 自定义弹窗 popupCustom
			* content- 自定义html
		*/
		var _fs = function(content,needCloseBtn,closeCallback,needModal)
			{
				if (_notset(content)) content = null;
				if (_notset(needCloseBtn)) needCloseBtn = true;
				if (_notset(closeCallback)) closeCallback = null;
				if (_notset(needModal)) needModal = true;
				_ensureDepth();
					
				var	pw = window.innerWidth,
					ph = window.innerHeight,
					tmpl = null,
					m = null;
				if (needModal)
					m = _makeModal();

				tmpl = '<div class="mDialog freeSet">' + content + '<a class="x">X</a>' + '</div>';
				_q('body').insertAdjacentHTML('beforeEnd', tmpl);
					
				tmpl = null;	
				var dlg = _q('div.mDialog:last-of-type', _q('body')),
					bx = _q('a.x', dlg),
				t = 0,
				evtsCache = [],
				listen = function(obj, evt, func){
					obj.addEventListener(evt, func);
					evtsCache.push({o:obj, e:evt, f:func});
				},

				close = function(e){
					if(closeCallback !=null){
						(closeCallback)();
					}				
					while(evtsCache.length){
						var eobj = evtsCache.shift();
						eobj.o.removeEventListener(eobj.e, eobj.f);
					};
					dlg.parentNode.removeChild(dlg);
					window._dlgBaseDepth--;
					if (m==null) return;
					m.parentNode.removeChild(m);
					window._dlgBaseDepth--;
					
					_lockPage(false);
				};
				/*close*/
				if (needCloseBtn){
					bx.href = nohref;
					listen(bx, 'click', close);
				}else{
					bx.parentNode.removeChild(bx);
					bx = null;
				}
				if (m!=null){
					listen(m, 'click', close);
				}
				
				/*position*/
				dlg.style.zIndex = window._dlgBaseDepth++;
				dlg.style.left = .5 * (pw - dlg.clientWidth) + 'px';
				t = parseInt(.45 * (ph - dlg.clientHeight));
				dlg.style.top = t + 'px';
				MData(dlg, 'ffixTop', t);
				
				if (needModal)
					_lockPage();
				
				D.close = close;
				return dlg;
			};
			
		var D = {
			ICON_TYPE_SUCC: 'succ',
			ICON_TYPE_WARN: 'warn',
			ICON_TYPE_FAIL: 'fail',
			BUTTON_STYLE_ON: 'on',
			BUTTON_STYLE_OFF: 'off',
			confirm: _c,
			alert: _a,
			notice: _n,
			popupImage: _pi,
			showLoading: _sl,
			popupCustom:_fs
		};
		return D;
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
	};