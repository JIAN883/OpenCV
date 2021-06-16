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
        string confirm = "應用", cancel = "還原", openForm = "預覽";

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
            splitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text.Equals(confirm))
            {
                (sender as Button).Text = cancel;
                (sender as Button).BackColor = Color.Black;
                (sender as Button).ForeColor = Color.White;
                topForm.pictureBox.Image = ImageProssce();
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
            Image tempImage = ImageProssce();

            splitContainer1.Panel1.BackgroundImage = tempImage;
        }

        Image ImageProssce()
        {
            int x = 0, z = 0;
            try
            {
                x = int.Parse(textBox1.Text);
                z = int.Parse(textBox2.Text);
            }
            catch { }
            Mat src = source.Clone();
            changeIlluminantFromCustomizeXZ(src.Data, src.Width, src.Height, x, z, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            return BitmapConverter.ToBitmap(dstMat);
        }
    }
}
