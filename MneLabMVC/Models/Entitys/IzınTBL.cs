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
    
    public partial class IzınTBL
    {
        public int IzinID { get; set; }
        public Nullable<int> IzinAlanPersonelID { get; set; }
        public Nullable<byte> IzınAlanPersonelGoreviID { get; set; }
        public Nullable<bool> PersonelIzinDurumu { get; set; }
        public Nullable<System.DateTime> IzinBaslangicTarih { get; set; }
        public Nullable<System.DateTime> IzınBitisTarih { get; set; }
    
        public virtual PersonellerTBL PersonellerTBL { get; set; }
        public virtual PersonelTurTBL PersonelTurTBL { get; set; }
    }
}
