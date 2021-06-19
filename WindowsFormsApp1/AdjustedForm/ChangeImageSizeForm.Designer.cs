
namespace WindowsFormsApp1.AdjustedForm
{
    partial class ChangeImageSizeForm
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
            this.HeightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.openResizeFormbutton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.HeightLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.widthLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HeightTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.widthTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.openResizeFormbutton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.confirmButton, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1095, 294);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeightLabel.Location = new System.Drawing.Point(3, 0);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(541, 97);
            this.HeightLabel.TabIndex = 0;
            this.HeightLabel.Text = "高度比例";
            this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.widthLabel.Location = new System.Drawing.Point(3, 97);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(541, 97);
            this.widthLabel.TabIndex = 1;
            this.widthLabel.Text = "寬度比例";
            this.widthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeightTextBox.Location = new System.Drawing.Point(550, 3);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(542, 25);
            this.HeightTextBox.TabIndex = 2;
            this.HeightTextBox.Text = "1.0";
            this.HeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.widthTextBox.Location = new System.Drawing.Point(550, 100);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(542, 25);
            this.widthTextBox.TabIndex = 3;
            this.widthTextBox.Text = "1.0";
            this.widthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openResizeFormbutton
            // 
            this.openResizeFormbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openResizeFormbutton.Location = new System.Drawing.Point(3, 197);
            this.openResizeFormbutton.Name = "openResizeFormbutton";
            this.openResizeFormbutton.Size = new System.Drawing.Size(541, 94);
            this.openResizeFormbutton.TabIndex = 4;
            this.openResizeFormbutton.Text = "調整原圖";
            this.openResizeFormbutton.UseVisualStyleBackColor = true;
            this.openResizeFormbutton.Click += new System.EventHandler(this.OpenResizeForm);
            // 
            // confirmButton
            // 
            this.confirmButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confirmButton.Location = new System.Drawing.Point(550, 197);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(542, 94);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "確認";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // ChangeImageSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 294);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChangeImageSizeForm";
            this.Text = "ChangeImageSizeForm";
            this.Load += new System.EventHandler(this.ChangeImageSizeForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Button openResizeFormbutton;
        private System.Windows.Forms.Button confirmButton;
    }
}