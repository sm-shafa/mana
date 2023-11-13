using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;

namespace ManaCoreWebApplication.App.Query;

public class GetCategoryQuery: PagingParamQuery<CategoryDto>
{
    public GetCategoryQuery(){}

    public GetCategoryQuery(int id)
    {
        Id = id;
    }
    
    public int Id { set; get; }
    
}