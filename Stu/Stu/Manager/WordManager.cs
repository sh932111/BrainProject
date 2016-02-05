using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Stu.Class;

namespace Stu.Manager
{
    class WordManager
    {
        private JSONArray definitionList = null;/*詞性*/
        private JSONArray translateList = null; /*詞性的解釋*/
        private JSONArray exampleList = null; /*詞性的造句*/
        private string enWord = null;
        public int Count = -1;
        private JSONObject wordItem = null;
        public WordManager(JSONObject word_item)
        {
            this.wordItem = word_item;
            this.definitionList = wordItem.getJSONArray("definitionList");
            this.translateList = wordItem.getJSONArray("translateList");
            this.exampleList = wordItem.getJSONArray("exampleList");
            this.enWord = wordItem.getString("enWord");
            this.Count = this.definitionList.Count;
        }
        public JSONObject getDefinition(int index)
        {
            return definitionList.getJSONObject(index);
        }
        public JSONObject getTranslate(int index)
        {
            return translateList.getJSONObject(index);
        }
        public JSONObject getExample(int index)
        {
            return exampleList.getJSONObject(index);
        }
        public string getWord()
        {
            return enWord;
        }
    }
}
