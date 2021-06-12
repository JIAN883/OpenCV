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
    public partial class GeneratePepperSaltForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern IntPtr GeneratePepperSalt(IntPtr src, int width, int height, float PepperPercent, float SaltPercent);

        Form1 topForm;
        Mat source;

        public GeneratePepperSaltForm()
        {
            InitializeComponent();
        }

        public GeneratePepperSaltForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (topForm == null)
                return;

            Mat destinationImage = source.Clone();
            float pepperPercent = (float)PepperPercentTrackBar.Value / (float)PepperPercentTrackBar.Maximum * 50f;
            float saltPercent = (float)SaltPercentTrackBar.Value / (float)SaltPercentTrackBar.Maximum * 50f;

            GeneratePepperSalt(destinationImage.Data, destinationImage.Width, destinationImage.Height, pepperPercent, saltPercent);//無法獲得圖片
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(destinationImage);
        }
    }
}
