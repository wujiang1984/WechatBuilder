using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WechatBuilder.Common;

namespace WechatBuilder.Web.admin.settings
{
    public partial class plugin_list : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("app_plugin_list", MXEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        #region 插件列表绑定==============================
        private void RptBind()
        {
            List<Model.plugin> lt = new List<Model.plugin>();
            BLL.plugin bll = new BLL.plugin();

            this.rptList.DataSource = bll.GetList(Utils.GetMapPath("../../plugins/"));
            this.rptList.DataBind();
        }
        #endregion

        #region 删除生成的ASPX文件========================
        private void RemoveTemplates(string dirName)
        {
            //插件目录
            string pluginPath = Utils.GetMapPath("../../plugins/" + dirName + "/" + MXKeys.FILE_PLUGIN_XML_CONFING);
            XmlNodeList xnList = XmlHelper.ReadNodes(pluginPath, "plugin/urls");
            if (xnList.Count > 0)
            {
                foreach (XmlElement xe in xnList)
                {
                    if (xe.NodeType != XmlNodeType.Comment && xe.Name.ToLower() == "rewrite" && xe.Attributes["page"] != null)
                    {
                        if (xe.Attributes["name"] != null && xe.Attributes["type"] != null)
                        {
                            //删除站点下的aspx文件
                            Utils.DeleteFile(siteConfig.webpath + "aspx/" + MXKeys.DIRECTORY_REWRITE_PLUGIN + "/" + xe.Attributes["page"].Value);
                        }
                    }
                }
            }
        }
        #endregion

        //安装插件
        protected void lbtnInstall_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("app_plugin_list", MXEnums.ActionEnum.Instal.ToString()); //检查权限
            //插件目录
            string pluginPath = Utils.GetMapPath("../../plugins/");
            BLL.plugin bll = new BLL.plugin();
            //查找列表
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string currDirName = ((HiddenField)rptList.Items[i].FindControl("hidDirName")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //是否未安装
                    Model.plugin model = bll.GetInfo(pluginPath + currDirName + @"\");
                    if (model.isload == 0)
                    {
                        //安装DLL
                        string currPath = pluginPath + currDirName + @"\bin\";
                        if (Directory.Exists(currPath))
                        {
                            string[] file = Directory.GetFiles(currPath);
                            foreach (string f in file)
                            {
                                FileInfo info = new FileInfo(f);
                                //复制DLL文件
                                if (info.Extension.ToLower() == ".dll")
                                {
                                    //移动到站点目录下
                                    string newFile = Utils.GetMapPath(siteConfig.webpath + @"bin\" + info.Name);
                                    File.Copy(info.FullName, newFile, true);
                                }
                            }
                        }
                        //执行SQL语句
                        bll.ExeSqlStr(pluginPath + currDirName + @"\", @"plugin/install");
                        //添加URL映射
                        bll.AppendNodes(pluginPath + currDirName + @"\", @"plugin/urls");
                        //添加后台导航记录
                        bll.AppendMenuNodes(string.Format("{0}plugins/{1}/", siteConfig.webpath, currDirName), pluginPath + currDirName + @"\", @"plugin/menu", "sys_plugins");
                        //生成模板
                        bll.MarkTemplet(siteConfig.webpath, "plugins/" + currDirName, "templet", pluginPath + currDirName + @"\", @"plugin/urls");
                        //修改plugins节点
                        bll.UpdateNodeValue(pluginPath + currDirName + @"\", @"plugin/isload", "1");
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Instal.ToString(), "安装插件"); //记录日志
            JscriptMsg("插件安装成功！", "plugin_list.aspx", "Success", "parent.loadMenuTree");

        }

        //卸载插件
        protected void lbtnUnInstall_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("app_plugin_list", MXEnums.ActionEnum.UnLoad.ToString()); //检查权限
            //插件目录
            string pluginPath = Utils.GetMapPath("../../plugins/");
            BLL.plugin bll = new BLL.plugin();
            //查找列表
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string currDirName = ((HiddenField)rptList.Items[i].FindControl("hidDirName")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //是否已安装
                    Model.plugin model = bll.GetInfo(pluginPath + currDirName + @"\");
                    if (model.isload == 1)
                    {
                        string currPath = pluginPath + currDirName + @"/bin/";
                        if (Directory.Exists(currPath))
                        {
                            string[] file = Directory.GetFiles(currPath);
                            foreach (string f in file)
                            {
                                FileInfo info = new FileInfo(f);
                                //复制DLL文件
                                if (info.Extension.ToLower() == ".dll")
                                {
                                    //删除站点目录下DLL文件
                                    string newFile = Utils.GetMapPath(siteConfig.webpath + @"bin/" + info.Name);
                                    if (File.Exists(newFile))
                                    {
                                        File.Delete(newFile);
                                    }
                                }
                            }

                        }
                        //执行SQL语句
                        bll.ExeSqlStr(pluginPath + currDirName + @"\", @"plugin/uninstall");
                        //删除URL映射
                        bll.RemoveNodes(pluginPath + currDirName + @"\", @"plugin/urls");
                        //删除后台导航记录
                        bll.RemoveMenuNodes(pluginPath + currDirName + @"\", @"plugin/menu");
                        //删除站点目录下的aspx文件
                        RemoveTemplates(currDirName);
                        //修改plugins节点
                        bll.UpdateNodeValue(pluginPath + currDirName + @"\", @"plugin/isload", "0");
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.UnLoad.ToString(), "卸载插件"); //记录日志
            JscriptMsg("插件卸载成功！", "plugin_list.aspx", "Success", "parent.loadMenuTree");

        }

        //生成模板
        protected void lbtnRemark_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("app_plugin_list", MXEnums.ActionEnum.Build.ToString()); //检查权限
            //插件目录
            string pluginPath = Utils.GetMapPath("../../plugins/");
            BLL.plugin bll = new BLL.plugin();
            //查找列表
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string currDirName = ((HiddenField)rptList.Items[i].FindControl("hidDirName")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    //是否安装
                    Model.plugin model = bll.GetInfo(pluginPath + currDirName + @"\");
                    if (model.isload == 1)
                    {
                        //生成模板
                        bll.MarkTemplet(siteConfig.webpath, "plugins/" + currDirName, "templet", pluginPath + currDirName + @"\", @"plugin/urls");
                    }
                    else
                    {
                        JscriptMsg("该插件尚未安装！", "plugin_list.aspx", "Error");
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Build.ToString(), "生成插件模板"); //记录日志
            JscriptMsg("生成模板成功！", "plugin_list.aspx", "Success");
        }
    }
}