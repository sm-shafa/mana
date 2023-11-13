using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;

namespace ManaCoreWebApplication.App.Query;

public class GetProductQuery: PagingParamQuery<ProductDto>
{
    public GetProductQuery() { }

    public GetProductQuery(int id)
    {
        Id = id;
    }

    public int Id { set; get; }
}