using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 小模块的链接地址信息
	/// </summary>
	[Serializable]
	public partial class wx_small_link
	{
		public wx_small_link()
		{}
		#region Model
		private int _id;
		private string _sname;
		private string _url;
		private string _stype;
		private int? _sortid;
		private bool _isglobal;
		private string _companyname;
		private string _comtel;
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
		/// 模块名称
		/// </summary>
		public string sName
		{
			set{ _sname=value;}
			get{return _sname;}
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
		/// 模块类型名称
		/// </summary>
		public string sType
		{
			set{ _stype=value;}
			get{return _stype;}
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
		/// 是否为全局
		/// </summary>
		public bool isGlobal
		{
			set{ _isglobal=value;}
			get{return _isglobal;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string companyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 联系方式
		/// </summary>
		public string comTel
		{
			set{ _comtel=value;}
			get{return _comtel;}
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

