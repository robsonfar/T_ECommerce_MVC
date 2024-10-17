namespace T_ECommerce_MVC.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        
        IProductRepository Product { get; }

        void Save();
    }
}
