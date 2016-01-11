using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商品属性对应的值
	/// </summary>
	[Serializable]
	public partial class wx_shop_productAttr_value
	{
		public wx_shop_productAttr_value()
		{}
		#region Model
		private int _id;
		private int? _attributeid;
		private int? _productid;
		private string _pavalue;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 属性id
		/// </summary>
		public int? attributeId
		{
			set{ _attributeid=value;}
			get{return _attributeid;}
		}
		/// <summary>
		/// 商品id
		/// </summary>
		public int? productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
        public string _attrName = "";
        /// <summary>
        /// 商品属性的名称
        /// </summary>
        public string attrName
        {
            set { _attrName = value; }
            get { return _attrName; }
        }
		/// <summary>
		/// 商品属性的值
		/// </summary>
		public string paValue
		{
			set{ _pavalue=value;}
			get{return _pavalue;}
		}
		#endregion Model

	}
}

