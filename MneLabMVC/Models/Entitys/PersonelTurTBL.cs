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
    
    public partial class PersonelTurTBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonelTurTBL()
        {
            this.IzınTBL = new HashSet<IzınTBL>();
            this.PersonellerTBL = new HashSet<PersonellerTBL>();
        }
    
        public byte PersonelTurID { get; set; }
        public string PersonelTur { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzınTBL> IzınTBL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonellerTBL> PersonellerTBL { get; set; }
    }
}