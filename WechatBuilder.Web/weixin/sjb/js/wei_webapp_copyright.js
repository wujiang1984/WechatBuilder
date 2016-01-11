/**
 * 微生活html5页面 底部版权
 * @author luan luan
 */
_onPageLoaded(function(){
	var logo = '';
	
	_writeCSS([
		'#mCopyright{height:33px;line-height:33px;margin-top:30px;margin-bottom:30px;z-index:1;}',
		'#mCopyright.footFix{margin-top:0;}',
		'#mCopyright .mcrInn{position:relative;}',
		'#mCopyright h1, #mCopyright h2{position:absolute;top:0;height:inherit;line-height:inherit;font-size:10px;margin:0;padding:0;background:none;}',
		'#mCopyright h1{color:#5F5F5F;text-indent:15px;left:50%;margin-left:-40px;width:64px;white-space:nowrap;',
				'background:url('+logo+') no-repeat 0 50%;-webkit-background-size:12px 13.5px;',
			'}',
		'#mCopyright h2{right:11px;color:rgba(84,88,99,.3);font-weight:normal;}'
	].join(''));
	
	var html = ['<div id="mCopyright" hidden><div class="mcrInn">',
					'<h1>奥秘之家</h1>',
					'<h2>&copy;震宇翱翔</h2>',
				'</div></div>'
		].join('');	
	_q('body').insertAdjacentHTML('beforeEnd', html);
	
	var mcr = _q('#mCopyright'),
		posiMcr = function(e){
			setTimeout(function(){
				_show(mcr);
				var ph = window.innerHeight,
					bh = _q('body').clientHeight;
				if (ph > bh){
					_addClass(mcr, 'footFix');
					_fixedStyleHook();
				}else{
					_removeClass(mcr, 'footFix');
				}
			}, 2000);
		};
	
	window._positionMCopyright = posiMcr;
	posiMcr();
	window.addEventListener('orientationchange', posiMcr);
	setInterval(posiMcr, 2000);

});
