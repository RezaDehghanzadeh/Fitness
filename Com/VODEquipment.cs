//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Com
{
    using System;
    using System.Collections.Generic;
    
    public partial class VODEquipment
    {
        public int VEID { get; set; }
        public int VID { get; set; }
        public int EID { get; set; }
        public string alaki { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual VOD VOD { get; set; }
    }
}
