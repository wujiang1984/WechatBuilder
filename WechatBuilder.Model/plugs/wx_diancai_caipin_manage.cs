using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// wx_diancai_caipin_manage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class wx_diancai_caipin_manage
	{
		public wx_diancai_caipin_manage()
		{}
		#region Model
		private int _id;
		private int? _categoryid;
		private string _cpname;
		private string _categoryname;
		private decimal? _cpprice;
		private decimal? _zkprice;
		private string _priceunite;
		private string _cppic;
		private string _picurl;
		private string _detailcontent;
		private DateTime? _createdate;
		private int? _shopid;
		private int _sortid;
		private int? _scan;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? categoryid
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cpName
		{
			set{ _cpname=value;}
			get{return _cpname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string categoryName
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cpPrice
		{
			set{ _cpprice=value;}
			get{return _cpprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? zkPrice
		{
			set{ _zkprice=value;}
			get{return _zkprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string priceUnite
		{
			set{ _priceunite=value;}
			get{return _priceunite;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cpPic
		{
			set{ _cppic=value;}
			get{return _cppic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string detailContent
		{
			set{ _detailcontent=value;}
			get{return _detailcontent;}
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
		/// <summary>
		/// 
		/// </summary>
		public int sortid
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? scan
		{
			set{ _scan=value;}
			get{return _scan;}
		}
		#endregion Model

	}
}

