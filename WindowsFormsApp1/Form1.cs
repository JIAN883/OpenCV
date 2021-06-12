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

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		Bitmap sourceImage, peekImage;

		public Form1()
		{
			InitializeComponent();

			//綁定menustrip的tag
			menuStrip1.Items[1].Tag = AdjustedFormManager.GetFormList(0);
			menuStrip1.Items[2].Tag = AdjustedFormManager.GetFormList(1);
			menuStrip1.Items[3].Tag = AdjustedFormManager.GetFormList(2);
			menuStrip1.Items[4].Tag = AdjustedFormManager.GetFormList(3);
		}

		private void OpenImage(object sender, EventArgs e)//以路徑開啟圖像
		{
			OpenFileDialog ofDialog = new OpenFileDialog();
			ofDialog.Filter = "JPG影象(*.jpg)|*.jpg|BMP影象(*.bmp)|*.bmp|所有檔案(*.*)|*.*";

			if (ofDialog.ShowDialog() != DialogResult.OK)
				return;

			Bitmap image = new Bitmap(ofDialog.FileName);
			pictureBox.Image = image;
			sourceImage = image.Clone() as Bitmap;
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
			newForm.Dock = DockStyle.Fill;
			newForm.Parent = splitContainer1.Panel2;

			splitContainer1.Panel2.Controls.Add(newForm);
			newForm.Show();
		}

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)//按下工具欄會重新綁定listbox的物件
        {
			if (e.ClickedItem.Tag != null && pictureBox.Image == null) //判斷使用者是否按了修圖功能按鈕
            {
				MessageBox.Show("請打開一張圖片");
				return;
			}

			listBox1.DataSource = e.ClickedItem.Tag as List<AdjustedFormManager>;
			listBox1.DisplayMember = "Name";
			listBox1.SelectedIndex = -1;
		}

		private void PeekStripStatusLabel_MouseHover(object sender, EventArgs e)
		{
			ToolStripStatusLabel peek = sender as ToolStripStatusLabel;
			peek.BackColor = Color.Black;
			peek.ForeColor = Color.White;

			PeekImage(true);
		}

        private void PeekStripStatusLabel_MouseLeave(object sender, EventArgs e)
        {
			ToolStripStatusLabel peek = sender as ToolStripStatusLabel;
			peek.BackColor = SystemColors.Control;
			peek.ForeColor = SystemColors.ControlText;

			PeekImage(false);
		}

		private void PeekImage(bool isBegin)
        {
			if (pictureBox.Image == null)
				return;

			//滑鼠離開peek
			if (!isBegin)
            {
				pictureBox.Image = peekImage;
				return;
            }

			//滑鼠進入peek
			peekImage = pictureBox.Image as Bitmap;
			pictureBox.Image = sourceImage;
		}
    }
}
