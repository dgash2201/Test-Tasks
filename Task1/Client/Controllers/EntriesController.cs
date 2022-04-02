using Client1.Models;
using Client1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client1.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IApiService _apiService;

        public EntriesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> ViewEntries()
        {
            var entries = await  _apiService.GetAsync();
            var viewModel = new EntriesViewModel
            {
                Entries = entries,
            };

            return View(viewModel);
        }

        public IActionResult AddEntries()
        {
            var viewModel = new TestViewModel
            {
                Strings = new List<string>() { "Test1", "Test2" }
            };

            return View(viewModel);
        }
    }
}
