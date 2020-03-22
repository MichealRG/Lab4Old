using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API
{
    class Program
    {
        static void Main(string[] args)
        {
            var api =new Website( "https://api.collegefootballdata.com/");
            var teams = api.DownloadAsync("/teams/fbs").Result.Content;
            var teamsCollection = JsonConvert.DeserializeObject<teamsCollection>(teams);
            var coaches = api.DownloadAsync($"/coaches?team=Akron").Result.Content; //tu jest przykład ze pobiera tylko dla Akrona ale powino pobrać dla każdego teamu z teams tylko nie mam tych danych pobranych

            Console.WriteLine(teamsCollection.Teams.Count); 
            //Console.WriteLine( api.Download("/api/docs/?url=/api-docs.json"));
            //Console.WriteLine( api.DownloadAsync("/api/docs/?url=/api-docs.json"));
            // Console.WriteLine(api.DownloadAsync("/api/docs/?url=/api-docs.json").Result.Content);  //odczytuje resulta a potem dobieram sie do contentu jak cw nr 1
            //Console.WriteLine(api.DownloadAsync("/api/docs/?url=/api-docs.json").GetAwaiter().GetResult().StatusCode);

        }
    }
}
