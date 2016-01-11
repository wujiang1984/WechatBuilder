using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商品规格表
	/// </summary>
	[Serializable]
	public partial class wx_shop_sku
	{
		public wx_shop_sku()
		{}
		#region Model
		private int _id;
		private int? _productid;
		private string _sku;
		private int? _stock;
		private decimal? _price;
		private string _attributevalue;
		private int? _attributeid;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 商品主键id
		/// </summary>
		public int? productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// sku货号
		/// </summary>
		public string sku
		{
			set{ _sku=value;}
			get{return _sku;}
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
		/// 价格
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 属性值
		/// </summary>
		public string attributeValue
		{
			set{ _attributevalue=value;}
			get{return _attributevalue;}
		}
		/// <summary>
		/// 属性表id
		/// </summary>
		public int? attributeId
		{
			set{ _attributeid=value;}
			get{return _attributeid;}
		}

        private string _attrName;
        /// <summary>
        /// 属性名称
        /// </summary>
        public string attrName
        {
            set { _attrName = value; }
            get { return _attrName; }
        }

		#endregion Model

	}
}

