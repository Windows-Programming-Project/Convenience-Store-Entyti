//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Convenience_Store_Entyti
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            this.Invoice_Detail = new HashSet<Invoice_Detail>();
        }
    
        public string iID { get; set; }
        public string eID { get; set; }
        public string cID { get; set; }
        public Nullable<System.DateTime> iDate { get; set; }
        public Nullable<double> iTotalpay { get; set; }
        public Nullable<double> iFinalTotalpay { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual LoyalCustomer LoyalCustomer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice_Detail> Invoice_Detail { get; set; }
    }
}
