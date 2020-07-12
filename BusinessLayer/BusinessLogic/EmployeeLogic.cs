namespace BusinessLayer.BusinessLogic
{
    using BusinessLayer.Interfaces;
    using DataAccess.Factory;
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using ServiceAccessLayer.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EmployeeLogic : IEmployeeLogic
    {
        #region Attributes
        public static IEmployeeLogic Interface { get; set; }
        private readonly IEmployeeService employeeService;
        private readonly IEmployeeQuery employeeQuery;
        private ISalary salary;
        #endregion

        #region Constructors
        public static IEmployeeLogic GetInstance(
            IEmployeeService employeeService,
            IEmployeeQuery employeeQuery)
        {
            if (Interface != null)
            {
                return Interface;
            }

            return new EmployeeLogic(employeeService, employeeQuery);
        }

        public EmployeeLogic(
            IEmployeeService employeeService,
            IEmployeeQuery employeeQuery)
        {
            this.employeeService = employeeService;
            this.employeeQuery = employeeQuery;
        }
        #endregion

        #region Interface Methods 
        public async Task<ResponseApi> GetEmployees(int? identity)
        {
            var response = await employeeService.GetEmployees();
            List<Employee> employees = (List<Employee>)response.Result;
            
            foreach (Employee employee in employees)
            {
                salary = FactorySalary.GetInstance(employee);
                salary.AnnualSalary();
            }

            if (identity != null)
            {
                response.Result = employeeQuery.GetEmployeeIdentity(employees, (int)identity);
            }

            return response;
        }
        #endregion
    }
}
