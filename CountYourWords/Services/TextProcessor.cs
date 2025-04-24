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
        private readonly IFileReader _reader;
        private readonly string _filePath;
        private readonly ISorter _sorter;
        public TextProcessor(IFileReader reader, ISorter sorter, IOptions<FileSettings> options)
        {
            _reader = reader;
            _sorter = sorter;
            _filePath = options.Value.InputFilePath;
        }

        public List<WordCount> ProcessText()
        {
            var input = _reader.ReadFile(_filePath);

            if (input == "FileEmptyException")
            {
                Console.Error.WriteLine("File is empty. Please add text to the file.");
                return null;
            }
            else if (input == "FileNotFoundException")
            {
                Console.Error.WriteLine("File not found. Please check the file path.");
                return null;
            }
            else
            {
                var cleaned = CleanInput(input);
                var split = SplitInput(cleaned);
                var counted = CountWords(split);
                var sorted = _sorter.Sort(counted);
                return sorted;
            }
        }


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
