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
    public partial class ThresholdProcessingForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //thresh：閥值條件 (0~254,可預設127)
        //maxval：觸發閥值後設定的值 (0~254 可預設255)
        static extern void thresholdProcessing(IntPtr src, int width, int height, double thresh, double maxval);

        Form1 topForm;
        bool isProcess = true;
        Mat source;
        string confirm = "銳化圖片", cancel = "取消銳化圖片";

        public ThresholdProcessingForm()
        {
            InitializeComponent();
        }

        public ThresholdProcessingForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void ThresholdProcessingForm_Load(object sender, EventArgs e)
        {
            trackBarThresh.Value = (int)(127d / 254d * (double)trackBarThresh.Maximum);
            trackBarMaxval.Value = trackBarMaxval.Maximum;
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            double thresh = (double)trackBarThresh.Value / (double)trackBarThresh.Maximum * 254d;
            double maxval = (double)trackBarMaxval.Value / (double)trackBarMaxval.Maximum * 254d;

            Mat src = source.Clone();
            thresholdProcessing(src.Data, src.Width, src.Height, thresh, maxval);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(src);
        }
    }
}
