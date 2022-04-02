using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entities;
using Server.Models;

namespace Client.Services
{
    public interface IApiService
    {
        public Task<Page<Entry>> GetAsync(int? code = null, string value = null, int pageNumber = 0, int pageSize = 10);
        public Task<int> SaveAsync(IEnumerable<Entry> entries);
    }
}
