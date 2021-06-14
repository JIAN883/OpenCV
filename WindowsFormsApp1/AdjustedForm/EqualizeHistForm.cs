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
    public partial class EqualizeHistForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //mode (int,1->RGB,2->HSV)
        static extern void equalizeHist(IntPtr src, int width, int height, int mode, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;

        public EqualizeHistForm()
        {
            InitializeComponent();
        }

        public EqualizeHistForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            HSVButton.Enabled = !HSVButton.Enabled;
            ProcessImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RGBButton.Enabled = !RGBButton.Enabled;
            ProcessImage();
        }

        private void ProcessImage()
        {
            int mode = 0;

            if (RGBButton.Enabled && !HSVButton.Enabled)
                mode = 1;
            else if (!RGBButton.Enabled && HSVButton.Enabled)
                mode = 2;

            if(mode == 0)
            {
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
                return;
            }

            Mat src = source.Clone();
            equalizeHist(src.Data, src.Width, src.Height, mode, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);
        }
    }
}
