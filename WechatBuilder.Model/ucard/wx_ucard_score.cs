using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 积分策略
	/// </summary>
	[Serializable]
	public partial class wx_ucard_score
	{
		public wx_ucard_score()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _userdcontent;
		private string _scoreregular;
		private int? _qiandaoscore;
		private int? _qiandao6score;
		private int? _consumemoney;
		private int? _consumemoneyscore;
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
		/// 微帐号id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 会员卡使用说明
		/// </summary>
		public string userdContent
		{
			set{ _userdcontent=value;}
			get{return _userdcontent;}
		}
		/// <summary>
		/// 积分规则说明
		/// </summary>
		public string scoreRegular
		{
			set{ _scoreregular=value;}
			get{return _scoreregular;}
		}
		/// <summary>
		/// 签到得分
		/// </summary>
		public int? qiandaoScore
		{
			set{ _qiandaoscore=value;}
			get{return _qiandaoscore;}
		}
		/// <summary>
		/// 连续6天签到奖励
		/// </summary>
		public int? qiandao6Score
		{
			set{ _qiandao6score=value;}
			get{return _qiandao6score;}
		}
		/// <summary>
		/// 消费多少金额
		/// </summary>
		public int? consumeMoney
		{
			set{ _consumemoney=value;}
			get{return _consumemoney;}
		}
		/// <summary>
		/// 消费金额奖励的积分
		/// </summary>
		public int? consumeMoneyScore
		{
			set{ _consumemoneyscore=value;}
			get{return _consumemoneyscore;}
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

