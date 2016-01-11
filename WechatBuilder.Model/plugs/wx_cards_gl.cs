using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 数据表2
	/// </summary>
	[Serializable]
	public partial class wx_cards_gl
	{
		public wx_cards_gl()
		{}
		#region Model
		private int _id;
		private int? _cardsid;
		private string _openid;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 关联编号
		/// </summary>
		public int? cardsid
		{
			set{ _cardsid=value;}
			get{return _cardsid;}
		}
		/// <summary>
		/// 转发人的openid
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		#endregion Model

	}
}

