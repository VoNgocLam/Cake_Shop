//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel;

namespace Cake_Shop_App
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.ORDER_PRODUCT = new HashSet<ORDER_PRODUCT>();
            this.PRODUCT_IMAGES = new HashSet<PRODUCT_IMAGES>();
        }
    
        public int ProductID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string productTitle { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<int> Price { get; set; }
        public string ProductAvatar { get; set; }
        public BindingList<String> listImages { get; set; }
        public virtual CATEGORy CATEGORy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_PRODUCT> ORDER_PRODUCT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_IMAGES> PRODUCT_IMAGES { get; set; }


    }
}
