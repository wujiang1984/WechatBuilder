using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WechatBuilder.Templates
{
   public  class GeneralFun
    {
        /// <summary>
        /// 读取HTML文件内容
        /// </summary>
        /// <param name="Path">物理路径</param>
        /// <returns></returns>
        public static string ReadHtml(string Path)
        {
            string result = string.Empty;
            if (File.Exists(Path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(Path))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                catch
                { }
            }
            else
            {
                result = "模板不存在!";
            }
            return result;
        }

        /// <summary>
        /// 写HTML文件
        /// </summary>
        /// <param name="Content">内容</param>
        /// <param name="FilePath">物理路径</param>
        public static void WriteHtml(string Content, string FilePath)
        {

            string getContent = "";
           
            try
            {
                string Dir = FilePath.Substring(0, FilePath.LastIndexOf("\\"));
                if (!Directory.Exists(Dir))
                    Directory.CreateDirectory(Dir);
                using (StreamWriter sw = new StreamWriter(FilePath, false))
                {
                    getContent = Content;
                    sw.Write(getContent);
                    sw.Dispose();
                }
            }
            catch
            { }
        }


    }
}
