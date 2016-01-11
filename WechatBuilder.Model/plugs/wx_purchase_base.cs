using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 团购基本表
	/// </summary>
	[Serializable]
	public partial class wx_purchase_base
	{
		public wx_purchase_base()
		{}
		#region Model
		private int _id;
		private string _activityname;
		private string _activitysummary;
		private DateTime? _activitytimebegin;
		private string _email;
		private string _emailpwd;
		private string _smtp;
		private string _shopspwd;
		private string _activedescription;
		private string _specialremind;
		private string _activityendtitle;
		private string _endexplanation;
		private string _shopstel;
		private string _address;
		private string _introduction;
		private string _goodname;
		private decimal? _costprice;
		private int? _limitcount;
		private decimal? _groupprice;
		private int? _totalcount;
		private int? _groupperson;
		private int? _virtualperson;
		private string _copyrightsetup;
		private DateTime? _activitytimeend;
		private DateTime? _createtime;
		private int? _wid;
		private string _imageurl;
		private string _imageurlend;
		private decimal? _txtlatxpoint;
		private decimal? _txtlngypoint;
		/// <summary>
		/// 编号
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 活动名称
		/// </summary>
		public string activityName
		{
			set{ _activityname=value;}
			get{return _activityname;}
		}
		/// <summary>
		/// 活动简介
		/// </summary>
		public string activitySummary
		{
			set{ _activitysummary=value;}
			get{return _activitysummary;}
		}
		/// <summary>
		/// 活动时间
		/// </summary>
		public DateTime? activityTimebegin
		{
			set{ _activitytimebegin=value;}
			get{return _activitytimebegin;}
		}
		/// <summary>
		/// 通知邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 邮箱密码
		/// </summary>
		public string emailPwd
		{
			set{ _emailpwd=value;}
			get{return _emailpwd;}
		}
		/// <summary>
		/// SMTP服务器
		/// </summary>
		public string smtp
		{
			set{ _smtp=value;}
			get{return _smtp;}
		}
		/// <summary>
		/// 消费确认密码
		/// </summary>
		public string shopsPwd
		{
			set{ _shopspwd=value;}
			get{return _shopspwd;}
		}
		/// <summary>
		/// 活动描述及商品描述
		/// </summary>
		public string activeDescription
		{
			set{ _activedescription=value;}
			get{return _activedescription;}
		}
		/// <summary>
		/// 特别提醒
		/// </summary>
		public string specialRemind
		{
			set{ _specialremind=value;}
			get{return _specialremind;}
		}
		/// <summary>
		/// 活动结束公告主题
		/// </summary>
		public string activityEndtitle
		{
			set{ _activityendtitle=value;}
			get{return _activityendtitle;}
		}
		/// <summary>
		/// 活动结束说明
		/// </summary>
		public string endExplanation
		{
			set{ _endexplanation=value;}
			get{return _endexplanation;}
		}
		/// <summary>
		/// 团购电话
		/// </summary>
		public string shopstel
		{
			set{ _shopstel=value;}
			get{return _shopstel;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 商家介绍
		/// </summary>
		public string introduction
		{
			set{ _introduction=value;}
			get{return _introduction;}
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string goodName
		{
			set{ _goodname=value;}
			get{return _goodname;}
		}
		/// <summary>
		/// 商品原价
		/// </summary>
		public decimal? costPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
		/// 每人最多团购产品数
		/// </summary>
		public int? limitCount
		{
			set{ _limitcount=value;}
			get{return _limitcount;}
		}
		/// <summary>
		/// 商品团购价
		/// </summary>
		public decimal? groupPrice
		{
			set{ _groupprice=value;}
			get{return _groupprice;}
		}
		/// <summary>
		/// 商品总数
		/// </summary>
		public int? totalCount
		{
			set{ _totalcount=value;}
			get{return _totalcount;}
		}
		/// <summary>
		/// 最低参团人数
		/// </summary>
		public int? groupPerson
		{
			set{ _groupperson=value;}
			get{return _groupperson;}
		}
		/// <summary>
		/// 虚拟参团人数
		/// </summary>
		public int? virtualPerson
		{
			set{ _virtualperson=value;}
			get{return _virtualperson;}
		}
		/// <summary>
		/// 版权设置
		/// </summary>
		public string copyrightSetup
		{
			set{ _copyrightsetup=value;}
			get{return _copyrightsetup;}
		}
		/// <summary>
		/// 活动结束时间
		/// </summary>
		public DateTime? activityTimeend
		{
			set{ _activitytimeend=value;}
			get{return _activitytimeend;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imageUrlend
		{
			set{ _imageurlend=value;}
			get{return _imageurlend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? txtLatXPoint
		{
			set{ _txtlatxpoint=value;}
			get{return _txtlatxpoint;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? txtLngYPoint
		{
			set{ _txtlngypoint=value;}
			get{return _txtlngypoint;}
		}
		#endregion Model

	}
}

