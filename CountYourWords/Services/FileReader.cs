using CountYourWords.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountYourWords.Services
{
    public class FileReader : IFileReader
    {
        string IFileReader.ReadFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
