using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商家基本信息
	/// </summary>
	[Serializable]
	public partial class wx_diancai_shopinfo
	{
		public wx_diancai_shopinfo()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _hotelname;
		private string _hotellogo;
		private DateTime? _hoteltimebegin;
		private DateTime? _hoteltimeend;
		private bool _limiteorder;
		private string _dcrename;
		private decimal? _sendprice;
		private decimal? _sendcost;
		private int? _freesendcost;
		private string _radius;
		private string _sendarea;
		private string _tel;
		private string _address;
		private int? _personlimite;
		private string _notice;
		private string _hotelintroduction;
		private string _email;
		private string _emailpwd;
		private string _stmp;
		private string _css;
		private DateTime? _createdate;
		private string _kctype;
		private string _miaoshu;
		private decimal? _xplace;
		private decimal? _yplace;
		private DateTime? _hoteltimebegin1;
		private DateTime? _hoteltimeend1;
		private DateTime? _hoteltimebegin2;
		private DateTime? _hoteltimeend2;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 关联编号
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 商家名称
		/// </summary>
		public string hotelName
		{
			set{ _hotelname=value;}
			get{return _hotelname;}
		}
		/// <summary>
		/// 商家logo
		/// </summary>
		public string hotelLogo
		{
			set{ _hotellogo=value;}
			get{return _hotellogo;}
		}
		/// <summary>
		/// 营业开始时间
		/// </summary>
		public DateTime? hoteltimeBegin
		{
			set{ _hoteltimebegin=value;}
			get{return _hoteltimebegin;}
		}
		/// <summary>
		/// 营业结束时间
		/// </summary>
		public DateTime? hoteltimeEnd
		{
			set{ _hoteltimeend=value;}
			get{return _hoteltimeend;}
		}
		/// <summary>
		/// 下单限制
		/// </summary>
		public bool limiteOrder
		{
			set{ _limiteorder=value;}
			get{return _limiteorder;}
		}
		/// <summary>
		/// 点单重命名
		/// </summary>
		public string dcRename
		{
			set{ _dcrename=value;}
			get{return _dcrename;}
		}
		/// <summary>
		/// 起送价格
		/// </summary>
		public decimal? sendPrice
		{
			set{ _sendprice=value;}
			get{return _sendprice;}
		}
		/// <summary>
		/// 配送费用
		/// </summary>
		public decimal? sendCost
		{
			set{ _sendcost=value;}
			get{return _sendcost;}
		}
		/// <summary>
		/// 订单满多少免配送费
		/// </summary>
		public int? freeSendcost
		{
			set{ _freesendcost=value;}
			get{return _freesendcost;}
		}
		/// <summary>
		/// 服务半径
		/// </summary>
		public string radius
		{
			set{ _radius=value;}
			get{return _radius;}
		}
		/// <summary>
		/// 配送区域
		/// </summary>
		public string sendArea
		{
			set{ _sendarea=value;}
			get{return _sendarea;}
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
		/// 联系地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 每人每天允许下单次数
		/// </summary>
		public int? personLimite
		{
			set{ _personlimite=value;}
			get{return _personlimite;}
		}
		/// <summary>
		/// 商家公告
		/// </summary>
		public string notice
		{
			set{ _notice=value;}
			get{return _notice;}
		}
		/// <summary>
		/// 商家简介
		/// </summary>
		public string hotelintroduction
		{
			set{ _hotelintroduction=value;}
			get{return _hotelintroduction;}
		}
		/// <summary>
		/// 下单通知邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 邮箱登入密码
		/// </summary>
		public string emailpwd
		{
			set{ _emailpwd=value;}
			get{return _emailpwd;}
		}
		/// <summary>
		/// SMTP服务器
		/// </summary>
		public string stmp
		{
			set{ _stmp=value;}
			get{return _stmp;}
		}
		/// <summary>
		/// 自定义css
		/// </summary>
		public string css
		{
			set{ _css=value;}
			get{return _css;}
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
		/// 快餐类型
		/// </summary>
		public string kcType
		{
			set{ _kctype=value;}
			get{return _kctype;}
		}
		/// <summary>
		/// 商家简短描述
		/// </summary>
		public string miaoshu
		{
			set{ _miaoshu=value;}
			get{return _miaoshu;}
		}
		/// <summary>
		/// 横坐标
		/// </summary>
		public decimal? xplace
		{
			set{ _xplace=value;}
			get{return _xplace;}
		}
		/// <summary>
		/// 纵坐标
		/// </summary>
		public decimal? yplace
		{
			set{ _yplace=value;}
			get{return _yplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? hoteltimeBegin1
		{
			set{ _hoteltimebegin1=value;}
			get{return _hoteltimebegin1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? hoteltimeEnd1
		{
			set{ _hoteltimeend1=value;}
			get{return _hoteltimeend1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? hoteltimeBegin2
		{
			set{ _hoteltimebegin2=value;}
			get{return _hoteltimebegin2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? hoteltimeEnd2
		{
			set{ _hoteltimeend2=value;}
			get{return _hoteltimeend2;}
		}
		#endregion Model

	}
}

