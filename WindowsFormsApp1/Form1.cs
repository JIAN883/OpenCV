using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.AdjustedForm;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		[DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		static extern void callObjectDetector();

		Bitmap sourceImage, peekImage;

		public Form1()
		{
			InitializeComponent();
			//綁定menustrip的tag
			ToolStripMenuItem_basic.Tag = AdjustedFormManager.basic;

			ToolStripMenuItem_spatialDomain_Intensity.Tag = AdjustedFormManager.spatialDomain_Intensity;
			ToolStripMenuItem_SpatialDomain_SharpeningFilter.Tag = AdjustedFormManager.spatialDomain_SharpeningFilter;
			ToolStripMenuItem_SpatialDomain_NoiseImageRecovery.Tag = AdjustedFormManager.spatialDomain_NoiseImageRecovery;

			//ToolStripMenuItem_FrequencyDomain_Intensity.Tag = AdjustedFormManager.frequencyDomain_Intensity;
			//ToolStripMenuItem_FrequencyDomain_NoiseImageRecovery.Tag = AdjustedFormManager.frequencyDomain_NoiseImageRecovery;
			ToolStripMenuItem_FrequencyDomain.Tag = AdjustedFormManager.frequencyDomain_Intensity;

			toolStripMenuItem_ColorImageProcess.Tag = AdjustedFormManager.colorImageProcess;

			toolStripMenuItem_ElseProcess.Tag = AdjustedFormManager.elseProcess;

			//debug模式專用
			//sourceImage = Properties.Resources.sample;
			//pictureBox.Image = sourceImage.Clone() as Bitmap;
		}

		private void OpenImage(object sender, EventArgs e)//以路徑開啟圖像
		{
			OpenFileDialog ofDialog = new OpenFileDialog();
			ofDialog.Filter = "JPG影象(*.jpg)|*.jpg|BMP影象(*.bmp)|*.bmp|所有檔案(*.*)|*.*";

			if (ofDialog.ShowDialog() != DialogResult.OK)
				return;

			try
			{
				Bitmap image = new Bitmap(ofDialog.FileName);
				sourceImage = image;
				pictureBox.Image = image.Clone() as Bitmap;
            }
            catch 
			{
				MessageBox.Show("無法開啟檔案");
			}
		}

		private void SaveFile(object sender, EventArgs e)
		{
			if(pictureBox.Image == null)
            {
				MessageBox.Show("請打開一張圖片");
				return;
            }

			SaveFileDialog sfDialog = new SaveFileDialog();
			sfDialog.Filter = "JPG影像(*.jpg)|*.jpg|PNG影像(*.png)|*.png|BMP影象(*.bmp)|*.bmp|所有檔案(*.*)|*.*";
			sfDialog.FileName = "picture";

			if (sfDialog.ShowDialog() != DialogResult.OK)
				return;

			Mat src = BitmapConverter.ToMat(pictureBox.Image as Bitmap);
			src.ImWrite(sfDialog.FileName);
		}

		private void CloseApp(object sender, EventArgs e)
        {
			Environment.Exit(0);
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)//偵測listbox被點擊的元素
        {
			if (pictureBox.Image == null)
				return;

			ListBox listBox = sender as ListBox;
			listBox.SelectedIndex = listBox1.IndexFromPoint(e.X, e.Y);

			if (listBox.SelectedIndex == -1)
			{
				splitContainer1.Panel2.Controls.Clear();
				return;
			}

			//利用listbox掛載的物件打開
			OpenAdjustedForm((listBox.SelectedItem as AdjustedFormManager).FormType);
		}

		private void OpenAdjustedForm(Type t)//利用type產生物件
		{
			Form newForm = (Form)Activator.CreateInstance(t, this);

			//調整子窗口
			splitContainer1.Panel2.Controls.Clear();

			newForm.TopLevel = false;
			newForm.FormBorderStyle = FormBorderStyle.None;
			newForm.Parent = splitContainer1.Panel2;
			newForm.Dock = DockStyle.Fill;

			splitContainer1.Panel2.Controls.Add(newForm);
			newForm.Show();
		}

		private void ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem temp = sender as ToolStripMenuItem;

			if (pictureBox.Image == null) //判斷使用者是否按了修圖功能按鈕
			{
				MessageBox.Show("請打開一張圖片");
				return;
			}

			listBox1.DataSource = temp.Tag as AdjustedFormManager[];
			listBox1.DisplayMember = "Name";
			listBox1.SelectedIndex = -1;
		}

		private void PeekStripStatusLabel_MouseHover(object sender, EventArgs e)
		{
			ToolStripStatusLabel peek = sender as ToolStripStatusLabel;
			peek.BackColor = Color.Black;
			peek.ForeColor = Color.White;

			if (pictureBox.Image != null)
			{
				peekImage = pictureBox.Image as Bitmap;
				pictureBox.Image = sourceImage;
			}
		}

        private void PeekStripStatusLabel_Click(object sender, EventArgs e)
        {
			peekImage = sourceImage.Clone() as Bitmap;
			if(splitContainer1.Panel2.Controls.Count != 0)
            {
				Control temp = splitContainer1.Panel2.Controls[0];
				OpenAdjustedForm(temp.GetType());
			}
        }

        private void AIToolStripMenuItem_Click(object sender, EventArgs e)
        {
			callObjectDetector();
        }

        private void PeekStripStatusLabel_MouseLeave(object sender, EventArgs e)
        {
			ToolStripStatusLabel peek = sender as ToolStripStatusLabel;
			peek.BackColor = SystemColors.Control;
			peek.ForeColor = SystemColors.ControlText;

			if (peekImage != null)
			{
				pictureBox.Image = peekImage;
			}
		}
    }
}
