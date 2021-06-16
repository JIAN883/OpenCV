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
        //k：鈍化倍數 float(>=0)
        static extern void HighboostFilter(IntPtr src, int width, int height, float k, out IntPtr dst);

        Form1 topForm;
        Mat source;
        float min = 0f, max = 50f;

        public HighboostFilterForm()
        {
            InitializeComponent();
        }

        public HighboostFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
            label2.Text = min.ToString();
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            label2.Text = value.ToString();

            Mat src = source.Clone();
            HighboostFilter(src.Data, src.Width, src.Height, value, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);
        }
    }
}
