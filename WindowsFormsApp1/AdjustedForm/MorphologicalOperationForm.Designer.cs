
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
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.button2, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_BlackHat, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_TopHat, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_Close, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_Open, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_gradient, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_Erosion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_Dilation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 453);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radioButton_BlackHat
            // 
            this.radioButton_BlackHat.AutoSize = true;
            this.radioButton_BlackHat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_BlackHat.Location = new System.Drawing.Point(501, 116);
            this.radioButton_BlackHat.Name = "radioButton_BlackHat";
            this.radioButton_BlackHat.Size = new System.Drawing.Size(78, 107);
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
            this.radioButton_TopHat.Location = new System.Drawing.Point(418, 116);
            this.radioButton_TopHat.Name = "radioButton_TopHat";
            this.radioButton_TopHat.Size = new System.Drawing.Size(77, 107);
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
            this.radioButton_Close.Location = new System.Drawing.Point(335, 116);
            this.radioButton_Close.Name = "radioButton_Close";
            this.radioButton_Close.Size = new System.Drawing.Size(77, 107);
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
            this.radioButton_Open.Location = new System.Drawing.Point(252, 116);
            this.radioButton_Open.Name = "radioButton_Open";
            this.radioButton_Open.Size = new System.Drawing.Size(77, 107);
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
            this.radioButton_gradient.Location = new System.Drawing.Point(169, 116);
            this.radioButton_gradient.Name = "radioButton_gradient";
            this.radioButton_gradient.Size = new System.Drawing.Size(77, 107);
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
            this.radioButton_Erosion.Location = new System.Drawing.Point(86, 116);
            this.radioButton_Erosion.Name = "radioButton_Erosion";
            this.radioButton_Erosion.Size = new System.Drawing.Size(77, 107);
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
            this.label1.Size = new System.Drawing.Size(576, 113);
            this.label1.TabIndex = 0;
            this.label1.Text = "選擇morphologyEx的模式";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton_Dilation
            // 
            this.radioButton_Dilation.AutoSize = true;
            this.radioButton_Dilation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_Dilation.Location = new System.Drawing.Point(3, 116);
            this.radioButton_Dilation.Name = "radioButton_Dilation";
            this.radioButton_Dilation.Size = new System.Drawing.Size(77, 107);
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
            this.label2.Location = new System.Drawing.Point(3, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 113);
            this.label2.TabIndex = 8;
            this.label2.Text = "size：kernel是幾乘幾(真實kernel大小=2*size+1)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 3);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 108);
            this.button1.TabIndex = 10;
            this.button1.Text = "確認";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.trackBar1, 3);
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Location = new System.Drawing.Point(252, 229);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(243, 107);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(501, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 113);
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
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(882, 455);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 13;
            // 
            // button2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button2, 3);
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(335, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 108);
            this.button2.TabIndex = 13;
            this.button2.Text = "查看原圖";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MorphologicalOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 455);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MorphologicalOperationForm";
            this.Text = "MorphologicalOperationForm";
            this.Load += new System.EventHandler(this.MorphologicalOperationForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.Button button2;
    }
}