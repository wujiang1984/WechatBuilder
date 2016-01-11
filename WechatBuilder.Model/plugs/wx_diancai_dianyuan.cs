using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 店员管理
	/// </summary>
	[Serializable]
	public partial class wx_diancai_dianyuan
	{
		public wx_diancai_dianyuan()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private DateTime? _createdate;
		private string _bianhao;
		private string _dianyuanname;
		private string _dianyuantel;
		private string _username;
		private string _pwd;
		private int? _userstatus;
		private string _fendian;
		private DateTime? _begintime;
		private DateTime? _endtime;
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
		/// 商家编号
		/// </summary>
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 常见时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 编号
		/// </summary>
		public string bianhao
		{
			set{ _bianhao=value;}
			get{return _bianhao;}
		}
		/// <summary>
		/// 店员姓名
		/// </summary>
		public string dianyuanName
		{
			set{ _dianyuanname=value;}
			get{return _dianyuanname;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string dianyuanTel
		{
			set{ _dianyuantel=value;}
			get{return _dianyuantel;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
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
		/// 在职状态
		/// </summary>
		public int? userStatus
		{
			set{ _userstatus=value;}
			get{return _userstatus;}
		}
		/// <summary>
		/// 分店
		/// </summary>
		public string fendian
		{
			set{ _fendian=value;}
			get{return _fendian;}
		}
		/// <summary>
		/// 到岗时间
		/// </summary>
		public DateTime? beginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 离职时间
		/// </summary>
		public DateTime? endTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

