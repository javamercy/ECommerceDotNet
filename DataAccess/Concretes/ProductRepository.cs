using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class ProductRepository : EFRepositoryBase<Product, ECommerceContext>, IProductRepository
    {
        public ProductRepository(ECommerceContext context) : base(context)
        {
        }
    }
}