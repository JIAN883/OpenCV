
namespace WindowsFormsApp1.AdjustedForm
{
    partial class IdealOrGaussianPassFilterForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxIdeal = new System.Windows.Forms.CheckBox();
            this.checkBoxGaussian = new System.Windows.Forms.CheckBox();
            this.checkBoxHighPass = new System.Windows.Forms.CheckBox();
            this.checkBoxLowPass = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1267, 604);
            this.splitContainer1.SplitterDistance = 409;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIdeal, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxGaussian, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxHighPass, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxLowPass, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(854, 604);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // checkBoxIdeal
            // 
            this.checkBoxIdeal.AutoSize = true;
            this.checkBoxIdeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxIdeal.Location = new System.Drawing.Point(3, 3);
            this.checkBoxIdeal.Name = "checkBoxIdeal";
            this.checkBoxIdeal.Size = new System.Drawing.Size(421, 145);
            this.checkBoxIdeal.TabIndex = 0;
            this.checkBoxIdeal.Text = "理想濾波器";
            this.checkBoxIdeal.UseVisualStyleBackColor = true;
            this.checkBoxIdeal.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxGaussian
            // 
            this.checkBoxGaussian.AutoSize = true;
            this.checkBoxGaussian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxGaussian.Location = new System.Drawing.Point(430, 3);
            this.checkBoxGaussian.Name = "checkBoxGaussian";
            this.checkBoxGaussian.Size = new System.Drawing.Size(421, 145);
            this.checkBoxGaussian.TabIndex = 1;
            this.checkBoxGaussian.Text = "高斯濾波器";
            this.checkBoxGaussian.UseVisualStyleBackColor = true;
            this.checkBoxGaussian.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBoxHighPass
            // 
            this.checkBoxHighPass.AutoSize = true;
            this.checkBoxHighPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxHighPass.Location = new System.Drawing.Point(3, 154);
            this.checkBoxHighPass.Name = "checkBoxHighPass";
            this.checkBoxHighPass.Size = new System.Drawing.Size(421, 145);
            this.checkBoxHighPass.TabIndex = 2;
            this.checkBoxHighPass.Text = "高通";
            this.checkBoxHighPass.UseVisualStyleBackColor = true;
            this.checkBoxHighPass.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBoxLowPass
            // 
            this.checkBoxLowPass.AutoSize = true;
            this.checkBoxLowPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxLowPass.Location = new System.Drawing.Point(430, 154);
            this.checkBoxLowPass.Name = "checkBoxLowPass";
            this.checkBoxLowPass.Size = new System.Drawing.Size(421, 145);
            this.checkBoxLowPass.TabIndex = 3;
            this.checkBoxLowPass.Text = "低通";
            this.checkBoxLowPass.UseVisualStyleBackColor = true;
            this.checkBoxLowPass.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // button1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(848, 145);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Location = new System.Drawing.Point(3, 305);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(421, 145);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(430, 305);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(421, 25);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // IdealOrGaussianPassFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 604);
            this.Controls.Add(this.splitContainer1);
            this.Name = "IdealOrGaussianPassFilterForm";
            this.Text = "IdealOrGaussianPassFilterForm";
            this.Load += new System.EventHandler(this.IdealOrGaussianPassFilterForm_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxIdeal;
        private System.Windows.Forms.CheckBox checkBoxGaussian;
        private System.Windows.Forms.CheckBox checkBoxHighPass;
        private System.Windows.Forms.CheckBox checkBoxLowPass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox1;
    }
}