﻿using System;
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
        [Display(Name = "NAMES_LABEL", ResourceType = typeof(ResManagment))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResShared), ErrorMessageResourceName = "REQUIRED_FIELD")]
        [Display(Name = "LASTNAME_LABEL", ResourceType = typeof(ResManagment))]
        public string LastName { get; set; }
        
        [Display(Name = "EMAIL_LABEL", ResourceType = typeof(ResManagment))]
        public string Email { get; set; }
        
        [Display(Name = "EMAIL2_LABEL", ResourceType = typeof(ResManagment))]
        public string Email2 { get; set; }
        
        [Display(Name = "PHONE_LABEL", ResourceType = typeof(ResManagment))]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "MOBILE_LABEL", ResourceType = typeof(ResManagment))]
        public string MobileNumber { get; set; }
        
        [Display(Name = "MOBILE2_LABEL", ResourceType = typeof(ResManagment))]
        public string MobileNumber2 { get; set; }
        
        [Display(Name = "OFFICE_NUMBER_LABEL", ResourceType = typeof(ResManagment))]
        public string OfficeNumber { get; set; }
        
        [Display(Name = "DOCUMENT_NUMBER_LABEL", ResourceType = typeof(ResManagment))]
        public string DocumentNumber { get; set; }
        
        [Display(Name = "BIRTHDAY_LABEL", ResourceType = typeof(ResManagment))]
        public DateTime BirthDay { get; set; }

        [Display(Name = "COMMENTS_LABEL", ResourceType = typeof(ResManagment))]
        public string Comments { get; set; }
    }
}