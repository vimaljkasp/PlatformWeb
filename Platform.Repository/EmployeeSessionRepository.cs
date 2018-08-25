using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Sql;

namespace Platform.Repository
{
    public class EmployeeSessionRepository 
    {


        PlatformDBEntities _repository;
        public EmployeeSessionRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<EmployeeSession> GetAll()
        {
            var employeeSessions = _repository.EmployeeSessions.ToList<Sql.EmployeeSession>();
            return employeeSessions;
        }

        public EmployeeSession GetById(int id)
        {

            var employeeSession = _repository.EmployeeSessions.FirstOrDefault(x => x.SessionId == id);



            return employeeSession;
        }


        public void Add(EmployeeSession employeeSession)
        {
            if (employeeSession != null)
            {
                _repository.EmployeeSessions.Add(employeeSession);
           //     _repository.SaveChanges();

            }
        }

        public void Update(EmployeeSession employeeSession)
        {

            if (employeeSession != null)
            {
                _repository.Entry<Sql.EmployeeSession>(employeeSession).State = System.Data.Entity.EntityState.Modified;
              //  _repository.SaveChanges();
            }




        }

        public void Delete(int id)
        {
            var employeeSession = _repository.EmployeeSessions.Where(x => x.SessionId == id).FirstOrDefault();
            if (employeeSession != null)
                _repository.EmployeeSessions.Remove(employeeSession);

          //  _repository.SaveChanges();

        }


        


    }
}
