using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DwellingRepository.Catalogs;
using DwellingRepository.Common;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;
using DwellingSystemUi.Controllers;
using DwellingSystemUi.Resources;
using Infrastructure.JqGrid.Model;

namespace DwellingSystemUi.Areas.Managment.Controllers
{
    public class ResidentController : BaseController
    {

        public ActionResult List(JqGridFilterModel opts)
        {
            var genericRepository = new GenericRepository<Resident>(Db);
            return Json(genericRepository.JqGridFindBy(opts, VwDwellingDataJson.Key, VwDwellingDataJson.Columns));
        }

        public ActionResult Upsert(int dwellingId, int residentId)
        {
            ViewBag.DocumentTypeList = new JavaScriptSerializer().Serialize(CatalogRepository.GetDocumentTypeCat(Db));

            Resident model;

            if (residentId > 0)
            {
                model = new GenericRepository<Resident>(Db).FindById(residentId);
                model.DwellingResidentRelToUSe = model.DwellingResidentRel.First(m => m.DwellingId == dwellingId);
            }
            else
            {
                model = new Resident
                        {
                            DwellingResidentRelToUSe = new DwellingResidentRel{DwellingId = dwellingId},
                            DocumentTypeId = 0
                        };
            }
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoUpsert(Resident model)
        {

            ModelState.Clear();

            if (!TryValidateModel(new object()))
                return Json(new ResponseMessageModel
                            {
                                HasError = true,
                                Title = ResShared.TITLE_REGISTER_FAILED,
                                Message = ResShared.ERROR_INVALID_MODEL
                            });

            if (!ModelState.IsValid)
            {
                return Json(new ResponseMessageModel
                            {
                                HasError = true,
                                Title = ResShared.TITLE_REGISTER_FAILED,
                                Message = ResShared.ERROR_INVALID_MODEL
                            });
            }

            return Json("");
        }
        
        [HttpPost]
        public ActionResult DoObsolete()
        {
            return Json("");
        }

	}
}