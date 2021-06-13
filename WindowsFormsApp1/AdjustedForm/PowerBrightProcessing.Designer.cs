
namespace WindowsFormsApp1.AdjustedForm
{
    partial class PowerBrightProcessing
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
            this.gammaTrackBar = new System.Windows.Forms.TrackBar();
            this.cTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.gammaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // gammaTrackBar
            // 
            this.gammaTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gammaTrackBar.Location = new System.Drawing.Point(0, 577);
            this.gammaTrackBar.Maximum = 100;
            this.gammaTrackBar.Minimum = 1;
            this.gammaTrackBar.Name = "gammaTrackBar";
            this.gammaTrackBar.Size = new System.Drawing.Size(960, 56);
            this.gammaTrackBar.TabIndex = 0;
            this.gammaTrackBar.Value = 1;
            // 
            // cTrackBar
            // 
            this.cTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cTrackBar.Location = new System.Drawing.Point(0, 521);
            this.cTrackBar.Minimum = -10;
            this.cTrackBar.Name = "cTrackBar";
            this.cTrackBar.Size = new System.Drawing.Size(960, 56);
            this.cTrackBar.TabIndex = 1;
            this.cTrackBar.Value = 1;
            this.cTrackBar.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // PowerBrightProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 633);
            this.Controls.Add(this.cTrackBar);
            this.Controls.Add(this.gammaTrackBar);
            this.Name = "PowerBrightProcessing";
            this.Text = "PowerBrightProcessing";
            this.Load += new System.EventHandler(this.PowerBrightProcessing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gammaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar gammaTrackBar;
        private System.Windows.Forms.TrackBar cTrackBar;
    }
}