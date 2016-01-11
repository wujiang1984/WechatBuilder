using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 通知
	/// </summary>
	[Serializable]
	public partial class wx_ucard_notice
	{
		public wx_ucard_notice()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _nname;
		private string _ncontent;
		private string _userdegree;
		private DateTime? _createdate;
		private int? _sid;
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
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 通知名称
		/// </summary>
		public string nName
		{
			set{ _nname=value;}
			get{return _nname;}
		}
		/// <summary>
		/// 通知的内容
		/// </summary>
		public string nContent
		{
			set{ _ncontent=value;}
			get{return _ncontent;}
		}
		/// <summary>
		/// 通知的人的等级（id使用逗号隔开）
		/// </summary>
		public string userDegree
		{
			set{ _userdegree=value;}
			get{return _userdegree;}
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
		/// 
		/// </summary>
		public int? sId
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		#endregion Model

	}
}

