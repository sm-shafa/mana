using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManaCoreWebApplication.App.Query;

public class GetProductQueryHandler: IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = _unitOfWork.Products.GetAll().AsNoTracking()
            .Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId
            }).SingleOrDefault(x => x.Id == request.Id);

        return result;
    }
}