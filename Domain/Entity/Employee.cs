using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public sealed class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime  DateOfBirth { get; set; }
    }
}
