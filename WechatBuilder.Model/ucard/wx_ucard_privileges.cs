using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 特权
	/// </summary>
	[Serializable]
	public partial class wx_ucard_privileges
	{
		public wx_ucard_privileges()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _pname;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private string _usedcontent;
		private string _userdegree;
		private int? _sid;
		private DateTime? _createdate= DateTime.Now;
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
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 特权名称
		/// </summary>
		public string pName
		{
			set{ _pname=value;}
			get{return _pname;}
		}
		/// <summary>
		/// 开始时间
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
		/// 使用说明
		/// </summary>
		public string usedContent
		{
			set{ _usedcontent=value;}
			get{return _usedcontent;}
		}
		/// <summary>
		/// 使用的人群等级（id用逗号隔开）
		/// </summary>
		public string userDegree
		{
			set{ _userdegree=value;}
			get{return _userdegree;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sId
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		#endregion Model

	}
}

