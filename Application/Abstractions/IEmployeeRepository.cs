using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Application.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetAll();

        Task<Employee> GetEmployeeById(Guid EmployeeId);

        Task<Employee> AddEmployee(Employee toCreate);

        Task<Employee> UpdateEmployee(Guid EmployeeId, string name, DateTime DateOfBirth);

        Task DeleteEmployee(Guid EmployeeId);
    }
}
