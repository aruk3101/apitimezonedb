using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apitimezonedb
{
    public static class ApiService
    {
        //Username : draczek API Key  : 692I4TQFJCPD
        private const string apiKey = "692I4TQFJCPD";
        public static async Task<string> FetchTimeByTimeZone(string timezone)
        {
            string url = $"http://api.timezonedb.com/v2.1/get-time-zone?key={apiKey}&format=json&by=zone&zone={timezone}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    dynamic json = JsonConvert.DeserializeObject(await client.GetStringAsync(url));

                    if (json != null && json.status == "OK")
                    {

                        return json.formatted.ToString();
                    }
                    else
                    {
                        return "Not Found";
                    }
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
            }
        }
    }

}
