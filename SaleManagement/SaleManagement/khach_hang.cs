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
    
    public partial class khach_hang
    {
        public khach_hang()
        {
            this.hoa_don_ban = new HashSet<hoa_don_ban>();
        }
    
        public int ma_khach_hang { get; set; }
        public string ho_ten { get; set; }
        public System.DateTime ngay_sinh { get; set; }
        public string dia_chi { get; set; }
        public string so_dien_thoai { get; set; }
    
        public virtual ICollection<hoa_don_ban> hoa_don_ban { get; set; }
    }
}