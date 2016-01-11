using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 相册分类
	/// </summary>
	[Serializable]
	public partial class wx_albums_type
	{
		public wx_albums_type()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _typename;
		private string _bannerpic;
		private string _typeico;
		private string _typepic;
		private string _tcontent;
		private string _remark;
		private string _music;
		private int? _showtype;
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
		/// 类型名称
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 头部图片
		/// </summary>
		public string bannerPic
		{
			set{ _bannerpic=value;}
			get{return _bannerpic;}
		}
		/// <summary>
		/// 图标
		/// </summary>
		public string typeIco
		{
			set{ _typeico=value;}
			get{return _typeico;}
		}
		/// <summary>
		/// 分类图片
		/// </summary>
		public string typePic
		{
			set{ _typepic=value;}
			get{return _typepic;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string tContent
		{
			set{ _tcontent=value;}
			get{return _tcontent;}
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
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		#endregion Model

	}
}

