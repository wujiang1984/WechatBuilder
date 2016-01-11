using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 卡面设置
	/// </summary>
	[Serializable]
	public partial class wx_ucard_cardinfo
	{
		public wx_ucard_cardinfo()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _cardname;
		private string _cardnamecolor;
		private string _logo;
		private bool _islogoshow;
		private int? _bgtypeid;
		private string _bgurl;
		private string _cardnocolor;
		private string _indextip;
		private string _noticepic;
		private string _privilegespic;
		private string _qiandaopic;
		private string _shopingpic;
		private string _perinfopic;
		private string _instructionspic;
		private string _contactuspic;
		private DateTime? _createdate;
		private int? _sid;
		private string _bgtypeurl;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 会员卡的名称
		/// </summary>
		public string cardName
		{
			set{ _cardname=value;}
			get{return _cardname;}
		}
		/// <summary>
		/// 会员卡名称的颜色
		/// </summary>
		public string cardNameColor
		{
			set{ _cardnamecolor=value;}
			get{return _cardnamecolor;}
		}
		/// <summary>
		/// 会员卡的图标
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// logo是否显示
		/// </summary>
		public bool isLogoShow
		{
			set{ _islogoshow=value;}
			get{return _islogoshow;}
		}
		/// <summary>
		/// 会员卡的背景类型
		/// </summary>
		public int? bgTypeId
		{
			set{ _bgtypeid=value;}
			get{return _bgtypeid;}
		}
		/// <summary>
		/// 自己设计背景
		/// </summary>
		public string bgUrl
		{
			set{ _bgurl=value;}
			get{return _bgurl;}
		}
		/// <summary>
		/// 卡号颜色
		/// </summary>
		public string cardNoColor
		{
			set{ _cardnocolor=value;}
			get{return _cardnocolor;}
		}
		/// <summary>
		/// 首页提示文字
		/// </summary>
		public string indexTip
		{
			set{ _indextip=value;}
			get{return _indextip;}
		}
		/// <summary>
		/// 通知页面的banner图
		/// </summary>
		public string noticePic
		{
			set{ _noticepic=value;}
			get{return _noticepic;}
		}
		/// <summary>
		/// 特权页面的banner图片
		/// </summary>
		public string privilegesPic
		{
			set{ _privilegespic=value;}
			get{return _privilegespic;}
		}
		/// <summary>
		/// 签到页面的图片
		/// </summary>
		public string qiandaoPic
		{
			set{ _qiandaopic=value;}
			get{return _qiandaopic;}
		}
		/// <summary>
		/// 消费记录banner图片
		/// </summary>
		public string shopingPic
		{
			set{ _shopingpic=value;}
			get{return _shopingpic;}
		}
		/// <summary>
		/// 个人资料banner图片
		/// </summary>
		public string perinfoPic
		{
			set{ _perinfopic=value;}
			get{return _perinfopic;}
		}
		/// <summary>
		/// 会员卡说明banner图片
		/// </summary>
		public string instructionsPic
		{
			set{ _instructionspic=value;}
			get{return _instructionspic;}
		}
		/// <summary>
		/// 联系我们banner图片
		/// </summary>
		public string contactusPic
		{
			set{ _contactuspic=value;}
			get{return _contactuspic;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sId
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bgTypeUrl
		{
			set{ _bgtypeurl=value;}
			get{return _bgtypeurl;}
		}
		#endregion Model

	}
}

