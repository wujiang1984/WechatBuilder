using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微相册里的图片
	/// </summary>
	[Serializable]
	public partial class wx_albums_photo
	{
		public wx_albums_photo()
		{}
		#region Model
		private int _id;
		private int? _aid;
		private string _pname;
		private string _photopic;
		private string _pcontent;
		private int? _seq;
		private bool _ishidden;
		private DateTime? _createdate;
		private string _createperson;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 相册表主键
		/// </summary>
		public int? aId
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 图片名称
		/// </summary>
		public string pName
		{
			set{ _pname=value;}
			get{return _pname;}
		}
		/// <summary>
		/// 图片uri
		/// </summary>
		public string photoPic
		{
			set{ _photopic=value;}
			get{return _photopic;}
		}
		/// <summary>
		/// 图片说明
		/// </summary>
		public string pContent
		{
			set{ _pcontent=value;}
			get{return _pcontent;}
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
		/// 是否隐藏
		/// </summary>
		public bool isHidden
		{
			set{ _ishidden=value;}
			get{return _ishidden;}
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
		#endregion Model

	}
}

