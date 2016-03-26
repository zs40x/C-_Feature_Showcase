using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _01_asynchronous_programming_with_async_and_await
{
    class WhoisLookup
    {
        private readonly string webApiBaseAddress = "http://api.hackertarget.com/whois/?q=";
        public string HostToLookup { get; private set; }

        public WhoisLookup(string hostToLookup)
        {
            HostToLookup = hostToLookup;
        }

        public async Task<string> GetWhoisInformationsAsync()
        {
            var client = new HttpClient();
            var apiRequestUrl = $"{webApiBaseAddress}{HostToLookup}";

            var getContentAsStringTask = client.GetStringAsync(apiRequestUrl);

            return await getContentAsStringTask;
        }
    }
}
