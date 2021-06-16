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
    public partial class ThresholdProcessingForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //thresh：閥值條件 (0~254,可預設127)
        //maxval：觸發閥值後設定的值 (0~254 可預設255)
        static extern void thresholdProcessing(IntPtr src, int width, int height, double thresh, double maxval);

        Form1 topForm;
        Mat source;
        float threshMin = 0f, threshMax = 254f, threshDefault = 127f, maxvalMin = 0f, maxvalMax = 254f, maxvalDefault = 254f;
        string confirm = "應用", cancel = "還原";

        public ThresholdProcessingForm()
        {
            InitializeComponent();
        }

        public ThresholdProcessingForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void ThresholdProcessingForm_Load(object sender, EventArgs e)
        {
            trackBarThresh.Value = AdjustedFormManager.SetTrackBarValue(trackBarThresh.Maximum, threshMax, threshMin, threshDefault);
            trackBarMaxval.Value = AdjustedFormManager.SetTrackBarValue(trackBarMaxval.Maximum, maxvalMax, maxvalMin, maxvalDefault);

            label2.Text = threshDefault.ToString();
            label4.Text = maxvalDefault.ToString();

            splitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Text = confirm;
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1.BackgroundImage = ImageProcess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                topForm.pictureBox.Image = ImageProcess();

                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
            }
            else
            {
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);

                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
            }
        }

        Bitmap ImageProcess()
        {
            double thresh = AdjustedFormManager.GetTrackValue(trackBarThresh.Maximum, trackBarThresh.Value, threshMax, threshMin);
            double maxval = AdjustedFormManager.GetTrackValue(trackBarMaxval.Maximum, trackBarMaxval.Value, maxvalMax, maxvalMin);
            label2.Text = ((float)thresh).ToString();
            label4.Text = ((float)maxval).ToString();

            Mat src = source.Clone();
            thresholdProcessing(src.Data, src.Width, src.Height, thresh, maxval);
            return BitmapConverter.ToBitmap(src);
        }

    }
}
