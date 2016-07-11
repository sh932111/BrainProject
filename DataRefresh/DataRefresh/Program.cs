using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DataRefresh
{
    class Program
    {
        static void Main(string[] args)
        {
            runPeople();
            runBrain();
            Console.WriteLine("finish");
            Console.ReadKey();
        }
        /*產生腦波為主的資料*/
        private static void runBrain()
        {
            ArrayList orders = new ArrayList();
            //orders.Add(Resource.step_1);
            orders.Add(Resource.step_2);
            //orders.Add(Resource.step_3);
            //orders.Add(Resource.step_4);
            ArrayList indexes = new ArrayList();
            //indexes.Add(Resource.resource_1);
            //indexes.Add(Resource.resource_2);
            indexes.Add(Resource.resource_3);
            ArrayList fileNames = new ArrayList();
            //fileNames.Add(ReadBrain.Brain);
            //fileNames.Add(ReadBrain.Brain);
            //fileNames.Add(ReadBrain.BrainNorm);
            fileNames.Add(ReadBrain.NormResultFile);
            
            for (int i = 0; i < Resource.actions.Length; i++)
            {
                string actionName = (string)Resource.actions[i];
                for (int x = 0; x < Resource.tables.Length; x++)
                {
                    string tableName = (string)Resource.tables[x];
                    string[] orderIDs = (string[])orders[i];
                    ArrayList list = new ArrayList();
                    int[] allIndex = (int[])indexes[x];
                    for (int z = 0; z < allIndex.Length; z++)
                    {
                        for (int a = 0; a < orderIDs.Length; a++)
                        {
                            string order = orderIDs[a];
                            string orderPath = PathUtils.getExistPath(order);
                            string resfileName = (string)fileNames[x];
                            ReadBrain readBrain = new ReadBrain(orderPath, resfileName);
                            int index = allIndex[z];
                            ArrayList dataList = readBrain.getListForIndex(index);
                            list.Add(dataList);
                        }
                    }
                    PathUtils.write(ReadBrain.brainFolder,actionName, tableName, list, false);
                }
            }
        }
        /*產生人名為主的資料*/
        private static void runPeople()
        {
            ArrayList orders = new ArrayList();
            //orders.Add(Resource.step_1);
            orders.Add(Resource.step_2);
           // orders.Add(Resource.step_3);
           // orders.Add(Resource.step_4);
            ArrayList indexes = new ArrayList();
            //indexes.Add(Resource.resource_1);
            //indexes.Add(Resource.resource_2);
            indexes.Add(Resource.resource_3);
            ArrayList fileNames = new ArrayList();
            //fileNames.Add(ReadBrain.Brain);
            //fileNames.Add(ReadBrain.Brain);
            //fileNames.Add(ReadBrain.BrainNorm);
            fileNames.Add(ReadBrain.NormResultFile);
            for (int i = 0; i < Resource.actions.Length; i++)
            {
                string actionName = (string)Resource.actions[i];
                for (int x = 0; x < Resource.tables.Length; x++)
                {
                    string tableName = (string)Resource.tables[x];
                    string[] orderIDs = (string[])orders[i];
                    ArrayList list = new ArrayList();
                    for (int a = 0; a < orderIDs.Length; a++)
                    {
                        string order = orderIDs[a];
                        string orderPath = PathUtils.getExistPath(order);
                        string resfileName = (string)fileNames[x];
                        int[] allIndex = (int[])indexes[x];
                        ReadBrain readBrain = new ReadBrain(orderPath, resfileName);
                        for (int z = 0; z < allIndex.Length; z++)
                        {
                            int index = allIndex[z];
                            ArrayList dataList = readBrain.getListForIndex(index);
                            list.Add(dataList);
                        }
                    }
                    PathUtils.write(ReadBrain.peopleFolder,actionName, tableName, list, true);
                }
            }
        }
    }
}
