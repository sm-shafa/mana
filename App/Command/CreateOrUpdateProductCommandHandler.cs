using AutoMapper;
using ManaCoreWebApplication.Repository;
using MediatR;

namespace ManaCoreWebApplication.App.Command;

public class CreateOrUpdateProductCommandHandler: IRequestHandler<CreateOrUpdateProductCommand> 
{
private readonly IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
    
public CreateOrUpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
{
    _unitOfWork = unitOfWork;
    _mapper = mapper;
}
    
public async Task Handle(CreateOrUpdateProductCommand request, CancellationToken cancellationToken)
{
    var product = _mapper.Map<Models.Product>(request);
    if (_unitOfWork.Categories.GetOne(product.CategoryId) is null)
        throw new Exception("The category was not found!");
        
    var oldProduct = _unitOfWork.Products.GetOne(product.Id);
    if (oldProduct is not null)
    {
        oldProduct.Name = product.Name;
        oldProduct.CategoryId = product.CategoryId;
        _unitOfWork.Products.Update(oldProduct);
    }
    else
    {
        await _unitOfWork.Products.AddAsync(product);
    }

    _unitOfWork.Complete();
} 
}