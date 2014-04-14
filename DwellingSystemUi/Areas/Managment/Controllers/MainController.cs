using System;
using System.Diagnostics;
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
    public class MainController : BaseController
    {
     
        public ActionResult Index()
        {
            ViewBag.PrevStreetId = 0;
            return View();
        }

        public ActionResult List(JqGridFilterModel opts)
        {
            var genericRepository = new GenericRepository<VwDwellingData>(Db);
            return Json(genericRepository.JqGridFindBy(opts, VwDwellingDataJson.Key, VwDwellingDataJson.Columns));
        }

        public ActionResult Upsert(int? id)
        {
            DwellingRel model;

            if (id != null)
            {
                model = new GenericRepository<DwellingRel>(Db).FindById(id);
                var dwellingSvc = new DwellingRelService(Db);
                model = dwellingSvc.FillDwellingModel(model);

                model.StreetId = model.IsApartment ? model.DwellingApartmentToUse.Building.StreetId : model.DwellingHouseToUse.StreetId;
            }
            else
            {
                model = new DwellingRel { CatLocation = new CatLocation() };
                ViewBag.PrevStreetId = 0;
            }

            ViewBag.StreetList = new JavaScriptSerializer().Serialize(CatalogRepository.GetStreetCat(Db));
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoUpsert(DwellingRel model)
        {

            if (model.IsApartment)
            {
                model.DwellingHouseToUse = null;
                model.DwellingApartmentToUse.Building.StreetId = model.StreetId;
            }
            else
            {
                model.DwellingApartmentToUse = null;
                model.DwellingHouseToUse.StreetId = model.StreetId;
            }
            try
            {
                ModelState.Clear();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return Json(new ResponseMessageModel
                {
                    HasError = true,
                    Title = ResShared.TITLE_REGISTER_FAILED,
                    Message = ResShared.ERROR_INVALID_MODEL
                });

            }

            if (!TryValidateModel(model))
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

            var dwellingSvc = new DwellingRelService(Db);

            return Json(dwellingSvc.SaveUpdateDwellingRel(model));
        }

        [HttpPost]
        public ActionResult DoObsolete(int id)
        {
            var dwellingSvc = new DwellingRelService(Db);
            return Json(dwellingSvc.DoObsolete(id));
        }
    }
}