using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Stu.Class
{
    class Calculate
    {
        public static double norm(ArrayList list)
        {
            double sum = customSum(list);
            double res = Math.Sqrt(sum);
            return res;
        }

        private static double customSum(ArrayList list)
        {
            double sum = 0;
            foreach (double it in list)
            {
                sum = sum + square(it);
            }
            return sum;
        }

        private static double square(double res)
        {
            return res * res;
        }

        public static String run16To2(String get)
        {
            Boolean isPlus = true;
            String result = "";
            for (int i = 0; i < get.Length; i++) 
            {
                String code = Convert.ToString(get[i]);
                int value = Int32.Parse(changeCode(code));
                if (i == 0 && value >= 8) {
                    isPlus = false; //表示為負數
                }
                int intNum = Convert.ToInt32(code, 16);
                String strBinary = Convert.ToString(intNum, 2);
                int strLength = strBinary.Length;
                for (int x = 0; x < 4 - strLength; x++) 
                {
                    strBinary = "0" + strBinary;
                }
                // Console.WriteLine(strBinary);
                result = result + strBinary;
            }
            if (isPlus) return run16ToString(get);
            // Console.WriteLine(result);
            result = complementWith2(result);
            // Console.WriteLine(result);
            int tempCode = 0;
            String temp = "";
            ArrayList tempArray = new ArrayList();
            for (int i = 0; i < result.Length; i++) 
            {
                String code = Convert.ToString(result[i]);
                temp = temp + code;
                if (tempCode == 3) 
                {
                    tempArray.Add((String)temp.Clone());
                    temp = "";
                    tempCode = 0;
                }
                else
                {
                    tempCode ++;
                }
            }
            String over = "";
            for (int i = 0; i < tempArray.Count; i++) 
            {
                String code = (String)tempArray[i];
                // Console.WriteLine(code);
                int intNum = Convert.ToInt32(code, 2);
                // Console.WriteLine(intNum);
                over = over + changeCode(intNum + "");
            }
            // Console.WriteLine(over);
            over = run16ToString(over);
            // Console.WriteLine(over);
            if (!isPlus) over = "-" + over;
            return over;
        }

        public static String complementWith2(String get)
        {
            if (get.Equals("0000000000000000")) return get;
            String result = "";
            for (int i = 0; i < get.Length; i++) 
            {
                String code = Convert.ToString(get[i]);
                if (code.Equals("0"))
                {
                    result = result + "1";
                }
                else
                {
                    result = result + "0";
                }
            }
            int temp = 1;
            String result2 = "";
            // Console.WriteLine(result);
            for (int i = result.Length - 1; i >= 0; i--)
            {
                String code = Convert.ToString(result[i]);
                int get_code = Int32.Parse(code);
                if (temp == 1)
                {
                    if (get_code + 1 == 2)
                    {
                        temp = 1;
                        result2 = "0" + result2;
                    }
                    else
                    {
                        temp = 0;
                        result2 = "1" + result2;
                    }
                }
                else
                {
                    result2 = code + result2;
                }
            }
            return result2;
        }

        public static String run16ToString(String get) 
        {
            int result = 0;
            ArrayList temp = new ArrayList();
            for (int i = get.Length - 1; i >= 0; i--)
            {
                String code = Convert.ToString(get[i]);
                if (code.Equals(" ")) continue;
                else temp.Add(code);
            }
            for (int i = 0; i < temp.Count; i++)
            {
                String code = (String)temp[i];
                int value = Int32.Parse(changeCode((code)));
                result = result + value * runLoop(i,16);
            }
            return result + "";
        }
        
        private static int runLoop(int value , int temp) 
        {
            if (value > 0) return runLoop(value - 1, temp) * temp;
            else return 1;
        }

        private static String changeCode(String str)
        {
            if (str.Equals("A") || str.Equals("a")) return "10";
            else if (str.Equals("B") || str.Equals("b")) return "11";
            else if (str.Equals("C") || str.Equals("c")) return "12";
            else if (str.Equals("D") || str.Equals("d")) return "13";
            else if (str.Equals("E") || str.Equals("e")) return "14";
            else if (str.Equals("F") || str.Equals("f")) return "15";
            else if (str.Equals("10") ) return "A";
            else if (str.Equals("11") ) return "B";
            else if (str.Equals("12") ) return "C";
            else if (str.Equals("13")) return "D";
            else if (str.Equals("14")) return "E";
            else if (str.Equals("15")) return "F";
            else return str;
        }
    }
}
