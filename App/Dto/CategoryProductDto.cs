namespace ManaCoreWebApplication.App.Dto;

public class CategoryProductDto
{
    public int Id { set; get; }
    public string Name { set; get; }
    public List<ProductDto> Products { get; set; } = new List<ProductDto>();
}