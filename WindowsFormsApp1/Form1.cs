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

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		[DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		static extern IntPtr showImage(out IntPtr img, string filename);
		[DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		static extern void test(IntPtr image);

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
    }
}
