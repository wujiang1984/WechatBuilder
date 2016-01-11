using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 模块的链接集合表
	/// </summary>
	[Serializable]
	public partial class wx_link_module
	{
		public wx_link_module()
		{}
		#region Model
		private int _id;
		private string _lname;
		private string _modulename;
		private string _modulecode;
		private int? _moduletype;
		private string _urlrule;
		private bool _urlneedreplace;
		private string _tablename;
		private bool _isglobal;
		private bool _ismore;
		private int? _sortid;
		private string _remark;
		private string _idcolumn;
		private string _namecolumn;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 链接名称
		/// </summary>
		public string lName
		{
			set{ _lname=value;}
			get{return _lname;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string moduleName
		{
			set{ _modulename=value;}
			get{return _modulename;}
		}
		/// <summary>
		/// 模块编码
		/// </summary>
		public string moduleCode
		{
			set{ _modulecode=value;}
			get{return _modulecode;}
		}
		/// <summary>
		/// 模块类型
		/// </summary>
		public int? moduleType
		{
			set{ _moduletype=value;}
			get{return _moduletype;}
		}
		/// <summary>
		/// url规则
		/// </summary>
		public string urlRule
		{
			set{ _urlrule=value;}
			get{return _urlrule;}
		}
		/// <summary>
		/// url是否需要替换
		/// </summary>
		public bool urlNeedReplace
		{
			set{ _urlneedreplace=value;}
			get{return _urlneedreplace;}
		}
		/// <summary>
		/// 模块对应的表名
		/// </summary>
		public string tableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 是否为全局的，如果是，则所有用户都能看到
		/// </summary>
		public bool isGlobal
		{
			set{ _isglobal=value;}
			get{return _isglobal;}
		}
		/// <summary>
		/// 是否为多条数据
		/// </summary>
		public bool isMore
		{
			set{ _ismore=value;}
			get{return _ismore;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
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
		/// id主键对应的列名
		/// </summary>
		public string idColumn
		{
			set{ _idcolumn=value;}
			get{return _idcolumn;}
		}
		/// <summary>
		/// 活动名称对应的列名
		/// </summary>
		public string nameColumn
		{
			set{ _namecolumn=value;}
			get{return _namecolumn;}
		}
		#endregion Model

	}
}

