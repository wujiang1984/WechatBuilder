using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 优惠券
	/// </summary>
	[Serializable]
	public partial class wx_ucard_ticket
	{
		public wx_ucard_ticket()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _tname;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private int? _typeid;
		private string _usedcontent;
		private int? _usedtimes;
		private string _userdegree;
		private int? _usertype;
		private int? _consumemoney;
		private int? _sid;
		private int? _dymoney;
		private DateTime? _createdate= DateTime.Now;
		private int? _sort_id=0;
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
		/// 优惠券名称
		/// </summary>
		public string tName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? beginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? endDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 类型id(1打折优惠券,2现金抵用券)
		/// </summary>
		public int? typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 使用说明
		/// </summary>
		public string usedContent
		{
			set{ _usedcontent=value;}
			get{return _usedcontent;}
		}
		/// <summary>
		/// 每个用户可以获得的张数
		/// </summary>
		public int? usedTimes
		{
			set{ _usedtimes=value;}
			get{return _usedtimes;}
		}
		/// <summary>
		/// 使用的人群等级（id用逗号隔开）
		/// </summary>
		public string userDegree
		{
			set{ _userdegree=value;}
			get{return _userdegree;}
		}
		/// <summary>
		/// 人群类型
		/// </summary>
		public int? userType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 消费金额
		/// </summary>
		public int? consumeMoney
		{
			set{ _consumemoney=value;}
			get{return _consumemoney;}
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
		/// 抵用金额（元）
		/// </summary>
		public int? dyMoney
		{
			set{ _dymoney=value;}
			get{return _dymoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		#endregion Model

	}
}

