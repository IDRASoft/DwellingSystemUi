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
    
    public partial class Building
    {
        public Building()
        {
            this.DwellingApartment = new HashSet<DwellingApartment>();
        }
    
        public int BuildingId { get; set; }
        public int StreetId { get; set; }
        public string NameBuilding { get; set; }
        public string OuterNumber { get; set; }
    
        public virtual Street Street { get; set; }
        public virtual ICollection<DwellingApartment> DwellingApartment { get; set; }
    }
}
