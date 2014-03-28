using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using DwellingSystemUi.Services;

namespace DwellingSystemUi.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {

            var t = await new CatalogService().GetLstColors(Db);
            ViewBag.Yony = t;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application  description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}