using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;

namespace ManaCoreWebApplication.App.Query;

public class GetCategoriesQuery: PagingParamQuery<PagedResultDto<CategoryDto>>
{
    public GetCategoriesQuery(){}
    
    public string? Filter { get; set; }
    public string? Sorting { get; set; }
}