
namespace WindowsFormsApp1.AdjustedForm
{
    partial class GeneratePepperSaltForm
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
            this.saltPercenttrackBar = new System.Windows.Forms.TrackBar();
            this.pepperPercentTrackBar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.saltPercenttrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pepperPercentTrackBar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saltPercenttrackBar
            // 
            this.saltPercenttrackBar.Location = new System.Drawing.Point(3, 283);
            this.saltPercenttrackBar.Maximum = 100;
            this.saltPercenttrackBar.Name = "saltPercenttrackBar";
            this.saltPercenttrackBar.Size = new System.Drawing.Size(498, 56);
            this.saltPercenttrackBar.TabIndex = 0;
            this.saltPercenttrackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // pepperPercentTrackBar
            // 
            this.pepperPercentTrackBar.Location = new System.Drawing.Point(3, 3);
            this.pepperPercentTrackBar.Maximum = 100;
            this.pepperPercentTrackBar.Name = "pepperPercentTrackBar";
            this.pepperPercentTrackBar.Size = new System.Drawing.Size(498, 56);
            this.pepperPercentTrackBar.TabIndex = 1;
            this.pepperPercentTrackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.03715F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.10401F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.85884F));
            this.tableLayoutPanel1.Controls.Add(this.pepperPercentTrackBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.saltPercenttrackBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(917, 560);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(507, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 280);
            this.label1.TabIndex = 2;
            this.label1.Text = "PepperPercent(%)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(783, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 280);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(507, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 280);
            this.label3.TabIndex = 4;
            this.label3.Text = "SaltPercent(%)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(783, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 280);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GeneratePepperSaltForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 560);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GeneratePepperSaltForm";
            this.Text = "GeneratePepperSaltForm";
            ((System.ComponentModel.ISupportInitialize)(this.saltPercenttrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pepperPercentTrackBar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar saltPercenttrackBar;
        private System.Windows.Forms.TrackBar pepperPercentTrackBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}