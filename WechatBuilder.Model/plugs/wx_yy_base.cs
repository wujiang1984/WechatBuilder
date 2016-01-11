using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 在线预约设置
	/// </summary>
	[Serializable]
	public partial class wx_yy_base
	{
		public wx_yy_base()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _title;
		private string _addr;
		private string _phone;
		private string _kfname;
		private string _content;
		private string _picurl;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private string _remark;
		private int? _extint;
		private string _extstr;
		private string _extstr2;
		private DateTime? _createdate;
		private int? _seq;
        private bool _needsms;

		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号主键id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 公司地址
		/// </summary>
		public string addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// 客服电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 客服名称
		/// </summary>
		public string kfName
		{
			set{ _kfname=value;}
			get{return _kfname;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 头部图片
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 时间
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 扩展整数
		/// </summary>
		public int? extInt
		{
			set{ _extint=value;}
			get{return _extint;}
		}
		/// <summary>
		/// 扩展内容
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
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
		}

        /// <summary>
        /// 需要手机短信提醒
        /// </summary>
        public bool needSMS
        {
            set { _needsms = value; }
            get { return _needsms; }
        }

		#endregion Model

	}
}

