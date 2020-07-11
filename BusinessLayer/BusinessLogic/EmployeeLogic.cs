namespace BusinessLayer.BusinessLogic
{
    using BusinessLayer.Interfaces;
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using System.Collections.Generic;

    public class EmployeeLogic : IEmployeeLogic
    {
        #region Attributes
        public static IEmployeeLogic Interface { get; set; }
        private readonly IEmployeeQuery employeeQuery;
        private string errorMessage;
        #endregion

        #region Constructors
        public static IEmployeeLogic GetInstance(IEmployeeQuery employeeQuery)
        {
            if (Interface != null)
            {
                return Interface;
            }

            return new EmployeeLogic(employeeQuery);
        }

        public EmployeeLogic(IEmployeeQuery employeeQuery)
        {
            this.employeeQuery = employeeQuery;
        }
        #endregion

        #region Interface Methods 
        public List<Employee> GetAllEmployee()
        {
            return employeeQuery.GetAllEmployee();
        }
        #endregion
    }
}
