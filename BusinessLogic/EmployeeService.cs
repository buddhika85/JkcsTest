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
    public class EmployeeService
    {
        UnitOfWork _uow = null;
        IRepository<TBL_EMPLOYEE> _employeeRepository = null;

        // constructor
        public EmployeeService()
        {
            if (_uow == null)
            {
                _uow = new UnitOfWork();
                _employeeRepository = _uow.EmployeeRepository;
            }
        }

        #region get
        public EmployeeViewModel GetById(int id)
        {
            try
            {
                var employee = _employeeRepository.Get(id);
                var vm = ConvertModelToVm(employee);
                return vm;
            }
            catch (Exception ex)
            {
                throw new JkcsException() { ExcpetionMessage = "Find employee by Id : " + id , ExcpetionTime = DateTime.Now};
            }
        }

        public IQueryable<EmployeeViewModel> GetAll()
        {
            try
            {
                var employees = _employeeRepository.GetAll();
                IList<EmployeeViewModel> employeeVms = new List<EmployeeViewModel>();
                foreach (var item in employees)
                {
                    employeeVms.Add(ConvertModelToVm(item));
                }
                return employeeVms.AsQueryable<EmployeeViewModel>();
            }
            catch (Exception)
            {
                throw new JkcsException() { ExcpetionMessage = "Get all error", ExcpetionTime = DateTime.Now };
            }
        }

        public void Insert(EmployeeViewModel viewModel)
        {
            try
            {
                _employeeRepository.Insert(ConvertVmToModel(viewModel));
            }
            catch (Exception)
            {
                throw new JkcsException() { ExcpetionMessage = "Save error", ExcpetionTime = DateTime.Now };
            }
        }
              
        public void Update(EmployeeViewModel viewModel)
        {
            try
            {
                _employeeRepository.Update(ConvertVmToModel(viewModel));
            }
            catch (Exception)
            {
                throw new JkcsException() { ExcpetionMessage = "Save error", ExcpetionTime = DateTime.Now };
            }
        }

        public void Delete(int id)
        {
            try
            {
                _employeeRepository.Delete(id);
            }
            catch (Exception)
            {
                throw new JkcsException() { ExcpetionMessage = "Save error", ExcpetionTime = DateTime.Now };
            }
        }
        #endregion

        private TBL_EMPLOYEE ConvertVmToModel(EmployeeViewModel viewModel)
        {
            try
            {
                var employee = new TBL_EMPLOYEE
                {    
                    EMPLOYEE_ID = viewModel.EmployeeId,                
                    FIRST_NAME = viewModel.FirstName,
                    LAST_NAME = viewModel.LastName,
                    DEPARTMENT_FK_ID = viewModel.DepartmentId,
                    PERMANENT = viewModel.Permanent,
                    SALARY = viewModel.Salary
                };
                return employee;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private EmployeeViewModel ConvertModelToVm(TBL_EMPLOYEE employee)
        {
            try
            {
                var employeeViewModel = new EmployeeViewModel
                {
                    EmployeeId = employee.EMPLOYEE_ID,
                    FirstName = employee.FIRST_NAME,
                    LastName = employee.LAST_NAME,
                    Salary = employee.SALARY,
                    Permanent = employee.PERMANENT,
                    DepartmentId = employee.TBL_DEPARTMENT.ID,
                    Department = employee.TBL_DEPARTMENT.NAME
                };
                return employeeViewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
