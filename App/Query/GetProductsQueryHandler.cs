using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;
using ManaCoreWebApplication.App.Helper;
using ManaCoreWebApplication.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManaCoreWebApplication.App.Query;

public class GetProductsQueryHandler: IRequestHandler<GetProductsQuery, PagedResultDto<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResultDto<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var query = GetFilterQuery(request);
        var count = await query.CountAsync();
        var result = PagedResultDto<ProductDto>.ToPagedList(query, count, request.PageIndex, request.PageSize);

        return result;
    }

    private IQueryable<ProductDto> GetFilterQuery(GetProductsQuery filter)
    {
        var categories = _unitOfWork.Products.GetAll().AsNoTracking()
            .Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId
            })
            .WhereIf(!string.IsNullOrEmpty(filter.Filter), p => p.Name.Contains(filter.Filter))
            .OrderByDescending(p => p.Name);

        return categories;
    }
    
}