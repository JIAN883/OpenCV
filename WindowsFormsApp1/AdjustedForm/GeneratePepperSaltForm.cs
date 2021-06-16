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
        //CH3_胡椒鹽雜訊 PepperPercent,SaltPercent，最大值皆為 50 (%)，最小值：0
        static extern void GeneratePepperSalt(IntPtr src, int width, int height, float PepperPercent, float SaltPercent);

        Form1 topForm;
        Mat source;
        float pepperMin = 0, pepperMax = 50, saltMin = 0, saltMax = 50;

        public GeneratePepperSaltForm()
        {
            InitializeComponent();
        }

        public GeneratePepperSaltForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);

            label2.Text = "0";
            label4.Text = "0";
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            float pepperPercent = AdjustedFormManager.GetTrackValue(pepperPercentTrackBar.Maximum, pepperPercentTrackBar.Value, pepperMax, pepperMin);
            float saltPercent = AdjustedFormManager.GetTrackValue(saltPercenttrackBar.Maximum, saltPercenttrackBar.Value, saltMax, saltMin);
            label2.Text = pepperPercent.ToString();
            label4.Text = saltPercent.ToString();

            Mat destinationImage = source.Clone();
            GeneratePepperSalt(destinationImage.Data, destinationImage.Width, destinationImage.Height, pepperPercent, saltPercent);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(destinationImage);
        }
    }
}
