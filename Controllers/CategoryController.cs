using ManaCoreWebApplication.App.Command;
using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;
using ManaCoreWebApplication.App.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManaCoreWebApplication.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [Route("Create")]
    public async Task Create(AddOrModifyCategoryCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
    }
    
    [HttpPut]
    [Route("UpdateCategory")]
    public async Task UpdateCategory(AddOrModifyCategoryCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
    }
    
    [HttpPost]
    [Route("GetCategories")]
    public async Task<ActionResult<PagedResultDto<CategoryDto>>> GetCategories(GetCategoriesQuery getCategoriesQuery,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(getCategoriesQuery, cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetCategory")]
    public async Task<ActionResult<CategoryDto>> Get(int categoryId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCategoryQuery(categoryId), cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetCategories")]
    public async Task<ActionResult<PagedResultDto<CategoryDto>>> GetCategories(int pageIndex, int pageSize,
        string? filter, string? sorting, CancellationToken cancellationToken)
    {
        GetCategoriesQuery getCategoriesQuery = new GetCategoriesQuery()
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Filter = filter,
            Sorting = sorting
        };
        var result = await _mediator.Send(getCategoriesQuery, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetCategoriesProducts")]
    public async Task<ActionResult<PagedResultDto<CategoryDto>>> GetCategoriesProducts(CancellationToken cancellationToken)
    {
        GetCategoryProductsDapperQuery getCategoryProductsDapperQuery = new GetCategoryProductsDapperQuery()
        {
        };
        var result = await _mediator.Send(getCategoryProductsDapperQuery, cancellationToken);
        
        return Ok(result);
    }
}

