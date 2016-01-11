using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 会员表
	/// </summary>
	[Serializable]
	public partial class wx_ucard_users
	{
		public wx_ucard_users()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private int? _sid;
		private string _openid;
		private string _cardno;
		private string _pwd;
		private int? _degreeid;
		private int? _sex;
		private DateTime? _birthday;
		private string _wxname;
		private string _realname;
		private int? _age;
		private string _qq;
		private DateTime? _regtime;
		private string _regip;
		private string _telphone;
		private string _mobile;
		private string _email;
		private string _addr;
		private DateTime? _enddate;
		private int _ttscore=0;
		private int _qdscore=0;
		private int _consumescore=0;
		private decimal _consumemoney=0;
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
		/// 店铺id
		/// </summary>
		public int? sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 微信码
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 会员卡号
		/// </summary>
		public string cardNo
		{
			set{ _cardno=value;}
			get{return _cardno;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 等级id
		/// </summary>
		public int? degreeId
		{
			set{ _degreeid=value;}
			get{return _degreeid;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int? sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 微信名称
		/// </summary>
		public string wxName
		{
			set{ _wxname=value;}
			get{return _wxname;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string realName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public int? age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qq
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime? regTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 注册ip
		/// </summary>
		public string regIp
		{
			set{ _regip=value;}
			get{return _regip;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string telphone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}
		/// <summary>
		/// 手机
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string addr
		{
			set{ _addr=value;}
			get{return _addr;}
		}
		/// <summary>
		/// 有效期截至时间
		/// </summary>
		public DateTime? endDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 总积分
		/// </summary>
		public int  ttScore
		{
			set{ _ttscore=value;}
			get{return _ttscore;}
		}
		/// <summary>
		/// 签到积分
		/// </summary>
		public int  qdScore
		{
			set{ _qdscore=value;}
			get{return _qdscore;}
		}
		/// <summary>
		/// 消费积分
		/// </summary>
		public int  consumeScore
		{
			set{ _consumescore=value;}
			get{return _consumescore;}
		}
		/// <summary>
		/// 消费金额
		/// </summary>
		public decimal  consumeMoney
		{
			set{ _consumemoney=value;}
			get{return _consumemoney;}
		}
		#endregion Model

	}
}

