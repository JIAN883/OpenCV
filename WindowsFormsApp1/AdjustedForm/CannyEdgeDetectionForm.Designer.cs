
namespace WindowsFormsApp1.AdjustedForm
{
    partial class CannyEdgeDetectionForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_upper = new System.Windows.Forms.Label();
            this.label_lower = new System.Windows.Forms.Label();
            this.trackBar_threshold2 = new System.Windows.Forms.TrackBar();
            this.trackBar_threshold1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_threshold2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_threshold1)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(726, 431);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(238, 429);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "預覽";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 403);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_upper, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_lower, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_threshold2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_threshold1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(480, 429);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 137);
            this.button2.TabIndex = 20;
            this.button2.Text = "查看原圖";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(162, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 143);
            this.label5.TabIndex = 17;
            this.label5.Text = "threshold2\r\n呼叫Canny的第二個閥值\r\n建議比率：threshold1:threshold2 = 3:1 或 2:1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(162, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 143);
            this.label6.TabIndex = 18;
            this.label6.Text = "threshold1\r\n呼叫Canny的第一個閥值";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(322, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 137);
            this.button1.TabIndex = 19;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_upper
            // 
            this.label_upper.AutoSize = true;
            this.label_upper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_upper.Location = new System.Drawing.Point(322, 143);
            this.label_upper.Name = "label_upper";
            this.label_upper.Size = new System.Drawing.Size(155, 143);
            this.label_upper.TabIndex = 21;
            this.label_upper.Text = "label1";
            this.label_upper.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_lower
            // 
            this.label_lower.AutoSize = true;
            this.label_lower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_lower.Location = new System.Drawing.Point(322, 0);
            this.label_lower.Name = "label_lower";
            this.label_lower.Size = new System.Drawing.Size(155, 143);
            this.label_lower.TabIndex = 22;
            this.label_lower.Text = "label1";
            this.label_lower.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackBar_threshold2
            // 
            this.trackBar_threshold2.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar_threshold2.Location = new System.Drawing.Point(3, 146);
            this.trackBar_threshold2.Maximum = 1000;
            this.trackBar_threshold2.Name = "trackBar_threshold2";
            this.trackBar_threshold2.Size = new System.Drawing.Size(153, 56);
            this.trackBar_threshold2.TabIndex = 23;
            this.trackBar_threshold2.Scroll += new System.EventHandler(this.trackBar_upper_Scroll);
            this.trackBar_threshold2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_upper_MouseUp);
            // 
            // trackBar_threshold1
            // 
            this.trackBar_threshold1.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar_threshold1.Location = new System.Drawing.Point(3, 3);
            this.trackBar_threshold1.Maximum = 1000;
            this.trackBar_threshold1.Name = "trackBar_threshold1";
            this.trackBar_threshold1.Size = new System.Drawing.Size(153, 56);
            this.trackBar_threshold1.TabIndex = 24;
            this.trackBar_threshold1.Scroll += new System.EventHandler(this.trackBar_lower_Scroll);
            this.trackBar_threshold1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_upper_MouseUp);
            // 
            // CannyEdgeDetectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 431);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CannyEdgeDetectionForm";
            this.Text = "CannyEdgeDetectionForm";
            this.Load += new System.EventHandler(this.CannyEdgeDetectionForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_threshold2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_threshold1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_upper;
        private System.Windows.Forms.Label label_lower;
        private System.Windows.Forms.TrackBar trackBar_threshold2;
        private System.Windows.Forms.TrackBar trackBar_threshold1;
    }
}