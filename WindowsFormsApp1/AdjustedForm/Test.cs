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
    public partial class Test : Form
    {
        //呼叫c++函式的地方
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void MedianFilter(IntPtr src, int width, int height, int KernelSize);

        Form1 topForm;
        Mat source;

        public Test()
        {
            InitializeComponent();
        }

        public Test(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (topForm == null)
                return;

            Mat destinationImage = source.Clone();
            float value = float.Parse(textBox1.Text);
            destinationImage = testArea(destinationImage, value);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(destinationImage);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (topForm == null)
                return;

            Mat destinationImage = source.Clone();
            float value = (float)trackBar1.Value;
            destinationImage = testArea(destinationImage, value);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(destinationImage);
        }

        private Mat testArea(Mat src, float value)//測試的地方
        {
            //do somethings
            MedianFilter(src.Data, src.Width, src.Height, (int)value);//要是大於1的奇數
            return src;
        }
    }
}
