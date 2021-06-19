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
    public partial class ColorSlicingForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_取得彩色切片(colorSlicing)
        //lowerH、lowerS、lowerV：取色彩範圍的下界(低於此的HSV不會被抓取)
        //upperH、upperS、upperV：取色彩範圍的上界(高於此的HSV不會被抓取)
        static extern void colorSlicing(IntPtr src, int width, int height, int lowerH, int lowerS, int lowerV, int upperH, int upperS, int upperV, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float min = 0f, max = 255f, defaule_lower = 0f, default_upper = 255f;
        string confirm = "應用", cancel = "還原";

        public ColorSlicingForm()
        {
            InitializeComponent();
        }

        public ColorSlicingForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void ColorSlicingForm_Load(object sender, EventArgs e)
        {
            //綁定tag
            trackBar_HLower.Tag = trackBar_HUpper;
            trackBar_HUpper.Tag = trackBar_HLower;
            trackBar_SLower.Tag = trackBar_SUpper;
            trackBar_SUpper.Tag = trackBar_SLower;
            trackBar_VLower.Tag = trackBar_VUpper;
            trackBar_VUpper.Tag = trackBar_VLower;

            //設定trackBar初始值
            trackBar_HLower.Value = AdjustedFormManager.SetTrackBarValue(trackBar_HLower.Maximum, max, min, defaule_lower);
            trackBar_SLower.Value = AdjustedFormManager.SetTrackBarValue(trackBar_SLower.Maximum, max, min, defaule_lower);
            trackBar_VLower.Value = AdjustedFormManager.SetTrackBarValue(trackBar_VLower.Maximum, max, min, defaule_lower);
            trackBar_HUpper.Value = AdjustedFormManager.SetTrackBarValue(trackBar_HUpper.Maximum, max, min, default_upper);
            trackBar_SUpper.Value = AdjustedFormManager.SetTrackBarValue(trackBar_SUpper.Maximum, max, min, default_upper);
            trackBar_VUpper.Value = AdjustedFormManager.SetTrackBarValue(trackBar_VUpper.Maximum, max, min, default_upper);

            pictureBox1.Image = ImageProcess();
            button1.Text = confirm;
            UpdataLabel();
        }

        private void trackBar_upper_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar_upper = sender as TrackBar;
            TrackBar trackBar_lower = trackBar_upper.Tag as TrackBar;

            int upperValue = (int)AdjustedFormManager.GetTrackValue(trackBar_upper.Maximum, trackBar_upper.Value, max, min);
            int lowerValue = (int)AdjustedFormManager.GetTrackValue(trackBar_lower.Maximum, trackBar_lower.Value, max, min);

            if (upperValue < lowerValue)
            {
                trackBar_lower.Value = trackBar_upper.Value;
                lowerValue = upperValue;
            }

            UpdataLabel();
        }

        private void trackBar_lower_Scroll(object sender, EventArgs e)//處理字串
        {
            TrackBar trackBar_lower = sender as TrackBar;
            TrackBar trackBar_upper = trackBar_lower.Tag as TrackBar;

            int upperValue = (int)AdjustedFormManager.GetTrackValue(trackBar_upper.Maximum, trackBar_upper.Value, max, min);
            int lowerValue = (int)AdjustedFormManager.GetTrackValue(trackBar_lower.Maximum, trackBar_lower.Value, max, min);

            if (lowerValue > upperValue)
            {
                trackBar_upper.Value = trackBar_lower.Value;
                upperValue = lowerValue;
            }

            UpdataLabel();
        }

        private void trackBar_HLower_MouseUp(object sender, MouseEventArgs e)
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
            Image image = pictureBox1.Image; ;
            Form imageForm = new Form();
            imageForm.WindowState = FormWindowState.Maximized;
            imageForm.BackgroundImage = image;
            imageForm.BackgroundImageLayout = ImageLayout.Zoom;
            imageForm.Show();
        }

        Bitmap ImageProcess()
        {
            Mat src = source.Clone();
            GetData(out int upperH, out int lowerH, out int upperS, out int lowerS, out int upperV, out int lowerV);
            colorSlicing(src.Data, src.Width, src.Height, lowerH, lowerS, lowerV, upperH, upperS, upperV, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            return BitmapConverter.ToBitmap(dstMat);
        }

        void GetData(out int upperH, out int lowerH, out int upperS, out int lowerS, out int upperV, out int lowerV)
        {
            lowerH = (int)AdjustedFormManager.GetTrackValue(trackBar_HLower.Maximum, trackBar_HLower.Value, max, min);
            lowerS = (int)AdjustedFormManager.GetTrackValue(trackBar_SLower.Maximum, trackBar_SLower.Value, max, min);
            lowerV = (int)AdjustedFormManager.GetTrackValue(trackBar_VLower.Maximum, trackBar_VLower.Value, max, min);
            upperH = (int)AdjustedFormManager.GetTrackValue(trackBar_HUpper.Maximum, trackBar_HUpper.Value, max, min);
            upperS = (int)AdjustedFormManager.GetTrackValue(trackBar_SUpper.Maximum, trackBar_SUpper.Value, max, min);
            upperV = (int)AdjustedFormManager.GetTrackValue(trackBar_VUpper.Maximum, trackBar_VUpper.Value, max, min);
        }

        void UpdataLabel()
        {
            GetData(out int upperH, out int lowerH, out int upperS, out int lowerS, out int upperV, out int lowerV);
            label_HRange.Text = lowerH.ToString() + " < 選取範圍 < " + upperH.ToString();
            label_SRange.Text = lowerS.ToString() + " < 選取範圍 < " + upperS.ToString();
            label_VRange.Text = lowerV.ToString() + " < 選取範圍 < " + upperV.ToString();
        }

    }
}
