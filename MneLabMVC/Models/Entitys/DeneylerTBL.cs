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
    
    public partial class DeneylerTBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeneylerTBL()
        {
            this.DeneyOnayTBL = new HashSet<DeneyOnayTBL>();
            this.DeneyPersonelIslemTBL = new HashSet<DeneyPersonelIslemTBL>();
        }
    
        public int DeneyID { get; set; }
        public string DeneyAdi { get; set; }
        public Nullable<byte> DeneyTurID { get; set; }
        public Nullable<int> DeneyYapanPersonelID1 { get; set; }
        public Nullable<int> NumuneID { get; set; }
        public Nullable<byte> NumuneTurID { get; set; }
        public Nullable<decimal> DeneyUcret { get; set; }
        public Nullable<System.DateTime> DeneyTarih { get; set; }
        public Nullable<bool> DeneyDurum { get; set; }
        public Nullable<int> KullanılanMalzID2 { get; set; }
        public Nullable<int> RaporTurID { get; set; }
        public Nullable<int> FaturaTurID { get; set; }
    
        public virtual DeneyTurTBL DeneyTurTBL { get; set; }
        public virtual FaturaTurTBL FaturaTurTBL { get; set; }
        public virtual MalzemelerTBL MalzemelerTBL { get; set; }
        public virtual NumunelerTBL NumunelerTBL { get; set; }
        public virtual NumuneTurTBL NumuneTurTBL { get; set; }
        public virtual PersonellerTBL PersonellerTBL { get; set; }
        public virtual RaporTurTBL RaporTurTBL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeneyOnayTBL> DeneyOnayTBL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeneyPersonelIslemTBL> DeneyPersonelIslemTBL { get; set; }
    }
}
