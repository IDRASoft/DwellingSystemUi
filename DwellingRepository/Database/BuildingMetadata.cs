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
        [StringLength(50, ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "LENGTH_FIELD_50", MinimumLength = 1)]
        public string OuterNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "NAME_LABEL", ResourceType = typeof(ResManagment))]
        [StringLength(50, ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "LENGTH_FIELD_50", MinimumLength = 1)]
        public string NameBuilding { get; set; }

    }
}