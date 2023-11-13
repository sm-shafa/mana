using MediatR;

namespace ManaCoreWebApplication.App.Command;

public class AddOrUpdateProductCommandHandler: IRequestHandler<AddOrModifyProductCommand> 
{
    public async Task Handle(AddOrModifyProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    } 
}