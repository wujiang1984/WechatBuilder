using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 会员积分明细
	/// </summary>
	[Serializable]
	public partial class wx_ucard_users_consumeinfo
	{
		public wx_ucard_users_consumeinfo()
		{}
		#region Model
		private int _id;
		private int? _sid;
		private int? _uid;
		private string _moduletype;
		private int? _moduletypeid;
		private string _moduleactionname;
		private int? _moduleactionid;
		private int? _cscoretype;
		private int? _score;
		private int? _cmoneytype;
		private decimal? _consumemoney;
		private string _ccontent;
		private string _remark;
		private DateTime? _addtime;
		private int? _sort_id;
		private string _sn;
		private string _opername;
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
		/// 店铺id
		/// </summary>
		public int? sId
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 会员主键id
		/// </summary>
		public int? uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 功能模块类型名称
		/// </summary>
		public string moduleType
		{
			set{ _moduletype=value;}
			get{return _moduletype;}
		}
		/// <summary>
		/// 功能模块类型Id
		/// </summary>
		public int? moduleTypeId
		{
			set{ _moduletypeid=value;}
			get{return _moduletypeid;}
		}
		/// <summary>
		/// 功能模块的活动名称
		/// </summary>
		public string moduleActionName
		{
			set{ _moduleactionname=value;}
			get{return _moduleactionname;}
		}
		/// <summary>
		/// 功能模版的活动id
		/// </summary>
		public int? moduleActionId
		{
			set{ _moduleactionid=value;}
			get{return _moduleactionid;}
		}
		/// <summary>
		/// 积分类型（1加，2减）
		/// </summary>
		public int? cScoreType
		{
			set{ _cscoretype=value;}
			get{return _cscoretype;}
		}
		/// <summary>
		/// 积分
		/// </summary>
		public int? score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 金额类型（1加，2减）
		/// </summary>
		public int? cMoneyType
		{
			set{ _cmoneytype=value;}
			get{return _cmoneytype;}
		}
		/// <summary>
		/// 消费金额
		/// </summary>
		public decimal? consumeMoney
		{
			set{ _consumemoney=value;}
			get{return _consumemoney;}
		}
		/// <summary>
		/// 消费类型
		/// </summary>
		public string cContent
		{
			set{ _ccontent=value;}
			get{return _ccontent;}
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
		/// 时间
		/// </summary>
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 排序字段
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// sn码
		/// </summary>
		public string sn
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 操作员姓名
		/// </summary>
		public string operName
		{
			set{ _opername=value;}
			get{return _opername;}
		}
		/// <summary>
		/// 操作密码
		/// </summary>
		public string pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		#endregion Model

	}
}

