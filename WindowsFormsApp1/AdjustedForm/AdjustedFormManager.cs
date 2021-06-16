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
            new AdjustedFormManager("負片", typeof(NegativeForm)),
            new AdjustedFormManager("旋轉", typeof(RotateForm)),
            new AdjustedFormManager("剪形", typeof(ShearForm)),
            new AdjustedFormManager("鏡射", typeof(ReflectForm)),
            new AdjustedFormManager("調整大小", typeof(ChangeImageSizeForm)),
            new AdjustedFormManager("調整亮度 Log", typeof(LogBrightProcessingForm)),
            new AdjustedFormManager("調整亮度 Power", typeof(PowerBrightProcessing)),
        };
        static public AdjustedFormManager[] spatialDomainProcess = {
            new AdjustedFormManager("直方圖資訊", typeof(HistogramProcessingForm)),
            new AdjustedFormManager("中位數濾波器", typeof(MedianFilterForm)),
            new AdjustedFormManager("最小值濾波器", typeof(MinFilter)),
            new AdjustedFormManager("最大值濾波器", typeof(MaxFilter)),
            new AdjustedFormManager("銳化濾波器", typeof(LaplicianFilterForm)),
            new AdjustedFormManager("模糊濾波器", typeof(BlurForm)),
            new AdjustedFormManager("高增幅濾波器", typeof(HighboostFilterForm)),
            new AdjustedFormManager("垂直濾波器", typeof(HorizontalIntensityFilterForm)),
            new AdjustedFormManager("水平濾波器", typeof(VerticalIntensityFilterForm)),
            new AdjustedFormManager("閥值處理", typeof(ThresholdProcessingForm)),
            new AdjustedFormManager("等化直方圖處理", typeof(EqualizeHistForm)),
            new AdjustedFormManager("適應性中間值濾波器", typeof(AdaptiveMedianFilter_BGRForm)),
            new AdjustedFormManager("幾何平均濾波器", typeof(GeometricMeanFilterForm)),
            new AdjustedFormManager("調和平均濾波器", typeof(HarmonicMeanFilterForm)),
            new AdjustedFormManager("反調和平均濾波器", typeof(CounterHarmonicMeanFilterForm)),
            new AdjustedFormManager("改變光源", typeof(ChangeIlluminantFromModelForm)),
            new AdjustedFormManager("改變光源(自己選X,Z值)", typeof(ChangeIlluminantFromCustomizeXZForm)),
        };
        static public AdjustedFormManager[] frequencyDomainPorcess = {
            new AdjustedFormManager("頻率域資訊", typeof(GetFrequencyDomainInformationForm)),
            new AdjustedFormManager("高斯濾波器", typeof(GaussianPassFilterForm)),
            new AdjustedFormManager("理想濾波器", typeof(IdeaPassFilterForm)),
            new AdjustedFormManager("Butterworth濾波器", typeof(ButterworthPassFilterForm)),
            new AdjustedFormManager("調整飽和度", typeof(ChangeSaturationForm)),
        };
        static public AdjustedFormManager[] elseProcess = {
            new AdjustedFormManager("鈍化圖形資訊", typeof(getUnsharpInformationForm)),
            new AdjustedFormManager("位元平面切片", typeof(BitPlaneSlicingForm)),
            new AdjustedFormManager("取得色彩平面", typeof(GetColorPlaneForm)),
            new AdjustedFormManager("取得單一或多重色彩的圖片", typeof(GetSingleOrMultiColorImageForm)),
            new AdjustedFormManager("胡椒鹽濾鏡", typeof(GeneratePepperSaltForm)),
            new AdjustedFormManager("色彩轉換", typeof(ColorTransformationForm)),
            new AdjustedFormManager("色彩切片", typeof(ColorSlicingForm)),
            new AdjustedFormManager("canny的邊緣偵測", typeof(CannyEdgeDetectionForm)),
            new AdjustedFormManager("morphologyEx的影像處理", typeof(MorphologicalOperationForm)),
        };
        static public AdjustedFormManager[] testProcess = {new AdjustedFormManager("測試", typeof(Test))};

        public string Name { get; set; }
        public Type FormType { get; set; }

        public AdjustedFormManager(string Name, Type FormType)
        {
            this.Name = Name;
            this.FormType = FormType;
        }

        public static int SetTrackBarValue(int trackBarMaximum, float max, float min, float defaultValue)
        {
            return (int)((float)trackBarMaximum / (max - min) * (defaultValue - min));
        }

        public static float GetTrackValue(int trackBarMaximum, int trackBarValue, float max, float min)
        {
            return (max - min) / (float)trackBarMaximum * (float)trackBarValue + min;
        }
    }
}
