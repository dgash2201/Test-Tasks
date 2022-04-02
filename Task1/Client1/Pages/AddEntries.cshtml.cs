using Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages
{
    public class AddEntriesModel : PageModel
    {
        private readonly IApiService _apiService;

        public AddEntriesModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<JsonResult> OnPostAsync([FromBody] IEnumerable<Entry> entries)
        {
            return new JsonResult(await _apiService.SaveAsync(entries));
        }
    }
}
