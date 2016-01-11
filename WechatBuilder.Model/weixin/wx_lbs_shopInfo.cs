using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微信lbs商店地理位置表
	/// </summary>
	[Serializable]
	public partial class wx_lbs_shopInfo
	{
		public wx_lbs_shopInfo()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _shopname;
		private string _telphone;
		private string _brief;
		private string _shopcontent;
		private string _shoplogo;
		private string _province;
		private string _city;
		private string _detailaddr;
		private decimal? _xpoint;
		private decimal? _ypoint;
		private string _wurl;
		private int? _seq;
		private string _remark;
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
		/// 微帐号主键Id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 商店名称
		/// </summary>
		public string shopName
		{
			set{ _shopname=value;}
			get{return _shopname;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string telphone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 简介
		/// </summary>
		public string brief
		{
			set{ _brief=value;}
			get{return _brief;}
		}
		/// <summary>
		/// 介绍
		/// </summary>
		public string shopContent
		{
			set{ _shopcontent=value;}
			get{return _shopcontent;}
		}
		/// <summary>
		/// 商家logo
		/// </summary>
		public string shopLogo
		{
			set{ _shoplogo=value;}
			get{return _shoplogo;}
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
		/// 地址
		/// </summary>
		public string detailAddr
		{
			set{ _detailaddr=value;}
			get{return _detailaddr;}
		}
		/// <summary>
		/// 纬度x坐标
		/// </summary>
		public decimal? xPoint
		{
			set{ _xpoint=value;}
			get{return _xpoint;}
		}
		/// <summary>
		/// 经度y坐标
		/// </summary>
		public decimal? yPoint
		{
			set{ _ypoint=value;}
			get{return _ypoint;}
		}
		/// <summary>
		/// 外部链接地址
		/// </summary>
		public string wUrl
		{
			set{ _wurl=value;}
			get{return _wurl;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
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
		/// 录入时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

        /// <summary>
        /// 距离
        /// </summary>
        public string juli { get; set; }

        public string khXPoint { get; set; }
        public string khYPoint { get; set; } 

	}
}

