using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class EmployeeRoleConvertor
    {
        public static EmployeeRoleDTO ConvertToEmployeeRoleDto(EmployeeRole employeeRole)
        {
            EmployeeRoleDTO employeeRoleDTO = new EmployeeRoleDTO();
            employeeRoleDTO.EmployeeId = employeeRole.EmployeeId;
            employeeRoleDTO.RoleId = employeeRole.RoleId;
         
            return employeeRoleDTO;


        }

        public static void ConvertToEmployeeRoleEntity(ref EmployeeRole employeeRole, EmployeeRoleDTO employeeRoleDTO, bool isUpdate)
        {
            if(isUpdate)
                employeeRole.EmployeeId = employeeRoleDTO.EmployeeId;
                employeeRole.RoleId = employeeRoleDTO.RoleId;


        }
    }
}
