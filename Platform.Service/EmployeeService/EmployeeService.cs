
using Platform.DTO;
using Platform.Repository;
using Platform.Sql;
using Platform.Utilities.Encryption;
using Platform.Utilities.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class EmployeeService : IEmployeeService,IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public void AddEmployee(EmployeeDTO employeDTO)
        {
            this.CheckForExisitngEmployee(employeDTO.UserName);

            Employee employee = new Employee();
            EmployeeConvertor.ConvertToEmployeeEntity(ref employee, employeDTO, false);
            employee.Password = EncryptionHelper.Encryptword(employeDTO.Password);
           unitOfWork.EmployeeRepository.Add(employee);

        }

        public void DeleteEmployee(int employeeId)
        {
            unitOfWork.EmployeeRepository.Delete(employeeId);
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>();
            var employees = unitOfWork.EmployeeRepository.GetAllEmployees();
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    employeeList.Add(EmployeeConvertor.ConvertToEmployeeDto(employee));
                }

            }

            return employeeList;
        }

        public EmployeeDTO GetEmployeeById(int employeId)
        {
            EmployeeDTO employeeDTO = null;
            var employee = unitOfWork.EmployeeRepository.GetById(employeId);
            if (employee != null)
            {
                employeeDTO = EmployeeConvertor.ConvertToEmployeeDto(employee);
            }
            return employeeDTO;
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
           
            Employee employee = new Employee();
            EmployeeConvertor.ConvertToEmployeeEntity(ref employee, employeeDTO, true);
            unitOfWork.EmployeeRepository.Update(employee);
        }


        private void CheckForExisitngEmployee(string userName)
        {
            var existingCustomer = unitOfWork.EmployeeRepository.GetEmployeeByUserName(userName);
            if (existingCustomer != null)
                throw new PlatformModuleException("Employee Account Already Exist with given User Name");
        }

      

        public bool ValidateLoginAndCreateEmployeeSession(LoginDto logindto)
        {
            List<Employee> employees = unitOfWork.EmployeeRepository.GetAllEmployees();
            logindto.Password = EncryptionHelper.Encryptword(logindto.Password);
            if (employees.Where(e => e.UserName.Equals(logindto.UserName, StringComparison.CurrentCultureIgnoreCase)
             && e.Password.Equals(logindto.Password, StringComparison.CurrentCultureIgnoreCase)).Any())
            {
                var employee = employees.Where(e => e.UserName.Equals(logindto.UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                this.CreateEmployeeSession(employee, logindto);
               
                return true;
            }
            else if (!employees.Where(e => e.UserName.Equals(logindto.UserName, StringComparison.CurrentCultureIgnoreCase)).Any())

            {
                throw new PlatformModuleException("The UserName that you've entered doesn't match any account");
            }
            else if (!employees.Where(e => e.UserName.Equals(logindto.Password, StringComparison.CurrentCultureIgnoreCase)).Any())
            {
                throw new PlatformModuleException("Password that you've entered doesn't match any account");

            }
            return false;
            
        }

        private void CreateEmployeeSession(Employee employee,LoginDto logindto)
        {
            
            EmployeeSession employeeSession = new EmployeeSession();
            employeeSession.SiteId = logindto.SiteId;
            employeeSession.EmployeeId = employee.EmployeeId;
            employeeSession.SessionStartDtm = DateTime.Now;
            employeeSession.SessionEndDtm = DateTime.MaxValue;
            employeeSession.IsLogout = false;
            unitOfWork.EmployeeSessionRepository.Add(employeeSession);
            unitOfWork.SaveChanges();
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
