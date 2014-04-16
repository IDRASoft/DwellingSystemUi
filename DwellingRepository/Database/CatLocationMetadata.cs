using System.ComponentModel.DataAnnotations;
using DwellingRepository.Resources;

namespace DwellingRepository.Database
{

    [MetadataType(typeof(CatLocationMetadata))]
    public partial class CatLocation
    {
        
    }
    public class CatLocationMetadata
    {
        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "ZIPCODE_LABEL", ResourceType = typeof(ResManagment))]
        [StringLength(5, ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "LENGTH_FIELD_50", MinimumLength = 1)]
        public string ZipCode { get; set; }
    }
}
