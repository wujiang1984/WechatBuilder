using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微信相关系统级配置
	/// </summary>
	[Serializable]
	public partial class wx_sysConfig
	{
		public wx_sysConfig()
		{}
		#region Model
		private int _id;
		private string _syscode;
		private string _sysname;
		private string _sysvalue;
		private int? _systypeid;
		private string _systypename;
		private DateTime? _createdate;
		private int? _parentid;
		private string _remark;
		private int? _sort_id;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 节点编码
		/// </summary>
		public string sysCode
		{
			set{ _syscode=value;}
			get{return _syscode;}
		}
		/// <summary>
		/// 节点名称
		/// </summary>
		public string sysName
		{
			set{ _sysname=value;}
			get{return _sysname;}
		}
		/// <summary>
		/// 值
		/// </summary>
		public string sysValue
		{
			set{ _sysvalue=value;}
			get{return _sysvalue;}
		}
		/// <summary>
		/// 类别Id
		/// </summary>
		public int? sysTypeId
		{
			set{ _systypeid=value;}
			get{return _systypeid;}
		}
		/// <summary>
		/// 类别名称
		/// </summary>
		public string sysTypeName
		{
			set{ _systypename=value;}
			get{return _systypename;}
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
		/// 上级配置Id
		/// </summary>
		public int? parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		#endregion Model

	}
}

