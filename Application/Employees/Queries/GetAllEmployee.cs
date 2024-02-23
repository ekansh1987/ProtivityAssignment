using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Queries
{
    public class GetAllEmployee : IRequest<List<Employee>>
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
    }
}
