using ManaCoreWebApplication.App.Command;
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
    
    [HttpGet]
    public async Task<ActionResult> GetCategories()
    {
        var products = await _mediator.Send(new GetCategoriesQuery());
        return Ok(products);
    }
}

