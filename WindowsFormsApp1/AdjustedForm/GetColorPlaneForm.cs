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
    public partial class GetColorPlaneForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_取得色彩平面(B,G,R,C,M,Y選一)(圖顯示會是灰色，表示該色彩的量)
        //color：選擇某色彩的切片(B:0,G:1,R:2,C:3,M:4,Y:5和其他 int)
        static extern void getColorPlane(IntPtr src, int width, int height, int color, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        int mode = 0;
        string confirm = "查看原圖", cancel = "還原";

        public GetColorPlaneForm()
        {
            InitializeComponent();
        }

        public GetColorPlaneForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void ChangeIlluminantFromModelForm_Load(object sender, EventArgs e)
        {
            radioButton_B.Tag = 0;
            radioButton_R.Tag = 1;
            radioButton_G.Tag = 2;
            radioButton_C.Tag = 3;
            radioButton_M.Tag = 4;
            radioButton_Y.Tag = 5;
            radioButton_B.Checked = true;
            button1.Text = confirm;
            ImageProssce();
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            mode = (int)(sender as RadioButton).Tag;
            ImageProssce();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap image = pictureBox1.Image as Bitmap;
            Form imageForm = new Form();
            imageForm.Width = image.Width;
            imageForm.Height = image.Height;
            imageForm.BackgroundImage = image;
            imageForm.BackgroundImageLayout = ImageLayout.Zoom;

            imageForm.Show();
        }

        void ImageProssce()
        {
            Mat src = source.Clone();
            getColorPlane(src.Data, src.Width, src.Height, mode, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC1, dst);
            pictureBox1.Image = BitmapConverter.ToBitmap(dstMat);
        }
    }
}
