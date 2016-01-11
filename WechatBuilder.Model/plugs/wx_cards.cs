using System;
namespace WechatBuilder.Model
{
	/// <summary>
	/// 数据表1
	/// </summary>
	[Serializable]
	public partial class wx_cards
	{
		public wx_cards()
		{}
		#region Model
		private int _id;
		private int? _wid;
		private string _openid;
		private string _title;
		private string _backpic;
		private string _backmusic;
		private string _backcartoon;
		private string _characters;
		private string _copyright;
		private string _buttoncharacter;
		private bool _display;
		private string _name;
		private string _url;
		private int? _ckcount;
		private int? _zfcount;
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
		/// 关联编号
		/// </summary>
		public int? wid
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 标题名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 背景图片
		/// </summary>
		public string backPic
		{
			set{ _backpic=value;}
			get{return _backpic;}
		}
		/// <summary>
		/// 背景音乐
		/// </summary>
		public string backMusic
		{
			set{ _backmusic=value;}
			get{return _backmusic;}
		}
		/// <summary>
		/// 背景动画
		/// </summary>
		public string backCartoon
		{
			set{ _backcartoon=value;}
			get{return _backcartoon;}
		}
		/// <summary>
		/// 默认文字
		/// </summary>
		public string characters
		{
			set{ _characters=value;}
			get{return _characters;}
		}
		/// <summary>
		/// 版权
		/// </summary>
		public string copyRight
		{
			set{ _copyright=value;}
			get{return _copyright;}
		}
		/// <summary>
		/// 按钮文字
		/// </summary>
		public string buttonCharacter
		{
			set{ _buttoncharacter=value;}
			get{return _buttoncharacter;}
		}
		/// <summary>
		/// 是否显示转发数 是否显示转发数
		/// </summary>
		public bool display
		{
			set{ _display=value;}
			get{return _display;}
		}
		/// <summary>
		/// 默认名字
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 点击礼品外链地址
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 查看次数
		/// </summary>
		public int? ckCount
		{
			set{ _ckcount=value;}
			get{return _ckcount;}
		}
		/// <summary>
		/// 转发次数
		/// </summary>
		public int? zfCount
		{
			set{ _zfcount=value;}
			get{return _zfcount;}
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

