using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Server.Database.Entities;

namespace Client1.Services
{
    public class ApiService : IApiService
    {
        private const string EntriesRoute = "Entries";
        private HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44369");
        }

        public async Task<IEnumerable<Entry>> GetAsync()
        {
            var response = await _httpClient.GetAsync(EntriesRoute);
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Entry>>(json);
        }
    }
}
