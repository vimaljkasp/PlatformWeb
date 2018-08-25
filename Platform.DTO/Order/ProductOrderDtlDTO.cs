using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.DTO
{
    [Validator(typeof(ProductOrderDtlValidator))]
    public class ProductOrderDtlDTO
    {
        public Int32 ProductOrderDetailId { get; set; }
        public Int32 OrderId { get; set; }
        public Int32 ProductMappingId { get; set; }
        public int CustomerId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal OrderTax { get; set; }
        public decimal TotalPrice { get; set; }
        public String OrderStatus { get; set; }
        public DateTime DeliveryExpectedDate { get; set; }
        public System.DateTime DeliveredDate { get; set; }
        public string DeliveredBy { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverNumber { get; set; }
        public string JCBDriverNumber { get; set; }
        public string RoyaltyNumber { get; set; }
        public string OrderAddress { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }



      


    }

    public class ProductOrderDtlValidator : AbstractValidator<ProductOrderDtlDTO>
    {
        public ProductOrderDtlValidator()
        {

           
            //   RuleFor(x => x.CustomerId).NotEmpty().WithMessage("The UserName cannot be blank.")
            //                               .Length(1, 10).WithMessage("The User Name cannot be more than 10 characters.");

            RuleFor(x => x.ProductMappingId).NotEmpty().WithMessage("Product Id cannot be blank.");

            RuleFor(x => x.ProductMappingId).GreaterThan(0).WithMessage("Product Id cannot be blank.");
            //       RuleFor(x => x.BirthDate).LessThan(DateTime.Today).WithMessage("You cannot enter a birth date in the future.");

            //     RuleFor(x => x.Username).Length(8, 999).WithMessage("The user name must be at least 8 characters long.");
        }
    }
}
