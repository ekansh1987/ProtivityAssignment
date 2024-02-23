using Application.Abstractions;
using Application.Employees.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.CommandHandlers
{
    public class CreateEmployeeHandler : IRequestHandler <CreateEmployee,Domain.Entity.Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Domain.Entity.Employee> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {
            var employee = new Domain.Entity.Employee
            {
                EmployeeId = Guid.NewGuid(),
                Name = request.Name,
                DateOfBirth = request.DateOfBirth
            };
            return await _employeeRepository.AddEmployee(employee);
        }

    };
}
