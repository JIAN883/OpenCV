
namespace WindowsFormsApp1.AdjustedForm
{
    partial class ReflectForm
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
            this.horizontalButton = new System.Windows.Forms.Button();
            this.verticalButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.horizontalButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.verticalButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // horizontalButton
            // 
            this.horizontalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalButton.Location = new System.Drawing.Point(3, 3);
            this.horizontalButton.Name = "horizontalButton";
            this.horizontalButton.Size = new System.Drawing.Size(394, 444);
            this.horizontalButton.TabIndex = 0;
            this.horizontalButton.Text = "水平鏡射";
            this.horizontalButton.UseVisualStyleBackColor = true;
            this.horizontalButton.Click += new System.EventHandler(this.horizontalButton_Click);
            // 
            // verticalButton
            // 
            this.verticalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verticalButton.Location = new System.Drawing.Point(403, 3);
            this.verticalButton.Name = "verticalButton";
            this.verticalButton.Size = new System.Drawing.Size(394, 444);
            this.verticalButton.TabIndex = 1;
            this.verticalButton.Text = "垂直鏡射";
            this.verticalButton.UseVisualStyleBackColor = true;
            this.verticalButton.Click += new System.EventHandler(this.verticalButton_Click);
            // 
            // ReflectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReflectForm";
            this.Text = "ReflectForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button horizontalButton;
        private System.Windows.Forms.Button verticalButton;
    }
}