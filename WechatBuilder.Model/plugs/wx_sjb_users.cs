using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 世界杯—用户基本表
	/// </summary>
	[Serializable]
	public partial class wx_sjb_users
	{
		public wx_sjb_users()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _openid;
		private string _uname;
		private string _tel;
		private int? _succtimes;
		private int? _failtimes;
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
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string uName
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 竞猜胜利次数
		/// </summary>
		public int? succTimes
		{
			set{ _succtimes=value;}
			get{return _succtimes;}
		}
		/// <summary>
		/// 失败次数
		/// </summary>
		public int? failTimes
		{
			set{ _failtimes=value;}
			get{return _failtimes;}
		}
		#endregion Model

	}
}

