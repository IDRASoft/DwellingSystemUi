using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DwellingRepository.Database;

namespace DwellingSystemUi.Areas.Managment.Models
{
    public partial class ServiceView
    {
        public virtual Boolean isPeridicity { get; set; }

        public virtual Boolean isTax { get; set; }


        
    }
}