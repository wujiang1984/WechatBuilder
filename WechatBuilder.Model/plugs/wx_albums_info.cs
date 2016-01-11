using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微相册信息表
	/// </summary>
	[Serializable]
	public partial class wx_albums_info
	{
		public wx_albums_info()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _aname;
		private string _facepic;
		private string _acontent;
		private bool _showcontent;
		private bool _ishidden;
		private int? _seq;
		private DateTime? _createdate;
		private string _createperson;
		private int? _typeid;
		private string _music;
		private int? _showtype;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 相册名称
		/// </summary>
		public string aName
		{
			set{ _aname=value;}
			get{return _aname;}
		}
		/// <summary>
		/// 封面图片uri
		/// </summary>
		public string facePic
		{
			set{ _facepic=value;}
			get{return _facepic;}
		}
		/// <summary>
		/// 相册描述
		/// </summary>
		public string aContent
		{
			set{ _acontent=value;}
			get{return _acontent;}
		}
		/// <summary>
		/// 是否显示描述
		/// </summary>
		public bool showContent
		{
			set{ _showcontent=value;}
			get{return _showcontent;}
		}
		/// <summary>
		/// 是否隐藏
		/// </summary>
		public bool isHidden
		{
			set{ _ishidden=value;}
			get{return _ishidden;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
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
		/// 创建者
		/// </summary>
		public string createPerson
		{
			set{ _createperson=value;}
			get{return _createperson;}
		}
		/// <summary>
		/// 分类id
		/// </summary>
		public int? typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 音乐
		/// </summary>
		public string music
		{
			set{ _music=value;}
			get{return _music;}
		}
		/// <summary>
		/// 展现形式（1手滑，2摇一摇）
		/// </summary>
		public int? showType
		{
			set{ _showtype=value;}
			get{return _showtype;}
		}
		#endregion Model

	}
}

