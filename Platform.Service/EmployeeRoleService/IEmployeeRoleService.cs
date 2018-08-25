using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IEmployeeRoleService
    {
        List<EmployeeRoleDTO> GetAllEmployeeRoles ();

        EmployeeRoleDTO GetEmployeeRoleById(int employeeRoleId);

        void AddEmployeeRole(EmployeeRoleDTO employeeRoleDTO);

        void UpdateEmployeeRole(EmployeeRoleDTO employeeRoleDTO);

        void DeleteEmployeeRole(int employeeRoleId);






    }
}
