using ManaCoreWebApplication.App.Dto.Pagination;
using MediatR;

namespace ManaCoreWebApplication.App.Query;

public class GetProductsQueryHandler: IRequestHandler<GetProductsQuery, PagedResultDto<Models.Product>>
{
    public GetProductsQueryHandler()
    {
        
    }
    
    public async Task<PagedResultDto<Models.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
}