using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微网站组件基本表
	/// </summary>
	[Serializable]
	public partial class wx_wsite_modulebase
	{
		public wx_wsite_modulebase()
		{}
		#region Model
		private int _id;
		private string _mname;
		private string _mcode;
		private int? _mvalueint;
		private string _mvalue;
		private string _mtype;
		private string _mtypename;
		private string _picurl;
		private string _remark;
		private int? _seq;
		private DateTime? _createdate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string mName
		{
			set{ _mname=value;}
			get{return _mname;}
		}
		/// <summary>
		/// 编码
		/// </summary>
		public string mCode
		{
			set{ _mcode=value;}
			get{return _mcode;}
		}
		/// <summary>
		/// 值2
		/// </summary>
		public int? mValueInt
		{
			set{ _mvalueint=value;}
			get{return _mvalueint;}
		}
		/// <summary>
		/// 值
		/// </summary>
		public string mValue
		{
			set{ _mvalue=value;}
			get{return _mvalue;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string mType
		{
			set{ _mtype=value;}
			get{return _mtype;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string mTypeName
		{
			set{ _mtypename=value;}
			get{return _mtypename;}
		}
		/// <summary>
		/// 效果图
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
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
		/// 排序号
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
		#endregion Model

	}
}

