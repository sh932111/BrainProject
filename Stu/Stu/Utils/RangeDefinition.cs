using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Stu.Utils
{
    class RangeDefinition
    {
        public static ArrayList getFirstRange() 
        {
            ArrayList fr = new ArrayList();

            fr.Add("0.1");
            fr.Add("4");
            fr.Add("8");
            fr.Add("12");
            fr.Add("16");
            fr.Add("21");

            return fr;
        }
        public static ArrayList getLastRange()
        {
            ArrayList lr = new ArrayList();

            lr.Add("3");
            lr.Add("7");
            lr.Add("12");
            lr.Add("15");
            lr.Add("20");
            lr.Add("30");

            return lr;
        }
    }
}
