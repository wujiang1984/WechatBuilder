using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 数据表3
	/// </summary>
	[Serializable]
	public partial class wx_message_blacklist
	{
		public wx_message_blacklist()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _openid;
		private DateTime? _blacktime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 编号
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 关联编号
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 名称 拉黑时间
		/// </summary>
		public DateTime? blacktime
		{
			set{ _blacktime=value;}
			get{return _blacktime;}
		}
		#endregion Model

	}
}

