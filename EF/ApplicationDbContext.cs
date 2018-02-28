using EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TBL_EMPLOYEE> Employees { get; set; }
        public DbSet<TBL_DEPARTMENT> Departments { get; set; }

        public ApplicationDbContext() : base("name=EmployeeMgmt")
        {

        }
    }
}
