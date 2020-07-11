namespace DataAccess.Queries
{
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using System;
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
        public List<Employee> GetAllEmployee()
        {
            try
            {
                //Conection APi
                return new List<Employee>();
            }
            catch (Exception)
            {
                return new List<Employee>();
            }
        }
        #endregion
    }
}
