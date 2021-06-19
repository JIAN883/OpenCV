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
    public partial class GetSingleOrMultiColorImageForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_取得單一或多重色彩的圖片(B,G,R間複選，C,M,Y間單選)(可分兩種：BGR一種複選，CMY一種單選) (CMY的話只能一次選一個喔)
        //color：2進制的選擇顯示是否含有該色的平面 4個bit，意義如下：0bit->是否R/Y，1bit->是否G/M，2bit->是否B/C，3bit->是否BGR系統(1->BGR,0->CMY) 
        static extern void getSingleOrMultiColorImage(IntPtr src, int width, int height, int color, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        string confirm = "添加到原圖", cancel = "還原";

        public GetSingleOrMultiColorImageForm()
        {
            InitializeComponent();
        }

        public GetSingleOrMultiColorImageForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void GetSingleOrMultiColorImageForm_Load(object sender, EventArgs e)
        {
            checkBox_R.Tag = 0;
            checkBox_G.Tag = 1;
            checkBox_B.Tag = 2;

            radioButton_Y.Tag = 0;
            radioButton_M.Tag = 1;
            radioButton_C.Tag = 2;

            radioButton_C.Checked = true;
            button3.Text = confirm;
            button4.Text = confirm;
            pictureBox1.Image = BitmapConverter.ToBitmap(source);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            int count = (int)Math.Pow(2, 3);
            if (checkBox_B.Checked)
                count += (int)Math.Pow(2, (int)(checkBox_B.Tag));
            if (checkBox_G.Checked)
                count += (int)Math.Pow(2, (int)(checkBox_G.Tag));
            if (checkBox_R.Checked)
                count += (int)Math.Pow(2, (int)(checkBox_R.Tag));

            ImagePorcess(count);
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (radioButton_Y.Checked)
                count += (int)Math.Pow(2, (int)(radioButton_Y.Tag));
            if (radioButton_M.Checked)
                count += (int)Math.Pow(2, (int)(radioButton_M.Tag));
            if (radioButton_C.Checked)
                count += (int)Math.Pow(2, (int)(radioButton_C.Tag));

            ImagePorcess(count);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text.Equals(confirm))
            {
                button.Text = cancel;
                button.BackColor = Color.Black;
                button.ForeColor = Color.White;
                topForm.pictureBox.Image = pictureBox1.Image.Clone() as Image;
            }
            else
            {
                button.Text = confirm;
                button.BackColor = SystemColors.ButtonFace;
                button.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image showImage = pictureBox1.Image;

            Form imageForm = new Form();
            imageForm.WindowState = FormWindowState.Maximized;
            imageForm.BackgroundImage = showImage;
            imageForm.BackgroundImageLayout = ImageLayout.Zoom;
            imageForm.Show();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedTab.Equals(tabPage1))
                checkBox_CheckedChanged(sender, e);
            else
                radioButton_Click(sender, e);

        }

        void ImagePorcess(int mode)
        {
            Mat src = source.Clone();
            getSingleOrMultiColorImage(src.Data, src.Width, src.Height, mode, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            pictureBox1.Image = BitmapConverter.ToBitmap(dstMat);
        }

    }
}
