using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商店图片
	/// </summary>
	[Serializable]
	public partial class wx_diancai_shoppic
	{
		public wx_diancai_shoppic()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private string _description;
		private int _sortid;
		private string _picurl;
		private string _pictzurl;
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
		/// 关联编号
		/// </summary>
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
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
		/// 排序
		/// </summary>
		public int sortid
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 图片跳转地址
		/// </summary>
		public string pictzUrl
		{
			set{ _pictzurl=value;}
			get{return _pictzurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

