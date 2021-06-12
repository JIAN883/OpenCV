
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
            this.SaltPercentTrackBar = new System.Windows.Forms.TrackBar();
            this.PepperPercentTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.SaltPercentTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PepperPercentTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SaltPercentTrackBar
            // 
            this.SaltPercentTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaltPercentTrackBar.Location = new System.Drawing.Point(0, 490);
            this.SaltPercentTrackBar.Maximum = 100;
            this.SaltPercentTrackBar.Name = "SaltPercentTrackBar";
            this.SaltPercentTrackBar.Size = new System.Drawing.Size(882, 56);
            this.SaltPercentTrackBar.TabIndex = 0;
            this.SaltPercentTrackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // PepperPercentTrackBar
            // 
            this.PepperPercentTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PepperPercentTrackBar.Location = new System.Drawing.Point(0, 434);
            this.PepperPercentTrackBar.Maximum = 100;
            this.PepperPercentTrackBar.Name = "PepperPercentTrackBar";
            this.PepperPercentTrackBar.Size = new System.Drawing.Size(882, 56);
            this.PepperPercentTrackBar.TabIndex = 1;
            this.PepperPercentTrackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // GeneratePepperSaltForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 546);
            this.Controls.Add(this.PepperPercentTrackBar);
            this.Controls.Add(this.SaltPercentTrackBar);
            this.Name = "GeneratePepperSaltForm";
            this.Text = "GeneratePepperSaltForm";
            ((System.ComponentModel.ISupportInitialize)(this.SaltPercentTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PepperPercentTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar SaltPercentTrackBar;
        private System.Windows.Forms.TrackBar PepperPercentTrackBar;
    }
}