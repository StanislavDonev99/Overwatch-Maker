﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Overwatch_Maker.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OverwatchDBEntities : DbContext
    {
        public OverwatchDBEntities()
            : base("name=OverwatchDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
    }
}
