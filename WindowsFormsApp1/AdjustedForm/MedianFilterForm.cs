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
    public partial class MedianFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void MedianFilter(IntPtr src, int width, int height, int KernelSize);

        Form1 topForm;
        Mat source;

        public MedianFilterForm()
        {
            InitializeComponent();
        }

        public MedianFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (topForm == null)
                return;

            Mat destinationImage = source.Clone();
            //ksize必须大于1且是奇数
            int kernelSize = 1 + (sender as TrackBar).Value * 2;
            MedianFilter(destinationImage.Data, destinationImage.Width, destinationImage.Height, kernelSize);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(destinationImage);
        }
    }
}
