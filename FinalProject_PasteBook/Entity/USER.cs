//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            this.COMMENTs = new HashSet<COMMENT>();
            this.FRIENDs = new HashSet<FRIEND>();
            this.FRIENDs1 = new HashSet<FRIEND>();
            this.LIKEs = new HashSet<LIKE>();
            this.NOTIFICATIONs = new HashSet<NOTIFICATION>();
            this.NOTIFICATIONs1 = new HashSet<NOTIFICATION>();
            this.POSTs = new HashSet<POST>();
            this.POSTs1 = new HashSet<POST>();
        }
    
        public int ID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string SALT { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public System.DateTime BIRTHDAY { get; set; }
        public Nullable<int> COUNTRY_ID { get; set; }
        public string MOBILE_NO { get; set; }
        public string GENDER { get; set; }
        public byte[] PROFILE_PIC { get; set; }
        public System.DateTime DATE_CREATED { get; set; }
        public string ABOUT_ME { get; set; }
        public string EMAIL_ADDRESS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT> COMMENTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FRIEND> FRIENDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FRIEND> FRIENDs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LIKE> LIKEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTIFICATION> NOTIFICATIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTIFICATION> NOTIFICATIONs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POST> POSTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POST> POSTs1 { get; set; }
        public virtual REF_COUNTRY REF_COUNTRY { get; set; }
    }
}
