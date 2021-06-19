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
    public partial class RotateForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void Rotate(IntPtr src, int width, int height, double angle, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float min = 0f, max = 360f;
        string confirm = "應用", cancel = "還原";

        public RotateForm()
        {
            InitializeComponent();
        }

        public RotateForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
            button1.Text = confirm;
        }

        private void RotateForm_Load(object sender, EventArgs e)
        {
            button1.Text = confirm;
            label2.Text = min.ToString();
            ImageProcess();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            label2.Text = value.ToString();
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
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

                topForm.pictureBox.Image = pictureBox1.Image.Clone() as Image;
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.ButtonFace;
                button1.ForeColor = SystemColors.ControlText;

                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        void ImageProcess()
        {
            float angle = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            Mat src = source.Clone();
            Rotate(src.Data, src.Width, src.Height, angle, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            pictureBox1.Image = BitmapConverter.ToBitmap(dstImage);
        }

    }
}
