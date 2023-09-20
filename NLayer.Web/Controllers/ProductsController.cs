using Microsoft.AspNetCore.Mvc;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {

        public IActionResult Index()
        {
            return View();
           
        }
    }
}
