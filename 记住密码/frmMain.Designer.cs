namespace 记住密码
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.combox1 = new System.Windows.Forms.ComboBox();
            this.chkcaes = new System.Windows.Forms.CheckBox();
            this.butOK = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "密  码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(84, 55);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(192, 21);
            this.txtPwd.TabIndex = 1;
            // 
            // combox1
            // 
            this.combox1.FormattingEnabled = true;
            this.combox1.Location = new System.Drawing.Point(84, 29);
            this.combox1.Name = "combox1";
            this.combox1.Size = new System.Drawing.Size(192, 20);
            this.combox1.TabIndex = 0;
            this.combox1.SelectedIndexChanged += new System.EventHandler(this.combox1_SelectedIndexChanged);
            this.combox1.TextChanged += new System.EventHandler(this.combox1_TextChanged);
            // 
            // chkcaes
            // 
            this.chkcaes.AutoSize = true;
            this.chkcaes.Location = new System.Drawing.Point(204, 87);
            this.chkcaes.Name = "chkcaes";
            this.chkcaes.Size = new System.Drawing.Size(72, 16);
            this.chkcaes.TabIndex = 2;
            this.chkcaes.Text = "记住密码";
            this.chkcaes.UseVisualStyleBackColor = true;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(84, 125);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(80, 23);
            this.butOK.TabIndex = 3;
            this.butOK.Text = "确认";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(193, 125);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(83, 23);
            this.butclose.TabIndex = 4;
            this.butclose.Text = "取消";
            this.butclose.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(303, 179);
            this.Controls.Add(this.butclose);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.chkcaes);
            this.Controls.Add(this.combox1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "密码保存";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.ComboBox combox1;
        private System.Windows.Forms.CheckBox chkcaes;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butclose;
    }
}

