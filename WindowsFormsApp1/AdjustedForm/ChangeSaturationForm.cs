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
    public partial class ChangeSaturationForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_調整飽和度
        //rate：飽和度倍數 (double) 
        static extern void changeSaturation(IntPtr src, int width, int height, double rate, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float max = 10f, min = 0f;
        string confirm = "應用", cancel = "還原";

        public ChangeSaturationForm()
        {
            InitializeComponent();
        }

        public ChangeSaturationForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void AdaptiveMedianFilter_BGRForm_Load(object sender, EventArgs e)
        {
            label2.Text = min.ToString();
            button1.Text = confirm;
            pictureBox1.Image = ImageProssce();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            label2.Text = value.ToString();
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = ImageProssce();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                topForm.pictureBox.Image = ImageProssce();
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        Bitmap ImageProssce()
        {
            double rate = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            Mat src = source.Clone();
            changeSaturation(src.Data, src.Width, src.Height, rate, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            return BitmapConverter.ToBitmap(dstMat);
        }
    }
}
