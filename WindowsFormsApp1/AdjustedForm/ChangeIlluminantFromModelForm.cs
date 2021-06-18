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
    public partial class ChangeIlluminantFromModelForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_改變光源(從固定幾個光源挑) changeIlluminantFromModel
        //mode：模式 (0->ILL_A，1->ILL_D50，2->ILL_D55，3->ILL_D65，其他->ILL_D75)
        static extern void changeIlluminantFromModel(IntPtr src, int width, int height, int mode, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        int mode = 0;
        string confirm = "應用", cancel = "還原";

        public ChangeIlluminantFromModelForm()
        {
            InitializeComponent();
        }

        public ChangeIlluminantFromModelForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void ChangeIlluminantFromModelForm_Load(object sender, EventArgs e)
        {
            radioButton_ILL_A.Tag = 0;
            radioButton_ILL_D50.Tag = 1;
            radioButton_ILL_D55.Tag = 2;
            radioButton_ILL_D65.Tag = 3;
            radioButton_ILL_D75.Tag = 4;
            radioButton_ILL_A.Checked = true;
            button1.Text = confirm;
            splitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
            splitContainer1.Panel1.BackgroundImage = ImageProssce();
        }

        private void radioButton_ILL_A_Click(object sender, EventArgs e)
        {
            mode = (int)(sender as RadioButton).Tag;
            splitContainer1.Panel1.BackgroundImage = ImageProssce();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                topForm.pictureBox.Image = ImageProssce();
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1.BackgroundImage == null)
                return;

            Image image = splitContainer1.Panel1.BackgroundImage;
            Form imageForm = new Form();
            imageForm.WindowState = FormWindowState.Maximized;
            imageForm.BackgroundImage = image;
            imageForm.BackgroundImageLayout = ImageLayout.Zoom;
            imageForm.Show();
        }

        Bitmap ImageProssce()
        {
            Mat src = source.Clone();
            changeIlluminantFromModel(src.Data, src.Width, src.Height, mode, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            Bitmap dstBitmap = BitmapConverter.ToBitmap(dstMat);
            return dstBitmap;
        }

    }
}
