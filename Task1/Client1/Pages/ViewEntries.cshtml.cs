using Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages
{
    public class ViewEntriesModel : PageModel
    {
        private readonly IApiService _apiService;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; private set; } = 10;
        public int TotalPages { get; private set; }
        public bool HasNextPage => PageNumber < TotalPages - 1;
        public bool HasPreviousPage => PageNumber > 0;
        public IEnumerable<Entry> Entries { get; private set; }

        public ViewEntriesModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync(int? code = null, string value = null)
        {
            var page = await _apiService.GetAsync(code, value, PageNumber, PageSize);

            TotalPages = page.TotalPages;
            Entries = page.Elements;
        }
    }
}
