using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using DwellingRepository.Catalogs;
using DwellingRepository.Models;

namespace DwellingSystemUi.Controllers
{
    public class CatalogController : BaseController
    {


        [AllowAnonymous]
        [HttpPost]
        public ActionResult LocationsByZipCode(string zipCode)
        {
            try
            {
                var lista = CatalogRepository.GetLocationsByZipCode(zipCode, Db);
               

                return Json(new
                            {
                                Locations = lista
                            });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Json("");
            }
        }
    }
}