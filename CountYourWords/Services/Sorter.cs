using CountYourWords.Interfaces;
using CountYourWords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountYourWords.Services
{
    public class Sorter : ISorter
    {
        public List<WordCount> Sort(List<WordCount> countedWordList)
        {
            for (int i = 0; i < countedWordList.Count - 1; i++)
            {
                for (int j = 0; j < countedWordList.Count - i - 1; j++)
                {
                    if (string.CompareOrdinal(countedWordList[j].Word, countedWordList[j + 1].Word) > 0)
                    {
                        var temp = countedWordList[j];
                        countedWordList[j] = countedWordList[j + 1];
                        countedWordList[j + 1] = temp;
                    }
                }
            }
            return countedWordList;
        }

    }
}
