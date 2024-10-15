using T_ECommerce_MVC.Models;

namespace T_ECommerce_MVC.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
