using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 球队基本表
	/// </summary>
	[Serializable]
	public partial class wx_sjb_qiudui
	{
		public wx_sjb_qiudui()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _qdname;
		private string _qdpic;
		private string _remark;
		private int? _succtimes;
		private int? _failtimes;
		private int? _sort_id;
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
		/// 微帐号的id
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 球队名称
		/// </summary>
		public string qdName
		{
			set{ _qdname=value;}
			get{return _qdname;}
		}
		/// <summary>
		/// 对球logo
		/// </summary>
		public string qdPic
		{
			set{ _qdpic=value;}
			get{return _qdpic;}
		}
		/// <summary>
		/// 介绍
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 胜利次数
		/// </summary>
		public int? succTimes
		{
			set{ _succtimes=value;}
			get{return _succtimes;}
		}
		/// <summary>
		/// 失败次数
		/// </summary>
		public int? failTimes
		{
			set{ _failtimes=value;}
			get{return _failtimes;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
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

