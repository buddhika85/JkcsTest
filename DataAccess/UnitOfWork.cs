using EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext entities = null;
        private bool disposed = false;

        public UnitOfWork(DbContext contextInjected)
        {
            entities = contextInjected;
            //entities = new EmployeeMgmtEntities();               
        }

        #region properties
        private IGenericRepository<TBL_EMPLOYEE> employeeRepository;
        private IGenericRepository<TBL_DEPARTMENT> departmentRepository;

        public IGenericRepository<TBL_EMPLOYEE> EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new GenericRepository<TBL_EMPLOYEE>(entities);
                return employeeRepository;
            }
        }

        public IGenericRepository<TBL_DEPARTMENT> DepartmentRepository
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new GenericRepository<TBL_DEPARTMENT>(entities);
                return departmentRepository;
            }
        }

        #endregion properties

        // save and commit to the DB
        public void Save()
        {
            entities.SaveChanges();
        }

        // clean and release the resouces
        public void Dispose()
        {
            if (disposed == false)
            {
                entities.Dispose();
                disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}
