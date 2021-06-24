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
    public partial class CannyEdgeDetectionForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_canny的邊緣偵測(cannyEdgeDetection)
        //threshold1：呼叫Canny的第一個閥值
        //threshold2：呼叫Canny的第二個閥值 建議比率：threshold1:threshold2 = 3:1 或 2:1
        static extern void cannyEdgeDetection(IntPtr src, int width, int height, int threshold1, int threshold2, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float min = 0f, max = 255f, threshold1Default = 0f, threshold2Default = 0f;
        string confirm = "應用", cancel = "還原";

        public CannyEdgeDetectionForm()
        {
            InitializeComponent();
        }

        public CannyEdgeDetectionForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void CannyEdgeDetectionForm_Load(object sender, EventArgs e)
        {
            label_lower.Text = threshold1Default.ToString();
            label_upper.Text = threshold2Default.ToString();
            trackBar_threshold1.Value = AdjustedFormManager.SetTrackBarValue(trackBar_threshold1.Maximum, max, min, threshold1Default);
            trackBar_threshold2.Value = AdjustedFormManager.SetTrackBarValue(trackBar_threshold2.Maximum, max, min, threshold2Default);

            pictureBox1.Image = ImageProcess();
        }

        private void trackBar_upper_Scroll(object sender, EventArgs e)
        {
            int upperValue = (int)AdjustedFormManager.GetTrackValue(trackBar_threshold2.Maximum, trackBar_threshold2.Value, max, min);
            int lowerValue = (int)AdjustedFormManager.GetTrackValue(trackBar_threshold1.Maximum, trackBar_threshold1.Value, max, min);

            label_upper.Text = upperValue.ToString();
            label_lower.Text = lowerValue.ToString();
        }

        private void trackBar_lower_Scroll(object sender, EventArgs e)
        {
            int upperValue = (int)AdjustedFormManager.GetTrackValue(trackBar_threshold2.Maximum, trackBar_threshold2.Value, max, min);
            int lowerValue = (int)AdjustedFormManager.GetTrackValue(trackBar_threshold1.Maximum, trackBar_threshold1.Value, max, min);

            label_lower.Text = lowerValue.ToString();
            label_upper.Text = upperValue.ToString();
        }

        private void trackBar_upper_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = ImageProcess();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            Form imageForm = new Form();
            imageForm.WindowState = FormWindowState.Maximized;
            imageForm.BackgroundImage = image;
            imageForm.BackgroundImageLayout = ImageLayout.Zoom;
            imageForm.Show();
        }

        Bitmap ImageProcess()
        {
            Mat src = source.Clone();
            int upperValue = (int)AdjustedFormManager.GetTrackValue(trackBar_threshold2.Maximum, trackBar_threshold2.Value, max, min);
            int lowerValue = (int)AdjustedFormManager.GetTrackValue(trackBar_threshold1.Maximum, trackBar_threshold1.Value, max, min);

            cannyEdgeDetection(src.Data, src.Width, src.Height, lowerValue, upperValue, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);

            return BitmapConverter.ToBitmap(dstMat);
        }

    }
}
