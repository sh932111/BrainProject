
using NCalc;
using System;

namespace Stu.Class
{   //取代欄位的數值，讀取公式數值的部分套件https://msdn.microsoft.com/zh-tw/evalcenter/ee854988.aspx **********************************
    /// <summary>
    /// 公式類別
    /// </summary>
    static class Rules
    {
        /// <summary>
        /// 公式轉數值
        /// </summary>
        /// <param name="rules">公式</param>
        /// <param name="array">陣列</param>
        /// <returns>數值</returns>
        public static double RulesToDouble(String rules, ref double[] array)
        {
            if (String.IsNullOrEmpty(rules))
                return 0.0d;

            String rule = rules
               .Replace("@3", array[3].ToString())
               .Replace("@4", array[4].ToString())
               .Replace("@5", array[5].ToString())
               .Replace("@6", array[6].ToString())
               .Replace("@7", array[7].ToString())
               .Replace("@8", array[8].ToString())
               .Replace("@9", array[9].ToString())
               .Replace("@10", array[10].ToString())
               .Replace("@11", array[11].ToString())
               .Replace("@12", array[12].ToString())
               .Replace("@2", array[2].ToString())
               .Replace("@1", array[1].ToString())
               .Replace("@0", array[0].ToString());


            try
            {
                Expression number = new Expression(rule);
                return Double.Parse(number.Evaluate().ToString());
            }
            catch
            {

            }
            return 0.0d;
        }

        /// <summary>
        /// 將公式轉換成對應的格式
        /// </summary>
        /// <param name="rule">公式</param>
        /// <returns>文字</returns>
        public static String GetReplaceString(String rule)
        {
            return rule
                .Replace("Delta", "@0").Replace("Theta", "@1").Replace("Low Alpha", "@2")
                         .Replace("High Alpha", "@3").Replace("Low Beta", "@4").Replace("High Beta", "@5")
                         .Replace("Low Gamma", "@6").Replace("High Gamma", "@7").Replace("Attention", "@8")
                         .Replace("Meditation", "@9").Replace("Presure", "@10").Replace("Sleep Qulaity", "@11")
                         .Replace("Tired", "@12");
        }
    }
}
//END OFF公式演算法數字套入部分********************************************************************************************************