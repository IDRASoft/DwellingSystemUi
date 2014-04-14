using System.ComponentModel.DataAnnotations;
using DwellingRepository.Resources;

namespace DwellingRepository.Database
{
    [MetadataType(typeof(ResidentMetadata))]
    public partial class Resident
    {
        private DwellingResidentRel DwellingResidentRelToUSe { get; set; }

    }
    public class ResidentMetadata
    {
        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "NAME_LABEL", ResourceType = typeof(ResManagment))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "INNER_NUMBER_LABEL", ResourceType = typeof(ResManagment))]
        public string LastName { get; set; }
    }
}
