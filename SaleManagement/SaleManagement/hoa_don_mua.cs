//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class hoa_don_mua
    {
        public hoa_don_mua()
        {
            this.chi_tiet_hoa_don_mua = new HashSet<chi_tiet_hoa_don_mua>();
        }
    
        public int ma_hoa_don { get; set; }
        public System.DateTime ngay_lap { get; set; }
        public int ma_nha_cung_cap { get; set; }
        public double tong_tien { get; set; }
    
        public virtual ICollection<chi_tiet_hoa_don_mua> chi_tiet_hoa_don_mua { get; set; }
        public virtual nha_cung_cap nha_cung_cap { get; set; }
    }
}