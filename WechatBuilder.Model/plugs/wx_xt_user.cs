using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 喜帖报名人信息
	/// </summary>
	[Serializable]
	public partial class wx_xt_user
	{
		public wx_xt_user()
		{}
		#region Model
		private int _id;
		private int? _bid;
		private string _openid;
		private string _uname;
		private string _phone;
		private int? _pnum;
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
		/// 喜帖基本表主键Id
		/// </summary>
		public int? bId
		{
			set{ _bid=value;}
			get{return _bid;}
		}
		/// <summary>
		/// 微信openid
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string uName
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 赴宴人数
		/// </summary>
		public int? pNum
		{
			set{ _pnum=value;}
			get{return _pnum;}
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

