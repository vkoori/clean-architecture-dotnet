namespace Infrastructure.Repositories;

using Domain.Repositories;

public class PaginationResult<TModel> : IPaginationResult<TModel>
{
    public int CurrentPage { get; set; }
    public int LastPages { get; set; }
    public int TotalItems { get; set; }
    public IEnumerable<TModel> Items { get; set; } = Array.Empty<TModel>();
}
