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
    
    public partial class VOD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VOD()
        {
            this.VODEquipments = new HashSet<VODEquipment>();
            this.VODModifyTypes = new HashSet<VODModifyType>();
            this.VODMovments = new HashSet<VODMovment>();
        }
    
        public int VID { get; set; }
        public string Name { get; set; }
        public System.DateTime Moment { get; set; }
        public string DesignerName { get; set; }
        public int DesignerUID { get; set; }
        public string Info { get; set; }
        public string Round { get; set; }
        public string Movment { get; set; }
        public bool IsPreMade { get; set; }
        public Nullable<int> Pattern { get; set; }
        public int MovmentCount { get; set; }
        public int TimeDuration { get; set; }
        public int Modality { get; set; }
        public int Place { get; set; }
        public int Body { get; set; }
        public int Energy { get; set; }
        public int PublicSkill { get; set; }
        public string PureContent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VODEquipment> VODEquipments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VODModifyType> VODModifyTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VODMovment> VODMovments { get; set; }
    }
}
