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
    public partial class IdealOrGaussianPassFilterForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void getUnsharpInformation(IntPtr src, int width, int height, out IntPtr dst);

        Form1 topForm;
        Mat source;
        Bitmap dstImage;

        public IdealOrGaussianPassFilterForm()
        {
            InitializeComponent();
        }

        public IdealOrGaussianPassFilterForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }
    }
}
