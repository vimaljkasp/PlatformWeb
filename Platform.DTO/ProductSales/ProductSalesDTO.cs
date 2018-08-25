using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.DTO
{
    [Validator(typeof(ProductSalesValidator))]
    public class ProductSalesDTO
    {
        public int SalesId { get; set; }
        public System.DateTime SalesDate { get; set; }
        public int ProductMappingId { get; set; }
        public decimal SalesQuantity { get; set; }
        public decimal SalesPrice { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
    }

    public class ProductSalesValidator : AbstractValidator<ProductSalesDTO>
    {
        public ProductSalesValidator()
        {
            //   RuleFor(x => x.CustomerId).NotEmpty().WithMessage("The UserName cannot be blank.")
            //                               .Length(1, 10).WithMessage("The User Name cannot be more than 10 characters.");

            //      RuleFor(x => x.WalletBalance).NotEmpty().WithMessage("The Password cannot be blank.");

            //       RuleFor(x => x.BirthDate).LessThan(DateTime.Today).WithMessage("You cannot enter a birth date in the future.");

            //     RuleFor(x => x.Username).Length(8, 999).WithMessage("The user name must be at least 8 characters long.");
        }
    }
}
