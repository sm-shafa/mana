namespace ManaCoreWebApplication.Models;

public class Category
{
    public int Id { set; get; }
    public string Name { set; get; }
    
    public ICollection<Product> Products { set; get; }
}