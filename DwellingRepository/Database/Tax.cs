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
    
    public partial class Tax
    {
        public Tax()
        {
            this.TaxServiceRel = new HashSet<TaxServiceRel>();
        }
    
        public int TaxId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Comments { get; set; }
        public bool IsObsolete { get; set; }
    
        public virtual ICollection<TaxServiceRel> TaxServiceRel { get; set; }
    }
}
