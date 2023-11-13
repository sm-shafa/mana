using ManaCoreWebApplication.App.Command;
using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.App.Dto.Pagination;
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
        
        [HttpPost]
        [Route("CreateProduct")]
        public async Task CreateProduct(CreateOrUpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task UpdateProduct(CreateOrUpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
        }
        
        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<PagedResultDto<ProductDto>>> GetProducts(int pageIndex, int pageSize,
            string? filter, string? sorting, CancellationToken cancellationToken)
        {
            GetProductsQuery getCategoriesQuery = new GetProductsQuery()
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
        [Route("GetProduct")]
        public async Task<ActionResult<CategoryDto>> Get(int productId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductQuery(productId), cancellationToken);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("GetProducts")]
        public async Task<ActionResult<PagedResultDto<ProductDto>>> GetProducts(GetProductsQuery getProductsQuery,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(getProductsQuery, cancellationToken);

            return Ok(result);
        }
    }
}