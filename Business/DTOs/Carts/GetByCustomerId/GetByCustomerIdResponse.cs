namespace Business.DTOs.Carts.GetByCustomerId;

public class GetByCustomerIdResponse
{
    public int CartId { get; set; }
    public int CustomerId { get; set; }
    public int Size { get; set; }
    public decimal TotalPrice { get; set; }
    public List<GetByCustomerIdCartItemDto> CartItems { get; set; } = [];
}

public class GetByCustomerIdCartItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductImageUrl { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
