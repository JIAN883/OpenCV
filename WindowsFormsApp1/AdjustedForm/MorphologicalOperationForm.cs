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
    public partial class MorphologicalOperationForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_morphologyEx的影像處理(morphologicalOperation)
        //mode：選擇morphologyEx的模式(0：Dilation, 1：Erosion, 2：gradient, 3：Open, 4：Close, 5：Top Hat, 6與其他：Black Hat)
        //size：kernel是幾乘幾 (真實kernel大小=2*size+1)
        static extern void morphologicalOperation(IntPtr src, int width, int height, int mode, int size, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        int mode = 0;

        public MorphologicalOperationForm()
        {
            InitializeComponent();
        }

        public MorphologicalOperationForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void MorphologicalOperationForm_Load(object sender, EventArgs e)
        {
            radioButton_Dilation.Tag = 0;
            radioButton_Erosion.Tag = 1;
            radioButton_gradient.Tag = 2;
            radioButton_Open.Tag = 3;
            radioButton_Close.Tag = 4;
            radioButton_TopHat.Tag = 5;
            radioButton_BlackHat.Tag = 6;

            radioButton_Dilation.Checked = true;
            label3.Text = (trackBar1.Value * 2 + 1).ToString();
            splitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = (trackBar1.Value * 2 + 1).ToString();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = (int)(sender as RadioButton).Tag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = trackBar1.Value;
            Mat src = source.Clone();
            morphologicalOperation(src.Data, src.Width, src.Height, mode, size, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            Bitmap dstImage = BitmapConverter.ToBitmap(dstMat);

            splitContainer1.Panel1.BackgroundImage = dstImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1.BackgroundImage == null)
                return;

            Image image = splitContainer1.Panel1.BackgroundImage;
            Form imageForm = new Form();
            imageForm.Width = image.Width;
            imageForm.Height = image.Height;
            imageForm.BackgroundImage = image;
            imageForm.BackgroundImageLayout = ImageLayout.Zoom;
            imageForm.Show();
        }
    }
}
