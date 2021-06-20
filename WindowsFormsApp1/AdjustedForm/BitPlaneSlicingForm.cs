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
    public partial class BitPlaneSlicingForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern void bitPlaneSlicing(IntPtr src, int width, int height, int bit);

        Form1 topForm;
        Mat source;
        string confirm = "應用", cancel = "還原";

        public BitPlaneSlicingForm()
        {
            InitializeComponent();
        }

        public BitPlaneSlicingForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void BitPlaneSlicingForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);

            button1.Text = confirm;
            splitContainer1.Panel1.BackgroundImage = BitmapConverter.ToBitmap(source);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals(confirm))
            {
                topForm.pictureBox.Image = splitContainer1.Panel1.BackgroundImage.Clone() as Image;

                button1.Text = cancel;
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
            }
            else
            {
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(source);

                button1.Text = confirm;
                button1.BackColor = SystemColors.ButtonFace;
                button1.ForeColor = SystemColors.ControlText;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            for(int i=0; i<checkedListBox1.Items.Count; i++)
                if(checkedListBox1.GetItemChecked(i))
                    count += (int)Math.Pow(2, i);
            
            Mat src = source.Clone();
            bitPlaneSlicing(src.Data, src.Width, src.Height, count);
            splitContainer1.Panel1.BackgroundImage = BitmapConverter.ToBitmap(src);
        }

    }
}
