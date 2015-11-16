
using System;
using System.Runtime.InteropServices;

namespace CYFang.Class
{
        public class Think
        {
            public static int BAUD_1200 = 1200;
            public static int BAUD_2400 = 2400;
            public static int BAUD_4800 = 4800;
            public static int BAUD_9600 = 9600;
            public static int BAUD_57600 = 57600;
            public static int BAUD_115200 = 115200;

            public static int STREAM_PACKETS = 0;
            public static int STREAM_5VRAW = 1;
            public static int STREAM_FILE_PACKETS = 2;

            public static int DATA_BATTERY = 0;
            public static int DATA_POOR_SIGNAL = 1;
            public static int DATA_ATTENTION = 2;
            public static int DATA_MEDITATION = 3;
            public static int DATA_RAW = 4;
            public static int DATA_DELTA = 5;
            public static int DATA_THETA = 6;
            public static int DATA_LowALPHA = 7;
            public static int DATA_HighALPHA = 8;
            public static int DATA_LowBETA = 9;
            public static int DATA_HighBETA = 10;
            public static int DATA_LowGAMMA = 11;
            public static int DATA_HighGAMMA = 12;

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_GetDriverVersion();

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_GetNewConnectionId();

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_SetStreamLog(int _connectionId, String filename);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_SetDataLog(int _connectionId, String filename);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_Connect(int _connectionId, String serialPortName, int serialBaudrate, int serialDataFormat);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_ReadPackets(int _connectionId, int numPackets);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double TG_GetValue(int _connectionId, int dataType);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_GetValueStatus(int _connectionId, int dataType);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_SendByte(int _connectionId, int b);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_SetBaudrate(int _connectionId, int serialBaudrate);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int TG_SetDataFormat(int _connectionId, int serialDataFormat);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void TG_Disconnect(int _connectionId);

            [DllImport("thinkgear.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void TG_FreeConnection(int _connectionId);
        }
}
