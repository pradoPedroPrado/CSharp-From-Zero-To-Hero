using System;
using System.Collections.Generic;
using System.Linq;

namespace BootCamp.Chapter
{
    public static class MostCommonLetterFinder
    {
        public static char Find(string sentence)
        {
            if (string.IsNullOrEmpty(sentence) || sentence == " ") { throw new ArgumentNullException(nameof(sentence)); }
            char[] sentenceArr = sentence.ToCharArray();
            Dictionary<char,int> map = new Dictionary<char,int>();
            foreach (char ch in sentenceArr)
            {
                if (map.ContainsKey(ch))
                {
                    map[ch] += 1;
                }
                else
                {
                    map.Add(ch, 1);
                }
            }
            char mostCommon = map.Keys.FirstOrDefault();
            int highestValue = 0;
            foreach (char ch in sentenceArr)
            {
                if (map[ch] > highestValue) 
                { 
                    highestValue = map[ch];
                    mostCommon = ch;
                }
            }
            return mostCommon;
        }
    }
}