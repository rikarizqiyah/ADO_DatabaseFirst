﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PeminjamanVideo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PeminjamanEntities : DbContext
    {
        public PeminjamanEntities()
            : base("name=PeminjamanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MsJenis> MsJenis1 { get; set; }
        public virtual DbSet<MsPelanggan> MsPelanggans { get; set; }
        public virtual DbSet<MsVideo> MsVideos { get; set; }
        public virtual DbSet<TrPinjam> TrPinjams { get; set; }
    }
}