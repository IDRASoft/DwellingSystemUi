using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;

namespace DwellingRepository.Catalogs
{
    public class CatalogRepository
    {
        public Task<List<ComboBoxModel>> GetLstColors(DwellingEntities db)
        {
            Thread.Sleep(5000);
            Debug.WriteLine("Repositorio");

            return db.CatColor.Where(e => e.IsObsolete == false)
                .Select(e => new ComboBoxModel
                    {
                        KeyId = e.CatColorId,
                        Value = e.Name
                    }
                ).ToListAsync();

        }
    }
}
