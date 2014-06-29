namespace Jiaowu
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbpwd = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbcode = new System.Windows.Forms.TextBox();
            this.pbcode = new System.Windows.Forms.PictureBox();
            this.tbuser = new System.Windows.Forms.TextBox();
            this.btlogin = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.status = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.RadioEntrance4 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioEntrance2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.RadioEntrance1 = new System.Windows.Forms.RadioButton();
            this.RadioEntrance3 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcode)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btlogin, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.97492F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.02508F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 351);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.75573F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.24428F));
            this.tableLayoutPanel2.Controls.Add(this.tbpwd, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.user, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pwd, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.code, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbuser, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(64, 105);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(256, 211);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tbpwd
            // 
            this.tbpwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbpwd.Location = new System.Drawing.Point(58, 99);
            this.tbpwd.Name = "tbpwd";
            this.tbpwd.Size = new System.Drawing.Size(195, 21);
            this.tbpwd.TabIndex = 5;
            this.tbpwd.Text = "326459";
            // 
            // user
            // 
            this.user.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(11, 30);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(41, 12);
            this.user.TabIndex = 0;
            this.user.Text = "用户名";
            // 
            // pwd
            // 
            this.pwd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pwd.AutoSize = true;
            this.pwd.Location = new System.Drawing.Point(23, 103);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(29, 12);
            this.pwd.TabIndex = 1;
            this.pwd.Text = "密码";
            // 
            // code
            // 
            this.code.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.code.AutoSize = true;
            this.code.Location = new System.Drawing.Point(11, 172);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(41, 12);
            this.code.TabIndex = 2;
            this.code.Text = "验证码";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.22613F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.77387F));
            this.tableLayoutPanel3.Controls.Add(this.tbcode, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pbcode, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(58, 149);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(195, 59);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // tbcode
            // 
            this.tbcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcode.Location = new System.Drawing.Point(3, 19);
            this.tbcode.Name = "tbcode";
            this.tbcode.Size = new System.Drawing.Size(82, 21);
            this.tbcode.TabIndex = 6;
            // 
            // pbcode
            // 
            this.pbcode.Location = new System.Drawing.Point(91, 3);
            this.pbcode.Name = "pbcode";
            this.pbcode.Size = new System.Drawing.Size(100, 50);
            this.pbcode.TabIndex = 0;
            this.pbcode.TabStop = false;
            this.pbcode.Click += new System.EventHandler(this.pbcode_Click);
            // 
            // tbuser
            // 
            this.tbuser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbuser.Location = new System.Drawing.Point(58, 26);
            this.tbuser.Name = "tbuser";
            this.tbuser.Size = new System.Drawing.Size(195, 21);
            this.tbuser.TabIndex = 4;
            this.tbuser.Text = "12271121";
            // 
            // btlogin
            // 
            this.btlogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btlogin.Location = new System.Drawing.Point(3, 105);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(55, 211);
            this.btlogin.TabIndex = 1;
            this.btlogin.Text = "登录";
            this.btlogin.UseVisualStyleBackColor = true;
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel4, 3);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.13705F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.86295F));
            this.tableLayoutPanel4.Controls.Add(this.progressBar, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.status, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 322);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(394, 26);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(226, 20);
            this.progressBar.TabIndex = 0;
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.status.Location = new System.Drawing.Point(235, 6);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(156, 14);
            this.status.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.RadioEntrance4, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.RadioEntrance2, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.RadioEntrance1, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.RadioEntrance3, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(64, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(256, 96);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // RadioEntrance4
            // 
            this.RadioEntrance4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RadioEntrance4.AutoSize = true;
            this.RadioEntrance4.Location = new System.Drawing.Point(165, 73);
            this.RadioEntrance4.Name = "RadioEntrance4";
            this.RadioEntrance4.Size = new System.Drawing.Size(53, 16);
            this.RadioEntrance4.TabIndex = 8;
            this.RadioEntrance4.TabStop = true;
            this.RadioEntrance4.Text = "入口4";
            this.RadioEntrance4.UseVisualStyleBackColor = true;
            this.RadioEntrance4.CheckedChanged += new System.EventHandler(this.RadioEntrance1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "直接登录";
            // 
            // RadioEntrance2
            // 
            this.RadioEntrance2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RadioEntrance2.AutoSize = true;
            this.RadioEntrance2.Location = new System.Drawing.Point(37, 73);
            this.RadioEntrance2.Name = "RadioEntrance2";
            this.RadioEntrance2.Size = new System.Drawing.Size(53, 16);
            this.RadioEntrance2.TabIndex = 6;
            this.RadioEntrance2.TabStop = true;
            this.RadioEntrance2.Text = "入口2";
            this.RadioEntrance2.UseVisualStyleBackColor = true;
            this.RadioEntrance2.CheckedChanged += new System.EventHandler(this.RadioEntrance1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "统一认证";
            // 
            // RadioEntrance1
            // 
            this.RadioEntrance1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RadioEntrance1.AutoSize = true;
            this.RadioEntrance1.Location = new System.Drawing.Point(37, 41);
            this.RadioEntrance1.Name = "RadioEntrance1";
            this.RadioEntrance1.Size = new System.Drawing.Size(53, 16);
            this.RadioEntrance1.TabIndex = 5;
            this.RadioEntrance1.TabStop = true;
            this.RadioEntrance1.Text = "入口1";
            this.RadioEntrance1.UseVisualStyleBackColor = true;
            this.RadioEntrance1.CheckedChanged += new System.EventHandler(this.RadioEntrance1_CheckedChanged);
            // 
            // RadioEntrance3
            // 
            this.RadioEntrance3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RadioEntrance3.AutoSize = true;
            this.RadioEntrance3.Location = new System.Drawing.Point(165, 41);
            this.RadioEntrance3.Name = "RadioEntrance3";
            this.RadioEntrance3.Size = new System.Drawing.Size(53, 16);
            this.RadioEntrance3.TabIndex = 7;
            this.RadioEntrance3.TabStop = true;
            this.RadioEntrance3.Text = "入口3";
            this.RadioEntrance3.UseVisualStyleBackColor = true;
            this.RadioEntrance3.CheckedChanged += new System.EventHandler(this.RadioEntrance1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 351);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcode)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbpwd;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label pwd;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox tbcode;
        private System.Windows.Forms.PictureBox pbcode;
        private System.Windows.Forms.TextBox tbuser;
        private System.Windows.Forms.Button btlogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RadioEntrance4;
        private System.Windows.Forms.RadioButton RadioEntrance3;
        private System.Windows.Forms.RadioButton RadioEntrance2;
        private System.Windows.Forms.RadioButton RadioEntrance1;


    }
}

