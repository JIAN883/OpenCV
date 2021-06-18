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
    public partial class MaxFilter : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void MaxOrMinFilter(IntPtr src, int width, int height, int mode, int KernelSize, out IntPtr dst);

        Form1 topForm;
        Mat source;

        public MaxFilter()
        {
            InitializeComponent();
        }

        public MaxFilter(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
            label2.Text = trackBar1.Minimum.ToString();
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            Mat src = source.Clone();
            MaxOrMinFilter(src.Data, src.Width, src.Height, 0, trackBar1.Value, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);
        }
    }
}
