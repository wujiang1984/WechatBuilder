using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微信属性值存储值 支持多用户平台
	/// </summary>
	[Serializable]
	public partial class wx_property_info
	{
		public wx_property_info()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _typeid;
		private string _typename;
		private string _iname;
		private string _icontent;
		private int? _expires_in;
		private DateTime? _createdate;
		private int? _count;
		private int? _categoryid;
		private string _categoryname;
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
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 分类id
		/// </summary>
		public int? typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string iName
		{
			set{ _iname=value;}
			get{return _iname;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string iContent
		{
			set{ _icontent=value;}
			get{return _icontent;}
		}
		/// <summary>
		/// 有效期（秒）
		/// </summary>
		public int? expires_in
		{
			set{ _expires_in=value;}
			get{return _expires_in;}
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
		/// 总数
		/// </summary>
		public int? count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 类分类d
		/// </summary>
		public int? categoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 分类名称
		/// </summary>
		public string categoryName
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
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

