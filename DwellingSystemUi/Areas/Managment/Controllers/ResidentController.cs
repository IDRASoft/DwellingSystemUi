using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DwellingRepository.Catalogs;
using DwellingRepository.Common;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;
using DwellingSystemUi.Controllers;
using DwellingSystemUi.Resources;
using DwellingSystemUi.Services;
using Infrastructure.JqGrid.Model;

namespace DwellingSystemUi.Areas.Managment.Controllers
{
    public class ResidentController : BaseController
    {

        public ActionResult List(JqGridFilterModel opts, int? dwellingId)
        {
            if (dwellingId == null)
                dwellingId = 0;

            var genericRepository = new GenericRepository<VwResident>(Db);

            var lista= genericRepository.JqGridFindBy(opts, VwResidentDataJson.Key, VwResidentDataJson.Columns,m => m.DwellingId == dwellingId);

            return Json(lista);
        }

        public ActionResult Upsert(int? idA, int? idB)
        {
            ViewBag.DocumentTypeList = new JavaScriptSerializer().Serialize(CatalogRepository.GetDocumentTypeCat(Db));

            Resident model;

            if (idB!=null && idB > 0)//id del residente
            {
                model = new GenericRepository<Resident>(Db).FindById(idB);
                model.DwellingResidentRelToUSe = model.DwellingResidentRel.First(m => m.DwellingId == idA && m.ResidentId==idB);
            }
            else
            {
                var dwellingId=0;

                if (idA != null) dwellingId = idA.Value;

                model = new Resident
                        {
                            //DwellingResidentRelToUSe = new DwellingResidentRel { DwellingId = dwellingId },
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

            var residentSvc = new ResidentService(Db);

            return Json(residentSvc.SaveUpdateResident(model));
        }
        
        [HttpPost]
        public ActionResult DoObsolete()
        {
            return Json("");
        }

	}
}