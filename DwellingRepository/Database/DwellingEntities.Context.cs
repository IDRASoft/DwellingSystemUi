﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DwellingEntities : DbContext
    {
        public DwellingEntities()
            : base("name=DwellingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<CatCountry> CatCountry { get; set; }
        public virtual DbSet<CatLocation> CatLocation { get; set; }
        public virtual DbSet<CatMunicipality> CatMunicipality { get; set; }
        public virtual DbSet<CatState> CatState { get; set; }
        public virtual DbSet<DwellingApartment> DwellingApartment { get; set; }
        public virtual DbSet<DwellingHouse> DwellingHouse { get; set; }
        public virtual DbSet<DwellingLocation> DwellingLocation { get; set; }
        public virtual DbSet<DwellingRel> DwellingRel { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<VwDwellingData> VwDwellingData { get; set; }
    }
}
