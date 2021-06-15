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
    public partial class ButterworthPassFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //isHighPass：true->高通,false->低通
        //d0：影響大小參數 (int,最小0)
        //n：影響大小參數 (float,1->不變,動一些就差很多)
        //isAddOri：true->最後再加上原圖，false->純粹顯示濾波後的圖片
        static extern void butterworthPassFilter(IntPtr src, int width, int height, bool isHighPass, int d0, float n, bool isAddOri, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float d0max = 10f, d0min = 0f, nmax = 5f, nmin = 1f;
        string confirm = "添加到原圖", cancel = "還原";

        public ButterworthPassFilterForm()
        {
            InitializeComponent();
        }

        public ButterworthPassFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void ButterworthPassFilterForm_Load(object sender, EventArgs e)
        {
            checkBoxHighPass.Checked = true;
            textBox_d0.Text = d0min.ToString();
            textBox_n.Text = nmin.ToString();
            button1.Text = confirm;
            ImagePorcess(false);
        }

        private void checkBoxHighPass_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxLowPass.Checked = !checkBoxHighPass.Checked;
            ImagePorcess(false);
        }

        private void checkBoxLowPass_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHighPass.Checked = !checkBoxLowPass.Checked;
            ImagePorcess(false);
        }

        private void trackBar_n_Scroll(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar_n.Maximum, trackBar_n.Value, nmax, nmin);
            textBox_n.Text = value.ToString();
            ImagePorcess(false);
        }

        private void textBox1_n_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float value = float.Parse(textBox_n.Text);
                trackBar_n.Value = AdjustedFormManager.SetTrackBarValue(trackBar_n.Maximum, nmax, nmin, value);
            }
            catch { }
            ImagePorcess(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
            ImagePorcess(true);
        }

        private void trackBar2_d0_Scroll(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar_d0.Maximum, trackBar_d0.Value, d0max, d0min);
            textBox_d0.Text = value.ToString();
            ImagePorcess(false);
        }

        private void textBox2_d0_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float value = float.Parse(textBox_d0.Text);
                trackBar_d0.Value = AdjustedFormManager.SetTrackBarValue(trackBar_d0.Maximum, d0max, d0min, value);
            }
            catch { }
            ImagePorcess(false);
        }

        void ImagePorcess(bool isAddOri)
        {
            bool isHighPass = false;
            int d0 = (int)AdjustedFormManager.GetTrackValue(trackBar_d0.Maximum, trackBar_d0.Value, d0max, d0min);
            float n = AdjustedFormManager.GetTrackValue(trackBar_n.Maximum, trackBar_n.Value, nmax, nmin);
            Mat src = source.Clone();
            if (checkBoxHighPass.Checked)
                isHighPass = true;

            butterworthPassFilter(src.Data, src.Width, src.Height, isHighPass, d0, n, isAddOri, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            Bitmap dstImage = BitmapConverter.ToBitmap(dstMat);
            
            if (isAddOri)
                topForm.pictureBox.Image = dstImage;
            else
                splitContainer1.Panel1.BackgroundImage = dstImage;
        }

    }
}
