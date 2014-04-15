using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DwellingRepository.Catalogs;
using DwellingRepository.Common;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;
using DwellingSystemUi.Controllers;
using DwellingSystemUi.Resources;

namespace DwellingSystemUi.Areas.Managment.Controllers
{
    public class ResidentController : BaseController
    {
        public ActionResult Upsert(int? id)
        {
            ViewBag.DocumentTypeList = new JavaScriptSerializer().Serialize(CatalogRepository.GetDocumentTypeCat(Db));

            Resident model;

            if (id != null)
            {
                model = new GenericRepository<Resident>(Db).FindById(id);
            }
            else
            {
                model = new Resident {DocumentTypeId = 0};
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

            try
            {
                Db.Resident.Attach(model);
                Db.SaveChanges();
                return Json(new ResponseMessageModel
                {
                    HasError = false,
                    Title = ResShared.TITLE_REGISTER_SUCCESS,
                    Message = ResShared.INFO_REGISTER_SAVED
                });
            }
            catch (Exception e)
            {
                return Json(new ResponseMessageModel
                {
                    HasError = true,
                    Title = ResShared.TITLE_REGISTER_FAILED,
                    Message = ResShared.ERROR_UNKOWN
                }); 
            }
        }
        
        [HttpPost]
        public ActionResult DoObsolete()
        {
            return Json("");
        }

	}
}