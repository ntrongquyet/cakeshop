﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CakeShop.SQL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbCakeShopEntities : DbContext
    {
        public dbCakeShopEntities()
            : base("name=dbCakeShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BANH> BANHs { get; set; }
        public virtual DbSet<CT_DONHANG> CT_DONHANG { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<LOAIBANH> LOAIBANHs { get; set; }
    }
}
