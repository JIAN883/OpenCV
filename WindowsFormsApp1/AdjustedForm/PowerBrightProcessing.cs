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
    public partial class PowerBrightProcessing : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //c ：亮度倍率(>=1,可預設1,float)
        //gamma：指數參數(=1->不變, >1->變暗, <1->變亮,可預設0.5)
        static extern void brightProcessing_power(IntPtr src, int width, int height, float c, float gamma, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float cDefault = 1f, cMax = 50f, cMin = 1f, gammaDefault = 0.5f, gammaMin = -5f, gammaMax = 5f;

        public PowerBrightProcessing()
        {
            InitializeComponent();
        }

        public PowerBrightProcessing(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void PowerBrightProcessing_Load(object sender, EventArgs e)
        {
            cTrackBar.Value = SetTrackBarValue(cTrackBar.Maximum, cMax, cMin, cDefault);
            gammaTrackBar.Value = SetTrackBarValue(gammaTrackBar.Maximum, gammaMax, gammaMin, gammaDefault);
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            float cValue = GetTrackValue(cTrackBar.Maximum, cTrackBar.Value, cMax, cMin);
            float gammaValue = GetTrackValue(gammaTrackBar.Maximum, gammaTrackBar.Value, gammaMax, gammaMin);
            
            Mat src = source.Clone();
            brightProcessing_power(src.Data, src.Width, src.Height, cValue, gammaValue, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);
        }

        int SetTrackBarValue(int trackBarMaximum, float max, float min, float defaultValue)
        {
            return (int)((float)trackBarMaximum / (max - min) * (defaultValue - min));
        }

        float GetTrackValue(int trackBarMaximum, int trackBarValue, float max, float min)
        {
            return (max - min) / (float)trackBarMaximum * (float)trackBarValue + min;
        }

    }
}
