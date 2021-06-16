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
    public partial class IdeaPassFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //isIdeal：true->理想濾波器,false->高斯濾波器
        //isHighPass：true->高通,false->低通
        //d0：影響大小參數 (int 最小0)
        //isAddOri：true->最後再加上原圖，false->純粹顯示濾波後的圖片
        static extern void idealOrGaussianPassFilter(IntPtr src, int width, int height, bool isIdeal, bool isHighPass, int d0, bool isAddOri, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float max = 10f, min = 1f;
        string confirm = "添加到原圖", cancel = "還原";

        public IdeaPassFilterForm()
        {
            InitializeComponent();
        }

        public IdeaPassFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void IdeaPassFilterForm_Load(object sender, EventArgs e)
        {
            checkBoxHighPass.Checked = true;
            textBox1.Text = "0";
            splitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Text = confirm;
            ImageProssce(false);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxLowPass.Checked = !checkBoxHighPass.Checked;
            ImageProssce(false);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHighPass.Checked = !checkBoxLowPass.Checked;
            ImageProssce(false);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            textBox1.Text = value.ToString();

            ImageProssce(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float value = float.Parse(textBox1.Text);
                trackBar1.Value = AdjustedFormManager.SetTrackBarValue(trackBar1.Maximum, max, min, value);
            }
            catch { }

            ImageProssce(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                ImageProssce(true);
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        void ImageProssce(bool isAddOri)
        {
            bool isHighPass = false;
            int value = (int)AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            Mat src = source.Clone();
            if (checkBoxHighPass.Checked)
                isHighPass = true;

            idealOrGaussianPassFilter(src.Data, src.Width, src.Height, true, isHighPass, value, isAddOri, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            Bitmap dstImage = BitmapConverter.ToBitmap(dstMat);

            if (isAddOri)
                topForm.pictureBox.Image = dstImage;
            else
                splitContainer1.Panel1.BackgroundImage = dstImage;
        }
    }
}
