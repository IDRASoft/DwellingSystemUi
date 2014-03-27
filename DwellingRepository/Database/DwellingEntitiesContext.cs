using System.Data.Common;
using System.Diagnostics;

namespace DwellingRepository.Database
{
    public partial class DwellingEntities
    {
        public DwellingEntities(DbConnection db, bool bConextOwnsConnection)
            : base(db, bConextOwnsConnection)
        {
        }
    }
}
