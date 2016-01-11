using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微网站模版表
	/// </summary>
	[Serializable]
	public partial class wx_templates
	{
		public wx_templates()
		{}
		#region Model
		private int _id;
		private string _tname;
		private string _author;
		private DateTime? _createdate;
		private string _version;
		private string _forwxversion;
		private string _typename;
		private int? _typeid;
		private string _aboutpic;
		private string _tfilename;
		private string _degreename;
		private int? _degreid;
		private string _remark;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 模版名称
		/// </summary>
		public string tName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		/// <summary>
		/// 创建者
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
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
		/// 版本
		/// </summary>
		public string version
		{
			set{ _version=value;}
			get{return _version;}
		}
		/// <summary>
		/// 适用版本
		/// </summary>
		public string forWxVersion
		{
			set{ _forwxversion=value;}
			get{return _forwxversion;}
		}
		/// <summary>
		/// 模版类型名称
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
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
		/// 模版的效果图
		/// </summary>
		public string aboutPic
		{
			set{ _aboutpic=value;}
			get{return _aboutpic;}
		}
		/// <summary>
		/// 模版的物理文件夹名称
		/// </summary>
		public string tFileName
		{
			set{ _tfilename=value;}
			get{return _tfilename;}
		}
		/// <summary>
		/// 模版适用级别名称
		/// </summary>
		public string degreeName
		{
			set{ _degreename=value;}
			get{return _degreename;}
		}
		/// <summary>
		/// 模版适用级别Id
		/// </summary>
		public int? degreId
		{
			set{ _degreid=value;}
			get{return _degreid;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

