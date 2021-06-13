
namespace WindowsFormsApp1.AdjustedForm
{
    partial class ThresholdProcessingForm
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
            this.trackBarMaxval = new System.Windows.Forms.TrackBar();
            this.trackBarThresh = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresh)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarMaxval
            // 
            this.trackBarMaxval.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarMaxval.Location = new System.Drawing.Point(0, 456);
            this.trackBarMaxval.Maximum = 1000;
            this.trackBarMaxval.Name = "trackBarMaxval";
            this.trackBarMaxval.Size = new System.Drawing.Size(849, 56);
            this.trackBarMaxval.TabIndex = 0;
            this.trackBarMaxval.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // trackBarThresh
            // 
            this.trackBarThresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarThresh.Location = new System.Drawing.Point(0, 400);
            this.trackBarThresh.Maximum = 1000;
            this.trackBarThresh.Name = "trackBarThresh";
            this.trackBarThresh.Size = new System.Drawing.Size(849, 56);
            this.trackBarThresh.TabIndex = 1;
            this.trackBarThresh.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // ThresholdProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 512);
            this.Controls.Add(this.trackBarThresh);
            this.Controls.Add(this.trackBarMaxval);
            this.Name = "ThresholdProcessingForm";
            this.Text = "ThresholdProcessingForm";
            this.Load += new System.EventHandler(this.ThresholdProcessingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarMaxval;
        private System.Windows.Forms.TrackBar trackBarThresh;
    }
}