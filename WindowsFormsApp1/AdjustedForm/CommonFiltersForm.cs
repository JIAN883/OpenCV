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
    public partial class CommonFiltersForm : Form
    {
        [DllImport("imgFunc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //其他功能_常用濾鏡選擇(cannyEdgeDetection)
        //mode：濾鏡模式(0：雕刻，1：雕刻，2：浮雕)
        static extern void CommonFilters(IntPtr src, int width, int height, int mode, out IntPtr dstBuffer);

        class FilterTool
        {
            public Button filterButton;
            public Label filterLabel;

            public FilterTool(Image buttonImage, string labelText, int mode)
            {
                filterButton = new Button();
                filterButton.Dock = DockStyle.Fill;
                filterButton.BackgroundImage = buttonImage;
                filterButton.BackgroundImageLayout = ImageLayout.Zoom;

                filterLabel = new Label();
                filterLabel.Dock = DockStyle.Fill;
                filterLabel.Text = labelText;
                filterLabel.TextAlign = ContentAlignment.MiddleCenter;

                filterButton.Tag = mode;
            }
        }

        Form1 topForm;
        Mat source;

        FilterTool[] toolArray =
        {
            new FilterTool(Properties.Resources.sample, "正常", 0),
            new FilterTool(Properties.Resources.sculpture, "雕刻", 1),
            new FilterTool(Properties.Resources.relief, "浮雕", 2),
            new FilterTool(Properties.Resources.Eclosion, "羽化", 3),
            new FilterTool(Properties.Resources.Nostalgia, "懷舊", 4),
            new FilterTool(Properties.Resources.sample, "連環", 5),
            new FilterTool(Properties.Resources.Casting, "鎔鑄", 6),
            new FilterTool(Properties.Resources.Freezing, "冰凍", 7),
            new FilterTool(Properties.Resources.sample, "擴散", 8),
            new FilterTool(Properties.Resources.sample, "素描", 9),
            new FilterTool(Properties.Resources.Swirl, "漩渦", 10),
            new FilterTool(Properties.Resources.Wind, "風", 11),
        };

        public CommonFiltersForm()
        {
            InitializeComponent();
        }

        public CommonFiltersForm(Form1 topForm) : this()
        {
            this.topForm = topForm;
            source = BitmapConverter.ToMat(topForm.pictureBox.Image as Bitmap);
        }

        private void CommonFiltersForm_Load(object sender, EventArgs e)
        {
            //初始化
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnCount = toolArray.Length;

            for (int i = 0; i < toolArray.Length; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180f));

                //加入濾鏡工具
                Button button = toolArray[i].filterButton;
                Label label = toolArray[i].filterLabel;
                
                tableLayoutPanel1.Controls.Add(button, i, 0);
                tableLayoutPanel1.Controls.Add(label, i, 1);
                button.Parent = tableLayoutPanel1;
                label.Parent = tableLayoutPanel1;
                button.Dock = DockStyle.Fill;
                label.Dock = DockStyle.Fill;
                button.MouseClick += FilterButton_MouseClick;
            }
        }

        private void FilterButton_MouseClick(object sender, MouseEventArgs e)
        {
            int mode = (int)((sender as Button).Tag);
            Mat src = source.Clone();
            if(mode == 0)
            {
                topForm.pictureBox.Image = BitmapConverter.ToBitmap(src);
                return;
            }

            CommonFilters(src.Data, src.Width, src.Height, mode, out IntPtr dst);
            Mat dstMat = new Mat(src.Height, src.Width, MatType.CV_8UC3, dst);
            topForm.pictureBox.Image = BitmapConverter.ToBitmap(dstMat);
        }
    }
}
