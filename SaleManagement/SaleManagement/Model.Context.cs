﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaleManagement
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_sale_managementEntities : DbContext
    {
        public db_sale_managementEntities()
            : base("name=db_sale_managementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<chi_tiet_hoa_don_ban> chi_tiet_hoa_don_ban { get; set; }
        public virtual DbSet<chi_tiet_hoa_don_mua> chi_tiet_hoa_don_mua { get; set; }
        public virtual DbSet<hoa_don_ban> hoa_don_ban { get; set; }
        public virtual DbSet<hoa_don_mua> hoa_don_mua { get; set; }
        public virtual DbSet<khach_hang> khach_hang { get; set; }
        public virtual DbSet<loai_san_pham> loai_san_pham { get; set; }
        public virtual DbSet<nha_cung_cap> nha_cung_cap { get; set; }
        public virtual DbSet<nhan_vien> nhan_vien { get; set; }
        public virtual DbSet<san_pham> san_pham { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}