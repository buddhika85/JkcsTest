using EF;

namespace DataAccess
{
    public interface IUnitOfWork
    {
        IGenericRepository<TBL_DEPARTMENT> DepartmentRepository { get; }
        IGenericRepository<TBL_EMPLOYEE> EmployeeRepository { get; }

        void Dispose();
        void Save();
    }
}