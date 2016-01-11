using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 用户地址表
	/// </summary>
	[Serializable]
	public partial class wx_shop_user_addr
	{
		public wx_shop_user_addr()
		{}
		#region Model
		private int _id;
		private int _wid;
		private string _openid;
		private string _province;
		private string _city;
		private string _area;
		private string _addrdetail;
		private string _tel;
		private string _jiedao;
		private string _contractperson;
		private DateTime _createdate= DateTime.Now;
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
		public int wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 微信用户openid
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 省份
		/// </summary>
		public string province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 城市
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 地区
		/// </summary>
		public string area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string addrDetail
		{
			set{ _addrdetail=value;}
			get{return _addrdetail;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 街道
		/// </summary>
		public string jiedao
		{
			set{ _jiedao=value;}
			get{return _jiedao;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string contractPerson
		{
			set{ _contractperson=value;}
			get{return _contractperson;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

