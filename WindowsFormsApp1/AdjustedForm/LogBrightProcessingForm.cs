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
        float max = 10f, min = 1f, defaultValue = 2f;

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
            trackBar1.Value = AdjustedFormManager.SetTrackBarValue(trackBar1.Maximum, max, min, defaultValue);
            label1.Text = min.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            label1.Text = value.ToString();

            Mat src = source.Clone();
            brightProcessing_log(src.Data, src.Width, src.Height, value, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);
        }
    }
}
