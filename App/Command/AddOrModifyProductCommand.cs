using MediatR;

namespace ManaCoreWebApplication.App.Command;

public class AddOrModifyProductCommand: IRequest
{
    public AddOrModifyProductCommand()
    {
    }

    public AddOrModifyProductCommand(string name, int categoryId)
    {
        Name = name;
        CategoryId = categoryId;
    }
    
    public string Name { set; get; }
    public int CategoryId { set; get; }
}