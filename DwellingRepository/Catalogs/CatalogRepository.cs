using System.Collections.Generic;
using System.Linq;
using DwellingRepository.Database;
using DwellingRepository.Models;
using DwellingRepository.Models.Shared;

namespace DwellingRepository.Catalogs
{
    public class CatalogRepository
    {
           public static List<ZipCodeLocationModel> GetLocationsByZipCode(string sZipCode, DwellingEntities db)
        {
            return db.CatLocation.Where(e => e.ZipCode.StartsWith(sZipCode)).Select(e => new ZipCodeLocationModel()
                                                                                         {
                                                                                             CountryName =
                                                                                                 e.CatMunicipality
                                                                                                 .CatState.Name,
                                                                                             StateName =
                                                                                                 e.CatMunicipality
                                                                                                 .CatState.Name,
                                                                                             MunicipalityName =
                                                                                                 e.CatMunicipality.Name,
                                                                                             LocationName = e.Name,
                                                                                             ZipCode = e.ZipCode,
                                                                                             LocationId = e.LocationId
                                                                                         })
                .ToList()
                .OrderBy(e => e.ZipCode)
                .ThenBy(e => e.LocationName)
                .ToList();

        }

        public static List<StreetComboBoxModel> GetStreetCat(DwellingEntities db)
        {
            return db.Street.Select(e => new StreetComboBoxModel()
                                         {
                                             KeyId = e.StreetId,
                                             Value = e.Name
                                         }).ToList().OrderBy(e=>e.Value).ToList();
        }
    }
}

