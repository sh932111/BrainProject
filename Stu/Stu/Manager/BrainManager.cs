using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Stu.Manager
{
    class BrainManager
    {
        private ArrayList streamLogList = null;
        private ArrayList dataLogList = null;
        private ArrayList brainList = null;

        public BrainManager(ArrayList stream_log_list, ArrayList data_log_list, ArrayList brain_list)
        {
            this.streamLogList = stream_log_list;
            this.dataLogList = data_log_list;
            this.brainList = brain_list;
        }

        public ArrayList getStreamLog()
        {
            return streamLogList;
        }

        public ArrayList getDataLog()
        {
            return dataLogList;
        }

        public ArrayList getBrainList()
        {
            return brainList;
        }
    }
}
