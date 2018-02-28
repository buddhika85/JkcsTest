using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork
    {
        private EmployeeMgmtEntities entities = null;
        private bool disposed = false;

        public UnitOfWork()
        {
            if (entities == null)
            {
                entities = new EmployeeMgmtEntities();
            }
        }

        #region properties
        private GenericRepository<TBL_EMPLOYEE> employeeRepository;
        private GenericRepository<TBL_DEPARTMENT> departmentRepository;

        public GenericRepository<TBL_EMPLOYEE> EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new GenericRepository<TBL_EMPLOYEE>(entities);
                return employeeRepository;
            }
        }

        public GenericRepository<TBL_DEPARTMENT> DepartmentRepository
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
