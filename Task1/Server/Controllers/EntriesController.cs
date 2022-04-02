using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Entities;
using Server.Services;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly IEntriesService _entriesService;

        public EntriesController(IEntriesService entriesService)
        {
            _entriesService = entriesService;
        }

        /// <summary>
        /// Получить записи
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <returns>Страница с записями</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetEntriesParameters parameters)
        {
            try
            {
                var page = await _entriesService.GetAsync(parameters);
                return Ok(page);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Сохранить записи
        /// </summary>
        /// <param name="entries">Список записей в виде объектов код: значение</param>
        /// <returns>Количество сохранённых записей</returns>
        [HttpPost]
        public async Task<IActionResult> Save(List<Dictionary<int, string>> entries)
        {
            try
            {
                var count = await _entriesService.SaveAsync(entries);
                return Ok(count);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
