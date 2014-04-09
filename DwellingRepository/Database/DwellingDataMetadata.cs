using Infrastructure.Extensions;

namespace DwellingRepository.Database
{
    public class VwDwellingDataJson
    {

        public static VwDwellingData ModelEnt;

        public static string Key = ModelEnt.PropertyName(e => e.DwellingId);

        public static string Columns = string.Join(",", new[]
                                                        {
                                                            ModelEnt.PropertyName(e => e.DwellingId),
                                                            ModelEnt.PropertyName(e => e.Address),
                                                            ModelEnt.PropertyName(e => e.DwellingType)
                                                        });
}
}