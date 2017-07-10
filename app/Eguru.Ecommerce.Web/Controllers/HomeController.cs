using Eguru.Ecommerce.Application;
using Eguru.Ecommerce.Web.Singleton;
using System.Linq;
using System.Web.Mvc;

namespace Eguru.Ecommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productApplication = new ProductApplication(SessionManager.GetInstance());
            var products = productApplication.Search(null).ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var productApplication = new ProductApplication(SessionManager.GetInstance());
            var product = productApplication.Get(id);
            return View(product);
        }
    }
}