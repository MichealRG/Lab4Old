//using IdentityModel.Client; //usunałem z nugetow pakiety
//using Nancy.Json; //usunalem z nugetow pakiety
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
//using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using RestSharp;
using System.Linq;

namespace API
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api =new Website( "https://api.collegefootballdata.com/");
            var teams = api.DownloadAsync("/teams/fbs").Result.Content;

            //using var ms = new MemoryStream(Encoding.Unicode.GetBytes(teams));
            //DataContractJsonSerializer deserialize = new DataContractJsonSerializer(typeof(teamsCollection));
            //teamsCollection druzyny = (teamsCollection)deserialize.ReadObject(ms);
            ////////////////////////////////
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //List<teams> druzyny = new List<teams>();
            //druzyny.Add(js.Deserialize<teams>(teams));

            //foreach (var item in druzyny)
            //{
            //    Console.WriteLine(item.id);
            //}
            ////////////////////////////////
            using var db = new FootballContext();
            db.Database.EnsureCreated();
            var deserialization = JsonSerializer.Deserialize<teams[]>(teams, new JsonSerializerOptions() { PropertyNameCaseInsensitive=true});
            var tasks = new List<Task<IRestResponse>>();
            foreach (var item in deserialization)
            {
                var coach = api.DownloadAsync($"/coaches?team={item.School}");
                tasks.Add(coach);
                
            }
            var responses = await Task.WhenAll(tasks);
            
            var deserializationCoaches = responses.SelectMany(x => JsonSerializer.Deserialize<coaches[]>(x.Content, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true }));
            foreach (var item in deserializationCoaches)
            {
                deserialization.SingleOrDefault(x => x.School == item.Seasons.FirstOrDefault().School).coaches.Add(item);
                //var donwdInf=deserialization.SingleOrDefault(x => x.School == item.Seasons.FirstOrDefault().School);
                //if (donwdInf!=null)
                //{
                //    deserialization.SingleOrDefault(x => x.School == item.Seasons.FirstOrDefault().School).coaches.Add(item);
                //}
            }
       
            

            var addTasks = deserialization.Select(x => db.AddAsync(x).AsTask());
            await Task.WhenAll(addTasks);
            await db.SaveChangesAsync();
            
            // var teamsCollection = JsonConvert.DeserializeObject<teamsCollection>(teams);
            //var coaches = api.DownloadAsync($"/coaches?team=Akron").Result.Content; //tu jest przykład ze pobiera tylko dla Akrona ale powino pobrać dla każdego teamu z teams tylko nie mam tych danych pobranych

            //Console.WriteLine(teamsCollection.Teams.Count); 
            //Console.WriteLine( api.Download("/api/docs/?url=/api-docs.json"));
            //Console.WriteLine( api.DownloadAsync("/api/docs/?url=/api-docs.json"));
            // Console.WriteLine(api.DownloadAsync("/api/docs/?url=/api-docs.json").Result.Content);  //odczytuje resulta a potem dobieram sie do contentu jak cw nr 1
            //Console.WriteLine(api.DownloadAsync("/api/docs/?url=/api-docs.json").GetAwaiter().GetResult().StatusCode);

        }
    }
}
