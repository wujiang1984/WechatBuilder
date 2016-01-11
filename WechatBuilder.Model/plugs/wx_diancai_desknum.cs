using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 桌号
	/// </summary>
	[Serializable]
	public partial class wx_diancai_desknum
	{
		public wx_diancai_desknum()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private int _sortid;
		private string _deskname;
		private bool _isstart;
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
		/// 商家编号
		/// </summary>
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 顺序号
		/// </summary>
		public int sortid
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 桌号名称
		/// </summary>
		public string deskName
		{
			set{ _deskname=value;}
			get{return _deskname;}
		}
		/// <summary>
		/// 是否启用
		/// </summary>
		public bool isStart
		{
			set{ _isstart=value;}
			get{return _isstart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

