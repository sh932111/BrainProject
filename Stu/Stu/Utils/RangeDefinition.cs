﻿using System;
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
            fr.Add("13");
            fr.Add("30");

            return fr;
        }
        public static ArrayList getLastRange()
        {
            ArrayList lr = new ArrayList();

            lr.Add("4");
            lr.Add("7.5");
            lr.Add("13");
            lr.Add("30");
            lr.Add("70");

            return lr;
        }
    }
}
