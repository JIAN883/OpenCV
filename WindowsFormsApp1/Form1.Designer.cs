
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.結束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_basic = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_spatialDomain = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_spatialDomain_Intensity = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SpatialDomain_SharpeningFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SpatialDomain_NoiseImageRecovery = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_FrequencyDomain = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_FrequencyDomain_Intensity = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ColorImageProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ElseProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.aI物件辨識ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PeekStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ToolStripMenuItem_basic,
            this.ToolStripMenuItem_spatialDomain,
            this.ToolStripMenuItem_FrequencyDomain,
            this.toolStripMenuItem_ColorImageProcess,
            this.toolStripMenuItem_ElseProcess,
            this.aI物件辨識ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1334, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.結束ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.fileToolStripMenuItem.Text = "檔案";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.openToolStripMenuItem.Text = "開啟";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenImage);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(206, 26);
            this.toolStripMenuItem2.Text = "另存新檔";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.SaveFile);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 6);
            // 
            // 結束ToolStripMenuItem
            // 
            this.結束ToolStripMenuItem.Name = "結束ToolStripMenuItem";
            this.結束ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.結束ToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.結束ToolStripMenuItem.Text = "結束";
            this.結束ToolStripMenuItem.Click += new System.EventHandler(this.CloseApp);
            // 
            // ToolStripMenuItem_basic
            // 
            this.ToolStripMenuItem_basic.Name = "ToolStripMenuItem_basic";
            this.ToolStripMenuItem_basic.Size = new System.Drawing.Size(83, 24);
            this.ToolStripMenuItem_basic.Text = "基本處理";
            this.ToolStripMenuItem_basic.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_spatialDomain
            // 
            this.ToolStripMenuItem_spatialDomain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_spatialDomain_Intensity,
            this.ToolStripMenuItem_SpatialDomain_SharpeningFilter,
            this.ToolStripMenuItem_SpatialDomain_NoiseImageRecovery});
            this.ToolStripMenuItem_spatialDomain.Name = "ToolStripMenuItem_spatialDomain";
            this.ToolStripMenuItem_spatialDomain.Size = new System.Drawing.Size(113, 24);
            this.ToolStripMenuItem_spatialDomain.Text = "空間域濾波器";
            // 
            // ToolStripMenuItem_spatialDomain_Intensity
            // 
            this.ToolStripMenuItem_spatialDomain_Intensity.Name = "ToolStripMenuItem_spatialDomain_Intensity";
            this.ToolStripMenuItem_spatialDomain_Intensity.Size = new System.Drawing.Size(197, 26);
            this.ToolStripMenuItem_spatialDomain_Intensity.Text = "基本影像強化";
            this.ToolStripMenuItem_spatialDomain_Intensity.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_SpatialDomain_SharpeningFilter
            // 
            this.ToolStripMenuItem_SpatialDomain_SharpeningFilter.Name = "ToolStripMenuItem_SpatialDomain_SharpeningFilter";
            this.ToolStripMenuItem_SpatialDomain_SharpeningFilter.Size = new System.Drawing.Size(197, 26);
            this.ToolStripMenuItem_SpatialDomain_SharpeningFilter.Text = "銳化空間濾波器";
            this.ToolStripMenuItem_SpatialDomain_SharpeningFilter.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_SpatialDomain_NoiseImageRecovery
            // 
            this.ToolStripMenuItem_SpatialDomain_NoiseImageRecovery.Name = "ToolStripMenuItem_SpatialDomain_NoiseImageRecovery";
            this.ToolStripMenuItem_SpatialDomain_NoiseImageRecovery.Size = new System.Drawing.Size(197, 26);
            this.ToolStripMenuItem_SpatialDomain_NoiseImageRecovery.Text = "影像還原";
            this.ToolStripMenuItem_SpatialDomain_NoiseImageRecovery.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_FrequencyDomain
            // 
            this.ToolStripMenuItem_FrequencyDomain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_FrequencyDomain_Intensity,
            this.ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery});
            this.ToolStripMenuItem_FrequencyDomain.Name = "ToolStripMenuItem_FrequencyDomain";
            this.ToolStripMenuItem_FrequencyDomain.Size = new System.Drawing.Size(113, 24);
            this.ToolStripMenuItem_FrequencyDomain.Text = "頻率域濾波器";
            // 
            // ToolStripMenuItem_FrequencyDomain_Intensity
            // 
            this.ToolStripMenuItem_FrequencyDomain_Intensity.Name = "ToolStripMenuItem_FrequencyDomain_Intensity";
            this.ToolStripMenuItem_FrequencyDomain_Intensity.Size = new System.Drawing.Size(182, 26);
            this.ToolStripMenuItem_FrequencyDomain_Intensity.Text = "基本影像強化";
            this.ToolStripMenuItem_FrequencyDomain_Intensity.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery
            // 
            this.ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery.Name = "ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery";
            this.ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery.Size = new System.Drawing.Size(182, 26);
            this.ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery.Text = "影像還原";
            this.ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_ColorImageProcess
            // 
            this.toolStripMenuItem_ColorImageProcess.Name = "toolStripMenuItem_ColorImageProcess";
            this.toolStripMenuItem_ColorImageProcess.Size = new System.Drawing.Size(113, 24);
            this.toolStripMenuItem_ColorImageProcess.Text = "彩色影像處理";
            this.toolStripMenuItem_ColorImageProcess.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_ElseProcess
            // 
            this.toolStripMenuItem_ElseProcess.Name = "toolStripMenuItem_ElseProcess";
            this.toolStripMenuItem_ElseProcess.Size = new System.Drawing.Size(83, 24);
            this.toolStripMenuItem_ElseProcess.Text = "其他工具";
            this.toolStripMenuItem_ElseProcess.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // aI物件辨識ToolStripMenuItem
            // 
            this.aI物件辨識ToolStripMenuItem.Name = "aI物件辨識ToolStripMenuItem";
            this.aI物件辨識ToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.aI物件辨識ToolStripMenuItem.Text = "AI物件辨識";
            this.aI物件辨識ToolStripMenuItem.Click += new System.EventHandler(this.AIToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1334, 662);
            this.splitContainer1.SplitterDistance = 440;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1332, 438);
            this.splitContainer2.SplitterDistance = 772;
            this.splitContainer2.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(772, 438);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(556, 438);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.PeekStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 690);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1334, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1250, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // PeekStripStatusLabel
            // 
            this.PeekStripStatusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PeekStripStatusLabel.Name = "PeekStripStatusLabel";
            this.PeekStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.PeekStripStatusLabel.Size = new System.Drawing.Size(69, 19);
            this.PeekStripStatusLabel.Text = "點擊還原";
            this.PeekStripStatusLabel.Click += new System.EventHandler(this.PeekStripStatusLabel_Click);
            this.PeekStripStatusLabel.MouseLeave += new System.EventHandler(this.PeekStripStatusLabel_MouseLeave);
            this.PeekStripStatusLabel.MouseHover += new System.EventHandler(this.PeekStripStatusLabel_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 715);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "影像處理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 結束ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_spatialDomain;
        private System.Windows.Forms.ToolStripStatusLabel PeekStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ElseProcess;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_basic;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_FrequencyDomain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_spatialDomain_Intensity;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SpatialDomain_SharpeningFilter;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SpatialDomain_NoiseImageRecovery;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_FrequencyDomain_Intensity;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ColorImageProcess;
        private System.Windows.Forms.ToolStripMenuItem aI物件辨識ToolStripMenuItem;
    }
}

