using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微活动分类
	/// </summary>
	[Serializable]
	public partial class wx_product_type
	{
		public wx_product_type()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _parentid;
		private string _tcode;
		private string _tname;
		private string _turl;
		private int? _class_layer;
		private string _remark;
		private string _icopic;
		private int? _sort_id;
		private DateTime? _creatdate;
		private string _extstr;
		private string _extstr2;
        private int? _store_id;
        private string _tel;
        private string _daohangurl;
        private bool _showdefault;

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
		/// 上级分类id
		/// </summary>
		public int? parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 类别编码
		/// </summary>
		public string tCode
		{
			set{ _tcode=value;}
			get{return _tcode;}
		}
		/// <summary>
		/// 类别名称
		/// </summary>
		public string tName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		public string tUrl
		{
			set{ _turl=value;}
			get{return _turl;}
		}
		/// <summary>
		/// 类别深度
		/// </summary>
		public int? class_layer
		{
			set{ _class_layer=value;}
			get{return _class_layer;}
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
		/// 分类图标
		/// </summary>
		public string icoPic
		{
			set{ _icopic=value;}
			get{return _icopic;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? creatDate
		{
			set{ _creatdate=value;}
			get{return _creatdate;}
		}
		/// <summary>
		/// 扩展1
		/// </summary>
		public string extStr
		{
			set{ _extstr=value;}
			get{return _extstr;}
		}
		/// <summary>
		/// 扩展2
		/// </summary>
		public string extStr2
		{
			set{ _extstr2=value;}
			get{return _extstr2;}
		}

        /// <summary>
        /// 产品库id
        /// </summary>
        public int? store_id
        {
            set { _store_id = value; }
            get { return _store_id; }
        }

        /// <summary>
        /// 联系电话
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

        /// <summary>
        /// 导航菜单是否显示首页
        /// </summary>
        public bool showDefault
        {
            set { _showdefault = value; }
            get { return _showdefault; }
        }

		#endregion Model

	}
}

