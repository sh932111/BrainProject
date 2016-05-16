using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRefresh
{
    class Resource
    {
        /*動作*/
        public static string[] actions = { "放空" , "一處" , "想一件事" , "亂想"};
        /*人名*/
        public static string[] names = { "a0423-1", "a0423-2", "a0423-3", "a0423-4", "a1050331", "yoga" };
        /*1.放空、2.一處、3.想一件事、4.亂想*/
        public static string[] step_1 = { "/20160423153954", "/20160423161921", "/20160423165425", "/20160423171712", "/20160331110405", "/20160516132721" };
        public static string[] step_2 = { "/20160423154623", "/20160423163610", "/20160423170003", "/20160423172208", "/20160331111357", "/20160516133125" };
        public static string[] step_3 = { "/20160423155502", "/20160423164146", "/20160423170550", "/20160423172818", "/20160331111940", "/20160516151141" };
        public static string[] step_4 = { "/20160423160048", "/20160423164656", "/20160423171109", "/20160423174007", "/20160331112359", "/20160516151516" };
        /*工作表明稱*/
        public static string[] tables = { "來源", "無正規化來源", "正規化來源" };
        /*工作表需要的內容  1."來源", 2."無正規化來源", 3."正規化來源"*/
        public static int[] resource_1 = { 9 , 10 }; /*Brain.csv*/ /*Attention Meditation*/
        public static int[] resource_2 = { 2, 3, 4, 7, 8 };/*Brain.csv*/ /*Theta	Low Alpha	High Alpha	Low Gamma	High Gamma*/
        public static int[] resource_3 = { 2, 3, 4, 7, 8 };/*BrainNorm.csv*/ /*Theta	Low Alpha	High Alpha	Low Gamma	High Gamma*/
    }
}
