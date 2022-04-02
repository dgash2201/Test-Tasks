using Server.Entities;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IEntriesService
    {
        public Task<int> SaveAsync(List<Dictionary<int, string>> entryList);
        public Task<Page<Entry>> GetAsync(GetEntriesParameters parameters);
    }
}
