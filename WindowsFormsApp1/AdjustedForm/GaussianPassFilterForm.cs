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
    public partial class GaussianPassFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //isIdeal：true->理想濾波器,false->高斯濾波器
        //isHighPass：true->高通,false->低通
        //d0：影響大小參數 (int 最小0)
        //isAddOri：true->最後再加上原圖，false->純粹顯示濾波後的圖片
        static extern void idealOrGaussianPassFilter(IntPtr src, int width, int height, bool isIdeal, bool isHighPass, int d0, bool isAddOri, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        float max = 100f, min = 0f;
        string confirm = "添加到原圖", cancel = "還原";

        public GaussianPassFilterForm()
        {
            InitializeComponent();
        }

        public GaussianPassFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void GaussianPassFilterForm_Load(object sender, EventArgs e)
        {
            checkBoxHighPass.Checked = true;
            label2.Text = min.ToString();
            splitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Text = confirm;
            pictureBox1.Image = ImageProssce(source.Clone(), false);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxLowPass.Checked = !checkBoxHighPass.Checked;
            pictureBox1.Image = ImageProssce(source.Clone(), false);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHighPass.Checked = !checkBoxLowPass.Checked;
            pictureBox1.Image = ImageProssce(source.Clone(), false);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int value = (int)AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            label2.Text = value.ToString();
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = ImageProssce(source.Clone(), false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                topForm.pictureBox.Image = ImageProssce(source.Clone(), true);
            }
            else
            {
                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);
            }
        }

        Bitmap ImageProssce(Mat src, bool isAddOri)
        {
            int value = (int)AdjustedFormManager.GetTrackValue(trackBar1.Maximum, trackBar1.Value, max, min);
            bool isHighPass = checkBoxHighPass.Checked ? true : false;
            idealOrGaussianPassFilter(src.Data, src.Width, src.Height, false, isHighPass, value, isAddOri, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            return BitmapConverter.ToBitmap(dstMat);
        }
    }
}
