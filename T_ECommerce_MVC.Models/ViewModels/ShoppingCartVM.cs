﻿namespace T_ECommerce_MVC.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        public double OrderTotal { get; set; }
    }
}