using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.AdjustedForm
{
    public class AdjustedFormManager
    {
        static public AdjustedFormManager[] basicProcess = {
            new AdjustedFormManager("調整大小", typeof(ChangeImageSizeForm)),
            new AdjustedFormManager("調整亮度 Log", typeof(LogBrightProcessingForm)),
            new AdjustedFormManager("調整亮度 Power", typeof(PowerBrightProcessing))
        };
        static public AdjustedFormManager[] spatialDomainProcess = {
            new AdjustedFormManager("中位數濾波器", typeof(MedianFilterForm)),
            new AdjustedFormManager("最小值濾波器", typeof(MinFilter)),
            new AdjustedFormManager("最大值濾波器", typeof(MaxFilter)),
            new AdjustedFormManager("銳化濾波器", typeof(LaplicianFilterForm)),
            new AdjustedFormManager("模糊濾波器", typeof(BlurForm)),
            new AdjustedFormManager("高增幅濾波器", typeof(HighboostFilterForm)),
            new AdjustedFormManager("垂直濾波器", typeof(HorizontalIntensityFilterForm)),
            new AdjustedFormManager("水平濾波器", typeof(VerticalIntensityFilterForm)),
            new AdjustedFormManager("閥值處理", typeof(ThresholdProcessingForm)),
            new AdjustedFormManager("等化直方圖處理", typeof(EqualizeHistForm))
        };
        static public AdjustedFormManager[] elseProcess = {
            new AdjustedFormManager("直方圖資訊", typeof(HistogramProcessingForm)),
            new AdjustedFormManager("鈍化圖形資訊", typeof(getUnsharpInformationForm)),
            new AdjustedFormManager("位元平面切片", typeof(BitPlaneSlicingForm)),
            new AdjustedFormManager("負片", typeof(NegativeForm)),
            new AdjustedFormManager("胡椒鹽濾鏡", typeof(GeneratePepperSaltForm))
        };
        static public AdjustedFormManager[] testProcess = {new AdjustedFormManager("測試", typeof(Test))};

        public string Name { get; set; }
        public Type FormType { get; set; }

        public AdjustedFormManager(string Name, Type FormType)
        {
            this.Name = Name;
            this.FormType = FormType;
        }
    }
}
