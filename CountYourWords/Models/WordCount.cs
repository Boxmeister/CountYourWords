using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountYourWords.Models
{
    public class WordCount
    {
        public WordCount(string Word, int Count)
        {
            this.Word = Word;
            this.Count = Count;
        }
        public string Word { get; set; }
        public int Count { get; set; }
    }
}
