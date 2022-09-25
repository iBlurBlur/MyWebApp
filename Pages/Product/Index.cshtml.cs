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

        public async Task OnGetAsync()
        {
            Products = await dekDueShopContext.Products.OrderByDescending(order => order.ProductId)
                .ProjectToType<ProductViewModel>()
                .ToListAsync();
        }

        //products/123 => user/123
        public async Task OnGetIDAsync(int id)
        {
           ViewData["Users"] = await userAPI.GetUser(id);
        }
    }
}
