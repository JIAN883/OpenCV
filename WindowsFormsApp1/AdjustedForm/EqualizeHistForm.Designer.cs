
namespace WindowsFormsApp1.AdjustedForm
{
    partial class EqualizeHistForm
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
            this.RGBButton = new System.Windows.Forms.Button();
            this.HSVButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.RGBButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.HSVButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 494);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RGBButton
            // 
            this.RGBButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RGBButton.Location = new System.Drawing.Point(3, 3);
            this.RGBButton.Name = "RGBButton";
            this.RGBButton.Size = new System.Drawing.Size(411, 488);
            this.RGBButton.TabIndex = 0;
            this.RGBButton.Text = "RGB等化處理";
            this.RGBButton.UseVisualStyleBackColor = true;
            this.RGBButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // HSVButton
            // 
            this.HSVButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HSVButton.Location = new System.Drawing.Point(420, 3);
            this.HSVButton.Name = "HSVButton";
            this.HSVButton.Size = new System.Drawing.Size(411, 488);
            this.HSVButton.TabIndex = 1;
            this.HSVButton.Text = "HSV等化處理";
            this.HSVButton.UseVisualStyleBackColor = true;
            this.HSVButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // EqualizeHistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 494);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EqualizeHistForm";
            this.Text = "EqualizeHistForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button RGBButton;
        private System.Windows.Forms.Button HSVButton;
    }
}