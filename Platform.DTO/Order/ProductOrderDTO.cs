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
        public string OrderNumber { get; set; }
        public int ProductOrderDetailId { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public String OrderStatus { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerMobileNumber { get; set; }


        public int ProductMappingId { get; set; }
        public decimal Quantity { get; set; }
        public int OrderCustomerId { get; set; }
        public string OrderComments { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public decimal OrderTax { get; set; }
        public decimal CGSTTax { get; set; }
        public decimal SGSTTax { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal OrderDiscount { get; set; }
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

    public enum OrderStatus
    {
        Pending = 0,
        Completed
    }
}
