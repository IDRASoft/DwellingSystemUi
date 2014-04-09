using System.ComponentModel.DataAnnotations;
using DwellingRepository.Resources;

namespace DwellingRepository.Database
{
    [MetadataType(typeof(StreetMetadata))]
    public partial class Street
    {
    
    }
    public class StreetMetadata
    {
        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "STREET_LABEL", ResourceType = typeof(ResManagment))]
        [StringLength(50, ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "LENGTH_FIELD_50", MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "STREET_DESCRIPTION_LABEL", ResourceType = typeof(ResManagment))]
        [StringLength(50, ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "LENGTH_FIELD_50", MinimumLength = 1)]
        public string Description { get; set; }


    }
}
