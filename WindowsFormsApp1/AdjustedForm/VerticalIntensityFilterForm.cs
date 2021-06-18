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
    public partial class VerticalIntensityFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void horizontalIntensityFilter(IntPtr src, int width, int height, bool isHorizontal, bool isAddOriImage, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        bool isProcess = true;
        string confirm = "銳化圖片", cancel = "取消銳化圖片";

        public VerticalIntensityFilterForm()
        {
            InitializeComponent();
        }

        public VerticalIntensityFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void VerticalIntensityFilterForm_Load(object sender, EventArgs e)
        {
            Mat src = source.Clone();
            horizontalIntensityFilter(src.Data, src.Width, src.Height, false, false, out IntPtr dst);
            Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            pictureBox1.Image = BitmapConverter.ToBitmap(dstImage);

            button1.Text = confirm;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isProcess)//準備銳化圖片
            {
                Mat src = source.Clone();
                horizontalIntensityFilter(src.Data, src.Width, src.Height, false, true, out IntPtr dst);
                Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);

                isProcess = false;
                button1.Text = cancel;
            }
            else
            {
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);

                isProcess = true;
                button1.Text = confirm;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Image dstImage = pictureBox1.Image;
            Form temp = new Form();
            temp.WindowState = FormWindowState.Maximized;
            temp.BackgroundImage = dstImage;
            temp.BackgroundImageLayout = ImageLayout.Zoom;
            temp.Show();
        }
    }
}
