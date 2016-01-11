using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WechatBuilder.Model
{	/// <summary>
    /// 微信平台的图片仓库表
    /// </summary>
    [Serializable]
    public partial class wx_PicStore
    {
        public wx_PicStore()
        { }
        #region Model
        private int _id;
        private string _picname;
        private string _picuri;
        private string _pictemplates;
        private int? _pictype;
        private string _picusedtype = "栏目icon";
        private string _picvalue;
        private string _piccreateperson;
        private DateTime? _createdate;
        /// <summary>
        /// 编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string picName
        {
            set { _picname = value; }
            get { return _picname; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string picUri
        {
            set { _picuri = value; }
            get { return _picuri; }
        }
        /// <summary>
        /// 图片来源 [模版]模版1，[模版]模版2
        /// </summary>
        public string picTemplates
        {
            set { _pictemplates = value; }
            get { return _pictemplates; }
        }
        /// <summary>
        /// 图片1 或者css3-icon 2
        /// </summary>
        public int? picType
        {
            set { _pictype = value; }
            get { return _pictype; }
        }
        /// <summary>
        /// 图片使用分类
        /// </summary>
        public string picUsedType
        {
            set { _picusedtype = value; }
            get { return _picusedtype; }
        }
        /// <summary>
        /// 图片对应的值
        /// </summary>
        public string picValue
        {
            set { _picvalue = value; }
            get { return _picvalue; }
        }
        /// <summary>
        /// 图片创建者
        /// </summary>
        public string picCreatePerson
        {
            set { _piccreateperson = value; }
            get { return _piccreateperson; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model

    }
}
