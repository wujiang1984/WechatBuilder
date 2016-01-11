using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 购物车
	/// </summary>
	[Serializable]
	public partial class wx_shop_cart
	{
		public wx_shop_cart()
		{}
		#region Model
		private int _id;
		private string _openid;
		private int _wid;
		private int _productid;
		private int _skuid;
		private string _skuinfo;
		private decimal _totprice;
		private int _productnum;
		private DateTime _createdate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 微用户id
		/// </summary>
		public int wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 商品id
		/// </summary>
		public int productId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 配件id
		/// </summary>
		public int skuId
		{
			set{ _skuid=value;}
			get{return _skuid;}
		}
		/// <summary>
		/// 配件信息
		/// </summary>
		public string skuInfo
		{
			set{ _skuinfo=value;}
			get{return _skuinfo;}
		}
		/// <summary>
		/// 商品总价格
		/// </summary>
		public decimal totPrice
		{
			set{ _totprice=value;}
			get{return _totprice;}
		}
		/// <summary>
		/// 商品数量
		/// </summary>
		public int productNum
		{
			set{ _productnum=value;}
			get{return _productnum;}
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

