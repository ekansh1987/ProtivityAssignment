using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Commands
{
    public class CreateEmployee : IRequest<Domain.Entity.Employee>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
