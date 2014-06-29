using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;

namespace Jiaowu
{
    public partial class Form1 : Form
    {
        JWManagerPJ jw = new JWManagerPJ();
        public Form1()
        {
            InitializeComponent();
            RadioEntrance1.Select();
        }
        private void init(JWManagerPJ.LoginMode loginmode)
        {
            
            jw.setLoginMode(loginmode);
            pbcode.Image = jw.getCheckCode();
            status.Text = "请登录";
        }
        private void pbcode_Click(object sender, EventArgs e)
        {
            pbcode.Image = jw.getCheckCode();
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            string html = "";
            bool flag = jw.login(tbuser.Text, tbpwd.Text, tbcode.Text, ref html);

            if (flag == false)
            {
                MessageBox.Show("登陆失败");
            }
            else
            {
                MessageBox.Show("登陆成功");
                this.Hide();
                Form2 form2 = new Form2(jw,this);
                form2.Show();
            }
        }

        private void RadioEntrance1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton bt = sender as RadioButton;

            if (bt.Name == RadioEntrance1.Name)
            {
                JWUrl.changeHost(JWUrl.Host1);
                init(JWManagerPJ.LoginMode.UNITED_AUTHORITY);
            }
            if (bt.Name == RadioEntrance2.Name)
            {
                JWUrl.changeHost(JWUrl.Host2);
                init(JWManagerPJ.LoginMode.UNITED_AUTHORITY);
            }
            if (bt.Name == RadioEntrance3.Name)
            {
                JWUrl.changeHost(JWUrl.Host1);
                init(JWManagerPJ.LoginMode.NORMAL);
            }
            if (bt.Name == RadioEntrance4.Name)
            {
                JWUrl.changeHost(JWUrl.Host2);
                init(JWManagerPJ.LoginMode.NORMAL);
            }
        }


    }
}
