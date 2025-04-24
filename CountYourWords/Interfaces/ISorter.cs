using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountYourWords.Interfaces
{
    interface ISorter
    {
        List<string> Sort(List<string> words);
    }
}
