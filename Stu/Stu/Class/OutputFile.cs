
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Stu.Class
{
    /// <summary>
    /// 輸出檔案類別
    /// </summary>
    public static class OutputFile
    {
        /// <summary>
        /// CSV
        /// </summary>
        public static class CSV
        {
            /// <summary>
            /// DataTable
            /// </summary>
            private static DataTable _table = new DataTable();

            /// <summary>
            /// 新增資料
            /// </summary>
            /// <param name="count">陣列長度</param>
            /// <param name="array">陣列</param>
            /// <param name="singnal">信號</param>
            public static void AddData(int count, ref double[] array, double singnal)
            {
                DataRow row = _table.NewRow();
              
                row["0"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                row["1"] = array[0];
                row["2"] = array[1];
                row["3"] = array[2];
                row["4"] = array[3];
                row["5"] = array[4];
                row["6"] = array[5];
                row["7"] = array[6];
                row["8"] = array[7];
                row["9"] = singnal;
                row["10"] = array[8];
                row["11"] = array[9];
                row["12"] = array[10];
                row["13"] = array[11];
                row["14"] = array[12];

                if (count > 13)
                    for (int index = 13; index < count; index++)
                        row[String.Format("{0}", index + 2)] = array[index];

                _table.Rows.Add(row);
            }

            /// <summary>
            /// 清除資料
            /// </summary>
            private static void CleanDataTable()
            {
                _table.Clear();
                _table = new DataTable();
            }

            /// <summary>
            /// 初始化資料
            /// </summary>
            /// <param name="max"></param>
            public static void InitDataTable(int max)
            {
                CleanDataTable();
                for (int index = 0; index < max; index++)
                    _table.Columns.Add(index.ToString());
            }


            /// <summary>
            /// Read Header
            /// </summary>
            /// <param name="path">File path</param>
            /// <returns>Headers</returns>
            public static String[] ReadHeaders(String path)
            {
                String[] headers = ReadCSV(path);
                if (headers == null || headers.Length <= 1)
                    return null;

                return headers[0].Split(new String[] { ",", Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);
            }

            /// <summary>
            /// 輸出CSV
            /// </summary>
            /// <param name="FileName">檔案名稱(包含路徑)</param>
            /// <param name="ColumnName">欄位名稱</param>
            /// <returns>Boolean</returns>
            public static Boolean OutputCSV(string FileName, string[] ColumnName)
            {
                return OutputCSV(_table, FileName, ColumnName);
            }

            //輸出CSV檔**************************************************************************************
            /// <summary>
            /// 輸出CSV
            /// </summary>
            /// <param name="table">資料表單</param>
            /// <param name="FileName">檔案名稱(包含路徑)</param>
            /// <param name="ColumnName">欄位名稱</param>
            /// <returns>Boolean</returns>
            public static Boolean OutputCSV(DataTable table, string FileName, string[] ColumnName)
            {
                string strValue = string.Empty;
                //CSV 匯出的標題 要先塞一樣的格式字串 充當標題
                strValue = string.Join(",", ColumnName);

                for (int i = 0; i < table.Rows.Count; i++)
                    for (int j = 0; j < table.Columns.Count; j++)
                        if (!string.IsNullOrEmpty(table.Rows[i][j].ToString()))
                            if (j > 0)
                                strValue = strValue + "," + table.Rows[i][j].ToString();
                            else
                            {
                                if (string.IsNullOrEmpty(strValue))
                                    strValue = table.Rows[i][j].ToString();
                                else
                                    strValue = strValue + Environment.NewLine + table.Rows[i][j].ToString();
                            }
                        else
                            if (j > 0)
                                strValue = strValue + ",";
                            else
                                strValue = strValue + Environment.NewLine;

                if (string.IsNullOrEmpty(strValue))
                    return false;
                else
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + FileName,
                        strValue, Encoding.UTF8);

                return true;
            }

            /// <summary>
            /// 讀取CSV
            /// </summary>
            /// <param name="path">Path</param>
            /// <returns>Array</returns>
            public static String[] ReadCSV(String path)
            {
                if (File.Exists(path) == false)
                    return null;

                List<String> list = new List<string>();

                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string temp = null;
                        while ((temp = reader.ReadLine()) != null)
                            list.Add(temp);

                        reader.Close();
                    }
                }

                return list.ToArray();
            }


            public static Boolean OldToNewCSV(String oldPath, String[] newRules, String[] ColumnName)
            {
                DataTable table;
           

                try
                {
                    String[] oldLines = ReadCSV(oldPath);
                    if (oldLines == null) return false;

                    //舊的CSV行數
                    int lineCount = oldLines.Length;
                    if (lineCount == 0) return false;

                    //公式總數量
                    int newCount = newRules.Length;


                  



                    //欄位數量
                    int columnCount = ColumnName.Length;




                    table = new DataTable();

                    for (int index = 0; index <= (columnCount + newCount); index++)
                        table.Columns.Add(index.ToString());



                    for (int index = 1; index < lineCount; index++)
                    {
                        DataRow row = table.NewRow();
                        String[] tempLine = oldLines[index].Split(new string[] { ",", Environment.NewLine }
                            , StringSplitOptions.RemoveEmptyEntries);


           //             "Attention","Meditation","壓力","疲勞指數", "Delta", "Theta", "Low Alpha", "High Alpha", 
            //    "Low Beta", "High Beta", "Low Gamma", "High Gamma","睡眠"};

                        //             , "Delta", "Theta", "Low Alpha", "High Alpha", 
                        //    "Low Beta", "High Beta", "Low Gamma", "High Gamma","Attention","Meditation","壓力",, "睡眠" "疲勞指數"};
                        double[] array = new double[]{
                            Double.Parse(tempLine[1]),
                            Double.Parse(tempLine[2]),
                            Double.Parse(tempLine[3]),
                            Double.Parse(tempLine[4]),
                            Double.Parse(tempLine[5]),
                            Double.Parse(tempLine[6]),
                            Double.Parse(tempLine[7]),
                            Double.Parse(tempLine[8]),
                            Double.Parse(tempLine[10]),
                            Double.Parse(tempLine[11]),
                            Double.Parse(tempLine[12]),
                            Double.Parse(tempLine[13]),
                            Double.Parse(tempLine[14])
                        };

    //CSV檔輸出欄位的順序***************************************************************************************************************************************
                        row["0"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        row["1"] = array[0];
                        row["2"] = array[1];
                        row["3"] = array[2];
                        row["4"] = array[3];
                        row["5"] = array[4];
                        row["6"] = array[5];
                        row["7"] = array[6];
                        row["8"] = array[7]; 
                        row["9"] = tempLine[9];
                        row["10"] = array[8];
                        row["11"] = array[9];
                        row["12"] = array[10];
                        row["13"] = array[11];
                        row["14"] = array[12];
                        
                        double[] tempArray = new double[newCount];

                        for (int n = 0; n < newCount; n++)
                        {
                            tempArray[n] = Rules.RulesToDouble(Rules.
                                GetReplaceString(newRules[n]), ref array);
                            row[(n + 15).ToString()] = tempArray[n];
                        }

                        table.Rows.Add(row);
                    }
                }
                catch (NullReferenceException ex)
                {
                    return false;
                }

                string fileName = oldPath.Substring(oldPath.LastIndexOf('\\') + 1, oldPath.Length - oldPath.LastIndexOf('\\') - 5);
                return OutputCSV(table, String.Format("{0} OldToNew.csv", fileName), ColumnName);

            }

        }
        //END OFFCSV檔輸出欄位的順序*************************************************************************************************************************************
        /// <summary>
        /// 設定檔案
        /// </summary>
        public static class Config
        {
            /// <summary>
            /// 設定檔
            /// </summary>
            private readonly static String _Path = String.Format("{0}\\CYFang.config", Directory.GetCurrentDirectory());

            /// <summary>
            /// 讀取設定檔
            /// </summary>
            /// <returns>陣列</returns>
            public static String[] ReadLines()
            {

                if (CreateFile() == false) return null;

                List<String> list = new List<string>();
                try
                {
                    using (var stream = File.Open(_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    using (var reader = new StreamReader(stream))
                    {
                        string line = null;
                        while ((line = reader.ReadLine()) != null)
                            list.Add(line);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    return null;
                }
                return list.ToArray();
            }

            /// <summary>
            /// 清除設定檔
            /// </summary>
            /// <param name="name">公式名稱</param>
            /// <param name="rule">公式值</param>
            /// <returns></returns>
            public static Boolean DeleteRules(String name, String rule)
            {
                if (CreateFile() == false) return false;

                string[] lines = ReadLines();
                File.Delete(_Path);

                using (var stream = File.Open(_Path, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.ReadWrite))
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    foreach (string line in lines)
                        if (line.Contains(String.Format("{0}__{1}", name, rule)) == false)
                            writer.WriteLine(line);
                    writer.Flush();
                }

                return true;
            }


            /// <summary>
            /// 取得公式名稱的陣列
            /// </summary>
            /// <returns>陣列</returns>
            public static String[] GetNames()
            {
                if (CreateFile() == false)
                    return null;

                List<String> list = new List<string>();
                String[] lines = ReadLines();
                foreach (String line in lines)
                {
                    String[] temp = line.Split(new String[] { "__" }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp.Length == 2)
                        list.Add(temp[0]);
                }

                return list.ToArray();
            }

            /// <summary>
            /// 取得公式值的陣列
            /// </summary>
            /// <returns>陣列</returns>
            public static String[] GetRules()
            {
                if (CreateFile() == false)
                    return null;
                List<String> list = new List<string>();
                String[] lines = ReadLines();
                if (lines == null) return null;

                foreach (String line in lines)
                {
                    String[] temp = line.Split(new String[] { "__" }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp.Length == 2)
                        list.Add(temp[1]);
                }


                return list.ToArray();
            }

            /// <summary>
            /// 儲存公式
            /// </summary>
            /// <param name="name">公式名稱</param>
            /// <param name="rule">公式值</param>
            /// <returns>Boolean</returns>
            public static Boolean SaveFile(String name, String rule)
            {
                try
                {
                    if (CreateFile())
                        File.AppendAllText(_Path, String.Format("{0}__{1}{2}",
                            name, rule, Environment.NewLine), Encoding.UTF8);
                }
                catch { return false; }
                return true;
            }

            private static Boolean CreateFile()
            {
                if (File.Exists(_Path) == false)
                {
                    File.Create(_Path);
                    FileInfo info = new FileInfo(_Path);
                    info.Attributes = FileAttributes.Hidden;
                    return true;
                }
                else
                    return true;

                return false;
            }

        }


    }
}
