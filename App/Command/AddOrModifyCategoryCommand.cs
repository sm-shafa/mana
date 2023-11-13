using MediatR;

namespace ManaCoreWebApplication.App.Command;

public class AddOrModifyCategoryCommand : IRequest
{
    public AddOrModifyCategoryCommand()
    {
    }

    public AddOrModifyCategoryCommand(string name)
    {
        Name = name;
    }
    
    public string Name { set; get; }
    
}