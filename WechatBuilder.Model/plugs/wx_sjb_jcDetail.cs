using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 用户竞猜详情
	/// </summary>
	[Serializable]
	public partial class wx_sjb_jcDetail
	{
		public wx_sjb_jcDetail()
		{}
		#region Model
		private int _id;
		private int? _uid;
		private int? _rcid;
		private int? _bsid;
		private int? _jcrettype;
		private bool ?_retisright;
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
		/// 用户id
		/// </summary>
		public int? uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 日程id
		/// </summary>
		public int? rcId
		{
			set{ _rcid=value;}
			get{return _rcid;}
		}
		/// <summary>
		/// 比赛Id
		/// </summary>
		public int? bsId
		{
			set{ _bsid=value;}
			get{return _bsid;}
		}
		/// <summary>
		/// 用户的竞猜选项
		/// </summary>
		public int? jcRetType
		{
			set{ _jcrettype=value;}
			get{return _jcrettype;}
		}
		/// <summary>
		/// 是否猜对了
		/// </summary>
		public bool ?retIsRight
		{
			set{ _retisright=value;}
			get{return _retisright;}
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

