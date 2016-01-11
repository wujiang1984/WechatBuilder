using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 上墙黑名单
	/// </summary>
	[Serializable]
	public partial class wx_sq_heimd
	{
		public wx_sq_heimd()
		{}
		#region Model
		private int _id;
		private int? _aid;
		private string _openid;
		private DateTime? _createdate;
		private string _remark;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 活动主键id
		/// </summary>
		public int? aid
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 微用户id
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

