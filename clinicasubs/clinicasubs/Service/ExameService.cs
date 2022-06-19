using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks ;
using Newtonsoft.Json;
using clinicasubs.Model;

namespace clinicasubs.Service
{
    public class ExameService
    {

        private readonly string urlBase = "http://localhost:5268/api/Exame";

        public async Task<List<Exame>> GetAll()
        {

            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(urlBase);
                return JsonConvert.DeserializeObject<List<Exame>>(result);
            }
        }

        public async Task Post(Exame exame)
        {

            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(exame);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(urlBase, content);
                result.EnsureSuccessStatusCode();
            }
        }
    }
}
