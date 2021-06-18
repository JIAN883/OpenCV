
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
            this.trackBar_d0 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label_d0 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_n = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_n)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_d0)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(947, 626);
            this.splitContainer1.SplitterDistance = 305;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxHighPass, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxLowPass, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_n, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_d0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_d0, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_n, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 624);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // checkBoxHighPass
            // 
            this.checkBoxHighPass.AutoSize = true;
            this.checkBoxHighPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxHighPass.Location = new System.Drawing.Point(3, 3);
            this.checkBoxHighPass.Name = "checkBoxHighPass";
            this.checkBoxHighPass.Size = new System.Drawing.Size(205, 150);
            this.checkBoxHighPass.TabIndex = 0;
            this.checkBoxHighPass.Text = "高通濾波器";
            this.checkBoxHighPass.UseVisualStyleBackColor = true;
            this.checkBoxHighPass.CheckedChanged += new System.EventHandler(this.checkBoxHighPass_CheckedChanged);
            // 
            // checkBoxLowPass
            // 
            this.checkBoxLowPass.AutoSize = true;
            this.checkBoxLowPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxLowPass.Location = new System.Drawing.Point(214, 3);
            this.checkBoxLowPass.Name = "checkBoxLowPass";
            this.checkBoxLowPass.Size = new System.Drawing.Size(205, 150);
            this.checkBoxLowPass.TabIndex = 1;
            this.checkBoxLowPass.Text = "低通濾波器";
            this.checkBoxLowPass.UseVisualStyleBackColor = true;
            this.checkBoxLowPass.CheckedChanged += new System.EventHandler(this.checkBoxLowPass_CheckedChanged);
            // 
            // button1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 3);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 471);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(630, 150);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar_n
            // 
            this.trackBar_n.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_n.Location = new System.Drawing.Point(3, 315);
            this.trackBar_n.Maximum = 1000;
            this.trackBar_n.Name = "trackBar_n";
            this.trackBar_n.Size = new System.Drawing.Size(205, 150);
            this.trackBar_n.TabIndex = 6;
            this.trackBar_n.Scroll += new System.EventHandler(this.trackBar_n_Scroll);
            this.trackBar_n.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_d0_MouseUp);
            // 
            // trackBar_d0
            // 
            this.trackBar_d0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_d0.Location = new System.Drawing.Point(3, 159);
            this.trackBar_d0.Maximum = 1000;
            this.trackBar_d0.Name = "trackBar_d0";
            this.trackBar_d0.Size = new System.Drawing.Size(205, 150);
            this.trackBar_d0.TabIndex = 8;
            this.trackBar_d0.Scroll += new System.EventHandler(this.trackBar2_d0_Scroll);
            this.trackBar_d0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_d0_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(214, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 156);
            this.label1.TabIndex = 10;
            this.label1.Text = "d0：影響大小參數 \r\n整數，>=0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_d0
            // 
            this.label_d0.AutoSize = true;
            this.label_d0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_d0.Location = new System.Drawing.Point(425, 156);
            this.label_d0.Name = "label_d0";
            this.label_d0.Size = new System.Drawing.Size(208, 156);
            this.label_d0.TabIndex = 11;
            this.label_d0.Text = "label2";
            this.label_d0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(214, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 156);
            this.label3.TabIndex = 12;
            this.label3.Text = "n：影響大小參數 \r\n浮點數，>=1\r\n1->不變，動一些就差很多";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_n
            // 
            this.label_n.AutoSize = true;
            this.label_n.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_n.Location = new System.Drawing.Point(425, 312);
            this.label_n.Name = "label_n";
            this.label_n.Size = new System.Drawing.Size(208, 156);
            this.label_n.TabIndex = 13;
            this.label_n.Text = "label4";
            this.label_n.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(303, 624);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "濾波後資訊";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 598);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ButterworthPassFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 626);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ButterworthPassFilterForm";
            this.Text = "ButterworthPassFilterForm";
            this.Load += new System.EventHandler(this.ButterworthPassFilterForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_n)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_d0)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxHighPass;
        private System.Windows.Forms.CheckBox checkBoxLowPass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar_n;
        private System.Windows.Forms.TrackBar trackBar_d0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_d0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_n;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}