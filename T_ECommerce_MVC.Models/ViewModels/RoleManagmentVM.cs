using System.Web.Mvc;

namespace T_ECommerce_MVC.Models.ViewModels
{
    public class RoleManagmentVM
    {
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }

        public IEnumerable<SelectListItem> CompanyList { get; set; }
    }
}
