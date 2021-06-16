using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace WindowsFormsApp1.AdjustedForm
{
    public partial class BlurForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void Blur(IntPtr src, int width, int height, float value);

        Form1 topForm;
        Mat source;

        public BlurForm()
        {
            InitializeComponent(); 
        }

        public BlurForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
            label2.Text = trackBar1.Minimum.ToString();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();

            Mat destinationImage = source.Clone();
            Blur(destinationImage.Data, destinationImage.Width, destinationImage.Height, (sender as TrackBar).Value);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(destinationImage);
        }
    }
}
