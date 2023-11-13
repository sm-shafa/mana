using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;

namespace ManaCoreWebApplication.App.Query;

public class GetProductsQuery: PagingParamQuery<PagedResultDto<ProductDto>>
{
    public GetProductsQuery(){}
    
    public string? Filter { get; set; }
    public string? Sorting { get; set; }
}