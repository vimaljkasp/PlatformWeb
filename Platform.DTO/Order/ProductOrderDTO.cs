using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.DTO
{
    [Validator(typeof(ProductOrderValidator))]
    public class ProductOrderDTO
    {
        public int OrderId { get; set; }
  
       
        public int ProductMappingId { get; set; }
        public decimal Qunatity { get; set; }
        public int OrderCustomerId { get; set; }
        public string OrderComments { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderPrice { get; set; }
        public string OrderPriority { get; set; }
        public string OrderAddress { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }

       


    }

    public class ProductOrderValidator : AbstractValidator<ProductOrderDTO>
    {
        public ProductOrderValidator()
        {

            RuleFor(x => x.OrderCustomerId).GreaterThan(0).WithMessage("Customer Id cannot be blank.");


        }
    }
}
