using System;
using System.Web.Mvc;
using DwellingRepository.Catalogs;
using DwellingRepository.Common;
using DwellingRepository.Database;
using DwellingSystemUi.Controllers;
using Infrastructure.JqGrid.Model;

namespace DwellingSystemUi.Areas.Managment.Controllers
{
    public class ServiceController : BaseController 
    {
        //
        // GET: /Managment/Service/
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult List(JqGridFilterModel opts)
        {
            var genericRepository = new GenericRepository<VwServiceData>(Db);
            return Json(genericRepository.JqGridFindBy(opts, VwServiceDataJson.Key, VwServiceDataJson.Columns, model=> model.IsObsolete == false));
        }

        public ActionResult Upsert(int? id)
        {
            var serviceRepository = new ServiceRepository(Db);
            var result = new Service();
            ViewBag.listPeriodicity = serviceRepository.GetCatPeriodicity();
            var resultTax = serviceRepository.GetCatTax();
            ViewBag.listTax = resultTax;
            if (id.HasValue)
            {
                result = serviceRepository.GetMetadataById(id);
            }
            else
            {
                result.PeriodEnd = DateTime.Now;
                result.PeriodStart = DateTime.Now;
            }
            return View(result);
        }

        [HttpPost]
        public ActionResult DoActive(int id)
        {
            var serviceRepository = new ServiceRepository(Db);
            return Json(serviceRepository.ActiveService(id));
        }

        [HttpPost]
        public ActionResult DoObsolete(int id)
        {
            var serviceRepository = new ServiceRepository(Db);
            return Json(serviceRepository.DoObsolete(id));
        }

        [HttpPost]
        public ActionResult DoDeactive(int id)
        {
            var serviceRepository = new ServiceRepository(Db);
            return Json(serviceRepository.DoDeactive(id));
        }

        [HttpPost]
        public ActionResult DoUpsert(Service service)
        {
            var serviceRepository = new ServiceRepository(Db);
            return Json(serviceRepository.DoUpsert(service));
        }

        public ActionResult AssociationDwelling()
        {
            return View();
        }
	}
}