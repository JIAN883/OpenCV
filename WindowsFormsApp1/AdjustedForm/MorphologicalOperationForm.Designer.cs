
namespace WindowsFormsApp1.AdjustedForm
{
    partial class MorphologicalOperationForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton_BlackHat = new System.Windows.Forms.RadioButton();
            this.radioButton_TopHat = new System.Windows.Forms.RadioButton();
            this.radioButton_Close = new System.Windows.Forms.RadioButton();
            this.radioButton_Open = new System.Windows.Forms.RadioButton();
            this.radioButton_gradient = new System.Windows.Forms.RadioButton();
            this.radioButton_Erosion = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_Dilation = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.Controls.Add(this.radioButton_BlackHat, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_TopHat, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_Close, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_Open, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_gradient, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_Erosion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_Dilation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(573, 435);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radioButton_BlackHat
            // 
            this.radioButton_BlackHat.AutoSize = true;
            this.radioButton_BlackHat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_BlackHat.Location = new System.Drawing.Point(489, 111);
            this.radioButton_BlackHat.Name = "radioButton_BlackHat";
            this.radioButton_BlackHat.Size = new System.Drawing.Size(81, 102);
            this.radioButton_BlackHat.TabIndex = 7;
            this.radioButton_BlackHat.TabStop = true;
            this.radioButton_BlackHat.Text = "Black Hat";
            this.radioButton_BlackHat.UseVisualStyleBackColor = true;
            this.radioButton_BlackHat.Click += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_TopHat
            // 
            this.radioButton_TopHat.AutoSize = true;
            this.radioButton_TopHat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_TopHat.Location = new System.Drawing.Point(408, 111);
            this.radioButton_TopHat.Name = "radioButton_TopHat";
            this.radioButton_TopHat.Size = new System.Drawing.Size(75, 102);
            this.radioButton_TopHat.TabIndex = 6;
            this.radioButton_TopHat.TabStop = true;
            this.radioButton_TopHat.Text = "Top Hat";
            this.radioButton_TopHat.UseVisualStyleBackColor = true;
            this.radioButton_TopHat.Click += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_Close
            // 
            this.radioButton_Close.AutoSize = true;
            this.radioButton_Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_Close.Location = new System.Drawing.Point(327, 111);
            this.radioButton_Close.Name = "radioButton_Close";
            this.radioButton_Close.Size = new System.Drawing.Size(75, 102);
            this.radioButton_Close.TabIndex = 5;
            this.radioButton_Close.TabStop = true;
            this.radioButton_Close.Text = "Close";
            this.radioButton_Close.UseVisualStyleBackColor = true;
            this.radioButton_Close.Click += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_Open
            // 
            this.radioButton_Open.AutoSize = true;
            this.radioButton_Open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_Open.Location = new System.Drawing.Point(246, 111);
            this.radioButton_Open.Name = "radioButton_Open";
            this.radioButton_Open.Size = new System.Drawing.Size(75, 102);
            this.radioButton_Open.TabIndex = 4;
            this.radioButton_Open.TabStop = true;
            this.radioButton_Open.Text = "Open";
            this.radioButton_Open.UseVisualStyleBackColor = true;
            this.radioButton_Open.Click += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_gradient
            // 
            this.radioButton_gradient.AutoSize = true;
            this.radioButton_gradient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_gradient.Location = new System.Drawing.Point(165, 111);
            this.radioButton_gradient.Name = "radioButton_gradient";
            this.radioButton_gradient.Size = new System.Drawing.Size(75, 102);
            this.radioButton_gradient.TabIndex = 3;
            this.radioButton_gradient.TabStop = true;
            this.radioButton_gradient.Text = "gradient";
            this.radioButton_gradient.UseVisualStyleBackColor = true;
            this.radioButton_gradient.Click += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_Erosion
            // 
            this.radioButton_Erosion.AutoSize = true;
            this.radioButton_Erosion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_Erosion.Location = new System.Drawing.Point(84, 111);
            this.radioButton_Erosion.Name = "radioButton_Erosion";
            this.radioButton_Erosion.Size = new System.Drawing.Size(75, 102);
            this.radioButton_Erosion.TabIndex = 2;
            this.radioButton_Erosion.TabStop = true;
            this.radioButton_Erosion.Text = "Erosion";
            this.radioButton_Erosion.UseVisualStyleBackColor = true;
            this.radioButton_Erosion.Click += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 7);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(567, 108);
            this.label1.TabIndex = 0;
            this.label1.Text = "選擇morphologyEx的模式";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton_Dilation
            // 
            this.radioButton_Dilation.AutoSize = true;
            this.radioButton_Dilation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_Dilation.Location = new System.Drawing.Point(3, 111);
            this.radioButton_Dilation.Name = "radioButton_Dilation";
            this.radioButton_Dilation.Size = new System.Drawing.Size(75, 102);
            this.radioButton_Dilation.TabIndex = 1;
            this.radioButton_Dilation.TabStop = true;
            this.radioButton_Dilation.Text = "Dilation";
            this.radioButton_Dilation.UseVisualStyleBackColor = true;
            this.radioButton_Dilation.Click += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 108);
            this.label2.TabIndex = 8;
            this.label2.Text = "kernel size\r\n>=1，奇數";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 3);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(327, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 105);
            this.button1.TabIndex = 10;
            this.button1.Text = "確認";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.trackBar1, 3);
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Location = new System.Drawing.Point(246, 219);
            this.trackBar1.Maximum = 25;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(237, 102);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(489, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 108);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
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
            this.splitContainer1.Size = new System.Drawing.Size(868, 437);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 13;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(287, 435);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "預覽";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 409);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button2, 3);
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 105);
            this.button2.TabIndex = 13;
            this.button2.Text = "查看原圖";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MorphologicalOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 437);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MorphologicalOperationForm";
            this.Text = "MorphologicalOperationForm";
            this.Load += new System.EventHandler(this.MorphologicalOperationForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton_BlackHat;
        private System.Windows.Forms.RadioButton radioButton_TopHat;
        private System.Windows.Forms.RadioButton radioButton_Close;
        private System.Windows.Forms.RadioButton radioButton_Open;
        private System.Windows.Forms.RadioButton radioButton_gradient;
        private System.Windows.Forms.RadioButton radioButton_Erosion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_Dilation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
    }
}