//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Platform.Sql
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOrder()
        {
            this.ProductOrderDetails = new HashSet<ProductOrderDetail>();
        }
    
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public System.DateTime OrderPurchaseDtm { get; set; }
        public Nullable<int> OrderCustomerId { get; set; }
        public decimal OrderPrice { get; set; }
        public Nullable<decimal> OrderTax { get; set; }
        public Nullable<decimal> OrderTotalPrice { get; set; }
        public string OrderPriority { get; set; }
        public string OrderComments { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrderDetail> ProductOrderDetails { get; set; }
    }
}
