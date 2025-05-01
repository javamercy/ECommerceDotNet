namespace Entities.Concretes;

public class CartItem : Entity
{
    public CartItem()
    {
    }

    public CartItem(int productId, int cartId, int quantity)
    {
        ProductId = productId;
        CartId = cartId;
        Quantity = quantity;
    }

    public CartItem(int productId, int cartId, int quantity, Cart? cart, Product? product)
    {
        CartId = cartId;
        ProductId = productId;
        Quantity = quantity;
        Cart = cart;
        Product = product;
    }

    public CartItem(int id, int productId, int cartId, int quantity, Cart? cart, Product? product)
    {
        Id = id;
        CartId = cartId;
        ProductId = productId;
        Quantity = quantity;
        Cart = cart;
        Product = product;
    }

    public int ProductId { get; set; }

    public int CartId { get; set; }

    public int Quantity { get; set; }

    public Cart? Cart { get; set; }

    public Product? Product { get; set; }
}