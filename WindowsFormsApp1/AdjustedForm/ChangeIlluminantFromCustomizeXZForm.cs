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
    public partial class ChangeIlluminantFromCustomizeXZForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_改變光源(自己選X,Z值) changeIlluminantFromCustomizeXZ
        //x：x刺激值
        //z：z刺激值
        static extern void changeIlluminantFromCustomizeXZ(IntPtr src, int width, int height, int x, int z, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        string confirm = "添加到原圖", cancel = "還原", openForm = "打開圖片選擇光源位置";

        public ChangeIlluminantFromCustomizeXZForm()
        {
            InitializeComponent();
        }

        public ChangeIlluminantFromCustomizeXZForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void ChangeIlluminantFromCustomizeXZForm_Load(object sender, EventArgs e)
        {
            button1.Text = openForm;
            button2.Text = confirm;
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text.Equals(confirm))
            {
                (sender as Button).Text = cancel;
                (sender as Button).BackColor = Color.Black;
                (sender as Button).ForeColor = Color.White;
                ImageProssce();
            }
            else
            {
                (sender as Button).Text = confirm;
                (sender as Button).BackColor = SystemColors.Control;
                (sender as Button).ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap tempImage = BitmapConverter.ToBitmap(source);

            Form tempForm = new Form();
            tempForm.Text = "請點一下滑鼠來選擇一點";
            tempForm.Width = tempImage.Width / 2;
            tempForm.Height = tempImage.Height / 2;
            tempForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            tempForm.MaximizeBox = false;
            tempForm.MinimizeBox = false;
            tempForm.BackgroundImage = tempImage;
            tempForm.BackgroundImageLayout = ImageLayout.Stretch;
            tempForm.MouseClick += new MouseEventHandler(GetPoint);
            tempForm.Show();
        }

        void GetPoint(object sender, MouseEventArgs e)
        {
            textBox1.Text = (e.X * 2).ToString();
            textBox2.Text = (e.Y * 2).ToString();
        }

        void ImageProssce()
        {
            int x = int.Parse(textBox1.Text);
            int z = int.Parse(textBox2.Text);
            Mat src = source.Clone();
            changeIlluminantFromCustomizeXZ(src.Data, src.Width, src.Height, x, z, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstMat);
        }
    }
}
