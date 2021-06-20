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
        float d0max = 1000f, d0min = 1f, nmax = 5f, nmin = 1f;
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
            label_d0.Text = d0min.ToString();
            label_n.Text = nmin.ToString();
            button1.Text = confirm;
            pictureBox1.Image = ImagePorcess(source.Clone(), false);
        }

        private void checkBoxHighPass_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxLowPass.Checked = !checkBoxHighPass.Checked;
            pictureBox1.Image = ImagePorcess(source.Clone(), false);
        }

        private void checkBoxLowPass_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHighPass.Checked = !checkBoxLowPass.Checked;
            pictureBox1.Image = ImagePorcess(source.Clone(), false);
        }

        private void trackBar_n_Scroll(object sender, EventArgs e)
        {
            float value = AdjustedFormManager.GetTrackValue(trackBar_n.Maximum, trackBar_n.Value, nmax, nmin);
            label_n.Text = value.ToString();
        }

        private void trackBar2_d0_Scroll(object sender, EventArgs e)
        {
            int value = (int)AdjustedFormManager.GetTrackValue(trackBar_d0.Maximum, trackBar_d0.Value, d0max, d0min);
            label_d0.Text = value.ToString();
        }

        private void trackBar_d0_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = ImagePorcess(source.Clone(), false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                topForm.pictureBox.Image = ImagePorcess(source.Clone(), true);
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        Bitmap ImagePorcess(Mat src, bool isAddOri)
        {
            int d0 = (int)AdjustedFormManager.GetTrackValue(trackBar_d0.Maximum, trackBar_d0.Value, d0max, d0min);
            float n = AdjustedFormManager.GetTrackValue(trackBar_n.Maximum, trackBar_n.Value, nmax, nmin);
            bool isHighPass = checkBoxHighPass.Checked ? true : false;

            butterworthPassFilter(src.Data, src.Width, src.Height, isHighPass, d0, n, isAddOri, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            return BitmapConverter.ToBitmap(dstMat);
        }

    }
}
