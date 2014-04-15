﻿using System.Web.Mvc;
using System.Web.Script.Serialization;
using DwellingRepository.Catalogs;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;
using DwellingSystemUi.Controllers;
using DwellingSystemUi.Resources;

namespace DwellingSystemUi.Areas.Managment.Controllers
{
    public class ResidentControlleeeeeeeeeeeeeeeer : BaseController
    {
        public ActionResult Upsert(int? id)
        {
            ViewBag.DocumentTypeList = new JavaScriptSerializer().Serialize(CatalogRepository.GetDocumentTypeCat(Db));

            /*Comentario rOOOOOOOOOl*/

          /*  Resident model;

            if (id != null)
            {
                model = new Resident();
                //model = new GenericRepository<Resident>(Db).FindById(id);
                //todo rellenar la informacion correspondiente para editar
          
            }
            else
            {
                model = new Resident {DocumentTypeId = 0};
            }*/

            ViewBag.StreetList = new JavaScriptSerializer().Serialize(CatalogRepository.GetStreetCat(Db));
            return View(new Resident {DocumentTypeId = 0});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoUpsert(Resident model)
        {
            
            /*
            ModelState.Clear();

            if (!TryValidateModel(new object()))
                return Json(new ResponseMessageModel
                            {
                                HasError = true,
                                Title = ResShared.TITLE_REGISTER_FAILED,
                                Message = ResShared.ERROR_INVALID_MODEL
                            });*/

            if (!ModelState.IsValid)
            {
                return Json(new ResponseMessageModel
                            {
                                HasError = true,
                                Title = ResShared.TITLE_REGISTER_FAILED,
                                Message = ResShared.ERROR_INVALID_MODEL
                            });
            }


            //return Json(dwellingSvc.SaveUpdateDwellingRel(model));
            return Json("");
        }
        
        [HttpPost]
        public ActionResult DoObsolete()
        {
            return Json("");
        }

	}
}