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
    
    public partial class RaporTurTBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RaporTurTBL()
        {
            this.DeneylerTBL = new HashSet<DeneylerTBL>();
            this.RaporlarTBL = new HashSet<RaporlarTBL>();
        }
    
        public int RaporTurID { get; set; }
        public string RaporTur { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeneylerTBL> DeneylerTBL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaporlarTBL> RaporlarTBL { get; set; }
    }
}