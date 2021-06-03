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


namespace WindowsFormsApp1
{

	public partial class Form1 : Form
	{
		[DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		static extern IntPtr showImage(string filename, out IntPtr img, int flags, string label_name);
		[DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		static extern void test(IntPtr image);

		public Form1()
		{
			InitializeComponent();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofDialog = new OpenFileDialog();
			if(ofDialog.ShowDialog() == DialogResult.OK)
			{
				IntPtr a;
				showImage(ofDialog.FileName, out a, 0,"a");
				showImage(ofDialog.FileName, out a, 1,"b");
				showImage(ofDialog.FileName, out a, 16,"c");
				showImage(ofDialog.FileName, out a, 17,"d");

				//test(a);
			}
		}

        private void CloseAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.Environment.Exit(0);
        }
    }
}
