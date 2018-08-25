using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Repository
{
    public class EmployeeRoleRepository 
    {

        PlatformDBEntities _repository;
        public EmployeeRoleRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<EmployeeRole> GetAll()
        {

            List<EmployeeRole> employeeRoleList = new List<EmployeeRole>();
            employeeRoleList = _repository.EmployeeRoles.ToList<Sql.EmployeeRole>();


            return employeeRoleList;
        }

        public EmployeeRole GetById(int employeeRoleId)
        {
            EmployeeRole employeeRole = new EmployeeRole();

            employeeRole = _repository.EmployeeRoles.FirstOrDefault(x => x.RoleId == employeeRoleId);



            return employeeRole;
        }


        public void Add(EmployeeRole employeeRole)
        {

            if (employeeRole != null)
            {
                _repository.EmployeeRoles.Add(employeeRole);
           //     _repository.SaveChanges();

            }




        }

        public void Update(EmployeeRole employeeRole)
        {

            if (employeeRole != null)
            {
                _repository.Entry<Sql.EmployeeRole>(employeeRole).State = System.Data.Entity.EntityState.Modified;
          //      _repository.SaveChanges();

            }


        }

        public void Delete(int employeeRoleId)
        {
            var employeeRole = _repository.EmployeeRoles.Where(x => x.RoleId == employeeRoleId).FirstOrDefault();
            if (employeeRole != null)
                _repository.EmployeeRoles.Remove(employeeRole);

         //   _repository.SaveChanges();

        }


        
    }
}
