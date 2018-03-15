using DataAccess;
using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLogic
{
    public class DepartmentService
    {
        IUnitOfWork _uow = null;
        IGenericRepository<TBL_DEPARTMENT> _departmentRepository = null;
        
        public DepartmentService(IUnitOfWork uowInjected)
        {
            _uow = uowInjected;
            _departmentRepository = _uow.DepartmentRepository;                            
        }

        public IQueryable<DepartmentViewModel> GetAll()
        {
            try
            {
                var departments = _departmentRepository.GetAll();
                IList<DepartmentViewModel> departmentVms = new List<DepartmentViewModel>();
                foreach (var item in departments)
                {
                    departmentVms.Add(ConvertModelToVm(item));
                }
                return departmentVms.AsQueryable<DepartmentViewModel>();
            }
            catch (Exception)
            {
                throw new JkcsException() { ExcpetionMessage = "Get all error", ExcpetionTime = DateTime.Now };
            }
        }

        private DepartmentViewModel ConvertModelToVm(TBL_DEPARTMENT item)
        {
            try
            {
                return new DepartmentViewModel
                {
                    Id = item.ID,
                    Name = item.NAME
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
