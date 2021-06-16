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
        float d0max = 10f, d0min = 1f, nmax = 5f, nmin = 1f;

        string confirm = "確定", cancel = "還原";

        public ColorSlicingForm()
        {
            InitializeComponent();
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

        public ColorSlicingForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void ColorSlicingForm_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int h_high = 0, h_low = 0, s_high = 0, s_low = 0, v_high = 0, v_low = 0;
            try
            {
                h_high = int.Parse(textBox_HHigh.Text);
                h_low = int.Parse(textBox_HLow.Text);
                s_high = int.Parse(textBox_SHigh.Text);
                s_low = int.Parse(textBox_SLow.Text);
                v_high = int.Parse(textBox_VHigh.Text);
                v_low = int.Parse(textBox_VLow.Text);
            }
            catch { }
            if (h_high < h_low)
                SwitchTextBoxContent(textBox_HHigh, textBox_HLow, out h_high, out h_low);
            if (s_high < s_low)
                SwitchTextBoxContent(textBox_SHigh, textBox_SLow, out s_high, out s_low);
            if (v_high < v_low)
                SwitchTextBoxContent(textBox_VHigh, textBox_VLow, out v_high, out v_low);

            Mat src = source.Clone();
            colorSlicing(src.Data, src.Width, src.Height, h_low, s_low, v_low, h_high, s_high, v_high, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            Bitmap dstImage = BitmapConverter.ToBitmap(dstMat);

            splitContainer1.Panel1.BackgroundImage = dstImage;
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
