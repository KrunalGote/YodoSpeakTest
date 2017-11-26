using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodoConvertorService
{
    public interface IConvertorService
    {
         Task<string> ConvertEnglishToYodoSpeak(string input);
    }
}
