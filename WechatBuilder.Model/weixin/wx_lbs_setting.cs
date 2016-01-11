using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微信lbs设置表
	/// </summary>
	[Serializable]
	public partial class wx_lbs_setting
	{
		public wx_lbs_setting()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private decimal? _searchradius;
		private string _bannerpicurl;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号主键Id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 搜索半径
		/// </summary>
		public decimal? searchRadius
		{
			set{ _searchradius=value;}
			get{return _searchradius;}
		}
		/// <summary>
		/// banner图片url
		/// </summary>
		public string bannerPicUrl
		{
			set{ _bannerpicurl=value;}
			get{return _bannerpicurl;}
		}
		#endregion Model

	}
}

