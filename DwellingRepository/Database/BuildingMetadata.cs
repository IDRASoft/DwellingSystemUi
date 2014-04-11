using System.ComponentModel.DataAnnotations;
using DwellingRepository.Resources;

namespace DwellingRepository.Database
{
    [MetadataType(typeof(BuildingMetadata))]
    public partial class Building
    {

    }
    public class BuildingMetadata
    {
        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "OUTER_NUMBER_LABEL", ResourceType = typeof(ResManagment))]
        public string OuterNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "BUILDING_LABEL", ResourceType = typeof(ResManagment))]
        public string NameBuilding { get; set; }

    }
}