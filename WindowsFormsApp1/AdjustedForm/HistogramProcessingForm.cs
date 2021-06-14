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
    public partial class HistogramProcessingForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void HistogramProcessing(IntPtr src, int width, int height, out IntPtr dstBufferB, out IntPtr dstBufferG, out IntPtr dstBufferR);

        Form1 topForm;
        Mat source;
        Bitmap dstImage;

        public HistogramProcessingForm()
        {
            InitializeComponent();
        }

        public HistogramProcessingForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void HistogramProcessingForm_Load(object sender, EventArgs e)
        {
            Mat src = source.Clone();
            HistogramProcessing(src.Data, src.Width, src.Height, out IntPtr dstB, out IntPtr dstG, out IntPtr dstR);
            Mat dstRImage = new Mat(400, 512, MatType.CV_8U, dstR);
            Mat dstGImage = new Mat(400, 512, MatType.CV_8U, dstG);
            Mat dstBImage = new Mat(400, 512, MatType.CV_8U, dstB);

            pictureBox1.Image = BitmapConverter.ToBitmap(dstRImage);
            pictureBox2.Image = BitmapConverter.ToBitmap(dstGImage);
            pictureBox3.Image = BitmapConverter.ToBitmap(dstBImage);
        }
    }
}
