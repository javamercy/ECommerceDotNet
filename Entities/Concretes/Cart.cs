namespace Entities.Concretes;

public class Cart : Entity
{
    public Cart()
    {
        CartItems = new HashSet<CartItem>();
    }

    public Cart(int customerId, List<CartItem> cartItems)
    {
        CustomerId = customerId;
        CartItems = cartItems;
    }

    public Cart(int id, int customerId, List<CartItem> cartItems)
    {
        Id = id;
        CustomerId = customerId;
        CartItems = cartItems;
    }

    public int CustomerId { get; set; }

    public ICollection<CartItem> CartItems { get; set; }
}