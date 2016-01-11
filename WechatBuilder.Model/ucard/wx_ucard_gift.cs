using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 礼品券
	/// </summary>
	[Serializable]
	public partial class wx_ucard_gift
	{
		public wx_ucard_gift()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _gname;
		private int? _score;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private string _usecontent;
		private DateTime? _createdate;
		private int? _sid;
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
		/// 名称
		/// </summary>
		public string gName
		{
			set{ _gname=value;}
			get{return _gname;}
		}
		/// <summary>
		/// 需要的积分
		/// </summary>
		public int? score
		{
			set{ _score=value;}
			get{return _score;}
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
		public string useContent
		{
			set{ _usecontent=value;}
			get{return _usecontent;}
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
		/// 
		/// </summary>
		public int? sId
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		#endregion Model

	}
}

