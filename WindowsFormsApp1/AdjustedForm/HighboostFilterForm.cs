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
    public partial class HighboostFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void HighboostFilter(IntPtr src, int width, int height, float k, out IntPtr dst);

        Form1 topForm;
        Mat source;

        public HighboostFilterForm()
        {
            InitializeComponent();
        }

        public HighboostFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            float value = (float)trackBar1.Value / (float)trackBar1.Maximum * 50f;
            Mat src = source.Clone();
            HighboostFilter(src.Data, src.Width, src.Height, value, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);
        }
    }
}
