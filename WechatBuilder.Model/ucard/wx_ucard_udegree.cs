using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 会员等级
	/// </summary>
	[Serializable]
	public partial class wx_ucard_udegree
	{
		public wx_ucard_udegree()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _degreenum;
		private string _callname;
		private int? _score_min;
		private int? _score_max;
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
		/// 等级级别
		/// </summary>
		public int? degreeNum
		{
			set{ _degreenum=value;}
			get{return _degreenum;}
		}
		/// <summary>
		/// 称呼
		/// </summary>
		public string callName
		{
			set{ _callname=value;}
			get{return _callname;}
		}
		/// <summary>
		/// 积分下限
		/// </summary>
		public int? score_min
		{
			set{ _score_min=value;}
			get{return _score_min;}
		}
		/// <summary>
		/// 积分上限
		/// </summary>
		public int? score_max
		{
			set{ _score_max=value;}
			get{return _score_max;}
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

