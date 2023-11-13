namespace ManaCoreWebApplication.Models;

public class Product
{
    public int Id { set; get; }
    public string Name { set; get; }
    public int CategoryId { set; get; }
    public Category Category { get; set; }
}