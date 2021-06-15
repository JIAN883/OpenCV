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
    public partial class LogBrightProcessingForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //c ：亮度倍率(>1,可預設2,float)
        static extern void brightProcessing_log(IntPtr src, int width, int height, float c, out IntPtr dst);

        Form1 topForm;
        Mat source;
        float max = 20, defaultValue = 2;

        public LogBrightProcessingForm()
        {
            InitializeComponent();
        }

        public LogBrightProcessingForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void LogBrightProcessingForm_Load(object sender, EventArgs e)
        {
            trackBar1.Value = (int)(defaultValue / max * (float)trackBar1.Maximum);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float value = (float)trackBar1.Value / (float)trackBar1.Maximum * max;
            Mat src = source.Clone();
            brightProcessing_log(src.Data, src.Width, src.Height, value, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);
        }
    }
}
