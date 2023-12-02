using AutoMapper;
using Dapper;
using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.Data;
using ManaCoreWebApplication.Models;
using MediatR;

namespace ManaCoreWebApplication.App.Query;

public class GetCategoryProductsDapperQueryHandler: IRequestHandler<GetCategoryProductsDapperQuery, List<CategoryProductDto>>
{
    private readonly DapperContext _context;
    private readonly IMapper _mapper;
    public GetCategoryProductsDapperQueryHandler(DapperContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CategoryProductDto>> Handle(GetCategoryProductsDapperQuery request, CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM Categories c JOIN Products p ON c.Id = p.CategoryId";
        using (var connection = _context.CreateConnection())
        {
            var categoriesDict = new Dictionary<int, CategoryProductDto>();
            var categories = await connection.QueryAsync<CategoryProductDto, ProductDto, CategoryProductDto>(
                query, (category, product) =>
                {
                    if (!categoriesDict.TryGetValue(category.Id, out var currentCategory))
                    {
                        currentCategory = category;
                        categoriesDict.Add(currentCategory.Id, currentCategory);
                    }
                    currentCategory.Products.Add(product);
                    return currentCategory;
                }
            );
            var aa = _mapper.Map<List<CategoryProductDto>>(categories.Distinct().ToList());
            return await Task.FromResult(aa);
        }

        // return await Task.FromResult(result.ToList());
    }
    
    
    private async Task<IEnumerable<CategoryProductDto>> GetFilterProductsQuery(int pageNo = 1, int pageSize = 10)
    {
        int skip = (pageNo - 1) * pageSize;
        
        var query = string.Format(@"SELECT * FROM [Products] ORDER BY [Id] OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", skip, pageSize);
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<CategoryProductDto>(query);
            return products;
        }
    }
    
}