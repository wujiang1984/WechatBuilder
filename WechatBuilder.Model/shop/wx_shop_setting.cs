using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商城基本信息设置
	/// </summary>
	[Serializable]
	public partial class wx_shop_setting
	{
		public wx_shop_setting()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _shopname;
		private string _copyright;
		private string _logo;
		private string _bgpic;
		private string _tel;
		private string _addr;
		private DateTime? _createdate;
		private int? _extint;
		private string _extstr;
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
		/// 商城名称
		/// </summary>
		public string shopName
		{
			set{ _shopname=value;}
			get{return _shopname;}
		}
		/// <summary>
		/// 版权
		/// </summary>
		public string copyright
		{
			set{ _copyright=value;}
			get{return _copyright;}
		}
		/// <summary>
		/// logo图片地址
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
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
		/// 联系电话
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
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
		/// 创建时间
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
		#endregion Model

	}
}

