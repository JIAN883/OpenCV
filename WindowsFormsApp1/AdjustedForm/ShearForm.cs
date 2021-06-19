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
    public partial class ShearForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //xshear ：水平剪形程度 (double)
        //yshear ：垂直剪形程度 (double)
        static extern void Shear(IntPtr src, int width, int height, double xshear, double yshear, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float xshearMin = 0f, xshearMax = 5f, yshearMin = 0f, yshearMax = 5f;
        string confirm = "應用", cancel = "還原";

        public ShearForm()
        {
            InitializeComponent();
        }

        public ShearForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
            button1.Text = confirm;
        }

        private void ShearForm_Load(object sender, EventArgs e)
        {
            label2.Text = xshearMin.ToString();
            label4.Text = yshearMin.ToString();
            button1.Text = confirm;

            ImageProcess();
        }

        private void trackBar_xshear_Scroll(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar_xshear.Maximum, trackBar_xshear.Value, xshearMax, xshearMin);
            label2.Text = value.ToString();
        }

        private void trackBar_yshear_Scroll(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar_yshear.Maximum, trackBar_yshear.Value, yshearMax, yshearMin);
            label4.Text = value.ToString();
        }

        private void trackBarThresh_MouseUp(object sender, MouseEventArgs e)
        {
            ImageProcess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;

                topForm.pictureBox.Image = pictureBox1.Image;
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;

                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        void ImageProcess()
        {
            Mat src = source.Clone();
            double xshear = AdjustedFormManager.GetTrackValue(trackBar_xshear.Maximum, trackBar_xshear.Value, xshearMax, xshearMin);
            double yshear = AdjustedFormManager.GetTrackValue(trackBar_yshear.Maximum, trackBar_yshear.Value, yshearMax, yshearMin);
            Shear(src.Data, src.Width, src.Height, xshear, yshear, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            pictureBox1.Image = BitmapConverter.ToBitmap(dstImage);
        }
    }
}
