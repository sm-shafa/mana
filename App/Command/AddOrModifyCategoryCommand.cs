using MediatR;

namespace ManaCoreWebApplication.App.Command;

public class AddOrModifyCategoryCommand : IRequest
{
    public AddOrModifyCategoryCommand()
    {
    }

    public AddOrModifyCategoryCommand(int? id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public int? Id { set; get; }
    public string Name { set; get; }
    
}