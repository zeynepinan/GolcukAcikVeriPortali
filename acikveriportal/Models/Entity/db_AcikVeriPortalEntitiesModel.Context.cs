﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace acikveriportal.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_AcikVeriPortalEntities01 : DbContext
    {
        public db_AcikVeriPortalEntities01()
            : base("name=db_AcikVeriPortalEntities01")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Formats> Formats { get; set; }
        public virtual DbSet<Labels> Labels { get; set; }
        public virtual DbSet<Licenses> Licenses { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<DataRequests> DataRequests { get; set; }
        public virtual DbSet<DataSetFileDetail> DataSetFileDetail { get; set; }
        public virtual DbSet<DataSets> DataSets { get; set; }
        public virtual DbSet<admin> admin { get; set; }
    }
}
