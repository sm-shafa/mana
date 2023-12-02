using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;
using ManaCoreWebApplication.Models;
using MediatR;

namespace ManaCoreWebApplication.App.Query;

public class GetProductsDapperQuery: IRequest<List<ProductDto>>
{
    public GetProductsDapperQuery(){}
    
    public int? PageNo { get; set; }
    public int? PageSize { get; set; }
}