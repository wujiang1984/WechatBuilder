using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 日程表
	/// </summary>
	[Serializable]
	public partial class wx_sjb_richeng
	{
		public wx_sjb_richeng()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _rcname;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private string _rcpic;
		private string _remark;
		private int? _sort_id;
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
		/// 微帐号的id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 日程名称
		/// </summary>
		public string rcName
		{
			set{ _rcname=value;}
			get{return _rcname;}
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
		/// 日程图片
		/// </summary>
		public string rcPic
		{
			set{ _rcpic=value;}
			get{return _rcpic;}
		}
		/// <summary>
		/// 日程简介
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

