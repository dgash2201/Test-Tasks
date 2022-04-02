using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Server.Entities;
using System.Linq;
using System.Net.Http.Json;
using Server.Models;
using Microsoft.Extensions.Configuration;

namespace Client.Services
{
    public class ApiService : IApiService
    {
        private const string EntriesRoute = "Entries";
        private const string ServerAddressKey = "BaseServerAddress";
        private HttpClient _httpClient;

        public ApiService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration[ServerAddressKey]);
        }

        public async Task<Page<Entry>> GetAsync(int? code = null, string value = null, int pageNumber = 0, int pageSize = 10)
        {
            var uri = EntriesRoute +  $"?code={code}&value={value}&pageNumber={pageNumber}&pageSize={pageSize}";

            var response = await _httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Page<Entry>>(json);
        }

        public async Task<int> SaveAsync(IEnumerable<Entry> entries)
        {
            var content = CreateContent(entries);
            var response = await _httpClient.PostAsync(EntriesRoute, content);

            return await response.Content.ReadFromJsonAsync<int>();
        }

        private HttpContent CreateContent(IEnumerable<Entry> entries)
        {
            var list = entries
                .Select(e => new Dictionary<int, string> { [e.Code] = e.Value })
                .ToList();

            return JsonContent.Create(list);
        }
    }
}
