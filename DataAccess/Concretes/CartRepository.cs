using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class CartRepository : EfRepositoryBase<Cart, ECommerceContext>, ICartRepository
{
    public CartRepository(ECommerceContext context) : base(context)
    {
    }
}