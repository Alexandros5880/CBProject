using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.HelperClasses
{
    public static class Pagination
    {
        // Get Pages Number IQuerable
        public static async Task<int> CountPagesAsync<TSource>(this IQueryable<TSource> source, int pageSize)
        {
            var list = await source.ToListAsync();
            int pages = list.Count % pageSize == 0 ? list.Count / pageSize : list.Count % pageSize + 1;
            return pages;
        }

        // Get Pages Number IQuerable
        public static int CountPages<TSource>(this IQueryable<TSource> source, int pageSize)
        {
            var list = source.ToList();
            int pages = list.Count % pageSize == 0 ? list.Count / pageSize : list.Count % pageSize + 1;
            return pages;
        }

        // IQuerable
        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        // Get Pages Number IEnumerable
        public static int CountPages<TSource>(this IEnumerable<TSource> source, int pageSize)
        {
            int pages = source.Count() % pageSize == 0 ? source.Count() / pageSize : source.Count() % pageSize + 1;
            return source.Count() / pageSize;
        }

        // IEnumerable
        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}