using T_ECommerce_MVC.Models;

namespace T_ECommerce_MVC.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
