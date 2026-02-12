using Microsoft.AspNetCore.Mvc;

namespace FooduFood_AkademiQ.AI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
