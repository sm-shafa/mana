using MediatR;

namespace ManaCoreWebApplication.App.Command;

public class AddOrModifyProductCommand: IRequest
{
    public AddOrModifyProductCommand()
    {
    }

    public AddOrModifyProductCommand(string title)
    {
        Title = title;
    }
    
    public string Title { set; get; }
}