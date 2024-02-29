using Microsoft.AspNetCore.Mvc;

namespace rememberCs.Controllers;

public class UsersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}