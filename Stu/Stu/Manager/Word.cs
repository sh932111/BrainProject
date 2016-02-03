using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Stu.Manager
{
    class Word
    {
        private ArrayList definitions = null;/*詞性*/
        private ArrayList translates = null; /*詞性的解釋*/
        private ArrayList example = null; /*詞性的造句*/
        private string theWord = null;
        public int codeLength = -1;
        private Dictionary<string, object> wordItem = null;
        public Word(Dictionary<string,object> word_item)
        {
            this.wordItem = word_item;
            this.definitions = (ArrayList)word_item["definitions"];
            this.translates = (ArrayList)word_item["translates"];
            this.example = (ArrayList)word_item["example"];
            this.theWord = (string)word_item["word"];
            this.codeLength = this.definitions.Count;
        }
        public string getDefinition(int index)
        {
            return (string)definitions[index];
        }
        public string getTranslate(int index)
        {
            return (string)translates[index];
        }
        public string getExample(int index)
        {
            return (string)example[index];
        }
        public string getWord()
        {
            return theWord;
        }
    }
}
