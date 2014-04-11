using System.ComponentModel.DataAnnotations;
using DwellingRepository.Resources;

namespace DwellingRepository.Database
{
    [MetadataType(typeof(DwellingApartmentMetadata))]
    public partial class DwellingApartment
    {
        
    }

    public class DwellingApartmentMetadata
    {
        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "INNER_NUMBER_LABEL", ResourceType = typeof(ResManagment))]
        public string InnerNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "FLOOR_LABEL", ResourceType = typeof(ResManagment))]
        public string Floor { get; set; }
    }
}
