using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 产品库主表
	/// </summary>
	[Serializable]
	public partial class wx_product
	{
		public wx_product()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _hdname;
		private string _psubject;
		private int? _typeid;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private string _addr;
		private string _pcontent;
		private int? _minpersonnum;
		private int? _maxpersonnum;
		private string _personcontent;
		private bool _isopen;
		private string _createperson;
		private DateTime? _createdate;
		private string _url;
		private string _urlname;
		private string _btnname;
		private decimal? _price;
		private bool _showprice;
		private bool _showyuding;
		private bool _showdate;
		private int? _extint;
		private string _extstr;
		private string _extstr2;
		private string _extstr3;

        private string _tel;
        private string _daohangurl;

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
		/// 名称
		/// </summary>
		public string hdName
		{
			set{ _hdname=value;}
			get{return _hdname;}
		}
		/// <summary>
		/// 主题
		/// </summary>
		public string pSubject
		{
			set{ _psubject=value;}
			get{return _psubject;}
		}
		/// <summary>
		/// 类型Id
		/// </summary>
		public int? typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
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
		/// 地点
		/// </summary>
		public string addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string pContent
		{
			set{ _pcontent=value;}
			get{return _pcontent;}
		}
		/// <summary>
		/// 最小人数
		/// </summary>
		public int? minPersonNum
		{
			set{ _minpersonnum=value;}
			get{return _minpersonnum;}
		}
		/// <summary>
		/// 最大人数
		/// </summary>
		public int? maxPersonNum
		{
			set{ _maxpersonnum=value;}
			get{return _maxpersonnum;}
		}
		/// <summary>
		/// 人员介绍
		/// </summary>
		public string personContent
		{
			set{ _personcontent=value;}
			get{return _personcontent;}
		}
		/// <summary>
		/// 是否开启
		/// </summary>
		public bool isOpen
		{
			set{ _isopen=value;}
			get{return _isopen;}
		}
		/// <summary>
		/// 创建者
		/// </summary>
		public string createPerson
		{
			set{ _createperson=value;}
			get{return _createperson;}
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
		/// 链接地址
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 链接地址名称
		/// </summary>
		public string urlName
		{
			set{ _urlname=value;}
			get{return _urlname;}
		}
		/// <summary>
		/// 按钮名称
		/// </summary>
		public string btnName
		{
			set{ _btnname=value;}
			get{return _btnname;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 显示价格
		/// </summary>
		public bool showPrice
		{
			set{ _showprice=value;}
			get{return _showprice;}
		}
		/// <summary>
		/// 显示预定
		/// </summary>
		public bool showYuDing
		{
			set{ _showyuding=value;}
			get{return _showyuding;}
		}
		/// <summary>
		/// 显示时间
		/// </summary>
		public bool showDate
		{
			set{ _showdate=value;}
			get{return _showdate;}
		}
		/// <summary>
		/// 扩展Int1
		/// </summary>
		public int? extInt
		{
			set{ _extint=value;}
			get{return _extint;}
		}
		/// <summary>
		/// 扩展字符串1
		/// </summary>
		public string extStr
		{
			set{ _extstr=value;}
			get{return _extstr;}
		}
		/// <summary>
		/// 扩展字符串2
		/// </summary>
		public string extStr2
		{
			set{ _extstr2=value;}
			get{return _extstr2;}
		}
		/// <summary>
		/// 扩展字符串3
		/// </summary>
		public string extStr3
		{
			set{ _extstr3=value;}
			get{return _extstr3;}
		}

        /// <summary>
        /// 电话
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 导航url
        /// </summary>
        public string daohangurl
        {
            set { _daohangurl = value; }
            get { return _daohangurl; }
        }

		#endregion Model

	}
}

