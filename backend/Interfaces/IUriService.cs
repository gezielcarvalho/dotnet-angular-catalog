using Backend.Filters;

namespace Backend.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
