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
    public partial class ReflectForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //isReflectAboutXaxis：true->上下鏡射 false->不上下鏡射
        //isReflectAboutYaxis：true->左右鏡射 false->不左右鏡射
        static extern void Reflect(IntPtr src, int width, int height, bool isReflectAboutXaxis, bool isReflectAboutYaxis, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        bool isReflectAboutXaxis = false, isReflectAboutYaxis = false;

        public ReflectForm()
        {
            InitializeComponent();
        }

        public ReflectForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void horizontalButton_Click(object sender, EventArgs e)
        {
            isReflectAboutYaxis = !isReflectAboutYaxis;

            if (isReflectAboutYaxis)
            {
                (sender as Button).BackColor = Color.Black;
                (sender as Button).ForeColor = Color.White;
            }
            else
            {
                (sender as Button).BackColor = SystemColors.Control;
                (sender as Button).ForeColor = SystemColors.ControlText;
            }

            ImageReflect();
        }

        private void verticalButton_Click(object sender, EventArgs e)
        {
            isReflectAboutXaxis = !isReflectAboutXaxis;

            if (isReflectAboutXaxis)
            {
                (sender as Button).BackColor = Color.Black;
                (sender as Button).ForeColor = Color.White;
            }
            else
            {
                (sender as Button).BackColor = SystemColors.Control;
                (sender as Button).ForeColor = SystemColors.ControlText;
            }

            ImageReflect();
        }

        void ImageReflect()
        {
            Mat src = source.Clone();
            Reflect(src.Data, src.Width, src.Height, isReflectAboutXaxis, isReflectAboutYaxis, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);
        }

    }
}
