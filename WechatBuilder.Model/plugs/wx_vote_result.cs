using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微投票结果
	/// </summary>
	[Serializable]
	public partial class wx_vote_result
	{
		public wx_vote_result()
		{}
		#region Model
		private int _id;
		private int? _baseid;
		private int? _itemid;
		private string _openid;
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
		/// 投票基本表Id
		/// </summary>
		public int? baseid
		{
			set{ _baseid=value;}
			get{return _baseid;}
		}
		/// <summary>
		/// 选项表id
		/// </summary>
		public int? itemid
		{
			set{ _itemid=value;}
			get{return _itemid;}
		}
		/// <summary>
		/// 用户openid
		/// </summary>
		public string openId
		{
			set{ _openid=value;}
			get{return _openid;}
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

