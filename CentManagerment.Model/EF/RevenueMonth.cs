//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CentManagerment.Model.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class RevenueMonth
    {
        public int Id { get; set; }
        public Nullable<int> ClassId { get; set; }
        public Nullable<int> Period { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
    
        public virtual Class Class { get; set; }
    }
}
