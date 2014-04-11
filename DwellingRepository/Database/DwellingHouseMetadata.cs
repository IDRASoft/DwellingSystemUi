using System.ComponentModel.DataAnnotations;
using DwellingRepository.Resources;

namespace DwellingRepository.Database
{
    [MetadataType(typeof(DwellingHouseMetadata))]
    public partial class DwellingHouse
    {
    }
    public class DwellingHouseMetadata
    {
        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "OUTER_NUMBER_LABEL", ResourceType = typeof(ResManagment))]
        public string OuterNumber { get; set; }
    }
}
