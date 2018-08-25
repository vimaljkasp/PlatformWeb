using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Platform.DTO
{
    [Validator(typeof(EmployeeValidator))]
   
    public class EmployeeDTO
    {
      
        public int EmployeeId { get; set; }
       
        public string Name { get; set; }
       
        public string UserName { get; set; }
       
        public string Password { get; set; }
       
        public string EncryptedPassword { get; set; }
       
        public string AddressLine1 { get; set; }
       
        public string AddressLine2 { get; set; }
       
        public string City { get; set; }
       
        public string District { get; set; }
       
        public string PostalCode { get; set; }
       
        public string MobileNumber { get; set; }
       
        public string HomePhone { get; set; }
       
        public Nullable<bool> IsActive { get; set; }
    }

    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("The UserName cannot be blank.")
                                        .Length(1, 10).WithMessage("The User Name cannot be more than 10 characters.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("The Password cannot be blank.");

            //       RuleFor(x => x.BirthDate).LessThan(DateTime.Today).WithMessage("You cannot enter a birth date in the future.");

            //     RuleFor(x => x.Username).Length(8, 999).WithMessage("The user name must be at least 8 characters long.");
        }
    }
}
