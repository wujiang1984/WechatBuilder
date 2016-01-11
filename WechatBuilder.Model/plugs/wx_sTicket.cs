using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 优惠券（简单版）
	/// </summary>
	[Serializable]
	public partial class wx_sTicket
	{
		public wx_sTicket()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _actionname;
		private string _succtip;
		private string _brief;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private string _acontent;
		private string _usedremark;
		private string _telphone;
		private string _wurl;
		private int? _seq;
		private string _remark;
		private DateTime? _createdate;
		private string _endnotice;
		private string _endcontent;
		private string _bannerpic;
		private string _beginpic;
		private string _endpic;
		private string _pwd;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 微帐号主键Id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 活动名称名称
		/// </summary>
		public string actionName
		{
			set{ _actionname=value;}
			get{return _actionname;}
		}
		/// <summary>
		/// 成功抢到券说明
		/// </summary>
		public string succTip
		{
			set{ _succtip=value;}
			get{return _succtip;}
		}
		/// <summary>
		/// 简介
		/// </summary>
		public string brief
		{
			set{ _brief=value;}
			get{return _brief;}
		}
		/// <summary>
		/// 活动开始时间
		/// </summary>
		public DateTime? beginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
		}
		/// <summary>
		/// 活动结束时间
		/// </summary>
		public DateTime? endDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 活动说明
		/// </summary>
		public string aContent
		{
			set{ _acontent=value;}
			get{return _acontent;}
		}
		/// <summary>
		/// 兑换券使用说明
		/// </summary>
		public string usedRemark
		{
			set{ _usedremark=value;}
			get{return _usedremark;}
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
		/// 外部链接地址
		/// </summary>
		public string wUrl
		{
			set{ _wurl=value;}
			get{return _wurl;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? seq
		{
			set{ _seq=value;}
			get{return _seq;}
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
		/// 录入时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 结束通知
		/// </summary>
		public string endNotice
		{
			set{ _endnotice=value;}
			get{return _endnotice;}
		}
		/// <summary>
		/// 结束说明
		/// </summary>
		public string endContent
		{
			set{ _endcontent=value;}
			get{return _endcontent;}
		}
		/// <summary>
		/// 头部图片地址
		/// </summary>
		public string bannerPic
		{
			set{ _bannerpic=value;}
			get{return _bannerpic;}
		}
		/// <summary>
		/// 活动开始的图片
		/// </summary>
		public string beginPic
		{
			set{ _beginpic=value;}
			get{return _beginpic;}
		}
		/// <summary>
		/// 活动结束的图片
		/// </summary>
		public string endPic
		{
			set{ _endpic=value;}
			get{return _endpic;}
		}
		/// <summary>
		/// 兑奖密码
		/// </summary>
		public string pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		#endregion Model

	}
}

