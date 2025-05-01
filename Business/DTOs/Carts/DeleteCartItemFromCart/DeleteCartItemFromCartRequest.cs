namespace Business.DTOs.Carts.DeleteCartItemFromCart;

public class DeleteCartItemFromCartRequest
{
    public int CartId { get; set; }
    public int CartItemId { get; set; }

    public int Quantity { get; set; }
}