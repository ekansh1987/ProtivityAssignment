using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Employees.Commands;
using Protivity_POC_Employee.Common;
using Serilog;
using Application.Employees.Queries;

namespace Protivity_POC_Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
       
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
           
        }
        [HttpPost("AddEmployee")]
        public async Task<ProjectJsonResult> AddEmployee([FromBody]CreateEmployee createEmployee)
        {
            try
            {
                
                var createemployeenew = new CreateEmployee
                {
                    Name = createEmployee.Name,
                    DateOfBirth = createEmployee.DateOfBirth,
                };
                var employee = await _mediator.Send(createemployeenew);

                var employeeList = await _mediator.Send(new GetAllEmployee());

                int count = employeeList.Count;
                Log.Information("Total Employee Added:" + count + "");
                return (new ProjectJsonResult() { IsSuccess = true, ErrorMessage = "", ErrorCode = "" });
            }
            catch(ProjectException)
            {
                return (new ProjectJsonResult() { IsSuccess = false, ErrorMessage = "Internal server error", ErrorCode = "" });
            }
            catch(Exception ex)
            {
                ProjectException pe = new ProjectException(ex);
                return (new ProjectJsonResult() { IsSuccess = false, ErrorMessage = pe.FriendlyMesssage, ErrorCode = "" });
            }

        }

    }
}
