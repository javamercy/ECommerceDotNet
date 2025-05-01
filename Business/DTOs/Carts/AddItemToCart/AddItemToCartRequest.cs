namespace Business.DTOs.Carts.AddItemToCart;

public class AddItemToCartRequest
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; } = 1;
}