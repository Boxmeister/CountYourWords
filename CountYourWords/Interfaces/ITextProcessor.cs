﻿using CountYourWords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountYourWords.Interfaces
{
    public interface ITextProcessor
    {
        string CleanInput(string input);
        List<string> SplitInput(string input);
        List<WordCount> CountWords(List<string> input);

    }
}
