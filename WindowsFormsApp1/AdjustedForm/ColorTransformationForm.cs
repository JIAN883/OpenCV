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
    public partial class ColorTransformationForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_色彩轉換(colorTransformation)
        //k：newBGR=BGR*k (k倍於原本色彩)
        static extern void changeIlluminantFromModel(IntPtr src, int width, int height, float k, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float max = 10f, min = 1f;
        string confirm = "添加到原圖", cancel = "還原";

        public ColorTransformationForm()
        {
            InitializeComponent();
        }

        public ColorTransformationForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void ColorTransformationForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            button1.Text = confirm;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int value = (int)AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            textBox1.Text = value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = int.Parse(textBox1.Text);
                trackBar1.Value = AdjustedFormManager.SetTrackBarValue(trackBar1.Maximum, max, min, value);
            }
            catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                ImageProssce();
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        void ImageProssce()
        {
            int kernelSize = (int)AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            Mat src = source.Clone();
            changeIlluminantFromModel(src.Data, src.Width, src.Height, kernelSize, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstMat);
        }
    }
}
