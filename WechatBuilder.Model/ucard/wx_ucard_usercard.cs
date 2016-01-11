using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 会员领取卡信息
	/// </summary>
	[Serializable]
	public partial class wx_ucard_usercard
	{
		public wx_ucard_usercard()
		{}
		#region Model
		private int _id;
		private int? _uid;
		private int? _sid;
		private DateTime? _adddate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 会员id
		/// </summary>
		public int? uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 店铺id
		/// </summary>
		public int? sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 领取时间
		/// </summary>
		public DateTime? addDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		#endregion Model

	}
}

