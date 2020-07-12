namespace DataAccess.Query
{
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using System.Collections.Generic;

    public class EmployeeQuery : IEmployeeQuery
    {

        #region Attributes
        public static IEmployeeQuery Interface { get; set; }
        #endregion

        #region Constructors
        public static IEmployeeQuery GetInstance()
        {
            if (Interface != null)
            {
                return Interface;
            }

            return new EmployeeQuery();
        }
        #endregion

        #region Methods
        public List<Employee> GetEmployeeIdentity(List<Employee> employees, int identity)
        {
            Employee employee = employees.Find(x => x.Id.Equals(identity));

            return new List<Employee>() { employee };
        }
        #endregion
    }
}
