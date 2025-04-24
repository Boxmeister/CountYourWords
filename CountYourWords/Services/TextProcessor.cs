using CountYourWords.Interfaces;
using CountYourWords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountYourWords.Services
{
    public class TextProcessor : ITextProcessor
    {
        public string CleanInput(string input)
        {
            var cleaned = Regex.Replace(input, @"[^a-zA-Z\s]", "");
            return cleaned.ToLower();
        }

        public List<WordCount> CountWords(List<string> input)
        {
            throw new NotImplementedException();
        }

        public List<string> SplitInput(string input)
        {
            throw new NotImplementedException();
        }
    }
}
