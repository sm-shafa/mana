using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;
using ManaCoreWebApplication.App.Helper;
using ManaCoreWebApplication.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManaCoreWebApplication.App.Query;

public class GetCategoriesQueryHandler
    : IRequestHandler<GetCategoriesQuery, PagedResultDto<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCategoriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResultDto<CategoryDto>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var query = GetFilterQuery(request);
        var count = await query.CountAsync();
        var result = PagedResultDto<CategoryDto>.ToPagedList(query, count, request.PageIndex, request.PageSize);

        return result;
    }

    private IQueryable<CategoryDto> GetFilterQuery(GetCategoriesQuery filter)
    {
        var categories = _unitOfWork.Categories.GetAll().AsNoTracking()
            .Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name
            })
            .WhereIf(!string.IsNullOrEmpty(filter.Filter), p => p.Name.Contains(filter.Filter))
            .OrderByDescending(p => p.Name);

        return categories;
    }
}