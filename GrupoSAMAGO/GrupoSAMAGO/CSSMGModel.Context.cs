﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrupoSAMAGO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CSSMGDBEntities : DbContext
    {
        public CSSMGDBEntities()
            : base("name=CSSMGDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cambio> Cambios { get; set; }
        public virtual DbSet<Combustivel> Combustivels { get; set; }
        public virtual DbSet<Cor> Cors { get; set; }
        public virtual DbSet<Veiculo> Veiculoes { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
    }
}
