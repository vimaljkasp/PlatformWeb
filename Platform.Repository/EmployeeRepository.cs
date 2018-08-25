using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Repository
{
    public class EmployeeRepository 
    {


        PlatformDBEntities _repository;
        public EmployeeRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            
                 employees = _repository.Employees.ToList<Sql.Employee>();
            
          
            return employees;
        }



        public Employee GetById(int id)
        {

            var employee = _repository.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }


        public void Add(Employee employee)
        {
            if (employee != null)
            {
                _repository.Employees.Add(employee);
                
              //  _repository.SaveChanges();

            }
        }

        public void Update(Employee employee)
        {
            
                if (employee != null)
                {
                    _repository.Entry<Sql.Employee>(employee).State = System.Data.Entity.EntityState.Modified;
                 //   _repository.SaveChanges();
                }

           

        }

        public void Delete(int id)
        {
            var employee = _repository.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (employee != null)
                _repository.Employees.Remove(employee);

          //  _repository.SaveChanges();

        }


        public Employee GetEmployeeByUserName(string userName)
        {
            var employee = _repository.Employees.Where(x => x.UserName == userName).FirstOrDefault();
            return employee;
        }


      

    }
}
