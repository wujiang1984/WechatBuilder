using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商品分类表
	/// </summary>
	[Serializable]
	public partial class wx_shop_category
	{
		public wx_shop_category()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _code;
		private int? _parent_id=0;
		private string _class_list;
		private int? _class_layer=1;
		private int? _sort_id=99;
		private string _link_url;
		private string _img_url;
		private string _class_content;
		private string _remark;
		private string _seo_title;
		private string _seo_keywords;
		private string _seo_description;
		private int? _wid;
		private string _ico_url;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 分类编码
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 上级id
		/// </summary>
		public int? parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 类别ID列表(逗号分隔开)
		/// </summary>
		public string class_list
		{
			set{ _class_list=value;}
			get{return _class_list;}
		}
		/// <summary>
		/// 类别深度
		/// </summary>
		public int? class_layer
		{
			set{ _class_layer=value;}
			get{return _class_layer;}
		}
		/// <summary>
		/// 排序数字
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// URL跳转地址
		/// </summary>
		public string link_url
		{
			set{ _link_url=value;}
			get{return _link_url;}
		}
		/// <summary>
		/// 分类图片url
		/// </summary>
		public string img_url
		{
			set{ _img_url=value;}
			get{return _img_url;}
		}
		/// <summary>
		/// 类别的内容
		/// </summary>
		public string class_content
		{
			set{ _class_content=value;}
			get{return _class_content;}
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
		/// SEO标题
		/// </summary>
		public string seo_title
		{
			set{ _seo_title=value;}
			get{return _seo_title;}
		}
		/// <summary>
		/// SEO关健字
		/// </summary>
		public string seo_keywords
		{
			set{ _seo_keywords=value;}
			get{return _seo_keywords;}
		}
		/// <summary>
		/// SEO描述
		/// </summary>
		public string seo_description
		{
			set{ _seo_description=value;}
			get{return _seo_description;}
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
		/// 图标ico
		/// </summary>
		public string ico_url
		{
			set{ _ico_url=value;}
			get{return _ico_url;}
		}
		#endregion Model

	}
}

