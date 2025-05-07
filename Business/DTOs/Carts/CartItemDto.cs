namespace Business.DTOs.Carts;

public class CartItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public double ProductPrice { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductImageUrl { get; set; } = string.Empty;
    public int Quantity { get; set; }
}