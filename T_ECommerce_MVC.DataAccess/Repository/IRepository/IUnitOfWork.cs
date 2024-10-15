﻿namespace T_ECommerce_MVC.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        
        IProductRepository Product { get; }
        
        ICompanyRepository Company { get; }
        
        IShoppingCartRepository ShoppingCart { get; }
        
        IApplicationUserRepository ApplicationUser { get; }
        
        IOrderDetailRepository OrderDetail { get; }
        
        IOrderHeaderRepository OrderHeader { get; }
        
        IProductImageRepository ProductImage { get; }

        void Save();
    }
}