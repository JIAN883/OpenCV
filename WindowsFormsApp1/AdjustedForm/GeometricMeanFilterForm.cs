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
    public partial class GeometricMeanFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH5_幾何平均濾波器 KernelSize 濾波器kernel = KernelSize * KernelSize (可接受偶數*偶數 不可0*0) 
        static extern void geometricMeanFilter(IntPtr src, int width, int height, int KernelSize, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float max = 10f, min = 1f;
        string confirm = "添加到原圖", cancel = "還原";

        public GeometricMeanFilterForm()
        {
            InitializeComponent();
        }

        public GeometricMeanFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void GeometricMeanFilterForm_Load(object sender, EventArgs e)
        {
            label2.Text = min.ToString();
            button1.Text = confirm;
            pictureBox1.Image = ImageProssce(source.Clone());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int value = (int)AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            label2.Text = value.ToString();
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
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
            int kernelSize = (int)AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            geometricMeanFilter(src.Data, src.Width, src.Height, kernelSize, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            return BitmapConverter.ToBitmap(dstMat);
        }
    }
}
