using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace sick1._0
{
    public class WebRequest
    {
        public static async Task<dynamic> Request(Uri url, params KeyValuePair<string, string>[] parameters)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url.OriginalString.Replace(url.LocalPath, ""));
                var content = new FormUrlEncodedContent(parameters);
                var result = await client.PostAsync(url.LocalPath, content);
                string resultstring = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<dynamic>(resultstring);
            }
        }
        public static async Task<dynamic> Request(Uri url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url.OriginalString.Replace(url.LocalPath, ""));
                var result = await client.GetAsync(url.LocalPath);
                string resultstring = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<dynamic>(resultstring);
            }
        }
    }
}


