using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.AdjustedForm
{
    public class AdjustedFormManager
    {
        public string Name { get; set; }
        public Type FormType { get; set; }

        public AdjustedFormManager(string Name, Type FormType)
        {
            this.Name = Name;
            this.FormType = FormType;
        }

        public static List<AdjustedFormManager> GetFormList()
        {
            AdjustedFormManager[] formArray = { new AdjustedFormManager("模糊", typeof(BlurForm)) };
            List<AdjustedFormManager> formList = formArray.OfType<AdjustedFormManager>().ToList();
            return formList;
        }
    }
}
