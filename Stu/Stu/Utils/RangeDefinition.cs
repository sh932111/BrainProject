using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Stu.Utils
{
    class RangeDefinition
    {
        public static ArrayList getNameRange()
        {
            ArrayList fr = new ArrayList();

            fr.Add("Delta");
            fr.Add("Theta");
            fr.Add("Low Alpha");
            fr.Add("Middle Alpha");
            fr.Add("High Alpha");
            fr.Add("Low Beta");
            fr.Add("Middle Beta");
            fr.Add("High Beta");
            fr.Add("Gamma");

            return fr;
        }
        public static ArrayList getFirstRange()
        {
            ArrayList fr = new ArrayList();

            fr.Add("0.1");
            fr.Add("4");
            fr.Add("8");
            fr.Add("9");
            fr.Add("12");
            fr.Add("12.5");
            fr.Add("16.5");
            fr.Add("20.5");
            fr.Add("30");

            return fr;
        }
        public static ArrayList getLastRange()
        {
            ArrayList lr = new ArrayList();

            lr.Add("3");
            lr.Add("7");
            lr.Add("9");
            lr.Add("12");
            lr.Add("14");
            lr.Add("16");
            lr.Add("20");
            lr.Add("28");
            lr.Add("70");

            return lr;
        }
    }
}
