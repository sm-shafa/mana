using ManaCoreWebApplication.App.Dto.Pagination;
using MediatR;

namespace ManaCoreWebApplication.App.Query;

public class GetCategoriesQueryHandler
    : IRequestHandler<GetCategoriesQuery, PagedResultDto<Models.Category>>
{
    public GetCategoriesQueryHandler()
    {
        
    }
    
    public async Task<PagedResultDto<Models.Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}