using System;
using DwellingRepository.Database;

namespace DwellingRepository.Common
{
    public class BaseRepository : IDisposable
    {
        protected DwellingEntities Db;

        public BaseRepository(DwellingEntities db)
        {
            Db = db;
        }

        public void Dispose()
        {
            try
            {
                if (Db != null)
                    Db.Dispose();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                Db = null;
            }
        }
    }
}