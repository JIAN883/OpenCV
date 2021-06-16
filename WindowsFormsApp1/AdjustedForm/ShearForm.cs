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
    public partial class ShearForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void Shear(IntPtr src, int width, int height, double xshear, double yshear, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        string confirm = "應用", cancel = "還原";

        public ShearForm()
        {
            InitializeComponent();
        }

        public ShearForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
            button1.Text = confirm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                double xshear = 0d, yshear = 0d;
                try
                {
                    xshear = double.Parse(xShearTextBox.Text);
                    yshear = double.Parse(yShearTextBox.Text);
                }
                catch { }
                Mat src = source.Clone();
                Shear(src.Data, src.Width, src.Height, xshear, yshear, out IntPtr dst);
                Mat dstImage = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstImage);

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
