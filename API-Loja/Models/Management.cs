//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_Loja.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Management
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Management()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int idManagement { get; set; }
        public string nameManagement { get; set; }
        public string loginManagement { get; set; }
        public string passwordManagement { get; set; }
        public string typeManagement { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
