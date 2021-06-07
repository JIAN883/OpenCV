using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		[DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		static extern void Blur(IntPtr src, int width, int height);

		public Form1()
		{
			InitializeComponent();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofDialog = new OpenFileDialog();
			ofDialog.Filter = "JPG影象(*.jpg)|*.jpg|BMP影象(*.bmp)|*.bmp|所有檔案(*.*)|*.*";

			if (ofDialog.ShowDialog() != DialogResult.OK)
				return;

			Bitmap image = new Bitmap(ofDialog.FileName);
			pictureBox1.Image = image;
		}

		private void CloseAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.Environment.Exit(0);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
		//	//測試用按鈕
		//	if (pictureBox1.Image == null)
		//		return;
		//	Mat src = BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
		//	Blur(src.Data, src.Width, src.Height);
		//	pictureBox1.Image = BitmapConverter.ToBitmap(src);
        //}
    }
}
