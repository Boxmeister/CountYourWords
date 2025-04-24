using CountYourWords.Configuration;
using CountYourWords.Interfaces;
using CountYourWords.Models;
using Microsoft.Extensions.Options;
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
            var numbersAndSymbolsRemoved = Regex.Replace(input, @"[^a-zA-Z\s]", "");
            //cleans up double spaces
            var cleaned = Regex.Replace(numbersAndSymbolsRemoved, @"\s+", " ");
            return cleaned.Trim().ToLower();
        }

        public List<WordCount> CountWords(List<string> input)
        {
            List<WordCount> wordCounts = new List<WordCount>();
            foreach (var word in input)
            {
                var wordCount = wordCounts.Where(w => w.Word == word).FirstOrDefault();
                if (wordCount != null)
                {
                    wordCount.Count += 1;
                }
                else
                {
                    wordCounts.Add(new WordCount(word, 1));
                }
            }
            return wordCounts;

        }

        public List<string> SplitInput(string input)
        {
            return input.Split(' ').ToList();
        }
    }
}
