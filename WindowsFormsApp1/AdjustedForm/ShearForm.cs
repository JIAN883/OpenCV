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
    public partial class ShearForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void Shear(IntPtr src, int width, int height, double xshear, double yshear, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        Bitmap dstImage;

        public ShearForm()
        {
            InitializeComponent();
        }

        public ShearForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double xshear = double.Parse(xShearTextBox.Text), yshear = double.Parse(yShearTextBox.Text);
            Mat src = source.Clone();
            Shear(src.Data, src.Width, src.Height, xshear, yshear, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);
        }
    }
}
