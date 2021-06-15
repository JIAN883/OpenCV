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
    public partial class ColorTransformationForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_色彩轉換(colorTransformation)
        //k：newBGR=BGR*k (k倍於原本色彩)
        static extern void changeIlluminantFromModel(IntPtr src, int width, int height, float k, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        int mode = 0;
        string confirm = "應用到原圖", cancel = "還原";

        public ColorTransformationForm()
        {
            InitializeComponent();
        }

        public ColorTransformationForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }
    }
}
