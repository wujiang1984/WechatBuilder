using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 黑名单
	/// </summary>
	[Serializable]
	public partial class wx_diancai_blacklist
	{
		public wx_diancai_blacklist()
		{}
		#region Model
		private int _id;
		private string _openid;
		private string _blackname;
		private DateTime? _blackdate;
		private DateTime? _createdate;
		private int? _shopid;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户openid
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string blackName
		{
			set{ _blackname=value;}
			get{return _blackname;}
		}
		/// <summary>
		/// 拉黑日期
		/// </summary>
		public DateTime? blackDate
		{
			set{ _blackdate=value;}
			get{return _blackdate;}
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
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		#endregion Model

	}
}

