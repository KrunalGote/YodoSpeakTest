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
            //Create HttpCilent to consume service            
            HttpClient client = new HttpClient();
            
            //Add Base Address
            client.BaseAddress = new Uri("https://yoda.p.mashape.com/yoda");
            
            // Clear Header
            client.DefaultRequestHeaders.Accept.Clear();
            
            //Add Header
            client.DefaultRequestHeaders.Add("X-Mashape-Key", "b2IuNDRHZPmshrOCPURlLwc62ayep1LkgkPjsngPT02HcnEkjV");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            
            //Call Yodo Speak Rest API client
            var result=await client.GetAsync(string.Format("?sentence={0}",input));
            
            //Check Status of Respose.
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
