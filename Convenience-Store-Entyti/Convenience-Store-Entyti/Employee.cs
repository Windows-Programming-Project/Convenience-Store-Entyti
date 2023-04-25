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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Accounts = new HashSet<Account>();
            this.Invoices = new HashSet<Invoice>();
        }
    
        public string eID { get; set; }
        public string eName { get; set; }
        public Nullable<System.DateTime> eBirthdate { get; set; }
        public Nullable<bool> eGender { get; set; }
        public string ePhone { get; set; }
        public string eAddress { get; set; }
        public string ePosition { get; set; }
        public Nullable<double> eSalary { get; set; }
        public byte[] eImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}