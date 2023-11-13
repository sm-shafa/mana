using AutoMapper;
using ManaCoreWebApplication.Repository;
using MediatR;

namespace ManaCoreWebApplication.App.Command;

public class AddOrModifyCategoryCommandHandler: IRequestHandler<AddOrModifyCategoryCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddOrModifyCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(AddOrModifyCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Models.Category>(request);
        var registered = await _unitOfWork.Categories.AddAsync(category);
        _unitOfWork.Complete();
    } 
    
}