namespace Business.DTOs.Carts;

public class CartResponse
{
    public int CartId { get; set; }
    public int CustomerId { get; set; }
    public int Size { get; set; }
    public double TotalPrice { get; set; }
    public List<CartItemDto> CartItems { get; set; } = [];
}