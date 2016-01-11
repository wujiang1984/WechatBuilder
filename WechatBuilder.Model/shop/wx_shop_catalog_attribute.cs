using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商品类型里的属性信息
	/// </summary>
	[Serializable]
	public partial class wx_shop_catalog_attribute
	{
		public wx_shop_catalog_attribute()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _catalogid;
		private string _aname;
		private int? _atype;
		private string _avalue;
		private DateTime? _createdate;
		private int? _sort_id;
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
		/// 所属商品类型id
		/// </summary>
		public int? catalogId
		{
			set{ _catalogid=value;}
			get{return _catalogid;}
		}
		/// <summary>
		/// 属性名称
		/// </summary>
		public string aName
		{
			set{ _aname=value;}
			get{return _aname;}
		}
		/// <summary>
		/// 类型(1供客户查看,2客户可选规格,3供客户填写)
		/// </summary>
		public int? aType
		{
			set{ _atype=value;}
			get{return _atype;}
		}
		/// <summary>
		/// 默认值
		/// </summary>
		public string aValue
		{
			set{ _avalue=value;}
			get{return _avalue;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 排序字段
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		#endregion Model

	}
}

