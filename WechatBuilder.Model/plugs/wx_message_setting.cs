using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 留言设置
	/// </summary>
	[Serializable]
	public partial class wx_message_setting
	{
		public wx_message_setting()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _title;
		private string _adminopenid;
		private string _picurl;
		private bool _needsh;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 显示名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 管理员管理员Openid
		/// </summary>
		public string adminOpenid
		{
			set{ _adminopenid=value;}
			get{return _adminopenid;}
		}
		/// <summary>
		/// 头部图片
		/// </summary>
		public string picUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool needSH
		{
			set{ _needsh=value;}
			get{return _needsh;}
		}
		#endregion Model

	}
}

