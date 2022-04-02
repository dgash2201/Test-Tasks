using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Server.Database
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> Apply<T>(this DbSet<T> context, 
            IEnumerable<Expression<Func<T, bool>>> filters) where T : class
        {
            IQueryable<T> query = context;

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            return query;
        }
    }
}
