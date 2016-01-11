using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微信用户的图片
	/// </summary>
	[Serializable]
	public partial class wx_sq_piclist
	{
		public wx_sq_piclist()
		{}
		#region Model
		private int _id;
		private int? _aid;
		private string _openid;
		private string _picurl;
		private DateTime? _createdate;
		private bool _hasshenghe;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 上墙活动表id
		/// </summary>
		public int? aid
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 微信用户
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 图片链接地址
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
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
		/// 是否审核通过
		/// </summary>
		public bool hasShenghe
		{
			set{ _hasshenghe=value;}
			get{return _hasshenghe;}
		}
		#endregion Model

	}
}

