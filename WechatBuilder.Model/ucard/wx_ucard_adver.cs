using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 广告信息
	/// </summary>
	[Serializable]
	public partial class wx_ucard_adver
	{
		public wx_ucard_adver()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _advername;
		private string _picurl;
		private string _linkurl;
		private bool _isshow;
		private int? _sort_id;
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
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 广告名称
		/// </summary>
		public string adverName
		{
			set{ _advername=value;}
			get{return _advername;}
		}
		/// <summary>
		/// 图片url
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 外部链接地址
		/// </summary>
		public string linkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 是否展示
		/// </summary>
		public bool isShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
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
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

