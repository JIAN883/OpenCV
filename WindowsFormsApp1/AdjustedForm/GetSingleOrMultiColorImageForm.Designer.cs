
namespace WindowsFormsApp1.AdjustedForm
{
    partial class GetSingleOrMultiColorImageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_R = new System.Windows.Forms.CheckBox();
            this.checkBox_G = new System.Windows.Forms.CheckBox();
            this.checkBox_B = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton_C = new System.Windows.Forms.RadioButton();
            this.radioButton_M = new System.Windows.Forms.RadioButton();
            this.radioButton_Y = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(985, 600);
            this.splitContainer1.SplitterDistance = 468;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(513, 600);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(505, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BGR";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_R, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_G, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_B, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 565);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(252, 3);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 3);
            this.button1.Size = new System.Drawing.Size(244, 559);
            this.button1.TabIndex = 3;
            this.button1.Text = "查看原圖";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_R
            // 
            this.checkBox_R.AutoSize = true;
            this.checkBox_R.Checked = true;
            this.checkBox_R.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_R.Location = new System.Drawing.Point(3, 3);
            this.checkBox_R.Name = "checkBox_R";
            this.checkBox_R.Size = new System.Drawing.Size(243, 182);
            this.checkBox_R.TabIndex = 4;
            this.checkBox_R.Text = "R";
            this.checkBox_R.UseVisualStyleBackColor = true;
            this.checkBox_R.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox_G
            // 
            this.checkBox_G.AutoSize = true;
            this.checkBox_G.Checked = true;
            this.checkBox_G.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_G.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_G.Location = new System.Drawing.Point(3, 191);
            this.checkBox_G.Name = "checkBox_G";
            this.checkBox_G.Size = new System.Drawing.Size(243, 182);
            this.checkBox_G.TabIndex = 5;
            this.checkBox_G.Text = "G";
            this.checkBox_G.UseVisualStyleBackColor = true;
            this.checkBox_G.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox_B
            // 
            this.checkBox_B.AutoSize = true;
            this.checkBox_B.Checked = true;
            this.checkBox_B.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_B.Location = new System.Drawing.Point(3, 379);
            this.checkBox_B.Name = "checkBox_B";
            this.checkBox_B.Size = new System.Drawing.Size(243, 183);
            this.checkBox_B.TabIndex = 6;
            this.checkBox_B.Text = "B";
            this.checkBox_B.UseVisualStyleBackColor = true;
            this.checkBox_B.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(505, 579);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CMY";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButton_C, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButton_M, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.radioButton_Y, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(499, 573);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(252, 3);
            this.button2.Name = "button2";
            this.tableLayoutPanel2.SetRowSpan(this.button2, 3);
            this.button2.Size = new System.Drawing.Size(244, 567);
            this.button2.TabIndex = 3;
            this.button2.Text = "查看原圖";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // radioButton_C
            // 
            this.radioButton_C.AutoSize = true;
            this.radioButton_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_C.Location = new System.Drawing.Point(3, 3);
            this.radioButton_C.Name = "radioButton_C";
            this.radioButton_C.Size = new System.Drawing.Size(243, 185);
            this.radioButton_C.TabIndex = 4;
            this.radioButton_C.TabStop = true;
            this.radioButton_C.Text = "C";
            this.radioButton_C.UseVisualStyleBackColor = true;
            this.radioButton_C.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButton_M
            // 
            this.radioButton_M.AutoSize = true;
            this.radioButton_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_M.Location = new System.Drawing.Point(3, 194);
            this.radioButton_M.Name = "radioButton_M";
            this.radioButton_M.Size = new System.Drawing.Size(243, 185);
            this.radioButton_M.TabIndex = 5;
            this.radioButton_M.TabStop = true;
            this.radioButton_M.Text = "M";
            this.radioButton_M.UseVisualStyleBackColor = true;
            this.radioButton_M.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButton_Y
            // 
            this.radioButton_Y.AutoSize = true;
            this.radioButton_Y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_Y.Location = new System.Drawing.Point(3, 385);
            this.radioButton_Y.Name = "radioButton_Y";
            this.radioButton_Y.Size = new System.Drawing.Size(243, 185);
            this.radioButton_Y.TabIndex = 6;
            this.radioButton_Y.TabStop = true;
            this.radioButton_Y.Text = "Y";
            this.radioButton_Y.UseVisualStyleBackColor = true;
            this.radioButton_Y.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // GetSingleOrMultiColorImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 600);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GetSingleOrMultiColorImageForm";
            this.Text = "GetSingleOrMultiColorImageForm";
            this.Load += new System.EventHandler(this.GetSingleOrMultiColorImageForm_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton_C;
        private System.Windows.Forms.RadioButton radioButton_M;
        private System.Windows.Forms.RadioButton radioButton_Y;
        private System.Windows.Forms.CheckBox checkBox_R;
        private System.Windows.Forms.CheckBox checkBox_G;
        private System.Windows.Forms.CheckBox checkBox_B;
    }
}