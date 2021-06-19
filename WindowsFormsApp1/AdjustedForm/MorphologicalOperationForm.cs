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
        string confirm = "應用", cancel = "還原";

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
            button1.Text = confirm;
            label3.Text = (trackBar1.Value * 2 + 1).ToString();
            pictureBox1.Image = ImageProcess();
        }

        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = (trackBar1.Value * 2 + 1).ToString();
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = ImageProcess();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = (int)(sender as RadioButton).Tag;
            pictureBox1.Image = ImageProcess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                topForm.pictureBox.Image = pictureBox1.Image.Clone() as Image;
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.ButtonFace;
                button1.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            Form imageForm = new Form();
            imageForm.WindowState = FormWindowState.Maximized;
            imageForm.BackgroundImage = image;
            imageForm.BackgroundImageLayout = ImageLayout.Zoom;
            imageForm.Show();
        }

        Bitmap ImageProcess()
        {
            int size = trackBar1.Value;
            Mat src = source.Clone();
            morphologicalOperation(src.Data, src.Width, src.Height, mode, size, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            return BitmapConverter.ToBitmap(dstMat);
        }

    }
}
