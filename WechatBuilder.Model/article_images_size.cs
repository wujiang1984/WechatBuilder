using System;
using System.Collections.Generic;
using System.Text;

namespace WechatBuilder.Model
{
    public class article_images_size
    {
        #region Model
        private int _id;
        private int _category_id;
        private string _height;
        private string _width;
        /// <summary>
        /// 编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 栏目编号
        /// </summary>
        public int category_id
        {
            set { _category_id = value; }
            get { return _category_id; }
        }
        /// <summary>
        /// 高度
        /// </summary>
        public string height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 宽度
        /// </summary>
        public string width
        {
            set { _width = value; }
            get { return _width; }
        }
        #endregion Model

    }
}
