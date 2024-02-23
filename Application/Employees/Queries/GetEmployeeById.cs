using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Queries
{
    public class GetEmployeeById : IRequest<Employee>
    {
        public Guid EmployeeId { get; set; }
    }
}
