using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodoConvertorService
{
   public static class Utilies
    {
        public const string YodoSpeakApiUrl= "https://yoda.p.mashape.com/yoda?sentence=";
        public const string HeaderMashapeKey = "X-Mashape-Key";
        public const string HeaderMashapeValue = "b2IuNDRHZPmshrOCPURlLwc62ayep1LkgkPjsngPT02HcnEkjV";
        public const string ApiDownMessage = "Sorry. Yodo service is down.";
    }
}
