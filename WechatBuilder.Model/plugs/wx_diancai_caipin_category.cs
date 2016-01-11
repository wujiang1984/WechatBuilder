using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 数据表6
	/// </summary>
	[Serializable]
	public partial class wx_diancai_caipin_category
	{
		public wx_diancai_caipin_category()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private int _sortid;
		private string _categoryname;
		private string _miaoshu;
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
		/// 商家id
		/// </summary>
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int sortid
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 主分类名称
		/// </summary>
		public string categoryName
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string miaoshu
		{
			set{ _miaoshu=value;}
			get{return _miaoshu;}
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

