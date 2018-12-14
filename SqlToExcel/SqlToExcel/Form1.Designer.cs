namespace SqlToExcel
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.clbTableName = new System.Windows.Forms.CheckedListBox();
            this.tbsqlText = new System.Windows.Forms.TextBox();
            this.cbDataName = new System.Windows.Forms.ComboBox();
            this.btndisCon = new System.Windows.Forms.Button();
            this.btnCon = new System.Windows.Forms.Button();
            this.Pwd = new System.Windows.Forms.TextBox();
            this.UID = new System.Windows.Forms.TextBox();
            this.textServer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lbwarn = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbExcelAdr = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbExcelName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sqlall = new System.Windows.Forms.RadioButton();
            this.sqlselcet = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.clbTableName);
            this.groupBox1.Controls.Add(this.tbsqlText);
            this.groupBox1.Controls.Add(this.cbDataName);
            this.groupBox1.Controls.Add(this.btndisCon);
            this.groupBox1.Controls.Add(this.btnCon);
            this.groupBox1.Controls.Add(this.Pwd);
            this.groupBox1.Controls.Add(this.UID);
            this.groupBox1.Controls.Add(this.textServer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 406);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库连接";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(114, 334);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "全选";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // clbTableName
            // 
            this.clbTableName.FormattingEnabled = true;
            this.clbTableName.Location = new System.Drawing.Point(114, 232);
            this.clbTableName.Name = "clbTableName";
            this.clbTableName.Size = new System.Drawing.Size(234, 100);
            this.clbTableName.TabIndex = 5;
            // 
            // tbsqlText
            // 
            this.tbsqlText.Enabled = false;
            this.tbsqlText.Location = new System.Drawing.Point(114, 361);
            this.tbsqlText.Multiline = true;
            this.tbsqlText.Name = "tbsqlText";
            this.tbsqlText.Size = new System.Drawing.Size(234, 21);
            this.tbsqlText.TabIndex = 3;
            this.tbsqlText.Text = "数据库导出不需要输入sql语句";
            this.tbsqlText.Enter += new System.EventHandler(this.tbsqlText_Enter);
            // 
            // cbDataName
            // 
            this.cbDataName.FormattingEnabled = true;
            this.cbDataName.Location = new System.Drawing.Point(114, 206);
            this.cbDataName.Name = "cbDataName";
            this.cbDataName.Size = new System.Drawing.Size(204, 20);
            this.cbDataName.TabIndex = 4;
            this.cbDataName.SelectedIndexChanged += new System.EventHandler(this.cbDataName_SelectedIndexChanged);
            // 
            // btndisCon
            // 
            this.btndisCon.Location = new System.Drawing.Point(259, 158);
            this.btndisCon.Name = "btndisCon";
            this.btndisCon.Size = new System.Drawing.Size(89, 33);
            this.btndisCon.TabIndex = 3;
            this.btndisCon.Text = "断开";
            this.btndisCon.UseVisualStyleBackColor = true;
            this.btndisCon.Click += new System.EventHandler(this.btndisCon_Click);
            // 
            // btnCon
            // 
            this.btnCon.Location = new System.Drawing.Point(94, 158);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(89, 33);
            this.btnCon.TabIndex = 3;
            this.btnCon.Text = "连接";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // Pwd
            // 
            this.Pwd.Location = new System.Drawing.Point(114, 131);
            this.Pwd.Name = "Pwd";
            this.Pwd.PasswordChar = '*';
            this.Pwd.ReadOnly = true;
            this.Pwd.Size = new System.Drawing.Size(234, 21);
            this.Pwd.TabIndex = 2;
            this.Pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pwd_KeyDown);
            // 
            // UID
            // 
            this.UID.Location = new System.Drawing.Point(114, 93);
            this.UID.Name = "UID";
            this.UID.ReadOnly = true;
            this.UID.Size = new System.Drawing.Size(234, 21);
            this.UID.TabIndex = 2;
            // 
            // textServer
            // 
            this.textServer.Location = new System.Drawing.Point(114, 30);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(234, 21);
            this.textServer.TabIndex = 2;
            this.textServer.Text = "(local)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "sql语句：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "选择数据库表：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "数据库名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器名称：";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(253, 62);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(107, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "Sql server验证";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton2_MouseClick);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(69, 62);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Windows验证";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.radioButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseClick);
            // 
            // lbwarn
            // 
            this.lbwarn.AutoSize = true;
            this.lbwarn.Location = new System.Drawing.Point(49, 39);
            this.lbwarn.Name = "lbwarn";
            this.lbwarn.Size = new System.Drawing.Size(0, 12);
            this.lbwarn.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "选择Excel存储路径：";
            // 
            // tbExcelAdr
            // 
            this.tbExcelAdr.Location = new System.Drawing.Point(131, 15);
            this.tbExcelAdr.Multiline = true;
            this.tbExcelAdr.Name = "tbExcelAdr";
            this.tbExcelAdr.Size = new System.Drawing.Size(167, 21);
            this.tbExcelAdr.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(8, 61);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(357, 33);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始导出";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(301, 13);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "浏览";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "输入Excel名称：";
            // 
            // tbExcelName
            // 
            this.tbExcelName.Enabled = false;
            this.tbExcelName.Location = new System.Drawing.Point(131, 64);
            this.tbExcelName.Multiline = true;
            this.tbExcelName.Name = "tbExcelName";
            this.tbExcelName.Size = new System.Drawing.Size(234, 21);
            this.tbExcelName.TabIndex = 2;
            this.tbExcelName.Text = "数据库导出不需要输入Excel名称";
            this.tbExcelName.Enter += new System.EventHandler(this.tbExcelName_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnOpen);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbExcelAdr);
            this.groupBox2.Controls.Add(this.tbExcelName);
            this.groupBox2.Location = new System.Drawing.Point(12, 424);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 102);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "sql信息";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbwarn);
            this.groupBox3.Controls.Add(this.sqlall);
            this.groupBox3.Controls.Add(this.sqlselcet);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Location = new System.Drawing.Point(12, 532);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "主操作";
            // 
            // sqlall
            // 
            this.sqlall.AutoSize = true;
            this.sqlall.Checked = true;
            this.sqlall.Location = new System.Drawing.Point(51, 20);
            this.sqlall.Name = "sqlall";
            this.sqlall.Size = new System.Drawing.Size(95, 16);
            this.sqlall.TabIndex = 4;
            this.sqlall.TabStop = true;
            this.sqlall.Text = "数据库表导出";
            this.sqlall.UseVisualStyleBackColor = true;
            this.sqlall.CheckedChanged += new System.EventHandler(this.sqlall_CheckedChanged);
            // 
            // sqlselcet
            // 
            this.sqlselcet.AutoSize = true;
            this.sqlselcet.Location = new System.Drawing.Point(253, 20);
            this.sqlselcet.Name = "sqlselcet";
            this.sqlselcet.Size = new System.Drawing.Size(89, 16);
            this.sqlselcet.TabIndex = 4;
            this.sqlselcet.Text = "sql查询导出";
            this.sqlselcet.UseVisualStyleBackColor = true;
            this.sqlselcet.CheckedChanged += new System.EventHandler(this.sqlselcet_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 641);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SqlToExcel";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbTableName;
        private System.Windows.Forms.ComboBox cbDataName;
        private System.Windows.Forms.Button btndisCon;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.TextBox Pwd;
        private System.Windows.Forms.TextBox UID;
        private System.Windows.Forms.TextBox textServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbExcelAdr;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lbwarn;
        private System.Windows.Forms.TextBox tbsqlText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbExcelName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton sqlall;
        private System.Windows.Forms.RadioButton sqlselcet;
    }
}

