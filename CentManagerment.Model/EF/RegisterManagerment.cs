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
    
    public partial class RegisterManagerment
    {
        public int register_id { get; set; }
        public string register_name { get; set; }
        public string register_phone { get; set; }
        public string register_email { get; set; }
        public Nullable<int> register_course { get; set; }
        public Nullable<int> register_status { get; set; }
    }
}
