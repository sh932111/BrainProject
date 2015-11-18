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
        private ArrayList fftList = null;

        public BrainManager(ArrayList stream_log_list, ArrayList data_log_list, ArrayList brain_list, ArrayList fft_list)
        {
            this.streamLogList = stream_log_list;
            this.dataLogList = data_log_list;
            this.brainList = brain_list;
            this.fftList = fft_list;
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

        public ArrayList getFFTList()
        {
            return fftList;
        }
    }
}
