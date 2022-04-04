using Microsoft.EntityFrameworkCore;
using Server.Database;
using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Server.Services
{
    public class EntriesService : IEntriesService
    {
        private readonly EntriesDbContext _dbContext;

        public EntriesService(EntriesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsync(List<Dictionary<int, string>> entryList)
        {
            await _dbContext.Database.ExecuteSqlRawAsync($"truncate table {nameof(_dbContext.Entries)}");

            var entries = entryList
                .SelectMany(x => x.Select(kvp => new Entry
                {
                    Code = kvp.Key,
                    Value = kvp.Value,
                }))
                .OrderBy(x => x.Code);

            _dbContext.Entries.AddRange(entries);
            await _dbContext.SaveChangesAsync();

            return _dbContext.Entries.Count();
        }

        public async Task<Page<Entry>> GetAsync(GetEntriesParameters parameters)
        {
            var filters = new List<Expression<Func<Entry, bool>>>();

            if (parameters.Code != null)
            {
                filters.Add(e => e.Code == parameters.Code.Value);
            }

            if (parameters.Value != null)
            {
                filters.Add(e => e.Value == parameters.Value);
            }

            var entries = await _dbContext
                .Entries
                .Apply(filters)
                .Skip(parameters.PageNumber * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await _dbContext
                .Entries.CountAsync();

            var page = new Page<Entry>()
            {
                Number = parameters.PageNumber,
                Size = parameters.PageSize,
                TotalPages = count / parameters.PageSize + (count % parameters.PageSize == 0 ? 0 : 1),
                Elements = entries
            };

            return page;
        }
    }
}
