using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Stu.Class
{
    class complex
    {
        public float real = 0.0f;
        public float imag = 0.0f;
        //Empty constructor
        public complex()
        {
        }
        public complex(float real, float im)
        {
            this.real = real;
            this.imag = im;
        }
        public string ToString()
        {
            string data = real.ToString() + " " + imag.ToString() + "i";
            return data;
        }
        //Convert from polar to rectangular
        public static complex from_polar(double r, double radians)
        {
            complex data = new complex((float)(r * Math.Cos(radians)), (float)(r * Math.Sin(radians)));
            return data;
        }
        //Override addition operator
        public static complex operator +(complex a, complex b)
        {
            complex data = new complex(a.real + b.real, a.imag + b.imag);
            return data;
        }
        //Override subtraction operator
        public static complex operator -(complex a, complex b)
        {
            complex data = new complex(a.real - b.real, a.imag - b.imag);
            return data;
        }
        //Override multiplication operator
        public static complex operator *(complex a, complex b)
         {
             complex data = new complex((a. real * b.real ) - (a.imag * b.imag ), (a. real * b.imag) + (a.imag * b.real ));
             return data;
         }
        //Return magnitude of complex number
        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2));
            }
        }
        public float phase
        {
            get
            {
                return (float)Math.Atan(imag / real);
            }
        }
    }
    class DSP 
    {
        public static complex[] DFT(complex[] x)
        {
            int N = x.Length;
            complex[] X = new complex[N];
            for (int k = 0; k < N; k++)
            {
                X[k] = new complex(0, 0);
                for (int n = 0; n < N; n++)
                {
                    complex temp = complex.from_polar(1, -2 * Math.PI * n * k / N);
                    temp *= x[n];
                    X[k] += temp;
                }
            }
            return X;
        }
        public static complex[] FFT(complex[] x)
        {
            int N = x.Length;
            complex[] X = new complex[N];
            complex[] d, D, e, E;
            if (N == 1)
            {
                X[0] = x[0];
                return X;
            }
            int k;
            e = new complex[N / 2];
            d = new complex[N / 2];
            for (k = 0; k < N / 2; k++)
            {
                e[k] = x[2 * k];
                d[k] = x[2 * k + 1];
            }
            D = FFT(d);
            E = FFT(e);
            for (k = 0; k < N / 2; k++)
            {
                complex temp = complex.from_polar(1, -2 * Math.PI * k / N);
                D[k] *= temp;
            }
            for (k = 0; k < N / 2; k++)
            {
                X[k] = E[k] + D[k];
                X[k + N / 2] = E[k] - D[k];
            }
            return X;
        }
        public static ArrayList getArrayWithDivision(float fs, float loopStart, float loopStop)
        {
            ArrayList list = new ArrayList();
            for (float i = loopStart; i < loopStop; i++)
            {
                float result = i / fs;
                list.Add(result);
            }
            return list;
        }
        public static ArrayList arrayMagic(ArrayList one, complex[] two, int row_count)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < row_count; i++)
            {
                ArrayList item = new ArrayList();
                item.Add(one[i] + "");
                item.Add(two[i].real + "");
                list.Add(item);
            }
            return list;
        }
        public static ArrayList getArrayWithMultiplication(float fs, float loopStart, float loopStop)
        {
            ArrayList list = new ArrayList();
            for (float i = loopStart; i <= loopStop; i++)
            {
                float result = i * fs;
                list.Add(result);
            }
            return list;
        }
    }
       // public static void runFFT(ArrayList Input_data)
       // {
       //     float N = 2048;// 點數2^n
       //     float fs = 512;// 取樣頻率
       //     float freqStep = fs / N;
       //     float f = 10 * freqStep;
       //     ArrayList time = getArrayWithDivision(fs, 0, N - 1);
       //     ArrayList freq = getArrayWithMultiplication(freqStep , 0 , N / 2);
       //     int row_len = Input_data.Count;
       //     int column_len = 1;
       //     ArrayList data_out = (ArrayList)freq.Clone();
       //     ArrayList data_out_norm = (ArrayList)freq.Clone();
       //     ArrayList data_out_time = (ArrayList)time.Clone();
       //     ArrayList m_zero = zeros(N / 2 + 1);
       //     for (int i = 1; i <= column_len; i++)
       //     {
       //         if ((float)Input_data[(int)(row_len - N)] == 0)
       //         {
       //             data_out = arrayMagic(data_out, m_zero);
       //             continue;
       //         }
       //     }
            
       //}
       
      
       // private static ArrayList zeros(float m)
       // {
       //     ArrayList list = new ArrayList();
       //     for (int i = 0; i <= m; i++)
       //     {
       //         list.Add(0);
       //     }
       //     return list;
       // }

       
    //}
}
