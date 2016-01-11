using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 短信发送信息
	/// </summary>
	[Serializable]
	public partial class wx_sms_info
	{
		public wx_sms_info()
		{}
		#region Model
		private int _id;
		private int _wid;
		private string _tel;
		private string _smscontent;
		private string _sstatusnum;
		private string _sstatus;
		private string _modulename;
		private int? _actionid;
		private string _actionname;
		private DateTime _createdate;
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
		/// 微帐号id
		/// </summary>
		public int wid
		{
			set{ _wid=value;}
			get{return _wid;}
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
		/// 短信内容
		/// </summary>
		public string smsContent
		{
			set{ _smscontent=value;}
			get{return _smscontent;}
		}
		/// <summary>
		/// 发送状态的数字
		/// </summary>
		public string sStatusNum
		{
			set{ _sstatusnum=value;}
			get{return _sstatusnum;}
		}
		/// <summary>
		/// 发送状态
		/// </summary>
		public string sStatus
		{
			set{ _sstatus=value;}
			get{return _sstatus;}
		}
		/// <summary>
		/// 发送短信的模块名称
		/// </summary>
		public string moduleName
		{
			set{ _modulename=value;}
			get{return _modulename;}
		}
		/// <summary>
		/// 模块活动的主键id
		/// </summary>
		public int? actionId
		{
			set{ _actionid=value;}
			get{return _actionid;}
		}
		/// <summary>
		/// 模块活动的名称
		/// </summary>
		public string actionName
		{
			set{ _actionname=value;}
			get{return _actionname;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime createDate
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

