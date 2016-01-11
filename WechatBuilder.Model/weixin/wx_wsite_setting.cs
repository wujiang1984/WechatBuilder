using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微网站设置表
	/// </summary>
	[Serializable]
	public partial class wx_wsite_setting
	{
		public wx_wsite_setting()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _wname;
		private string _companyname;
		private string _bgmusic;
		private string _bgpic;
		private int? _bgdonghuaid;
		private string _wcopyright;
		private string _wbrief;
		private string _remark;
		private string _phone;
		private string _addr;
		private string _addrurl;
		private string _email;
		private string _seo_title;
		private string _seo_keywords;
		private string _seo_desc;
		private DateTime? _createdate;
		private int? _extint;
		private string _extstr;
		private string _extstr2;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号
		/// </summary>
		public int? wId
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 网站名称
		/// </summary>
		public string wName
		{
			set{ _wname=value;}
			get{return _wname;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string companyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 背景音乐
		/// </summary>
		public string bgMusic
		{
			set{ _bgmusic=value;}
			get{return _bgmusic;}
		}
		/// <summary>
		/// 背景图片
		/// </summary>
		public string bgPic
		{
			set{ _bgpic=value;}
			get{return _bgpic;}
		}
		/// <summary>
		/// 背景动画
		/// </summary>
		public int? bgDongHuaId
		{
			set{ _bgdonghuaid=value;}
			get{return _bgdonghuaid;}
		}
		/// <summary>
		/// 网站版权信息
		/// </summary>
		public string wCopyright
		{
			set{ _wcopyright=value;}
			get{return _wcopyright;}
		}
		/// <summary>
		/// 微网站简介
		/// </summary>
		public string wBrief
		{
			set{ _wbrief=value;}
			get{return _wbrief;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// 导航地址
		/// </summary>
		public string addrUrl
		{
			set{ _addrurl=value;}
			get{return _addrurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// seo标题
		/// </summary>
		public string seo_title
		{
			set{ _seo_title=value;}
			get{return _seo_title;}
		}
		/// <summary>
		/// seo关键词
		/// </summary>
		public string seo_keywords
		{
			set{ _seo_keywords=value;}
			get{return _seo_keywords;}
		}
		/// <summary>
		/// seo描述
		/// </summary>
		public string seo_desc
		{
			set{ _seo_desc=value;}
			get{return _seo_desc;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 扩展int
		/// </summary>
		public int? extInt
		{
			set{ _extint=value;}
			get{return _extint;}
		}
		/// <summary>
		/// 扩展str
		/// </summary>
		public string extStr
		{
			set{ _extstr=value;}
			get{return _extstr;}
		}
		/// <summary>
		/// 扩展str2
		/// </summary>
		public string extStr2
		{
			set{ _extstr2=value;}
			get{return _extstr2;}
		}
		#endregion Model

	}
}

