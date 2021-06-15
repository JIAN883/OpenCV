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
    public partial class GetSingleOrMultiColorImageForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //CH6_取得單一或多重色彩的圖片(B,G,R間複選，C,M,Y間單選)(可分兩種：BGR一種複選，CMY一種單選) (CMY的話只能一次選一個喔)
        //color：2進制的選擇顯示是否含有該色的平面 4個bit，意義如下：0bit->是否R/Y，1bit->是否G/M，2bit->是否B/C，3bit->是否BGR系統(1->BGR,0->CMY) 
        static extern void getSingleOrMultiColorImage(IntPtr src, int width, int height, int color, out IntPtr dstBuffer);

        Form1 topForm;
        Mat source;
        int mode = 0;
        string confirm = "應用到原圖", cancel = "還原";

        public GetSingleOrMultiColorImageForm()
        {
            InitializeComponent();
        }

        public GetSingleOrMultiColorImageForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }
    }
}
