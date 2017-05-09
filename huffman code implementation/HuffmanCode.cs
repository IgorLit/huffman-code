using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffman_code_implementation
{
    class HuffmanCode
    {
        private static Dictionary<char, string> dicCode;
       
        public string Encode(string text)
        {
            Dictionary<char, int> dicSymb = getDictionary(text);
            dicCode = initDictionaryCode(dicSymb);
            dicCode = getCode(dicSymb, dicCode);
            return getTextCompression(text, dicCode);
        }
        private string getTextCompression(string text, Dictionary<char, string> dicCode)
        {
            string compressionText = "";
            foreach (var symb in text)
                compressionText += dicCode[symb];
            return compressionText;
        }
        private Dictionary<char, int> getDictionary(string text)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (var symb in text)
            {
                if (dic.ContainsKey(symb))
                {
                    dic[symb]++;
                }
                else
                {
                    dic.Add(symb, 1);
                }
            }
            return dic.OrderBy(el => el.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        private Dictionary<char, string> initDictionaryCode(Dictionary<char, int> dic)
        {
            Dictionary<char, string> returnDic = new Dictionary<char, string>();
            foreach (var el in dic)
                returnDic.Add(el.Key, "");
            return returnDic;
        }
        private string restoreText(string commpressionText, Dictionary<char, string> dicCode)
        {
            Dictionary<string, char> revDicCode = dicCode.ToDictionary(pair => pair.Value, pair => pair.Key);
            string restoreText = "";
            string tempText = "";
            foreach (var symb in commpressionText)
            {
                tempText += symb;
                if (dicCode.ContainsValue(tempText))
                {
                    restoreText += revDicCode[tempText];
                    tempText = "";
                }
            }
            return restoreText;
        }
        private Dictionary<char, string> getCode(Dictionary<char, int> inDic, Dictionary<char, string> toReturn)
        {
            Dictionary<char, string> returnDic = toReturn;
            List<Element> tempList = new List<Element>();
            foreach (var symb in inDic)
                tempList.Add(new Element(symb.Value, symb.Key.ToString()));
            while (tempList.Count > 1)
            {
                Element e1 = tempList[0];
                Element e2 = tempList[1];
                tempList.RemoveRange(0, 2);
                tempList.Add(new Element(e1.count + e2.count, e1.symbs + e2.symbs));
                tempList.Sort(delegate (Element el1, Element el2) { return el1.count.CompareTo(el2.count); });
                foreach (var c in e1.symbs)
                    returnDic[c] = "1" + returnDic[c];
                foreach (var c in e2.symbs)
                    returnDic[c] = "0" + returnDic[c];

            }

            return returnDic;
        }
        public string Decode(string text)
        {
            return restoreText(text, dicCode);
        }
    }
}
