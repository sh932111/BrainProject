using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stu.Class
{
    class JSONArray
    {
        private List<object> resource = null;
        public int Count = -1; 
        public JSONArray(List<object> list)
        {
            this.resource = list;
            this.Count = list.Count;
        }
        public JSONObject getJSONObject(int index)
        {
            string wordItem = resource[index].ToString();
            Dictionary<string, object> item = JsonConvert.DeserializeObject<Dictionary<string, object>>(wordItem);
            return new JSONObject(item);
        }
        /*GET*/
        public string getString(int index)
        {
            return resource[index].ToString();
        }
        /*GET*/
        /*SET*/
        /*SET*/
    }
}
