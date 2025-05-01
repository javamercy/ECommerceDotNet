using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class CartItemRepository : EfRepositoryBase<CartItem, ECommerceContext>, ICartItemRepository
{
    public CartItemRepository(ECommerceContext context) : base(context)
    {
    }
}