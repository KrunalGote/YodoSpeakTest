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
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri(Utilies.YodoSpeakApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add(Utilies.HeaderMashapeKey, Utilies.HeaderMashapeValue);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            
            var result=await client.GetAsync(string.Format("{0}",input));
            if(result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            else
            {
                return Utilies.ApiDownMessage; ;
            }
        }
    }
}
