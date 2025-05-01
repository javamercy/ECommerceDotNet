namespace Business.DTOs.Carts.GetByCustomerId;

public class GetByCustomerIdResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int TotalCount { get; set; }
    public List<CartItemDto> CartItems { get; set; } = [];
}

public class CartItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductImageUrl { get; set; } = string.Empty;

    public int Quantity { get; set; }
}