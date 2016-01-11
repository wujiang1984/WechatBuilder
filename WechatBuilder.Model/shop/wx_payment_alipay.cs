using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 微信支付宝接口信息表
	/// </summary>
	[Serializable]
	public partial class wx_payment_alipay
	{
		public wx_payment_alipay()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _ownername;
		private string _partner;
		private string _e_key;
		private string _private_key;
		private string _public_key;
		private string _sign_type;
		private DateTime? _createdate;
		private int? _extint;
		private string _extstr;
		private string _extstr2;
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
		/// 所属者姓名
		/// </summary>
		public string ownerName
		{
			set{ _ownername=value;}
			get{return _ownername;}
		}
		/// <summary>
		/// 合作身份者ID
		/// </summary>
		public string partner
		{
			set{ _partner=value;}
			get{return _partner;}
		}
		/// <summary>
		/// 交易安全检验码
		/// </summary>
		public string e_key
		{
			set{ _e_key=value;}
			get{return _e_key;}
		}
		/// <summary>
		/// 商户的私钥
		/// </summary>
		public string private_key
		{
			set{ _private_key=value;}
			get{return _private_key;}
		}
		/// <summary>
		/// 支付宝的公钥
		/// </summary>
		public string public_key
		{
			set{ _public_key=value;}
			get{return _public_key;}
		}
		/// <summary>
		/// 签名方式
		/// </summary>
		public string sign_type
		{
			set{ _sign_type=value;}
			get{return _sign_type;}
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
		/// 扩展int
		/// </summary>
		public int? extInt
		{
			set{ _extint=value;}
			get{return _extint;}
		}
		/// <summary>
		/// 扩展str
		/// </summary>
		public string extStr
		{
			set{ _extstr=value;}
			get{return _extstr;}
		}
		/// <summary>
		/// 扩展str2
		/// </summary>
		public string extStr2
		{
			set{ _extstr2=value;}
			get{return _extstr2;}
		}
		#endregion Model

	}
}

