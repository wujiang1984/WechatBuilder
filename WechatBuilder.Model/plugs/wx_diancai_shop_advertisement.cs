using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 招商表
	/// </summary>
	[Serializable]
	public partial class wx_diancai_shop_advertisement
	{
		public wx_diancai_shop_advertisement()
		{}
		#region Model
		private int _id;
		private int? _setupid;
		private string _advertisementname;
		private int _sortid;
		private string _picurl;
		private string _webseturl;
		private bool _isdisplay;
		private string _createdate;
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
		public int? setupid
		{
			set{ _setupid=value;}
			get{return _setupid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string advertisementName
		{
			set{ _advertisementname=value;}
			get{return _advertisementname;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int sortid
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 图片外链地址
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 外链网站或活动
		/// </summary>
		public string websetUrl
		{
			set{ _webseturl=value;}
			get{return _webseturl;}
		}
		/// <summary>
		/// 是否显示
		/// </summary>
		public bool isdisplay
		{
			set{ _isdisplay=value;}
			get{return _isdisplay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

