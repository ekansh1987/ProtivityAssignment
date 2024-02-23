using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _context;
        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployee(Employee toCreate)
        {
            _context.Employees.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async Task DeleteEmployee(Guid EmployeeId)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == EmployeeId);
            if (employee == null) return;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(Guid EmployeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId);
        }

        public async Task<Employee> UpdateEmployee(Guid EmployeeId, string name, DateTime DateOfBirth)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId);
            employee.Name = name;
            employee.DateOfBirth = DateOfBirth;

            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
