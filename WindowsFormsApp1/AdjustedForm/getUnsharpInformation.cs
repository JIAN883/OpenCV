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

namespace WindowsFormsApp1.AdjustedForm
{
    public partial class getUnsharpInformationForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void getUnsharpInformation(IntPtr src, int width, int height, out IntPtr dst);

        Form1 topForm;
        Mat source;
        Bitmap dstImage;

        public getUnsharpInformationForm()
        {
            InitializeComponent();
        }

        public getUnsharpInformationForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void getUnsharpInformationForm_Load(object sender, EventArgs e)
        {
            Mat src = source.Clone();
            getUnsharpInformation(src.Data, src.Width, src.Height, out IntPtr dst);
            dstImage = BitmapConverter.ToBitmap(new Mat(src.Height, src.Width, MatType.CV_8UC3, dst));
            splitContainer1.Panel1.BackgroundImage = dstImage;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Form temp = new Form();
            temp.WindowState = FormWindowState.Maximized;
            temp.BackgroundImageLayout = ImageLayout.Zoom;
            temp.BackgroundImage = dstImage;
            temp.Show();
        }

    }
}
