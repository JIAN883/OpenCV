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
    public partial class LaplicianFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void LaplicianFilter(IntPtr src, int width, int height, bool isAddOriImage);

        Form1 topForm;
        Mat source;
        bool isProcess = true;
        string confirm = "銳化圖片", cancel = "取消銳化圖片";

        public LaplicianFilterForm()
        {
            InitializeComponent();
        }

        public LaplicianFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void LaplicianFilterForm_Load(object sender, EventArgs e)
        {
            Mat dst = source.Clone();
            LaplicianFilter(dst.Data, dst.Width, dst.Height, false);
            splitContainer1.Panel1.BackgroundImage = BitmapConverter.ToBitmap(dst);

            button1.Text = confirm;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (topForm == null)
                return;

            if (isProcess)//準備銳化圖片
            {
                Mat dst = source.Clone();
                LaplicianFilter(dst.Data, dst.Width, dst.Height, true);
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(dst);

                isProcess = false;
                button1.Text = cancel;
            }
            else
            {
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);

                isProcess = true;
                button1.Text = confirm;
            }
        }
    }
}
