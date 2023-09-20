using Microsoft.AspNetCore.Mvc;

namespace NLayer.Web.Controllers
{
    public class ProductsController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
