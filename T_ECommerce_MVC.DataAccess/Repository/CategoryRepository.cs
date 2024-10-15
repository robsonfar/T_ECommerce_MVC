using T_ECommerce_MVC.DataAccess.Data;
using T_ECommerce_MVC.DataAccess.Repository.IRepository;
using T_ECommerce_MVC.Models;

namespace T_ECommerce_MVC.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
