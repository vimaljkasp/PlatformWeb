using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAllEmployees();



        EmployeeDTO GetEmployeeById(int employeId);


        void AddEmployee(EmployeeDTO employeDTO);


         void UpdateEmployee(EmployeeDTO employeeRoleDTO);


         void DeleteEmployee(int employeeId);

        bool ValidateLoginAndCreateEmployeeSession(LoginDto loginDto);


       

    }
}
