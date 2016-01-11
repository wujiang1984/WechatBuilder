using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商品品牌表
	/// </summary>
	[Serializable]
	public partial class wx_shop_brand
	{
		public wx_shop_brand()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _bname;
		private string _logo;
		private string _companyurl;
		private string _companyname;
		private string _remark;
		private int? _sort_id;
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
		/// 名称
		/// </summary>
		public string bName
		{
			set{ _bname=value;}
			get{return _bname;}
		}
		/// <summary>
		/// logo地址
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 公司网址
		/// </summary>
		public string companyUrl
		{
			set{ _companyurl=value;}
			get{return _companyurl;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string companyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
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

