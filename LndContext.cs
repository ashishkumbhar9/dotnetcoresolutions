using DotNetCoreMvc.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMvc.Data
{
    public class LndContext : DbContext
    {
        public LndContext(DbContextOptions<LndContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        
        public DbSet<JsonResultModel> STP_GetEmployeeByID { get; set; }
        public DbSet<EmployeeModel> TT_Employee { get; set; }
        
        public async Task<EmployeeModel> getEmployee(long empId)
        {
            List<EmployeeModel> employeeModel = new List<EmployeeModel>();
            string query = "EXEC [dbo].[STP_GetEmployeeByID] @EmpID";
            var param = new SqlParameter("EmpID", empId);
            JsonResultModel JsonResult = await STP_GetEmployeeByID.FromSql(new RawSqlString(query), param).FirstAsync<JsonResultModel>();
            employeeModel = JsonConvert.DeserializeObject<List<EmployeeModel>>(JsonResult.JsonData);
            return employeeModel.FirstOrDefault();
        }
     }
}
