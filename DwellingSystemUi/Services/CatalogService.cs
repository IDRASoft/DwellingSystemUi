using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using DwellingRepository.Catalogs;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;

namespace DwellingSystemUi.Services
{
    public class CatalogService
    {
        public Task<string> ToJson(IList<ComboBoxModel> lstColors)
        {
            var serJson = new JavaScriptSerializer();

            var tsk = Task.Factory.StartNew(() =>
            {
                try
                {
                    return serJson.Serialize(lstColors);                
                }
                catch (Exception ex)
                {
                    
                    return ex.Message;
                }
            });
            return tsk;
        }

        public Task<string> GetLstColors(DwellingEntities db)
        {
            var lstColors = new CatalogRepository().GetLstColors(db);
            Debug.WriteLine("Servicios");            
            var jsonVal =  ToJson(lstColors.Result);
            return jsonVal;
        }
    }
}