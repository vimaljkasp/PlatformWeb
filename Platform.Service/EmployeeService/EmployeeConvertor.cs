using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class EmployeeConvertor
    {
        public static EmployeeDTO ConvertToEmployeeDto(Employee employee)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.EmployeeId = employee.EmployeeId;
            employeeDTO.Name = employee.Name;
            employeeDTO.UserName = employee.UserName;
            employeeDTO.Password = employee.Password;
            employeeDTO.AddressLine1 = employee.AddressLine1;
            employeeDTO.AddressLine2 = employee.AddressLine2;
            employeeDTO.City = employee.City;

            employeeDTO.District = employee.District;
            employeeDTO.HomePhone = employee.HomePhonne;
            employeeDTO.PostalCode = employee.PostalCode;
            employeeDTO.MobileNumber = employee.MobileNumber;
            employeeDTO.IsActive = employee.IsActive;

            return employeeDTO;
      

    }

        public static void ConvertToEmployeeEntity(ref Employee employee, EmployeeDTO employeeDTO, bool isUpdate)
        {
            if (isUpdate)
            employee.EmployeeId = employeeDTO.EmployeeId;
            employee.Name = employeeDTO.Name;
            employee.UserName = employeeDTO.UserName;
            employee.Password = employeeDTO.Password;
            employee.AddressLine1 = employeeDTO.AddressLine1;
            employee.AddressLine2 = employeeDTO.AddressLine2;
            employee.City = employeeDTO.City;
            employee.District = employeeDTO.District;
            employee.HomePhonne = employeeDTO.HomePhone;
            employee.PostalCode = employeeDTO.PostalCode;
            employee.MobileNumber = employeeDTO.MobileNumber;
            employee.IsActive = employeeDTO.IsActive;


        }
    }
}
