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
    public partial class GetFrequencyDomainInformationForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void getFrequencyDomainInformation(IntPtr src, int width, int height, out IntPtr dstBufferB, out IntPtr dstBufferG, out IntPtr dstBufferR);

        Form1 topForm;
        Mat source;
        Bitmap dstImage;

        public GetFrequencyDomainInformationForm()
        {
            InitializeComponent();
        }

        public GetFrequencyDomainInformationForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void GetFrequencyDomainInformationForm_Load(object sender, EventArgs e)
        {
            Mat src = source.Clone();
            getFrequencyDomainInformation(src.Data, src.Width, src.Height, out IntPtr dstB, out IntPtr dstG, out IntPtr dstR);
            Mat dstRImage = new Mat(src.Height, src.Width, MatType.CV_8UC1, dstR);
            Mat dstGImage = new Mat(src.Height, src.Width, MatType.CV_8UC1, dstG);
            Mat dstBImage = new Mat(src.Height, src.Width, MatType.CV_8UC1, dstB);

            pictureBox1.Image = BitmapConverter.ToBitmap(dstRImage);
            pictureBox2.Image = BitmapConverter.ToBitmap(dstGImage);
            pictureBox3.Image = BitmapConverter.ToBitmap(dstBImage);
        }
    }
}
