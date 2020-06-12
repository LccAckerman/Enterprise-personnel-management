using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWMS
{
    public partial class F_Main : Form
    {
        //实现了导航菜单的内容
        DataClass.MyMeans MyClass = new PWMS.DataClass.MyMeans();
        ModuleClass.MyModule MyMenu = new PWMS.ModuleClass.MyModule();
        public F_Main()
        {
            InitializeComponent();
        }

        #region  通过权限对主窗体进行初始化
        /// <summary>
        /// 对主窗体初始化
        /// </summary>
        private void Preen_Main()
        {
            statusStrip1.Items[2].Text = DataClass.MyMeans.Login_Name;  //在状态栏显示当前登录的用户名
            treeView1.Nodes.Clear();
            MyMenu.GetMenu(treeView1, menuStrip1);  //调用公共类MyModule下的GetMenu()方法，将menuStrip1控件的子菜单添加到treeView1控件中
            MyMenu.MainMenuF(menuStrip1);   //将菜单栏中的各子菜单项设为不可用状态
            MyMenu.MainPope(menuStrip1, DataClass.MyMeans.Login_Name);  //根据权限设置相应子菜单的可用状态
        }
        #endregion

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
    }
}
