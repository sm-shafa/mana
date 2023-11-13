using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManaCoreWebApplication.App.Query;

public class GetCategoryQueryHandler: IRequestHandler<GetCategoryQuery, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = _unitOfWork.Categories.GetAll().AsNoTracking().Select(x => new CategoryDto()
        {
            Id = x.Id,
            Name = x.Name
        }).SingleOrDefault(x => x.Id == request.Id);

        return result;
    }
    
}