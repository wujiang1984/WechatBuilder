using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微帐号的模版表
	/// </summary>
	[Serializable]
	public partial class wx_templates_wcode
	{
		public wx_templates_wcode()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _tid;
		private string _remark;
		private DateTime? _createdate;
		private int? _extint;
		private string _extstr;
		private string _extstr2;

        private int? _listtid;
        private int? _detailtid;
        private int? _channeltid;
        private int? _bmenutid;
        private int? _topcolortypeid;
        private string _topcolortypename;
        private string _topcolorhtml;

		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号Id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 模版主键Id
		/// </summary>
		public int? tid
		{
			set{ _tid=value;}
			get{return _tid;}
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
		/// <summary>
		/// 扩展str2
		/// </summary>
		public string extStr2
		{
			set{ _extstr2=value;}
			get{return _extstr2;}
		}

        /// <summary>
        /// 列表页模版Id
        /// </summary>
        public int? listTid
        {
            set { _listtid = value; }
            get { return _listtid; }
        }
        /// <summary>
        /// 详细页面模版Id
        /// </summary>
        public int? detailTid
        {
            set { _detailtid = value; }
            get { return _detailtid; }
        }
        /// <summary>
        /// 频道页面模版Id
        /// </summary>
        public int? channelTid
        {
            set { _channeltid = value; }
            get { return _channeltid; }
        }
        /// <summary>
        /// 底部菜单模版Id
        /// </summary>
        public int? bmenuTid
        {
            set { _bmenutid = value; }
            get { return _bmenutid; }
        }
        /// <summary>
        /// 顶部颜色类别
        /// </summary>
        public int? topcolorTypeId
        {
            set { _topcolortypeid = value; }
            get { return _topcolortypeid; }
        }
        /// <summary>
        /// 顶部颜色名称
        /// </summary>
        public string topcolorTypeName
        {
            set { _topcolortypename = value; }
            get { return _topcolortypename; }
        }
        /// <summary>
        /// 顶部颜色html
        /// </summary>
        public string topcolorHtml
        {
            set { _topcolorhtml = value; }
            get { return _topcolorhtml; }
        }

		#endregion Model

	}
}

