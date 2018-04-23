using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Utils.Drawing.Animation;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        AutoHideBar bar1;
        AutoHideBar bar2;
        public Form1()
        {
            InitializeComponent();
            bar1 = new AutoHideBar(barManager1, BarDockStyle.Top);
            bar2 =  new AutoHideBar(barManager1, BarDockStyle.Bottom);
            for (int i = 0; i < 10; i++)
            {
                bar1.AddItem(new BarButtonItem(barManager1, "Test"));
                bar2.AddItem(new BarButtonItem(barManager1, "Test"));
            }
         
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            bar1.HideBar();
            bar2.HideBar();
        }
    }
}