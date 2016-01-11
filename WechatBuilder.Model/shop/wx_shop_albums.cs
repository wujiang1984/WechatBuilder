using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商品相册
	/// </summary>
	[Serializable]
	public partial class wx_shop_albums
	{
		public wx_shop_albums()
		{}
		#region Model
		private int _id;
		private int? _productid;
		private string _thumb_path;
		private string _original_path;
		private string _remark;
		private DateTime? _add_time;
		private int? _wid;
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
		/// 缩略图路径
		/// </summary>
		public string thumb_path
		{
			set{ _thumb_path=value;}
			get{return _thumb_path;}
		}
		/// <summary>
		/// 原图路径
		/// </summary>
		public string original_path
		{
			set{ _original_path=value;}
			get{return _original_path;}
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
		/// 添加时间
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		#endregion Model

	}
}

