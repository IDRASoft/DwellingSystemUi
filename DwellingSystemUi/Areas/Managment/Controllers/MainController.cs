using System;
using System.Diagnostics;
using System.Web.Mvc;
using DwellingRepository.Common;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;
using DwellingSystemUi.Controllers;
using DwellingSystemUi.Resources;
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

        public ActionResult Upsert()
        {
            return View(new DwellingRel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoUpsert(DwellingRel model, string param)
        {
            try
            {

                var cosa = model;

                Debug.WriteLine(param);

                if(model.DwellingHouseToUse.OuterNumber == null)
                    Debug.WriteLine("es nula la cosa");

                if (ModelState.IsValid)
                {
                    return Json(new ResponseMessageModel
                                {
                                    HasError = false,
                                    Title = ResShared.TITLE_REGISTER_FAILED,
                                    Message = ResShared.ERROR_INVALID_MODEL
                                });
                }

                /*
                Db.DwellingApartment.Add(model.DwellingApartmentToUse);

                var repository = new GenericRepository<DwellingRel>();

                if (model.DwellingId == EntityConstants.NULL_VALUE)
                {
                    repository.Add(model);
                }
                else
                {
                    repository.Update(model);
                }*/

                return Json(new ResponseMessageModel
                            {
                                HasError = true,
                                Title = ResShared.TITLE_REGISTER_SUCCESS,
                                Message = ResShared.INFO_REGISTER_SAVED
                            });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return Json(new ResponseMessageModel
                {
                    HasError = true,
                    Title = ResShared.TITLE_REGISTER_FAILED,
                    Message = ResShared.ERROR_UNKOWN
                });
            }
        }
    }
}