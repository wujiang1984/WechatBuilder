using System;
using System.Collections.Generic;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商品表
	/// </summary>
	[Serializable]
	public partial class wx_shop_product
	{
		public wx_shop_product()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _categoryid;
		private int? _brandid;
		private string _sku;
		private string _productname;
		private string _shortdesc;
		private string _unit;
		private decimal? _weight;
		private string _description;
		private string _seo_title;
		private string _seo_keywords;
		private string _seo_description;
		private string _focusimgurl;
		private string _thumbnailsurll;
		private bool _recommended;
		private bool _latest;
		private bool _hotsale;
		private bool _specialoffer;
		private decimal? _costprice;
		private decimal? _marketprice;
		private decimal? _saleprice;
		private bool _upselling;
		private int? _stock;
		private DateTime? _adddate;
		private int? _visticounts;
		private int? _sort_id;
		private DateTime? _productiondate;
		private DateTime? _expiryenddate;
		private DateTime? _updatedate;
        private int _catalogId = 0;

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
		/// 分类id
		/// </summary>
		public int? categoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 品牌id
		/// </summary>
		public int? brandId
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 库存单元，货号
		/// </summary>
		public string sku
		{
			set{ _sku=value;}
			get{return _sku;}
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string productName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 简单介绍
		/// </summary>
		public string shortDesc
		{
			set{ _shortdesc=value;}
			get{return _shortdesc;}
		}
		/// <summary>
		/// 计量单位
		/// </summary>
		public string unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 重量
		/// </summary>
		public decimal? weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// seo标题
		/// </summary>
		public string seo_title
		{
			set{ _seo_title=value;}
			get{return _seo_title;}
		}
		/// <summary>
		/// seo关键词
		/// </summary>
		public string seo_keywords
		{
			set{ _seo_keywords=value;}
			get{return _seo_keywords;}
		}
		/// <summary>
		/// seo描述
		/// </summary>
		public string seo_description
		{
			set{ _seo_description=value;}
			get{return _seo_description;}
		}
		/// <summary>
		/// 商品主题
		/// </summary>
		public string focusImgUrl
		{
			set{ _focusimgurl=value;}
			get{return _focusimgurl;}
		}
		/// <summary>
		/// 缩略图
		/// </summary>
		public string thumbnailsUrll
		{
			set{ _thumbnailsurll=value;}
			get{return _thumbnailsurll;}
		}
		/// <summary>
		/// 推荐
		/// </summary>
		public bool recommended
		{
			set{ _recommended=value;}
			get{return _recommended;}
		}
		/// <summary>
		/// 最新
		/// </summary>
		public bool latest
		{
			set{ _latest=value;}
			get{return _latest;}
		}
		/// <summary>
		/// 最热
		/// </summary>
		public bool hotsale
		{
			set{ _hotsale=value;}
			get{return _hotsale;}
		}
		/// <summary>
		/// 特价
		/// </summary>
		public bool specialOffer
		{
			set{ _specialoffer=value;}
			get{return _specialoffer;}
		}
		/// <summary>
		/// 成本
		/// </summary>
		public decimal? costPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
		/// 市场价
		/// </summary>
		public decimal? marketPrice
		{
			set{ _marketprice=value;}
			get{return _marketprice;}
		}
		/// <summary>
		/// 销售价
		/// </summary>
		public decimal? salePrice
		{
			set{ _saleprice=value;}
			get{return _saleprice;}
		}
		/// <summary>
		/// 上架:0放入库存，1上架
		/// </summary>
		public bool upselling
		{
			set{ _upselling=value;}
			get{return _upselling;}
		}
		/// <summary>
		/// 库存
		/// </summary>
		public int? stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? addDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		/// <summary>
		/// 浏览次数
		/// </summary>
		public int? vistiCounts
		{
			set{ _visticounts=value;}
			get{return _visticounts;}
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
		/// 生产日期
		/// </summary>
		public DateTime? productionDate
		{
			set{ _productiondate=value;}
			get{return _productiondate;}
		}
		/// <summary>
		/// 有效期最后日期
		/// </summary>
		public DateTime? ExpiryEndDate
		{
			set{ _expiryenddate=value;}
			get{return _expiryenddate;}
		}
		/// <summary>
		/// 修改日期
		/// </summary>
		public DateTime? updateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}

        /// <summary>
        /// 商品类型id
        /// </summary>
        public int catalogId
        {
            get { return _catalogId; }
            set { _catalogId = value; }
        }


        /// <summary>
        /// 图片相册
        /// </summary>
        private List<wx_shop_albums> _albums;
        public List<wx_shop_albums> albums
        {
            set { _albums = value; }
            get { return _albums; }
        }

        private List<wx_shop_productAttr_value> _attrs;

        /// <summary>
        /// 属性值列表
        /// </summary>
        public List<wx_shop_productAttr_value> attrs
        {
            set { _attrs = value; }
            get { return _attrs; }
        }

        private List<wx_shop_sku> _skulist;
        /// <summary>
        /// 商品sku列表
        /// </summary>
        public List<wx_shop_sku> skulist
        {
            set { _skulist = value; }
            get { return _skulist; }
        }

		#endregion Model

	}
}

