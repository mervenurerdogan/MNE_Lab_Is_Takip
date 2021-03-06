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
    
    public partial class FaturalarTBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FaturalarTBL()
        {
            this.OdenenFaturaTBL = new HashSet<OdenenFaturaTBL>();
        }
    
        public int FaturaID { get; set; }
        public string FaturaNo { get; set; }
        public Nullable<System.DateTime> FaturaTarih { get; set; }
        public Nullable<int> LabID { get; set; }
        public Nullable<int> PersonelID { get; set; }
        public Nullable<int> NumuneID { get; set; }
        public Nullable<bool> FaturaDurumu { get; set; }
        public Nullable<decimal> FaturaTutar { get; set; }
        public Nullable<int> FaturaTurID { get; set; }
    
        public virtual FaturaTurTBL FaturaTurTBL { get; set; }
        public virtual LaboratuvarlarTBL LaboratuvarlarTBL { get; set; }
        public virtual NumunelerTBL NumunelerTBL { get; set; }
        public virtual PersonellerTBL PersonellerTBL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OdenenFaturaTBL> OdenenFaturaTBL { get; set; }
    }
}
