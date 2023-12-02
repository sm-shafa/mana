using ManaCoreWebApplication.App.Dto;
using MediatR;

namespace ManaCoreWebApplication.App.Query;

public class GetCategoryProductsDapperQuery: IRequest<List<CategoryProductDto>>
{
    public GetCategoryProductsDapperQuery(){}
    
    public int? PageNo { get; set; }
    public int? PageSize { get; set; }
}