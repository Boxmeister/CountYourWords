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
        public string ReadFile(string path)
        {
            try
            {
                string content = File.ReadAllText(path);
                return string.IsNullOrWhiteSpace(content) ? "FileEmptyException" : content;
            }
            catch (FileNotFoundException)
            {
                return "FileNotFoundException";
            }
            catch (Exception e)
            {
                return $"UnExpectedError,{e}";
            }
        }
    }
}
