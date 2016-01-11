using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 会员卡设置
	/// </summary>
	[Serializable]
	public partial class wx_ucard_sys
	{
		public wx_ucard_sys()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _tradetel;
		private string _tradecontent;
		private int? _cardtype;
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
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 招商电话
		/// </summary>
		public string tradeTel
		{
			set{ _tradetel=value;}
			get{return _tradetel;}
		}
		/// <summary>
		/// 招商说明
		/// </summary>
		public string tradeContent
		{
			set{ _tradecontent=value;}
			get{return _tradecontent;}
		}
		/// <summary>
		/// 版面选择(1会员卡商家很少,2会员卡商家很多)
		/// </summary>
		public int? cardType
		{
			set{ _cardtype=value;}
			get{return _cardtype;}
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

