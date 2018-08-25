using Platform.DTO;
using Platform.Repository;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class EmployeeRoleService : IEmployeeRoleService,IDisposable

    {
        private  UnitOfWork unitOfWork=new UnitOfWork();
        
      

        public List<EmployeeRoleDTO> GetAllEmployeeRoles()
        {
            List<EmployeeRoleDTO> employeeRoleList = new List<EmployeeRoleDTO>();
            var employeeRoles = unitOfWork.EmployeeRoleRepository.GetAll();
            if (employeeRoles != null)
            {
                foreach (var employee in employeeRoles)
                {
                    employeeRoleList.Add(EmployeeRoleConvertor.ConvertToEmployeeRoleDto(employee));
                }

            }

            return employeeRoleList;

        }


        public EmployeeRoleDTO GetEmployeeRoleById(int employeeRoleId)
        {
            EmployeeRoleDTO employeeRoleDTO = null;
            var employeeRole = unitOfWork.EmployeeRoleRepository.GetById(employeeRoleId);
            if (employeeRole != null)
            {
                employeeRoleDTO = EmployeeRoleConvertor.ConvertToEmployeeRoleDto(employeeRole);
            }
            return employeeRoleDTO;
        }

        public void AddEmployeeRole(EmployeeRoleDTO employeeRoleDTO)
        {
            EmployeeRole employeeRole = new EmployeeRole();
            EmployeeRoleConvertor.ConvertToEmployeeRoleEntity(ref employeeRole, employeeRoleDTO, false);
            unitOfWork.EmployeeRoleRepository.Add(employeeRole);
            
        }

        public void UpdateEmployeeRole(EmployeeRoleDTO employeeRoleDTO)
        {
            EmployeeRole employeeRole = null;
            EmployeeRoleConvertor.ConvertToEmployeeRoleEntity(ref employeeRole, employeeRoleDTO, true);
            unitOfWork.EmployeeRoleRepository.Update(employeeRole);
        }

        public void DeleteEmployeeRole(int employeeRoleId)
        {
            unitOfWork.EmployeeRoleRepository.Delete(employeeRoleId);
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (unitOfWork != null)
                {
                    unitOfWork.Dispose();
                    unitOfWork = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
