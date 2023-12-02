using Dapper;
using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;
using ManaCoreWebApplication.App.Helper;
using ManaCoreWebApplication.Data;
using ManaCoreWebApplication.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManaCoreWebApplication.App.Query;

public class GetProductsDapperQueryHandler: IRequestHandler<GetProductsDapperQuery, List<ProductDto>>
{
    private readonly DapperContext _context;
    public GetProductsDapperQueryHandler(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> Handle(GetProductsDapperQuery request, CancellationToken cancellationToken)
    {
        var result = await GetFilterProductsQuery(request.PageNo ?? 1, request.PageSize ?? 5);

        return await Task.FromResult(result.ToList());
    }
    
    
    private async Task<IEnumerable<ProductDto>> GetFilterProductsQuery(int pageNo = 1, int pageSize = 10)
    {
        int skip = (pageNo - 1) * pageSize;
        
        var query = string.Format(@"SELECT * FROM [Products] ORDER BY [Id] OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", skip, pageSize);
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<ProductDto>(query);
            return products;
        }
    }
    
}