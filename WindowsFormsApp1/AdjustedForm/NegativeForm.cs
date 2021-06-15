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
    public partial class NegativeForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void negative(IntPtr src, int width, int height);

        Form1 topForm;
        Mat source;
        string confirm = "負片", cancel = "取消負片";

        public NegativeForm()
        {
            InitializeComponent();
        }

        public NegativeForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
            button1.Text = confirm;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))//準備銳化圖片
            {
                Mat src = source.Clone();
                negative(src.Data, src.Width, src.Height);
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(src);

                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
            }
            else
            {
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);

                button1.Text = confirm;
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
