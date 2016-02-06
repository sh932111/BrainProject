using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Stu.Class
{
    class HttpWorker
    {
        public static string wordList = "http://shared.tw/En/api/module/en/word/list.php";
        public static string orderCreate = "http://shared.tw/En/api/module/order/create.php";

        private string requestURL = null;
        private JSONObject requestForm = null;
        private BackgroundWorker bgBluetooth;
        private string reponse = null;

        public delegate void responseCallback(JSONObject dataResponse);
        private responseCallback aCb;

        public HttpWorker(string url , responseCallback cb)
        {
            this.requestURL = url;
            this.aCb = cb;
        }
        public void setData(JSONObject form)
        {
            this.requestForm = form;
        }

        private void post()
        {
            /*data*/
            string json = requestForm.toString();
            Encoding enc = new UTF8Encoding(true, true);
            byte[] bytes = enc.GetBytes(json);
            string encode = "data=" + enc.GetString(bytes);
            byte[] byteArray = Encoding.UTF8.GetBytes(encode);
            /*http*/
            WebRequest request = WebRequest.Create(this.requestURL);
            request.Method = "POST";
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            this.reponse  = reader.ReadToEnd();
            // Display the content.
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        public void httpWorker()
        {
            bgBluetooth = new BackgroundWorker();
            bgBluetooth.WorkerReportsProgress = true;
            bgBluetooth.WorkerSupportsCancellation = true;
            bgBluetooth.DoWork += new DoWorkEventHandler(background_DoWork);
            bgBluetooth.RunWorkerCompleted += new RunWorkerCompletedEventHandler(background_Finish);
            bgBluetooth.RunWorkerAsync();
        }

        private void stopWorker()
        {
            if (bgBluetooth != null)
            {
                bgBluetooth.CancelAsync();
                bgBluetooth = null;
            }
        }

        private void background_DoWork(object sender, DoWorkEventArgs e)
        {
            post();
        }

        private void background_Finish(object sender, RunWorkerCompletedEventArgs e)
        {
            JSONObject values = new JSONObject(reponse);
            JSONObject data = values.getJSONObject("data");
            if (aCb != null) aCb(data);
            stopWorker();
        }
    }
}
