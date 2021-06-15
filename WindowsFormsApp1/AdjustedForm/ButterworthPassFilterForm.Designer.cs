
namespace WindowsFormsApp1.AdjustedForm
{
    partial class ButterworthPassFilterForm
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
            this.checkBoxHighPass = new System.Windows.Forms.CheckBox();
            this.checkBoxLowPass = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar_n = new System.Windows.Forms.TrackBar();
            this.textBox_n = new System.Windows.Forms.TextBox();
            this.trackBar_d0 = new System.Windows.Forms.TrackBar();
            this.textBox_d0 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_n)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_d0)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(952, 640);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxHighPass, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxLowPass, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_n, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_n, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_d0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_d0, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(641, 640);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // checkBoxHighPass
            // 
            this.checkBoxHighPass.AutoSize = true;
            this.checkBoxHighPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxHighPass.Location = new System.Drawing.Point(3, 3);
            this.checkBoxHighPass.Name = "checkBoxHighPass";
            this.checkBoxHighPass.Size = new System.Drawing.Size(314, 154);
            this.checkBoxHighPass.TabIndex = 0;
            this.checkBoxHighPass.Text = "高通濾波器";
            this.checkBoxHighPass.UseVisualStyleBackColor = true;
            this.checkBoxHighPass.CheckedChanged += new System.EventHandler(this.checkBoxHighPass_CheckedChanged);
            // 
            // checkBoxLowPass
            // 
            this.checkBoxLowPass.AutoSize = true;
            this.checkBoxLowPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxLowPass.Location = new System.Drawing.Point(323, 3);
            this.checkBoxLowPass.Name = "checkBoxLowPass";
            this.checkBoxLowPass.Size = new System.Drawing.Size(315, 154);
            this.checkBoxLowPass.TabIndex = 1;
            this.checkBoxLowPass.Text = "低通濾波器";
            this.checkBoxLowPass.UseVisualStyleBackColor = true;
            this.checkBoxLowPass.CheckedChanged += new System.EventHandler(this.checkBoxLowPass_CheckedChanged);
            // 
            // button1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(635, 154);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar_n
            // 
            this.trackBar_n.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_n.Location = new System.Drawing.Point(3, 323);
            this.trackBar_n.Name = "trackBar_n";
            this.trackBar_n.Size = new System.Drawing.Size(314, 154);
            this.trackBar_n.TabIndex = 6;
            this.trackBar_n.Scroll += new System.EventHandler(this.trackBar_n_Scroll);
            // 
            // textBox_n
            // 
            this.textBox_n.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_n.Location = new System.Drawing.Point(323, 323);
            this.textBox_n.Name = "textBox_n";
            this.textBox_n.Size = new System.Drawing.Size(315, 25);
            this.textBox_n.TabIndex = 7;
            this.textBox_n.TextChanged += new System.EventHandler(this.textBox1_n_TextChanged);
            // 
            // trackBar_d0
            // 
            this.trackBar_d0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_d0.Location = new System.Drawing.Point(3, 163);
            this.trackBar_d0.Name = "trackBar_d0";
            this.trackBar_d0.Size = new System.Drawing.Size(314, 154);
            this.trackBar_d0.TabIndex = 8;
            this.trackBar_d0.Scroll += new System.EventHandler(this.trackBar2_d0_Scroll);
            // 
            // textBox_d0
            // 
            this.textBox_d0.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_d0.Location = new System.Drawing.Point(323, 163);
            this.textBox_d0.Name = "textBox_d0";
            this.textBox_d0.Size = new System.Drawing.Size(315, 25);
            this.textBox_d0.TabIndex = 9;
            this.textBox_d0.TextChanged += new System.EventHandler(this.textBox2_d0_TextChanged);
            // 
            // ButterworthPassFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 640);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ButterworthPassFilterForm";
            this.Text = "ButterworthPassFilterForm";
            this.Load += new System.EventHandler(this.ButterworthPassFilterForm_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_n)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_d0)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxHighPass;
        private System.Windows.Forms.CheckBox checkBoxLowPass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar_n;
        private System.Windows.Forms.TextBox textBox_n;
        private System.Windows.Forms.TrackBar trackBar_d0;
        private System.Windows.Forms.TextBox textBox_d0;
    }
}