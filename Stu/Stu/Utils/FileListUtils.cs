using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Stu.Utils
{
    class FileListUtils
    {
        ListView fileList = null;
        ArrayList fileNameList = null;

        /*ListView Initialize*/
        public FileListUtils(ListView _list)
        {
            this.fileNameList   = new ArrayList();

            this.fileList       = _list;

            fileList.BeginUpdate();

            fileList.View = View.Details;

            loadListTitle();

            fileList.EndUpdate();
        }
        /*ListView Initialize*/

        /*取得ListView的檔案路徑*/
        public ArrayList getFiles()
        {
            return fileNameList;
        }
        /*取得ListView的檔案路徑*/

        /*放置檔案元素*/
        public void setFileListItem(string[] file_names) 
        {
            fileNameList.Clear();
            foreach (String file_path in file_names)
            {
                fileNameList.Add(file_path);
            }
            reloadList();
        }
        /*放置檔案元素*/

        /*重新載入ListView*/
        private void reloadList()
        {
            fileList.BeginUpdate();

            fileList.Clear();

            loadListTitle();

            foreach (String file_path in fileNameList)
            {
                String file_name = file_path.Substring(file_path.LastIndexOf("\\") + 1);

                FileInfo f = new FileInfo(file_path);

                ListViewItem i1 = new ListViewItem(file_name);

                ListViewItem.ListViewSubItem sub_i1 = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem sub_i2 = new ListViewItem.ListViewSubItem();

                sub_i2.Text = file_path;
                sub_i1.Text = f.Length.ToString();
                
                i1.SubItems.Add(sub_i1);
                i1.SubItems.Add(sub_i2);

                fileList.Items.Add(i1);

            }

            fileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            fileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            fileList.EndUpdate();
        }
        /*重新載入ListView*/

        /*載入ListView標題列*/
        private void loadListTitle()
        {
            #region 增加Item的標題，共有三個列
            fileList.Columns.Add("文件名");
            fileList.Columns.Add("大小");
            fileList.Columns.Add("文件路徑");
            #endregion
        }
        /*載入ListView標題列*/

    }

}
