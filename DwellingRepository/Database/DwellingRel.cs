//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regeneraaa el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DwellingRepository.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class DwellingRel
    {
        public DwellingRel()
        {
            this.DwellingApartment = new HashSet<DwellingApartment>();
            this.DwellingHouse = new HashSet<DwellingHouse>();
            this.DwellingLocation = new HashSet<DwellingLocation>();
        }
    
        public int DwellingId { get; set; }
        public int LocationId { get; set; }
        public bool IsObsolete { get; set; }
    
        public virtual CatLocation CatLocation { get; set; }
        public virtual ICollection<DwellingApartment> DwellingApartment { get; set; }
        public virtual ICollection<DwellingHouse> DwellingHouse { get; set; }
        public virtual ICollection<DwellingLocation> DwellingLocation { get; set; }
    }
}
