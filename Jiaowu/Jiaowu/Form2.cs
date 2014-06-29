using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jiaowu
{
    public partial class Form2 : Form
    {
        JWManagerPJ jw;
        CoursesPJ[] cpj;
        Form1 loginform = null;
        TeacherPJ curtpj;
        TreeNode curnode;
        bool allUploaded = true;
    
        public Form2(JWManagerPJ mjw,Form1 from1)
        {
            InitializeComponent();
            jw = mjw;
            loginform = from1;
            ca.SelectedIndex = 5;
            cb.SelectedIndex = 1;
            init();
            updateTreeView();
        }
        private void init()
        {
            cpj = jw.getCoursePJs(jw.getCoursePJHTML());
            for (int i = 0; i < cpj.Length;i++ )
            {
                jw.getTeacherInfo(ref cpj[i]);
            }
        }
        private void updateTreeView()
        {
            treeView1.Nodes.Clear();
            for (int i = 0; i < cpj.Length; i++)
            {
                CoursesPJ c = cpj[i];
                string nodename = cpj[i].name + "  " + (cpj[i].sfpj == "1" ? "已提交" : "未提交");
                TreeNode node = new TreeNode(nodename);
                node.Tag = new int[] { i, -1 };
                treeView1.Nodes.Add(node);
                for (int j = 0; j < cpj[i].teacherpj.Length; j++)
                {
                    TeacherPJ t = cpj[i].teacherpj[j];
                    nodename = (t.hasUploaded == true?"":"*")+t.name + "  " + (t.evaluation != null&&t.evaluation.Length==6 ? "评分：" + JWGeneratorPJ.convertToEvaluation(t.evaluation) : "未评价");
                    TreeNode node2 = new TreeNode(nodename);
                    node2.Tag = new int[] { i,j};
                    node.Nodes.Add(node2);
                }
            }
            treeView1.ExpandAll();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginform.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            curnode = e.Node;

            if (curnode == null || e.Node.Level == 0) return;
            int[] index = curnode.Tag as int[];
            curtpj = cpj[index[0]].teacherpj[index[1]];
            setInfo(curtpj);
            setLabel();
        }
        private void setInfo(TeacherPJ tpj)
        {
            if (tpj.evaluation != null)
            {
                cb0.SelectedIndex = (int.Parse(tpj.evaluation[0].ToString()) - 1);
                cb1.SelectedIndex = (int.Parse(tpj.evaluation[1].ToString()) - 1);
                cb2.SelectedIndex = (int.Parse(tpj.evaluation[2].ToString()) - 1);
                cb3.SelectedIndex = (int.Parse(tpj.evaluation[3].ToString()) - 1);
                cb4.SelectedIndex = (int.Parse(tpj.evaluation[4].ToString()) - 1);
                cb5.SelectedIndex = (int.Parse(tpj.evaluation[5].ToString()) - 1);
                tbpy.Text = tpj.py;
                
            }
            if (tpj.sfpj == "1" && tpj.coursepj.sfpj == "1")
            {
                cb0.Enabled = false;
                cb1.Enabled = false;
                cb2.Enabled = false;
                cb3.Enabled = false;
                cb4.Enabled = false;
                cb5.Enabled = false;
                tbpy.Enabled = false;
            }
            else
            {
                cb0.Enabled = true;
                cb1.Enabled = true;
                cb2.Enabled = true;
                cb3.Enabled = true;
                cb4.Enabled = true;
                cb5.Enabled = true;
                tbpy.Enabled = true;
            }
        }
        public void setTeacherpj(ref TeacherPJ tpj)
        {
            char[] result = new char[6];
            result[0] = Convert.ToChar(cb0.SelectedIndex - 1);
            result[1] = Convert.ToChar(cb1.SelectedIndex - 1);
            result[2] = Convert.ToChar(cb2.SelectedIndex - 1);
            result[3] = Convert.ToChar(cb3.SelectedIndex - 1);
            result[4] = Convert.ToChar(cb4.SelectedIndex - 1);
            result[5] = Convert.ToChar(cb5.SelectedIndex - 1);
            tpj.evaluation = new string(result);
            tpj.py = tbpy.Text;
            updateTreeView();
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            jw.saveTeacherPj(curtpj);
            curtpj.hasUploaded = true;
            jw.getTeacherInfo(ref curtpj.coursepj);
            updateTreeView();
        }

        private void ca_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numOfA = ca.SelectedIndex;
            int numOfB = cb.SelectedIndex;
            if (numOfA + numOfB > 6)
            {
                cc.SelectedIndex = 0;
                cb.SelectedIndex = 6 - numOfA;
            }
            else
            {
                cc.SelectedIndex = 6 - numOfA - numOfB;
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numOfA = ca.SelectedIndex;
            int numOfB = cb.SelectedIndex;
            if (numOfA + numOfB > 6)
            {
                cc.SelectedIndex = 0;
                ca.SelectedIndex = 6 - numOfB;
            }
            else
            {
                cc.SelectedIndex = 6 - numOfA - numOfB;
            }
        }

        private void btst_Click(object sender, EventArgs e)
        {
            if (curtpj.name == null) return;
            int[] a = curnode.Tag as int[];
            cpj[a[0]].teacherpj[a[1]].evaluation = JWGeneratorPJ.generator(ca.SelectedIndex, cb.SelectedIndex);
            cpj[a[0]].teacherpj[a[1]].py = "认真负责的好老师。";
            cpj[a[0]].teacherpj[a[1]].hasUploaded = false;

            if(!curnode.Text.StartsWith("*"))curnode.Text = "*" + curnode.Text;
            setInfo(cpj[a[0]].teacherpj[a[1]]);
        }

        private void btcommitallchange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cpj.Length; i++)
            {
                for (int j = 0; j < cpj[i].teacherpj.Length; j++)
                {
                    TeacherPJ t = cpj[i].teacherpj[j];
                    if (t.hasUploaded == true) continue;
                    jw.saveTeacherPj(t);
                }
            }
            init();
            updateTreeView();
        }

        private void btat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cpj.Length; i++)
            {
                for (int j = 0; j < cpj[i].teacherpj.Length; j++)
                {
                    cpj[i].teacherpj[j].evaluation = JWGeneratorPJ.generator(ca.SelectedIndex, cb.SelectedIndex);
                    cpj[i].teacherpj[j].py = "认真负责的好老师。";
                    cpj[i].teacherpj[j].hasUploaded = false;
                }
            }
            updateTreeView();
        }

        private void btsc_Click(object sender, EventArgs e)
        {
            if (curtpj.name == null) return;
            int[] a = curnode.Tag as int[];
            jw.updatePj(cpj[a[0]]);
        }
        private void setLabel()
        {
            if (curnode == null)
            {
                lbc.Text = "空";
                lbt.Text = "空";
            }
            if (curnode.Level == 0)
            {
                lbc.Text = curnode.Text;
                lbt.Text = "空";
            }
            else
            {
                lbc.Text = curnode.Parent.Text;
                lbt.Text = curnode.Text;
            }
        }
    }
}
