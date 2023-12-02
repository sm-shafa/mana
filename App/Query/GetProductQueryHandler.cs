using Dapper;
using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.Data;
using ManaCoreWebApplication.Models;
using ManaCoreWebApplication.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManaCoreWebApplication.App.Query;

public class GetProductQueryHandler: IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DapperContext _context;

    public GetProductQueryHandler(IUnitOfWork unitOfWork, DapperContext context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        // var result = _unitOfWork.Products.GetAll().AsNoTracking()
        //     .Select(x => new ProductDto()
        //     {
        //         Id = x.Id,
        //         Name = x.Name,
        //         CategoryId = x.CategoryId
        //     }).SingleOrDefault(x => x.Id == request.Id);
        //
        // return result;
        
        var query = "SELECT * FROM Products WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            var product = await connection.QuerySingleOrDefaultAsync<ProductDto>(query, new { request.Id });
            
            return product;
        }
    }
}