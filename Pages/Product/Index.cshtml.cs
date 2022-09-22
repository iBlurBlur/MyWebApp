using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Entities;
using MyWebApp.ViewModels;

namespace MyWebApp.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly DekDueShopContext dekDueShopContext;

        public IEnumerable<ProductViewModel>? Products { get; set; }

        public IndexModel(DekDueShopContext dekDueShopContext) => this.dekDueShopContext = dekDueShopContext;

        public async Task OnGetAsync()
        {
            Products = await dekDueShopContext.Products.OrderByDescending(order => order.ProductId)
                .ProjectToType<ProductViewModel>()
                .ToListAsync();
        }
    }
}
