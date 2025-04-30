namespace Entities.Concretes;

public class Product : Entity
{
    public Product()
    {
        Id = default;
        Name = string.Empty;
        Description = string.Empty;
        Price = default;
        ImageUrl = string.Empty;
        Stock = default;
        Status = default;
    }

    public Product(int id, string name, string description, decimal price, string imageUrl, int stock, bool status)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        Stock = stock;
        Status = status;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int Stock { get; set; }
    public bool Status { get; set; }
}