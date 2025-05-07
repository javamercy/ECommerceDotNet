namespace Entities.Concretes;

public class Product : Entity
{
    public Product()
    {
        Id = 0;
        Name = string.Empty;
        Description = string.Empty;
        Price = 0;
        ImageUrl = string.Empty;
        Stock = 0;
        Status = false;
    }

    public Product(int id, string name, string description, double price, string imageUrl, int stock, bool status)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        Stock = stock;
        Status = status;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
    public int Stock { get; set; }
    public bool Status { get; set; }
}