using Microsoft.AspNetCore.Mvc;

namespace FooduFood_AkademiQ.AI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
