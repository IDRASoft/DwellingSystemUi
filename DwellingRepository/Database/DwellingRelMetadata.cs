using System.ComponentModel.DataAnnotations;
using DwellingRepository.Resources;

namespace DwellingRepository.Database
{
    [MetadataType(typeof(DwellingRelMetadata))]
    public partial class DwellingRel
    {
        public DwellingApartment DwellingApartmentToUse { get; set; }
        public DwellingHouse DwellingHouseToUse { get; set; }

        public string CountryName { get; set; }

        public string StateName { get; set; }

        public string MunicipalityName { get; set; }

        public string LocationName { get; set; }

        public string ZipCode { get; set; }

        public bool IsApartment { get; set; }

        //TODO COMPLETAR LA CLASE CON LO QUE ESTA EN PROFESIONALES

    }

    public class DwellingRelMetadata
    {
        public string CountryName { get; set; }

        public string StateName { get; set; }

        public string MunicipalityName { get; set; }

        public string LocationName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "FIELD_ZIPCODE", ResourceType = typeof(ResManagment))]
        [StringLength(5, ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "LENGTH_FIELD_50", MinimumLength = 1)]
        public string ZipCode { get; set; }
        
    }
}


