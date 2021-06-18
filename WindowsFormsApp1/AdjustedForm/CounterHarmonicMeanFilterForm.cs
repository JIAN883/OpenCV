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
    public partial class CounterHarmonicMeanFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH5_反調和平均濾波器 KernelSize 濾波器kernel = KernelSize * KernelSize (可接受偶數*偶數 不可0*0) 
        //Q：影響程度(Q>1：解決黑雜點，Q<-1：解決白雜點,可float)
        static extern void counterHarmonicMeanFilter(IntPtr src, int width, int height, int KernelSize, float Q, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float kMax = 10f, kMin = 1f, qMax = 5f, qMin = 1f;
        float qNegativeControl = 1;
        string confirm = "添加到原圖", cancel = "還原";
        string description = "影響程度切換" + Environment.NewLine + "Q > 1：解決黑雜點" + Environment.NewLine + "Q < -1：解決白雜點";

        public CounterHarmonicMeanFilterForm()
        {
            InitializeComponent();
        }

        public CounterHarmonicMeanFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void CounterHarmonicMeanFilterForm_Load(object sender, EventArgs e)
        {
            label1.Text = qMin.ToString();
            label2.Text = kMin.ToString();
            button1.Text = confirm;
            button2.Text = description;
            pictureBox1.Image = ImageProssce(source.Clone());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (qNegativeControl == 1)
                qNegativeControl = -1;
            else
                qNegativeControl = 1;

            float qValue = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, qMax, qMin) * qNegativeControl;
            label1.Text = qValue.ToString();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            float qValue = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, qMax, qMin) * qNegativeControl;
            label1.Text = qValue.ToString();

            int kValue = (int)AdjustedFormManager.GetTrackValue(trackBar2.Maximum, trackBar2.Value, kMax, kMin);
            label2.Text = kValue.ToString();
        }

        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = ImageProssce(source.Clone());
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
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        Bitmap ImageProssce(Mat src)
        {
            int kernelSize = (int)AdjustedFormManager.GetTrackValue(trackBar2.Maximum, trackBar2.Value, kMax, kMin);
            float Q = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, qMax, qMin) * qNegativeControl;
            counterHarmonicMeanFilter(src.Data, src.Width, src.Height, kernelSize, Q, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            return BitmapConverter.ToBitmap(dstMat);
        }
    }
}
