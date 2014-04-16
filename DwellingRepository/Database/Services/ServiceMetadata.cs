using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DwellingRepository.Models.Shared;
using DwellingRepository.Resources;
using Infrastructure.Extensions;

namespace DwellingRepository.Database
{

    [MetadataType(typeof(ServiceMetadata))]
    public partial class Service
    {
        
        public ICollection<ComboBoxModel> ListTax { get; set; }

    }

    public class VwServiceDataJson
    {
        public static VwServiceData ModelEnt;

        public static string Key = ModelEnt.PropertyName(e => e.ServiceId);

        public static string Columns = string.Join(",", new[]
                                                        {
                                                            ModelEnt.PropertyName(e => e.ServiceId),
                                                            ModelEnt.PropertyName(e => e.Name),
                                                            ModelEnt.PropertyName(e => e.StartDate),
                                                            ModelEnt.PropertyName(e => e.EndDate),
                                                            ModelEnt.PropertyName(e => e.Periodicity),
                                                            ModelEnt.PropertyName(e => e.Value),
                                                            ModelEnt.PropertyName(e => e.Active)
                                                        });
    }

    public class ServiceMetadata
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared),
       ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "LABEL_NAME", ResourceType = typeof(ResService))]
        public String Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared),
       ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "LABEL_START_DATE", ResourceType = typeof(ResService))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/mm/dd}")] 
        public DateTime PeriodStart { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared),
       ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Range(1,30,ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "MIN_MAX_VALUE")]
        [Display(Name = "LABEL_DAY_TO_PAY", ResourceType = typeof(ResService))]
        public int DaysToPay { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared),
       ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Range(1, 9999, ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "MIN_MAX_VALUE")]
        [Display(Name = "LABEL_VALUE", ResourceType = typeof(ResService))]
        public decimal Value { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared),
       ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Range(1,30, ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "MIN_MAX_VALUE")]
        [Display(Name = "LABEL_DAYS_EXTENSION", ResourceType = typeof(ResService))]
        public int DaysExtension { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResShared),
       ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "LABEL_PERIODICITY", ResourceType = typeof(ResService))]
        public int PeriodicityId { get; set; }


    }
}
