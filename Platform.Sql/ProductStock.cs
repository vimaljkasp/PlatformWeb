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
    
    public partial class ProductStock
    {
        public int StockId { get; set; }
        public System.DateTime StockDate { get; set; }
        public int StockProductId { get; set; }
        public int StockCreatedBy { get; set; }
        public System.DateTime StockCreatedDtm { get; set; }
        public decimal StockQuantiy { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
    
        public virtual ProductSiteMapping ProductSiteMapping { get; set; }
    }
}