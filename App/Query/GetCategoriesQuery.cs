using ManaCoreWebApplication.App.Dto.Pagination;

namespace ManaCoreWebApplication.App.Query;

public class GetCategoriesQuery: PagingParamQuery<PagedResultDto<Models.Category>>
{
    public GetCategoriesQuery(){}
}