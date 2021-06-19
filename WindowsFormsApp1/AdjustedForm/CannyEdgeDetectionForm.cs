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
        //lowerThreshold：低於此值就不被選中
        //upperThreshold：高於此值就不被選中
        static extern void cannyEdgeDetection(IntPtr src, int width, int height, int lowerThreshold, int upperThreshold, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float min = 0f, max = 255f, lowerDefault = 0f, upperDefault = 255f;
        string confirm = "應用", cancel = "還原";
        string description = " < 選取範圍 < ";

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
            label_lower.Text = lowerDefault.ToString();
            label_upper.Text = upperDefault.ToString();
            trackBar_lower.Value = AdjustedFormManager.SetTrackBarValue(trackBar_lower.Maximum, max, min, lowerDefault);
            trackBar_upper.Value = AdjustedFormManager.SetTrackBarValue(trackBar_upper.Maximum, max, min, upperDefault);
            label4.Text = label_lower.Text + description + label_upper.Text;

            pictureBox1.Image = ImageProcess();
        }

        private void trackBar_upper_Scroll(object sender, EventArgs e)
        {
            int upperValue = (int)AdjustedFormManager.GetTrackValue(trackBar_upper.Maximum, trackBar_upper.Value, max, min);
            int lowerValue = (int)AdjustedFormManager.GetTrackValue(trackBar_lower.Maximum, trackBar_lower.Value, max, min);

            if (upperValue < lowerValue)
            {
                trackBar_lower.Value = trackBar_upper.Value;
                lowerValue = upperValue;
            }

            label_upper.Text = upperValue.ToString();
            label_lower.Text = lowerValue.ToString();
            label4.Text = label_lower.Text + description + label_upper.Text;
        }

        private void trackBar_lower_Scroll(object sender, EventArgs e)
        {
            int upperValue = (int)AdjustedFormManager.GetTrackValue(trackBar_upper.Maximum, trackBar_upper.Value, max, min);
            int lowerValue = (int)AdjustedFormManager.GetTrackValue(trackBar_lower.Maximum, trackBar_lower.Value, max, min);

            if (lowerValue > upperValue)
            {
                trackBar_upper.Value = trackBar_lower.Value;
                upperValue = lowerValue;
            }

            label_lower.Text = lowerValue.ToString();
            label_upper.Text = upperValue.ToString();
            label4.Text = label_lower.Text + description + label_upper.Text;
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
            int upperValue = (int)AdjustedFormManager.GetTrackValue(trackBar_upper.Maximum, trackBar_upper.Value, max, min);
            int lowerValue = (int)AdjustedFormManager.GetTrackValue(trackBar_lower.Maximum, trackBar_lower.Value, max, min);

            cannyEdgeDetection(src.Data, src.Width, src.Height, lowerValue, upperValue, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);

            return BitmapConverter.ToBitmap(dstMat);
        }

    }
}
