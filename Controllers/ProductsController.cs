using ManaCoreWebApplication.App.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManaCoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ProductsController(IMediator mediator) => _mediator = mediator;
        
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
    }
}