using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
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
        //
        // GET: /Managment/Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(JqGridFilterModel opts)
        {
            var genericRepository = new GenericRepository<VwDwellingData>(Db);            
            return Json(genericRepository.JqGridFindBy(opts,VwDwellingDataJson.Key,VwDwellingDataJson.Columns));
        }

        public ActionResult Upsert(int? id)
        {
            /*DwellingRel model = null;
            if (id != null)
            {
                model = new GenericRepository<DwellingRel>(Db).FindById(id);

                //model.DwellingApartmentToUse = (DwellingApartment)model.DwellingApartment.DefaultIfEmpty();
                //model.DwellingHouseToUse = model.dwel
            }
            else
            {
                model =new DwellingRel();
            }*/

            return View(new DwellingRel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoUpsert(DwellingRel model)
        {

            if (ModelState.IsValid)
            {
                return Json(new ResponseMessageModel
                            {
                                HasError = false,
                                Title = ResShared.TITLE_REGISTER_FAILED,
                                Message = ResShared.ERROR_INVALID_MODEL
                            });
            }

            var dwellingSvc = new DwellingRelService();

            return Json(dwellingSvc.SaveUpdateDwellingRel(model));
        }

    }
}