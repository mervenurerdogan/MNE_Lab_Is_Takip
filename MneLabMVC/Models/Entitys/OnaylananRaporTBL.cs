//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MneLabMVC.Models.Entitys
{
    using System;
    using System.Collections.Generic;
    
    public partial class OnaylananRaporTBL
    {
        public int OnayRaporID { get; set; }
        public Nullable<int> RaporID { get; set; }
        public Nullable<bool> OnayRaporDurum { get; set; }
        public Nullable<System.DateTime> OnayTarihi { get; set; }
        public Nullable<int> OnaylayanPersonelID { get; set; }
    
        public virtual RaporlarTBL RaporlarTBL { get; set; }
        public virtual PersonellerTBL PersonellerTBL { get; set; }
    }
}
