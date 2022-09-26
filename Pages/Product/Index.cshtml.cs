using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Entities;
using MyWebApp.Services;
using MyWebApp.ViewModels;

namespace MyWebApp.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly DekDueShopContext dekDueShopContext;
        private readonly IUserAPI userAPI;

        public IEnumerable<ProductViewModel>? Products { get; set; }

        public IndexModel(DekDueShopContext dekDueShopContext, IUserAPI userAPI)
        {
            this.dekDueShopContext = dekDueShopContext;
            this.userAPI = userAPI;
        }

        public async Task OnGetAsync(int? id)
        {
            if(id != null)
            {
                ViewData["Users"] = await userAPI.GetUser(id ?? 0);
                return;
            }
            Products = await dekDueShopContext.Products.OrderByDescending(order => order.ProductId)
                .ProjectToType<ProductViewModel>()
                .ToListAsync();
        }
    }
}
