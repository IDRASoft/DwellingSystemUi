using System;
using System.Web.Mvc;
using DwellingRepository.Database;

namespace DwellingSystemUi.Controllers
{
    public class BaseController : Controller
    {
        protected DwellingEntities Db = new DwellingEntities();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    Db.Dispose();
                }
                catch (Exception)
                {
                }
            }
            base.Dispose(disposing);
        }
    }
}