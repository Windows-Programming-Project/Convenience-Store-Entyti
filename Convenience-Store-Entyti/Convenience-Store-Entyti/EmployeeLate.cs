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
    
    public partial class EmployeeLate
    {
        public string eID { get; set; }
        public Nullable<System.DateTime> LateDate { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}