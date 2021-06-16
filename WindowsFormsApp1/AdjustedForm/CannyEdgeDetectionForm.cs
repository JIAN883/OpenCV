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
            splitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int high = 0, low = 0;
            try
            {
                high = int.Parse(textBox_High.Text);
                low = int.Parse(textBox_Low.Text);
            }
            catch { }
            if (high < low)
                SwitchTextBoxContent(textBox_High, textBox_Low, out high, out low);

            Mat src = source.Clone();
            cannyEdgeDetection(src.Data, src.Width, src.Height, low, high, out IntPtr dst);
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

        void SwitchTextBoxContent(TextBox a, TextBox b, out int aValue, out int bValue)
        {
            aValue = 0;
            bValue = 0;
            string temp = a.Text;
            a.Text = b.Text;
            b.Text = temp;

            try
            {
                aValue = int.Parse(a.Text);
                bValue = int.Parse(b.Text);
            }
            catch { }
        }

    }
}
