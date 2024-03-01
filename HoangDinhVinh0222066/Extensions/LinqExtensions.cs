using System.Linq.Expressions;

namespace HoangDinhVinh0222066.Extensions;

public static class LinqExtensions
{
    public static IQueryable<T> ToOrderedQuery<T>(this IQueryable<T> query, Expression<Func<T, object>> selector, bool asc = true)
    {
        return asc ? query.OrderBy(selector) : query.OrderByDescending(selector);
    }
}