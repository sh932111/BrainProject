using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stu.Class
{
    class JSONObject
    {
        private Dictionary<string, object> resource = null;
        public JSONObject()
        {
            this.resource = new Dictionary<string, object>();
        }
        public JSONObject(Dictionary<string, object> res)
        {
            this.resource = res;
        }
        public JSONObject(string res)
        {
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(res);
            this.resource = values;
        }
        public string toString()
        {
            return JsonConvert.SerializeObject(resource, Formatting.Indented);
        }
        /*GET*/
        public JSONObject getJSONObject(string key)
        {
            string dataDiry = resource[key].ToString();
            Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataDiry);
            JSONObject result = new JSONObject(data);
            return result;
        }
        public JSONArray getJSONArray(string key)
        {
            string dataDiry = resource[key].ToString();
            List<object> list = JsonConvert.DeserializeObject<List<object>>(dataDiry);
            return new JSONArray(list);
        }
        public string getString(string key)
        {
            return resource[key].ToString();
        }
        /*GET*/
        /*SET*/
        public void setString(string key , string value)
        {
            this.resource[key] = value;
        }
        /*SET*/
    }
}
