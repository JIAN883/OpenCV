
namespace WindowsFormsApp1.AdjustedForm
{
    partial class GetColorPlaneForm
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
            this.radioButton_Y = new System.Windows.Forms.RadioButton();
            this.radioButton_B = new System.Windows.Forms.RadioButton();
            this.radioButton_R = new System.Windows.Forms.RadioButton();
            this.radioButton_G = new System.Windows.Forms.RadioButton();
            this.radioButton_C = new System.Windows.Forms.RadioButton();
            this.radioButton_M = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.radioButton_Y, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_B, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_R, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_G, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_C, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.radioButton_M, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 458);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // radioButton_Y
            // 
            this.radioButton_Y.AutoSize = true;
            this.radioButton_Y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_Y.Location = new System.Drawing.Point(427, 383);
            this.radioButton_Y.Name = "radioButton_Y";
            this.radioButton_Y.Size = new System.Drawing.Size(206, 72);
            this.radioButton_Y.TabIndex = 6;
            this.radioButton_Y.TabStop = true;
            this.radioButton_Y.Text = "Y";
            this.radioButton_Y.UseVisualStyleBackColor = true;
            this.radioButton_Y.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButton_B
            // 
            this.radioButton_B.AutoSize = true;
            this.radioButton_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_B.Location = new System.Drawing.Point(427, 3);
            this.radioButton_B.Name = "radioButton_B";
            this.radioButton_B.Size = new System.Drawing.Size(206, 70);
            this.radioButton_B.TabIndex = 0;
            this.radioButton_B.TabStop = true;
            this.radioButton_B.Text = "B";
            this.radioButton_B.UseVisualStyleBackColor = true;
            this.radioButton_B.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButton_R
            // 
            this.radioButton_R.AutoSize = true;
            this.radioButton_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_R.Location = new System.Drawing.Point(427, 79);
            this.radioButton_R.Name = "radioButton_R";
            this.radioButton_R.Size = new System.Drawing.Size(206, 70);
            this.radioButton_R.TabIndex = 1;
            this.radioButton_R.TabStop = true;
            this.radioButton_R.Text = "R";
            this.radioButton_R.UseVisualStyleBackColor = true;
            this.radioButton_R.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButton_G
            // 
            this.radioButton_G.AutoSize = true;
            this.radioButton_G.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_G.Location = new System.Drawing.Point(427, 155);
            this.radioButton_G.Name = "radioButton_G";
            this.radioButton_G.Size = new System.Drawing.Size(206, 70);
            this.radioButton_G.TabIndex = 2;
            this.radioButton_G.TabStop = true;
            this.radioButton_G.Text = "G";
            this.radioButton_G.UseVisualStyleBackColor = true;
            this.radioButton_G.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButton_C
            // 
            this.radioButton_C.AutoSize = true;
            this.radioButton_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_C.Location = new System.Drawing.Point(427, 231);
            this.radioButton_C.Name = "radioButton_C";
            this.radioButton_C.Size = new System.Drawing.Size(206, 70);
            this.radioButton_C.TabIndex = 3;
            this.radioButton_C.TabStop = true;
            this.radioButton_C.Text = "C";
            this.radioButton_C.UseVisualStyleBackColor = true;
            this.radioButton_C.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButton_M
            // 
            this.radioButton_M.AutoSize = true;
            this.radioButton_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_M.Location = new System.Drawing.Point(427, 307);
            this.radioButton_M.Name = "radioButton_M";
            this.radioButton_M.Size = new System.Drawing.Size(206, 70);
            this.radioButton_M.TabIndex = 4;
            this.radioButton_M.TabStop = true;
            this.radioButton_M.Text = "M";
            this.radioButton_M.UseVisualStyleBackColor = true;
            this.radioButton_M.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(639, 3);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 3);
            this.button1.Size = new System.Drawing.Size(207, 222);
            this.button1.TabIndex = 5;
            this.button1.Text = "查看原圖";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 6);
            this.pictureBox1.Size = new System.Drawing.Size(418, 452);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(639, 231);
            this.button2.Name = "button2";
            this.tableLayoutPanel1.SetRowSpan(this.button2, 3);
            this.button2.Size = new System.Drawing.Size(207, 224);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GetColorPlaneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 458);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GetColorPlaneForm";
            this.Text = "GetColorPlaneForm";
            this.Load += new System.EventHandler(this.ChangeIlluminantFromModelForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton_B;
        private System.Windows.Forms.RadioButton radioButton_R;
        private System.Windows.Forms.RadioButton radioButton_G;
        private System.Windows.Forms.RadioButton radioButton_C;
        private System.Windows.Forms.RadioButton radioButton_M;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton_Y;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
    }
}