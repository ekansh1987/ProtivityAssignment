using Application.Abstractions;
using Application.Employees.Queries;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.QueryHandlers
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployee, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> Handle(GetAllEmployee request, CancellationToken cancellationToken)
        {
            return(List<Employee>) await _employeeRepository.GetAll();
        }
    }
}
