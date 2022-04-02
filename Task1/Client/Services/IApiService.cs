using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Database.Entities;

namespace Client1.Services
{
    public interface IApiService
    {
        public Task<IEnumerable<Entry>> GetAsync();
    }
}
