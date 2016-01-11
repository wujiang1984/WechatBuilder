using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 预约的表单字段
	/// </summary>
	[Serializable]
	public partial class wx_yy_control
	{
		public wx_yy_control()
		{}
		#region Model
		private int _id;
		private int? _formid;
		private string _cname;
		private string _ctype;
		private int? _minlength;
		private int? _maxlength;
		private string _defaultvalue;
		private bool _isbitian;
		private int? _seq;
		private DateTime? _createdate;
		private string _remark;
		private int? _extint;
		private string _extstr;
        private bool _issys;
        private string _syscontrolertype;

		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 表单主键id
		/// </summary>
		public int? formId
		{
			set{ _formid=value;}
			get{return _formid;}
		}
		/// <summary>
		/// 控件名称
		/// </summary>
		public string cName
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 控件类型（显示类型0输入框1下拉框2单选框3复选择）
		/// </summary>
		public string cType
		{
			set{ _ctype=value;}
			get{return _ctype;}
		}
		/// <summary>
		/// 最小长度
		/// </summary>
		public int? minLength
		{
			set{ _minlength=value;}
			get{return _minlength;}
		}
		/// <summary>
		/// 最大长度
		/// </summary>
		public int? maxLength
		{
			set{ _maxlength=value;}
			get{return _maxlength;}
		}
		/// <summary>
		/// 默认值
		/// </summary>
		public string defaultValue
		{
			set{ _defaultvalue=value;}
			get{return _defaultvalue;}
		}
		/// <summary>
		/// 必填项
		/// </summary>
		public bool isBiTian
		{
			set{ _isbitian=value;}
			get{return _isbitian;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
        /// 是否为系统内置字段
        /// </summary>
        public bool isSys
        {
            set { _issys = value; }
            get { return _issys; }
        }
        /// <summary>
        /// 内置字段的类型
        /// </summary>
        public string sysControlerType
        {
            set { _syscontrolertype = value; }
            get { return _syscontrolertype; }
        }

		#endregion Model

	}
}

