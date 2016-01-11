using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微相册系统设置
	/// </summary>
	[Serializable]
	public partial class wx_albums_sys
	{
		public wx_albums_sys()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _bannerpic;
		private string _code;
		private int? _typeid;
		private string _typename;
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
		/// 头部图片
		/// </summary>
		public string bannerPic
		{
			set{ _bannerpic=value;}
			get{return _bannerpic;}
		}
		/// <summary>
		/// 编码
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 类别id
		/// </summary>
		public int? typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 类别名称
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		#endregion Model

	}
}

