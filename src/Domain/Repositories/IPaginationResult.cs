namespace Domain.Repositories;

public interface IPaginationResult<TModel>
{
    int CurrentPage { get; set; }
    int LastPages { get; set; }
    int TotalItems { get; set; }
    IEnumerable<TModel> Items { get; set; }
}
