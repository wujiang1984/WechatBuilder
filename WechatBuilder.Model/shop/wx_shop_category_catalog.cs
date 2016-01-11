using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 分类对应的类型
	/// </summary>
	[Serializable]
	public partial class wx_shop_category_catalog
	{
		public wx_shop_category_catalog()
		{}
		#region Model
		private int _id;
		private int? _categoryid;
		private int? _catalogid;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 类型id
		/// </summary>
		public int? catalogId
		{
			set{ _catalogid=value;}
			get{return _catalogid;}
		}
		#endregion Model

	}
}

