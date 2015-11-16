using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Stu.Utils
{
    class RangeListUtils
    {
        ListView rangeList = null;
        ArrayList fRangeList = null;
        ArrayList lRangeList = null;

        /*ListView Initialize*/
        public RangeListUtils(ListView _list)
        {
            this.fRangeList = new ArrayList();
            this.lRangeList = new ArrayList();
            this.rangeList       = _list;

            rangeList.BeginUpdate();

            rangeList.View = View.Details;

            loadListTitle();

            rangeList.EndUpdate();
        }
        /*ListView Initialize*/

        public ArrayList getfRangeList()
        {
            return fRangeList;
        }

        public ArrayList getlRangeList()
        {
            return lRangeList;
        }

        public void addRangeItem(String r1,String r2)
        {
            fRangeList.Add(r1);
            lRangeList.Add(r2);
            reloadList();
        }

        /*重新載入ListView*/
        private void reloadList()
        {
            rangeList.BeginUpdate();

            rangeList.Clear();

            loadListTitle();

            for (int i = 0; i < fRangeList.Count; i++)
            {
                ListViewItem i1 = new ListViewItem("範圍：");

                ListViewItem.ListViewSubItem sub_i1 = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem sub_i2 = new ListViewItem.ListViewSubItem();

                sub_i1.Text = (String)fRangeList[i];
                sub_i2.Text = (String)lRangeList[i];

                i1.SubItems.Add(sub_i1);
                i1.SubItems.Add(sub_i2);

                rangeList.Items.Add(i1);
            }

            rangeList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            rangeList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            rangeList.EndUpdate();
        }
        /*重新載入ListView*/

        /*載入ListView標題列*/
        private void loadListTitle()
        {
            #region 增加Item的標題，共有三個列
            rangeList.Columns.Add("");
            rangeList.Columns.Add("起始範圍");
            rangeList.Columns.Add("終點範圍");
            #endregion
        }
        /*載入ListView標題列*/

    }
}
