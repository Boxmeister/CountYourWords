using CountYourWords.Configuration;
using CountYourWords.Interfaces;
using CountYourWords.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CountYourWords.Services
{
    public class TextProcessorHandler
    {
        private readonly IFileReader _reader;
        private readonly string _filePath;
        private readonly ISorter _sorter;
        private readonly ITextProcessor _textProcessor;
        public TextProcessorHandler(IFileReader reader, ISorter sorter, ITextProcessor textProcessor, IOptions<FileSettings> options)
        {
            _reader = reader;
            _sorter = sorter;
            _filePath = options.Value.InputFilePath;
            _textProcessor = textProcessor;
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
                var cleaned = _textProcessor.CleanInput(input);
                var split = _textProcessor.SplitInput(cleaned);
                var counted = _textProcessor.CountWords(split);
                var sorted = _sorter.Sort(counted);
                return sorted;
            }
        }
    }
}
