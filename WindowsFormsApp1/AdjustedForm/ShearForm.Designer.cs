
namespace WindowsFormsApp1.AdjustedForm
{
    partial class ShearForm
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
            this.xShearLabel = new System.Windows.Forms.Label();
            this.yShearLabel = new System.Windows.Forms.Label();
            this.yShearTextBox = new System.Windows.Forms.TextBox();
            this.xShearTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xShearLabel
            // 
            this.xShearLabel.AutoSize = true;
            this.xShearLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xShearLabel.Location = new System.Drawing.Point(3, 0);
            this.xShearLabel.Name = "xShearLabel";
            this.xShearLabel.Size = new System.Drawing.Size(294, 258);
            this.xShearLabel.TabIndex = 0;
            this.xShearLabel.Text = "垂直剪形";
            this.xShearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yShearLabel
            // 
            this.yShearLabel.AutoSize = true;
            this.yShearLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yShearLabel.Location = new System.Drawing.Point(3, 258);
            this.yShearLabel.Name = "yShearLabel";
            this.yShearLabel.Size = new System.Drawing.Size(294, 259);
            this.yShearLabel.TabIndex = 1;
            this.yShearLabel.Text = "水平剪形";
            this.yShearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yShearTextBox
            // 
            this.yShearTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yShearTextBox.Location = new System.Drawing.Point(303, 3);
            this.yShearTextBox.Name = "yShearTextBox";
            this.yShearTextBox.Size = new System.Drawing.Size(294, 25);
            this.yShearTextBox.TabIndex = 2;
            this.yShearTextBox.Text = "0.00";
            // 
            // xShearTextBox
            // 
            this.xShearTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xShearTextBox.Location = new System.Drawing.Point(303, 261);
            this.xShearTextBox.Name = "xShearTextBox";
            this.xShearTextBox.Size = new System.Drawing.Size(294, 25);
            this.xShearTextBox.TabIndex = 3;
            this.xShearTextBox.Text = "0.00";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(603, 3);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 2);
            this.button1.Size = new System.Drawing.Size(296, 511);
            this.button1.TabIndex = 4;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.xShearLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.yShearLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.xShearTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.yShearTextBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(902, 517);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ShearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 517);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ShearForm";
            this.Text = "ShearForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label xShearLabel;
        private System.Windows.Forms.Label yShearLabel;
        private System.Windows.Forms.TextBox yShearTextBox;
        private System.Windows.Forms.TextBox xShearTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}