using DotNetCoreMvc.DAL.IRepository;
using DotNetCoreMvc.Data;
using DotNetCoreMvc.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreMvc.DAL.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly LndContext lndContext;

        public EmployeeRepository(LndContext lndContext)
        {
            this.lndContext = lndContext;

        }
        
        
        public Task<EmployeeModel> getEmployee(long empId) {
            return Task.Run<EmployeeModel>(() =>
            {
                return lndContext.getEmployee(empId);
            });
        }
    }
}
