using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace YodoConvertorService
{
    public class ConvertorService : IConvertorService
    {
        public async Task<string> ConvertEnglishToYodoSpeak(string input)
        {
            //throw new NotImplementedException();
            //return input;
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri("https://yoda.p.mashape.com/yoda");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-Mashape-Key", "b2IuNDRHZPmshrOCPURlLwc62ayep1LkgkPjsngPT02HcnEkjV");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            
            var result=await client.GetAsync(string.Format("?sentence={0}",input));
            if(result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            else
            {
                return "Sorry. Yodo service is down.";
            }
        }
    }
}
