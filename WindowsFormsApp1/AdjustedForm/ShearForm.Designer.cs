
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
            this.SuspendLayout();
            // 
            // xShearLabel
            // 
            this.xShearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xShearLabel.AutoSize = true;
            this.xShearLabel.Location = new System.Drawing.Point(80, 385);
            this.xShearLabel.Name = "xShearLabel";
            this.xShearLabel.Size = new System.Drawing.Size(67, 15);
            this.xShearLabel.TabIndex = 0;
            this.xShearLabel.Text = "垂直剪形";
            // 
            // yShearLabel
            // 
            this.yShearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yShearLabel.AutoSize = true;
            this.yShearLabel.Location = new System.Drawing.Point(80, 447);
            this.yShearLabel.Name = "yShearLabel";
            this.yShearLabel.Size = new System.Drawing.Size(67, 15);
            this.yShearLabel.TabIndex = 1;
            this.yShearLabel.Text = "水平剪形";
            // 
            // yShearTextBox
            // 
            this.yShearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yShearTextBox.Location = new System.Drawing.Point(235, 385);
            this.yShearTextBox.Name = "yShearTextBox";
            this.yShearTextBox.Size = new System.Drawing.Size(100, 25);
            this.yShearTextBox.TabIndex = 2;
            this.yShearTextBox.Text = "0.00";
            // 
            // xShearTextBox
            // 
            this.xShearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xShearTextBox.Location = new System.Drawing.Point(235, 444);
            this.xShearTextBox.Name = "xShearTextBox";
            this.xShearTextBox.Size = new System.Drawing.Size(100, 25);
            this.xShearTextBox.TabIndex = 3;
            this.xShearTextBox.Text = "0.00";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(404, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 495);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.xShearTextBox);
            this.Controls.Add(this.yShearTextBox);
            this.Controls.Add(this.yShearLabel);
            this.Controls.Add(this.xShearLabel);
            this.Name = "ShearForm";
            this.Text = "ShearForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xShearLabel;
        private System.Windows.Forms.Label yShearLabel;
        private System.Windows.Forms.TextBox yShearTextBox;
        private System.Windows.Forms.TextBox xShearTextBox;
        private System.Windows.Forms.Button button1;
    }
}