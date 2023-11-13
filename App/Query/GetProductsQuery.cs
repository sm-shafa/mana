using ManaCoreWebApplication.App.Dto.Pagination;

namespace ManaCoreWebApplication.App.Query;

public class GetProductsQuery: PagingParamQuery<PagedResultDto<Models.Product>>
{
    public GetProductsQuery(){}
    
}