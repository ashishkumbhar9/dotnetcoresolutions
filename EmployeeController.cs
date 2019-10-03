using DotNetCoreMvc.DAL.IRepository;
using DotNetCoreMvc.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMvc.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class EmployeeController: Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        [HttpGet]
        public async Task<IActionResult> getEmployee(long empId)
        {
            EmployeeModel employee = await employeeRepository.getEmployee(empId);
            return Ok(employee);
        }
    }
}
