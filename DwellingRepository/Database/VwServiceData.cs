//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DwellingRepository.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class VwServiceData
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Periodicity { get; set; }
        public bool Active { get; set; }
        public bool IsObsolete { get; set; }
    }
}
