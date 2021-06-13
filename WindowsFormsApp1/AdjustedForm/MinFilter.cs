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
    public partial class MinFilter : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void MaxOrMinFilter(IntPtr src, int width, int height, int mode, float KernelSize);

        Form1 topForm;
        Mat source;

        public MinFilter()
        {
            InitializeComponent();
        }

        public MinFilter(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (topForm == null)
                return;

            Mat dst = source.Clone();
            MaxOrMinFilter(dst.Data, dst.Width, dst.Height, 1, trackBar1.Value);

            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dst);
        }
    }
}
