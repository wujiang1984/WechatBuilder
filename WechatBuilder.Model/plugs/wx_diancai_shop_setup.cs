using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 商家设置
	/// </summary>
	[Serializable]
	public partial class wx_diancai_shop_setup
	{
		public wx_diancai_shop_setup()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _unionmanage;
		private string _uniontel;
		private DateTime? _createdate;
		private int? _shopid;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 关联编号
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 招商说明
		/// </summary>
		public string unionManage
		{
			set{ _unionmanage=value;}
			get{return _unionmanage;}
		}
		/// <summary>
		/// 招商电话
		/// </summary>
		public string unionTel
		{
			set{ _uniontel=value;}
			get{return _uniontel;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 商家id
		/// </summary>
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		#endregion Model

	}
}

