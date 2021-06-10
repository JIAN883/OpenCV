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
		public Form1()
		{
			InitializeComponent();

			//綁定listbox的陣列資料
			listBox1.DataSource = AdjustedFormManager.GetFormList();
			listBox1.DisplayMember = "Name";
		}

		private void OpenImage(object sender, EventArgs e)
		{
			OpenFileDialog ofDialog = new OpenFileDialog();
			ofDialog.Filter = "JPG影象(*.jpg)|*.jpg|BMP影象(*.bmp)|*.bmp|所有檔案(*.*)|*.*";

			if (ofDialog.ShowDialog() != DialogResult.OK)
				return;

			Bitmap image = new Bitmap(ofDialog.FileName);
			pictureBox.Image = image;
		}

		private void CloseApp(object sender, EventArgs e)
        {
			Environment.Exit(0);
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
			if (pictureBox.Image == null)
				return;

			ListBox listBox = sender as ListBox;
			listBox.SelectedIndex = listBox1.IndexFromPoint(e.X, e.Y);

			//利用listbox掛載物件打開
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
    }
}
