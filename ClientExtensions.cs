using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTerminatorV2
{
    public static class ClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string url, HttpContent iContent)
        {
            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, new Uri(url))
            {
                Content = iContent
            };

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException) { }

            return response;
        }
    }
}
