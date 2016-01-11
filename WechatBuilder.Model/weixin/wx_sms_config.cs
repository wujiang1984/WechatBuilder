using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 短信配置
	/// </summary>
	[Serializable]
	public partial class wx_sms_config
	{
		public wx_sms_config()
		{}
		#region Model
		private int _id;
		private int _wid;
		private string _uname;
		private string _ucode;
		private string _pwd;
		private string _qianming;
		private DateTime _createdate;
		private string _remark;
		private int? _sortid;
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
		/// 姓名
		/// </summary>
		public string uName
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 帐号
		/// </summary>
		public string ucode
		{
			set{ _ucode=value;}
			get{return _ucode;}
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
		/// 签名
		/// </summary>
		public string qianming
		{
			set{ _qianming=value;}
			get{return _qianming;}
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
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sortId
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		#endregion Model

	}
}

