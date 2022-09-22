using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; } = "Hello cat";

        public void OnGet()
        {
            Message = "Hello dog";

            // Dictionary
            ViewData["Username"] = "Tanakorn";
        }
    }
}