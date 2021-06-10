﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.AdjustedForm
{
    public class AdjustedFormManager
    {
        static AdjustedFormManager[][] formArray =
            {
                new AdjustedFormManager[]{ new AdjustedFormManager("卷積模糊", typeof(BlurForm)),  new AdjustedFormManager("高斯模糊", typeof(BlurForm))},
                new AdjustedFormManager[]{ new AdjustedFormManager("亮度", typeof(BlurForm)) } 
            };

        public string Name { get; set; }
        public Type FormType { get; set; }

        public AdjustedFormManager(string Name, Type FormType)
        {
            this.Name = Name;
            this.FormType = FormType;
        }

        public static List<AdjustedFormManager> GetFormList(int index)
        {
            if (index + 1 > formArray.Length)
                return null;

            AdjustedFormManager[] formArraySub = formArray[index];
            List<AdjustedFormManager> formListSub = formArraySub.OfType<AdjustedFormManager>().ToList();
            return formListSub;
        }
    }
}
