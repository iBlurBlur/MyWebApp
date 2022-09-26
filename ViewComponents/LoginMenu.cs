using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.ViewComponents;

public class LoginMenu : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var data = new { name = "tanakorn" };
        return View(data);
    }
}
