using T_ECommerce_MVC.Models;

namespace T_ECommerce_MVC.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
