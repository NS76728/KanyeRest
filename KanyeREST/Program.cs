using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeREST
{
    class Program
    {
        public static string Ron(HttpClient client)
        {
            var RonUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var response = client.GetStringAsync(RonUrl).Result;
            var ronQuote = JArray.Parse(response).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            return ronQuote;
        }
        public static string West(HttpClient client)
        {
            var WestUrl = "https://api.kanye.rest";
            var response = client.GetStringAsync(WestUrl).Result;
            var westQuote = JObject.Parse(response).GetValue("quote").ToString();
            return westQuote;
        }


        static void Main(string[] args)
        {
            var client = new HttpClient();
            for (int i =0; i<5;i++)
            {
                Console.WriteLine("Ron: " + Ron(client));
                Console.WriteLine($"Kanye: \"{West(client)}\"      ");
            }




        }
    }
}
